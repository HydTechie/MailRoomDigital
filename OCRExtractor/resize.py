
from PIL import Image
size = 4964, 7020
im = Image.open("2.jpg")
im_resized = im.resize(size, Image.ANTIALIAS)
quality_val = 600
#im_resized.save("my_image_resized6.jpg", quality = quality_val)
im_resized.save("my_image_resized6.jpg", 'JPEG', quality=quality_val) 
 
