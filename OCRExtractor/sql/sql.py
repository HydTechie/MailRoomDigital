with open("column_name.txt") as f:
    lines_filled = f.readlines()
# you may also want to remove whitespace characters like `\n` at the end of each line
lines_filled = [x.strip() for x in lines_filled] 
print(len(lines_filled))



with open("column_name_extension.txt") as f3:
    lines_filled_extension = f3.readlines()
# you may also want to remove whitespace characters like `\n` at the end of each line
lines_filled_extension = [x.strip() for x in lines_filled_extension] 
print(len(lines_filled_extension))


with open("data_size.txt") as f1:
    data_size = f1.readlines()
# you may also want to remove whitespace characters like `\n` at the end of each line
data_size = [x.strip() for x in data_size] 
print(len(data_size))


with open("data_type.txt") as f2:
    data_type = f2.readlines()
# you may also want to remove whitespace characters like `\n` at the end of each line
data_type = [x.strip() for x in data_type] 
print(len(data_type))

sqlc = ""
for i in range(0,131):
   if (data_type[i]=='varchar'):
      sqlc += '`'+str(lines_filled[i])+'_'+str(lines_filled_extension[i])+'` '+data_type[i]+'('+data_size[i]+'),'
   else:
      sqlc += '`'+str(lines_filled[i])+'_'+str(lines_filled_extension[i])+'` '+data_type[i]+'('+data_size[i]+') DEFAULT NULL,'
print(sqlc)