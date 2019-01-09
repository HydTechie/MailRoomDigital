#importing libraries
from random import randint
from PIL import Image
import cv2
import pytesseract
import numpy as np
import io
import os

#special note
#create the following folders in which this file is placed 
#image
#cropped
#binary







#tesseract path is give here.if it is installed in different path change the path
pytesseract.pytesseract.tesseract_cmd ="C:/Program Files (x86)/Tesseract-OCR/tesseract.exe"


#function to generate randomn four digt number to append to claim id
#in future to increase the random number value replace input n in the function for the required number of digits 
def random_with_N_digits(n):
    range_start = 10**(n-1)
    range_end = (10**n)-1
    return randint(range_start, range_end)

# Encrypting the text of first and last words with  the help of cyper encryption
def encrypt(text,s):
   result = ""
   # transverse the plain text
   for i in range(len(text)):
      char = text[i]
      # Encrypt uppercase characters in plain text
      
      if (char.isupper()):
         result += chr((ord(char) + s-65) % 26 + 65)
      # Encrypt lowercase characters in plain text
      else:
         result += chr((ord(char) + s - 97) % 26 + 97)
      return result
#check the above function

#generating claim id using lat name first word, first name first word,insured number,date of birth of the insured in mm dd and gender 
def claim_id_generation(last_name,first_name,insured_number,mm,dd,gender):
   fourdigi = random_with_N_digits(5)
   s = 13
   encrypted_first = str(encrypt(str(first_name[0:1]),s))
   encrypted_last = str(encrypt(str(last_name[0:1]),s))
   Claim_Id = encrypted_first+encrypted_last+insured_number[-5:]+mm+dd+gender[0]+str(fourdigi)
   return Claim_Id

#<=================================payer details are extracted from the top left corner===============================================>
def payer_details(image_path):
    output_data=pytesseract.image_to_data(Image.open(image_path),lang='eng',config='tessedit_char_whitelist=0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz')
    data=io.StringIO(output_data)
    data_lines=data.readlines()
    list_data=[]
    idx=0
    conf=0
    text=""
    line_number=0
    #here we are taking data in tsv format and accessing the variables like confidence values and text detected
    for x in data_lines:
        list_data.append(x.split('\t'))
    data=[] 
    for i in range(1,len(list_data)):
        data.append([list_data[i][4],list_data[i][10],list_data[i][11]])
    data = [x for x in data if x[2]!= '\n']
    for i in range(0,len(data)):
        f = data[i][2]
        data[i][2]=data[i][2].replace('\n','')
        data[i][2]=data[i][2].replace(' \n','')

    firstdata = []
    str1 = ''
    str2 = ''
    str3 = ''
    str4 = ''

    for x in data:
        if x[0] == '1':
            str1 += x[2]
        elif x[0] == '2':
            str2 += x[2]
        elif x[0] == '3':
            str3 += x[2]
        elif x[0] == '4':
            str4 += x[2]
        else:
            pass  
    #print(data)
    firstdata.append(str1)
    firstdata.append(str2)
    firstdata.append(str3)
    firstdata.append(str4)
    return firstdata

#<===================================================box extraction====================================================================>
def preprocess(img):
    image=cv2.imread(img,0)
    #gray_image = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    edges = cv2.Canny(image,0,255,L2gradient=False)
    #cv2.imwrite('edges.jpg',edges)
    ret,thresh1 = cv2.threshold(edges,110,255,cv2.THRESH_BINARY_INV)
    kernel = np.ones((3,3),np.uint8)
    erosion = cv2.erode(thresh1,kernel,iterations =3)
    kernel1 = np.ones((3,3),np.uint8)
    erosion=cv2.dilate(erosion,kernel1,iterations = 2)
    cv2.imwrite('blob.jpg',erosion)
    return True

def sort_contours(cnts, method="left-to-right"):
    # initialize the reverse flag and sort index
    reverse = False
    i = 0

    # handle if we need to sort in reverse
    if method == "right-to-left" or method == "bottom-to-top":
        reverse = True

    # handle if we are sorting against the y-coordinate rather than
    # the x-coordinate of the bounding box
    if method == "top-to-bottom" or method == "bottom-to-top":
        i = 1

    # construct the list of bounding boxes and sort them from top to
    # bottom
    boundingBoxes = [cv2.boundingRect(c) for c in cnts]
    (cnts, boundingBoxes) = zip(*sorted(zip(cnts, boundingBoxes),
                                        key=lambda b: b[1][i], reverse=reverse))

    # return the list of sorted contours and bounding boxes
    return (cnts, boundingBoxes)

def box_extraction(img_for_box_extraction_path,cropping_image,cropped_dir_path):

    img = cv2.imread(img_for_box_extraction_path, 0)  # Read the image
    img1=cv2.imread(cropping_image)
    height,width=img1.shape[:2]
    (thresh, img_bin) = cv2.threshold(img, 128, 255,
                                      cv2.THRESH_BINARY | cv2.THRESH_OTSU)  # Thresholding the image
    img_bin = 255-img_bin  # Invert the image

    #cv2.imwrite("Image_bin.jpg",img_bin)
   
    # Defining a kernel length
    kernel_length = np.array(img).shape[1]//40
     
    # A verticle kernel of (1 X kernel_length), which will detect all the verticle lines from the image.
    verticle_kernel = cv2.getStructuringElement(cv2.MORPH_RECT, (1, kernel_length))
    # A horizontal kernel of (kernel_length X 1), which will help to detect all the horizontal line from the image.
    hori_kernel = cv2.getStructuringElement(cv2.MORPH_RECT, (kernel_length, 1))
    # A kernel of (3 X 3) ones.
    kernel = cv2.getStructuringElement(cv2.MORPH_RECT, (3, 3))

    # Morphological operation to detect verticle lines from an image
    img_temp1 = cv2.erode(img_bin, verticle_kernel, iterations=3)
    verticle_lines_img = cv2.dilate(img_temp1, verticle_kernel, iterations=3)
    #cv2.imwrite("verticle_lines.jpg",verticle_lines_img)

    # Morphological operation to detect horizontal lines from an image
    img_temp2 = cv2.erode(img_bin, hori_kernel, iterations=3)
    horizontal_lines_img = cv2.dilate(img_temp2, hori_kernel, iterations=3)
    #cv2.imwrite("horizontal_lines.jpg",horizontal_lines_img)

    # Weighting parameters, this will decide the quantity of an image to be added to make a new image.
    alpha = 0.5
    beta = 1.0 - alpha
    # This function helps to add two image with specific weight parameter to get a third image as summation of two image.
    img_final_bin = cv2.addWeighted(verticle_lines_img, alpha, horizontal_lines_img, beta, 0.0)
    img_final_bin = cv2.erode(~img_final_bin, kernel, iterations=2)
    (thresh, img_final_bin) = cv2.threshold(img_final_bin, 128, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)

    # For Debugging
    # Enable this line to see verticle and horizontal lines in the image which is used to find boxes
    cv2.imwrite("img_final_bin.jpg",img_final_bin)
    # Find contours for image, which will detect all the boxes
    img_final_bin,contours, hierarchy = cv2.findContours(img_final_bin, cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)
    #_, contours, _ = cv2.findContours(img_final_bin, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
	# Sort all the contours by top to bottom.
    (contours, boundingBoxes) = sort_contours(contours, method="top-to-bottom")
    path=cropped_dir_path
    idx = 0
    for c in contours:
        # Returns the location and width,height for every contour
        x, y, w, h = cv2.boundingRect(c)

        # If the box height is greater then 20, widht is >80, then only save it as a box in "cropped/" folder.
        if ((w <width and h <(0.9*height)) and (w >(0.8*width) and h >(0.8*height)) ):
            idx += 1
            print(idx)
            if idx==1 or idx==2:
               a=int(0.5*(x+w))
               print(a)
               top_image=img1[0:y,a:x+w]
               new_img = img1[y:y+h, x:x+w]
               image_name=str(idx)+'.tif'
               top_name=str(idx+1)+'.tif'
               #cv2.imwrite(str(idx) + '.tif', new_img)
               cv2.imwrite(os.path.join(path ,image_name),new_img)
               cv2.imwrite(os.path.join(path ,top_name),top_image)
            else:
                new_img = img1[y-2:y+h, x-2:x+w]
                cv2.imwrite(str(idx) + '.tif', new_img)
    return True

#<===================================================stripping data based on boundaries==================================================>
def stripping(path_to_bottom_data):
    cordinates=[[11, 197, 91, 261],[413, 196, 493, 263],[837, 196, 922, 268],[1378, 189, 1452, 262],[1794, 188, 1874, 262],[2270, 180, 2350, 261],[2632, 189, 2712, 262],[2947, 169, 4716, 269],[24, 370, 1693, 464],[1794, 392, 1948, 479],[1988, 386, 2129, 473],[2149, 392, 2384, 479],[2451, 383, 2545, 464],[2752, 383, 2833, 464],[2947, 376, 4703, 469],[11, 552, 1693, 673],[4, 760, 1485, 867],[1512, 752, 1693, 866],[5, 947, 748, 1074],[855, 974, 1036, 1088],[1076, 977, 1693, 1084],[1914, 592, 1995, 673],[2216, 591, 2303, 678],[2451, 591, 2531, 678],[2752, 584, 2839, 672],[2933, 551, 4716, 665],[2933, 759, 4328, 866],[4368, 751, 4723, 872],[2927, 947, 3677, 1087],[3845, 981, 4033, 1082],[4073, 977, 4710, 1078],[1733, 752, 2900, 1074],[5, 1162, 1686, 1269],[17, 1349, 1700, 1463],[11, 1544, 1700, 1672],[11, 1765, 1700, 1879],[17, 1961, 1700, 2075],[2042, 1396, 2122, 1476],[2397, 1396, 2477, 1476],[2042, 1598, 2122, 1678],[2422, 1597, 2500, 1671],[2632, 1585, 2786, 1672],[2042, 1793, 2122, 1874],[2397, 1793, 2477, 1881],[1740, 1970, 2907, 2077],[2933, 1166, 4730, 1280],[3121, 1392, 3269, 1486],[3295, 1398, 3443, 1486],[3510, 1392, 3751, 1479],[4019, 1391, 4106, 1478],[4442, 1396, 4529, 1476],[2933, 1568, 4716, 1676],[2933, 1760, 4723, 1881],[3054, 1989, 3134, 2069],[3349, 1989, 3436, 2083],[305, 2284, 1800, 2438],[2109, 2338, 2236, 2446],[2250, 2338, 2343, 2446],[2357, 2338, 2571, 2445],[3269, 2310, 4703, 2451],[57, 2602, 212, 2682],[232, 2601, 386, 2681],[413, 2600, 634, 2680],[909, 2586, 1593, 2680],[1794, 2576, 1981, 2683],[2156, 2602, 2317, 2689],[2337, 2600, 2491, 2680],[2504, 2601, 2759, 2681],[3175, 2601, 3309, 2688],[3329, 2601, 3510, 2681],[3530, 2600, 3778, 2680],[4026, 2602, 4174, 2689],[4187, 2599, 4341, 2681],[4368, 2594, 4609, 2681],[3, 2765, 165, 2879],[185, 2771, 1586, 2878],[1747, 2691, 1861, 2785],[1874, 2690, 2920, 2784],[1881, 2786, 2907, 2886],[3181, 2783, 3315, 2884],[3342, 2789, 3510, 2883],[3537, 2790, 3771, 2877],[4019, 2796, 4174, 2884],[4187, 2804, 4348, 2885],[4368, 2795, 4589, 2876],[5, 2949, 2900, 3076],[3061, 2989, 3141, 3069],[3369, 2989, 3450, 3069],[3631, 2968, 4194, 3082],[4214, 2968, 4730, 3082],[138, 3170, 540, 3271],[902, 3197, 1311, 3277],[1686, 3190, 2102, 3271],[2471, 3209, 2886, 3276],[131, 3297, 540, 3365],[902, 3304, 1318, 3371],[1680, 3297, 2102, 3378],[2464, 3304, 2886, 3371],[131, 3385, 540, 3472],[909, 3391, 1324, 3472],[1693, 3392, 2102, 3473],[2471, 3391, 2880, 3465],[2471, 3094, 2565, 3215],[2960, 3197, 3604, 3284],[3631, 3197, 4737, 3284],[2947, 3358, 4730, 3485],[3704, 3692, 3818, 3786],[3838, 3699, 3999, 3779],[4013, 3692, 4737, 3779],[11, 3784, 151, 3891],[178, 3790, 332, 3884],[352, 3790, 520, 3884],[533, 3783, 688, 3884],[708, 3782, 882, 3883],[902, 3783, 1056, 3884],[1076, 3787, 1244, 3874],[1264, 3794, 1418, 3874],[1459, 3786, 1854, 3880],[1881, 3793, 2075, 3880],[2095, 3793, 2250, 3880],[2270, 3799, 2431, 3880],[2464, 3798, 2612, 3886],[2638, 3787, 2920, 3881],[2940, 3787, 3302, 3888],[3315, 3786, 3456, 3880],[3470, 3786, 3691, 3880],[3711, 3794, 3818, 3881],[4019, 3773, 4737, 3879],[3704, 3888, 3818, 3981],[3838, 3888, 3999, 3981],[4019, 3887, 4743, 3981],[11, 3993, 158, 4087],[178, 3992, 332, 4086],[359, 3999, 520, 4086],[540, 3991, 694, 4085],[708, 3999, 889, 4086],[902, 4000, 1063, 4087],[1076, 3987, 1244, 4081],[1264, 3993, 1425, 4087],[1452, 3987, 1861, 4081],[1888, 3994, 2082, 4088],[2095, 3993, 2250, 4088],[2270, 3993, 2431, 4090],[2451, 3995, 2612, 4088],[2638, 3987, 2920, 4081],[2940, 3988, 3302, 4082],[3322, 3989, 3456, 4083],[3470, 3994, 3698, 4081],[3711, 3994, 3818, 4081],[3999, 4002, 4743, 4082],[3711, 4096, 3818, 4190],[3838, 4095, 3999, 4188],[4019, 4096, 4743, 4190],[4, 4192, 158, 4279],[171, 4195, 332, 4276],[352, 4194, 520, 4281],[540, 4187, 694, 4288],[714, 4186, 889, 4280],[909, 4194, 1056, 4281],[1076, 4195, 1244, 4277],[1264, 4188, 1425, 4276],[1459, 4189, 1861, 4277],[1881, 4197, 2075, 4284],[2095, 4202, 2250, 4282],[2270, 4203, 2431, 4282],[2457, 4203, 2612, 4284],[2632, 4188, 2927, 4282],[2940, 4191, 3302, 4285],[3315, 4189, 3456, 4283],[3470, 4188, 3698, 4282],[3711, 4190, 3818, 4284],[4019, 4196, 4743, 4277],[3704, 4290, 3818, 4384],[3838, 4289, 3999, 4390],[4019, 4291, 4743, 4385],[11, 4395, 158, 4489],[178, 4382, 332, 4489],[352, 4395, 513, 4489],[540, 4395, 694, 4489],[708, 4395, 889, 4489],[909, 4393, 1056, 4487],[1076, 4397, 1251, 4484],[1271, 4396, 1425, 4483],[1472, 4391, 1861, 4492],[1888, 4398, 2069, 4485],[2095, 4391, 2250, 4485],[2276, 4397, 2431, 4491],[2451, 4397, 2618, 4484],[2632, 4392, 2920, 4486],[2940, 4391, 3309, 4492],[3322, 4385, 3456, 4492],[3470, 4391, 3698, 4491],[3718, 4398, 3818, 4492],[4019, 4397, 4743, 4484],[3704, 4497, 3825, 4584],[3838, 4498, 3999, 4585],[4019, 4492, 4743, 4586],[11, 4603, 165, 4684],[185, 4604, 339, 4678],[352, 4603, 520, 4684],[540, 4597, 694, 4678],[721, 4604, 882, 4678],[902, 4604, 1056, 4678],[1076, 4593, 1251, 4680],[1271, 4598, 1418, 4679],[1459, 4598, 1867, 4679],[1888, 4604, 2075, 4687],[2095, 4605, 2256, 4692],[2276, 4598, 2431, 4692],[2451, 4599, 2618, 4687],[2632, 4606, 2927, 4680],[2940, 4594, 3309, 4688],[3322, 4594, 3456, 4688],[3470, 4593, 3698, 4680],[3718, 4594, 3825, 4694],[4019, 4595, 4743, 4688],[3704, 4702, 3818, 4789],[3838, 4702, 3999, 4796],[4019, 4700, 4743, 4787],[4, 4800, 158, 4880],[178, 4798, 339, 4885],[352, 4798, 520, 4885],[540, 4792, 701, 4879],[714, 4799, 889, 4879],[909, 4793, 1056, 4880],[1076, 4794, 1251, 4881],[1271, 4795, 1425, 4882],[1459, 4794, 1867, 4881],[1881, 4794, 2075, 4888],[2095, 4794, 2256, 4888],[2276, 4795, 2431, 4889],[2451, 4794, 2618, 4888],[2632, 4794, 2927, 4881],[2940, 4795, 3309, 4882],[3322, 4796, 3456, 4890],[3476, 4788, 3698, 4889],[3718, 4794, 3825, 4888],[4019, 4801, 4737, 4888],[11, 4965, 942, 5086],[989, 4998, 1056, 5078],[1103, 4991, 1184, 5078],[1324, 4965, 2176, 5079],[2236, 4999, 2317, 5079],[2531, 4998, 2618, 5085],[3014, 4962, 3436, 5090],[3450, 4956, 3597, 5090],[3698, 4970, 4039, 5091],[4053, 4962, 4180, 5090],[4180, 4963, 4576, 5091],[4596, 4956, 4743, 5090],[5, 5360, 795, 5541],[768, 5447, 916, 5555],[922, 5440, 1029, 5555],[1029, 5447, 1244, 5555],[1324, 5173, 2886, 5267],[1324, 5274, 2886, 5368],[1324, 5367, 2886, 5461],[1378, 5495, 1988, 5589],[2062, 5495, 2920, 5589],[3919, 5098, 4100, 5192],[4153, 5105, 4743, 5192],[2933, 5207, 4730, 5275],[2947, 5288, 4730, 5362],[2947, 5382, 4730, 5456],[2994, 5496, 3610, 5583],[3677, 5499, 4743, 5593]]
    img=cv2.imread(path_to_bottom_data)
    idx=0
    path='./cropped/'
    for i in cordinates:
        a=i[1]
        b=i[3]
        c=i[0]
        d=i[2]
        idx+=1
        new_img = img[a:b,c:d]
        image_name=str(idx) + '.png'
        cv2.imwrite(os.path.join(path ,image_name),new_img)
    return True

#<===================================================converting images into binary======================================================>
def image_binary(imagepath,binsave):
    img = cv2.imread(imagepath,0)
    img = cv2.medianBlur(img,5)
    ret,th1 = cv2.threshold(img,127,255,cv2.THRESH_BINARY)
    cv2.imwrite(binsave,th1)

def binarize(inputpath,path):
    # path="./binary/"
    # inputpath="./cropped/"
    for i in range(1,267):
        input_image=str(i)+".png"
        inputpath=os.path.join(inputpath,input_image)
        image_name=str(i)+".png"
        outputpath=os.path.join(path ,image_name)
        image_binary(inputpath,outputpath)
    return True
	
def names(nlist):
    suffixes = ['Jr.','Sr.','Jnr','Snr']
    new_list_names = nlist
    no_value =''
    new_list_names1 = [i.strip() for i in new_list_names]
    if (len(new_list_names1)==4):
        pass
    elif (len(new_list_names1)>2 and len(new_list_names1)<4):
        if new_list_names1[1] in suffixes:
            new_list_names1.append(no_value)
        else:
            new_list_names1.append(no_value)
            x = new_list_names1[1]
            y = new_list_names1[2]
            new_list_names1[1] = no_value
            new_list_names1[2] = x
            new_list_names1[3] = y
    elif(len(new_list_names1)>1 and len(new_list_names1)<3):
        if new_list_names1[1] in suffixes:
            new_list_names1.append(no_value)
            new_list_names1.append(no_value)
        else:
            new_list_names1.append(no_value)
            new_list_names1.append(no_value)
            z = new_list_names1[1]
            new_list_names1[1] = no_value
            new_list_names1[2] = z
    elif(len(new_list_names1)>0 and len(new_list_names1)<2):
        new_list_names1.append(no_value)
        new_list_names1.append(no_value)
        new_list_names1.append(no_value)
    else:
        if new_list_names1[1] in suffixes:
            new_list_names1 = new_list_names1[0:4]
        else:
            new_list_names1 = new_list_names1[0:4]
            r = new_list_names1[1]
            h = new_list_names1[2]
            new_list_names1[1] = no_value
            new_list_names1[2] = r
            new_list_names1[3] = h
    return new_list_names1
				
#<=====================================cms1500_1=============================================================>
cms1500_1=[8, 9, 10,11, 12, 15, 16, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 42, 45, 46, 47, 48, 49, 52, 53, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 239, 242, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255, 256, 257, 258, 259, 260, 261, 262, 263, 264, 265, 266]
integer_list=[10,11,12,28,29,31,32,47,48,49,57,58,59,61,62,63,66,67,68,69,70,71,72,73,74,80,81,82,83,84,85,89,90,103,242,245,246,247,248,252,253,254,260,261]
others = [8, 9, 15, 16, 21, 22, 23, 24, 25, 26, 27, 30, 33, 34, 35, 36, 37, 42, 45, 46, 52, 53, 56, 60, 64, 65, 71, 75, 76, 77, 78, 79, 86, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 104, 105, 106, 239, 249, 250, 251, 255, 256, 257, 258, 259, 262, 263, 264, 265, 266]
#<=====================================cms1500_2==============================================================>
column_24 = [107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238]
table24_interger_data=[110, 111, 112, 113, 114, 115, 116, 118, 119, 120, 121, 122, 124, 125, 132, 133, 134, 135, 136, 137, 138, 140, 141, 142, 143, 144, 146, 147, 154, 155, 156, 157, 158, 159, 160, 162, 163, 164, 165, 166, 168, 169, 176, 177, 178, 179, 180, 181, 182, 184, 185, 186, 187, 188, 190, 191, 198, 199, 200, 201, 202, 203, 204, 206, 207, 208, 209, 210, 212, 213, 220, 221, 222, 223, 224, 225, 226, 228, 229, 230, 231, 232, 234, 235]
table24_string_data=[107,108,109,117,123,126,127,128,129,130,131,139,145,148,149,150,151,152,153,161,167,170,171,172,173,174,175,183,189,192,193,194,195,196,197,205,211,214,215,216,217,218,219,227,233,236,237,238]
#<=====================================checkboxes==============================================================>
cross_mark=[1,2,3,4,5,6,7,13,14,17,18,19,20,38,39,40,41,43,44,50,51,54,55,87,88,240,241,243,244]

ravi=preprocess('1.jpg')
if ravi:
   print('image pre processed')
   if box_extraction("blob.jpg","1.jpg" ,"./image/"):
        print('boxes extracted')
        if stripping(os.path.join('./image/1.tif')):
           print('images are stripped')
           if binarize("./cropped/","./binary/"):
             print('images are binarized')

# image_name = ""
# data_list = []
# path=os.path.join('./binary/')
# for i in cms1500_1:
    # if i in others:
        # image_name =path+ str(i)+".tif"
        # output_data=pytesseract.image_to_data(Image.open(image_name),lang='eng',config='--psm 10 tessedit_char_whitelist=0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz')
        # data=io.StringIO(output_data)
        # data_lines=data.readlines()
        # list_data=[]
        # idx=0
        # conf=0
        # text=""
        # for x in data_lines:
            # list_data.append(x.split('\t'))
        # for i in range(1,len(list_data)):
            # if list_data[i][10]!='-1' and int(list_data[i][10])>10:
                # idx+=1
                # conf+=int(list_data[i][10])
                # text+=list_data[i][11]
        # if idx==0:
            # idx=1
            # conf=int(conf/idx)
        # else:
            # conf=int(conf/idx)
        # text=text.replace('\n',' ')
        # data_list.append((text,str(conf)))
    # if i in integer_list:
        # image_name =path+str(i)+".tif"
        # output_data=pytesseract.image_to_data(Image.open(image_name),lang='eng',config='--psm 10  outputbase digits')
        # data=io.StringIO(output_data)
        # data_lines=data.readlines()
        # list_data=[]
        # idx=0
        # conf=0
        # text=""
        # for x in data_lines:
            # list_data.append(x.split('\t'))
        # for i in range(1,len(list_data)):
            # if list_data[i][10]!='-1' and int(list_data[i][10])>60:
                # idx+=1
                # conf+=int(list_data[i][10])
                # text+=list_data[i][11]
        # if idx==0:
            # idx=1
            # conf=int(conf/idx)
        # else:
            # conf=int(conf/idx)
        # text=text.replace('\n',' ')
        # data_list.append((text,str(conf)))
    # image_name = ""
    
# numplusdata = []

# for i in range(0,len(data_list)):
    # selection = [cms1500_1[i],data_list[i]]
    # numplusdata.append(selection)

# data_list_24 = []




# for i in column_24:
    # if i in table24_string_data:
        # image_name =path+str(i)+".tif"
        # f_.write("    \n"+image_name+"    \n")
        # output_data=pytesseract.image_to_data(Image.open(image_name),lang='eng',config='--psm 10 tessedit_char_whitelist=0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz')
        # data=io.StringIO(output_data)
        # data_lines=data.readlines()
        # list_data=[]
        # idx=0
        # conf=0
        # text=""
        # for x in data_lines:
            # list_data.append(x.split('\t'))
        # for i in range(1,len(list_data)):
            # if list_data[i][10]!='-1' and int(list_data[i][10])>10:
                # idx+=1
                # conf+=int(list_data[i][10])
                # text+=list_data[i][11]
            # if idx==0:
                # idx=1
                # conf=int(conf/idx)
            # else:
                # conf=int(conf/idx)
        # text=text.replace('\n',' ')
        # data_list_24.append((text,str(conf)))
    # if i in table24_interger_data:
        # image_name = path+str(i)+".tif"
        # output_data=pytesseract.image_to_data(Image.open(image_name),lang='eng',config='--psm 10  outputbase digits')
        # data=io.StringIO(output_data)
        # data_lines=data.readlines()
        # list_data=[]
        # idx=0
        # conf=0
        # text=""
        # for x in data_lines:
            # list_data.append(x.split('\t'))
        # for i in range(1,len(list_data)):
            # if list_data[i][10]!='-1' and int(list_data[i][10])>10:
                # idx+=1
                # conf+=int(list_data[i][10])
                # text+=list_data[i][11]
        # if idx==0:
            # idx=1
            # conf=int(conf/idx)
        # else:
            # conf=int(conf/idx)
        # text=text.replace('\n',' ')
        # data_list_24.append((text,str(conf)))
    # image_name = ""

# numplusdata_1 = []

# for i in range(0,len(data_list_24)):
    # selection = [column_24[i],data_list_24[i]]
    # numplusdata_1.append(selection)

# temp_marked=[]
# for i in cross_mark:
    # img = cv2.imread(path+str(i)+'.tif')
    # img_gray = cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
    # template = cv2.imread('template.png',0)
    # w , h = template.shape[::-1]
    # res = cv2.matchTemplate(img_gray,template,cv2.TM_CCOEFF_NORMED)
    # #min_val, max_val,min_loc,max_loc = cv2.minMaxLoc(res)
    # #top_left = max_loc
    # #bottom_right = (top_left[0]+w , top_left[1]+h)
    # threshold = 0.5
    # loc = np.where(res >= threshold)
    # for pt in zip(*loc[::-1]):
        # cv2.rectangle(img,pt, (pt[0] + w, pt[1] + h),(0,0,255),2)
        # temp_marked.append(i)
# marked=list(set(temp_marked))
# marked.sort()



# cross_data_list =[ 'Medicare','Medicaid','Tricare','Champva','Group Health Plan','FECA BLK LUNG','Other','Male','Female','Self','Spouse','Child','Other','Yes','No','Yes','No','Yes','No','Male','Female','Yes','No','Yes','No','SSN','EIN','Yes','No']

# cross_list_final = []

# for x in marked:
    # #print(cross_mark.index(x))
    # i = cross_mark.index(x)
    # selection = [x,(cross_data_list[i],'100')]
    # cross_list_final.append(selection)

# list_ = cross_list_final + numplusdata 

# list_final = sorted(list_, key=lambda x: x[0])

# val = []
# conf_val = []
# for x in list_final:
    # (a,b) = x[1]
    # val.append(a)
    # conf_val.append(b)

# names1=val[2].split(',')
# names2=val[7].split(',')
# names3=val[22].split(',')

# new_list_names1 = names(names1)
# new_list_names2 = names(names2)
# new_list_names3 = names(names3)

# CLAIM_ID=claim_id_generation(new_list_names2[0],new_list_names2[2],val[1],val[3],val[4],val[6])
# new_val = []
# new_val.append(CLAIM_ID)
# #new_val = val[0:2]+ new_list_names1 + val[3:7]+new_list_names2+val[8:22]+new_list_names3 + val[23:]

# details_payer=payer_details(os.path.join('./image/2.tif'))
# new_val+=details_payer
# print(details_payer)

# new_val+= val[0:2]+ new_list_names1 + val[3:7]+new_list_names2+val[8:22]+new_list_names3 + val[23:]



# print(new_val)
# print(len(new_val))


