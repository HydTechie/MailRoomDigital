            image_name = ""
            f=open('tesdata.text','w')
            data_list = []


            for i in cms1500_1:
               if i in others:
                  image_name = str(i)+".tif"
                  f.write("    \n"+image_name+"    \n")
                  output_data=pytesseract.image_to_data(Image.open(image_name),lang='eng',config='--psm 10 tessedit_char_whitelist=0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz')
                  data=io.StringIO(output_data)
                  data_lines=data.readlines()
                  list_data=[]
                  idx=0
                  conf=0
                  text=""
                  for x in data_lines:
                     list_data.append(x.split('\t'))
                  for i in range(1,len(list_data)):
                     if list_data[i][10]!='-1' and int(list_data[i][10])>10:
                        idx+=1
                        conf+=int(list_data[i][10])
                        text+=list_data[i][11]
                  if idx==0:
                     idx=1
                     conf=int(conf/idx)
                  else:
                     conf=int(conf/idx)
                  text=text.replace('\n',' ')
                  f.write("["+text+","+str(conf)+"]")
                  data_list.append((text,str(conf)))
                  f.write("\n<=====================================================================================>")
                  #f.write(pytesseract.image_to_data(Image.open(image_name),lang='eng',config='--psm 10 --oem 3'))
               if i in integer_list:
                  image_name = str(i)+".tif"
                  f.write("    \n"+image_name+"    \n")
                  output_data=pytesseract.image_to_data(Image.open(image_name),lang='eng',config='--psm 10  outputbase digits')
                  data=io.StringIO(output_data)
                  data_lines=data.readlines()
                  list_data=[]
                  idx=0
                  conf=0
                  text=""
                  for x in data_lines:
                     list_data.append(x.split('\t'))
                  for i in range(1,len(list_data)):
                     if list_data[i][10]!='-1' and int(list_data[i][10])>60:
                        idx+=1
                        conf+=int(list_data[i][10])
                        text+=list_data[i][11]
                  if idx==0:
                     idx=1
                     conf=int(conf/idx)
                  else:
                     conf=int(conf/idx)
                  text=text.replace('\n',' ')
                  f.write("["+text+","+str(conf)+"]")
                  data_list.append((text,str(conf)))
                  f.write("\n<=====================================================================================>")
               image_name = ""
            f.close()




            #print(data_list)
            print(len(data_list))
            print(len(cms1500_1))


            numplusdata = []

            for i in range(0,len(data_list)):
               selection = [cms1500_1[i],data_list[i]]
               numplusdata.append(selection)

   
   
            #print(numplusdata)

            data_list_24 = []


            f_=open('tesdata24.text','w')


            for i in column_24:
               if i in table24_string_data:
                  image_name = str(i)+".tif"
                  f_.write("    \n"+image_name+"    \n")
                  output_data=pytesseract.image_to_data(Image.open(image_name),lang='eng',config='--psm 10 tessedit_char_whitelist=0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz')
                  data=io.StringIO(output_data)
                  data_lines=data.readlines()
                  list_data=[]
                  idx=0
                  conf=0
                  text=""
                  for x in data_lines:
                     list_data.append(x.split('\t'))
                  for i in range(1,len(list_data)):
                     if list_data[i][10]!='-1' and int(list_data[i][10])>10:
                        idx+=1
                        conf+=int(list_data[i][10])
                        text+=list_data[i][11]
                  if idx==0:
                     idx=1
                     conf=int(conf/idx)
                  else:
                     conf=int(conf/idx)
                  text=text.replace('\n',' ')
                  f_.write("["+text+","+str(conf)+"]")
                  data_list_24.append((text,str(conf)))
                  f_.write("\n<=====================================================================================>")
                  #f.write(pytesseract.image_to_data(Image.open(image_name),lang='eng',config='--psm 10 --oem 3'))
               if i in table24_interger_data:
                  image_name = str(i)+".tif"
                  f_.write("    \n"+image_name+"    \n")
                  output_data=pytesseract.image_to_data(Image.open(image_name),lang='eng',config='--psm 10  outputbase digits')
                  data=io.StringIO(output_data)
                  data_lines=data.readlines()
                  list_data=[]
                  idx=0
                  conf=0
                  text=""
                  for x in data_lines:
                     list_data.append(x.split('\t'))
                  for i in range(1,len(list_data)):
                     if list_data[i][10]!='-1' and int(list_data[i][10])>10:
                        idx+=1
                        conf+=int(list_data[i][10])
                        text+=list_data[i][11]
                  if idx==0:
                     idx=1
                     conf=int(conf/idx)
                  else:
                     conf=int(conf/idx)
                  text=text.replace('\n',' ')
                  f_.write("["+text+","+str(conf)+"]")
                  data_list_24.append((text,str(conf)))
                  f_.write("\n<=====================================================================================>")
               image_name = ""
            f_.close()


            #print(data_list_24)
            print(len(data_list_24))
            print(len(column_24))

            numplusdata_1 = []

            for i in range(0,len(data_list_24)):
               selection = [column_24[i],data_list_24[i]]
               numplusdata_1.append(selection)




            temp_marked=[]
            for i in cross_mark:

               img = cv2.imread(str(i)+'.tif')
               img_gray = cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
               template = cv2.imread('template.png',0)
               w , h = template.shape[::-1]
               res = cv2.matchTemplate(img_gray,template,cv2.TM_CCOEFF_NORMED)
               #min_val, max_val,min_loc,max_loc = cv2.minMaxLoc(res)
               #top_left = max_loc
               #bottom_right = (top_left[0]+w , top_left[1]+h)
               threshold = 0.5
               loc = np.where(res >= threshold)
               for pt in zip(*loc[::-1]):
                  cv2.rectangle(img,pt, (pt[0] + w, pt[1] + h),(0,0,255),2)
                  temp_marked.append(i)
                  #print(pt[0] + w)
            #   cv2.rectangle(img,top_left,bottom_right,255,2)
            #  print(top_left,bottom_right)
               #cv2.imwrite(path+'test/'+str(i)+'test.png',img)
            marked=list(set(temp_marked))
            marked.sort()
            print(marked)

            cross_data_list =[ 'Medicare','Medicaid','Tricare','Champva','Group Health Plan','FECA BLK LUNG','Other','Male','Female','Self','Spouse','Child','Other','Yes','No','Yes','No','Yes','No','Male','Female','Yes','No','Yes','No','SSN','EIN','Yes','No']

            cross_list_final = []

            for x in marked:
               print(cross_mark.index(x))
               i = cross_mark.index(x)
               selection = [x,(cross_data_list[i],'100')]
               cross_list_final.append(selection)
	  
	  
            #print(cross_list_final)
	  
            list_ = cross_list_final + numplusdata 

            list_final = sorted(list_, key=lambda x: x[0])

            #print(list_final)
            print(len(list_final))

            val = []
            conf_val = []

            for x in list_final:
               (a,b) = x[1]
               val.append(a)
               conf_val.append(b)
   

            print(len(val))
            print(len(conf_val))





            #print(val)


            names1=val[2].split(',')
            names2=val[7].split(',')
            names3=val[22].split(',')

            new_list_names1 = names(names1)
            new_list_names2 = names(names2)
            new_list_names3 = names(names3)

            CLAIM_ID=claim_id_generation(new_list_names2[0],new_list_names2[2],val[1],val[3],val[4],val[6])
            new_val = []
            new_val.append(CLAIM_ID)
            #new_val = val[0:2]+ new_list_names1 + val[3:7]+new_list_names2+val[8:22]+new_list_names3 + val[23:]

            details_payer=payer_details(os.path.join('./image/2.tif'))
            new_val+=details_payer
            print(details_payer)

            new_val+= val[0:2]+ new_list_names1 + val[3:7]+new_list_names2+val[8:22]+new_list_names3 + val[23:]



            print(new_val)
            print(len(new_val))