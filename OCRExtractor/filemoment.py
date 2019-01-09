import shutil
import os

source = 'C:/Users/KP00557911/Desktop/API/test1/'
dest1 = 'C:/Users/KP00557911/Desktop/API/test2/'


files = os.listdir(source)
print(files)

current_file = files[0]

for f in files:
    if( f == current_file):
        shutil.move(source+f, dest1)