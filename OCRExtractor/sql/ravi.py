with open("column_name1.txt") as f:
    lines_filled = f.readlines()
# you may also want to remove whitespace characters like `\n` at the end of each line
lines_filled = [x.strip() for x in lines_filled] 
print(len(lines_filled))

with open("a_data.txt") as f1:
    data_size = f1.readlines()
# you may also want to remove whitespace characters like `\n` at the end of each line
data_size = [x.strip() for x in data_size] 
print(len(data_size))

with open("data_type.txt") as f2:
    data_type = f2.readlines()
# you may also want to remove whitespace characters like `\n` at the end of each line
data_type = [x.strip() for x in data_type] 
print(len(data_type))

sqlc = "INSERT INTO `cms1500_2`("
for i in range(0,130):
   if (data_type[i]=='varchar'):
      sqlc += '\''+str(data_size[i])+'\','
   else:
      #if ( len(data_size[i]) >0):
      sqlc +=str(data_size[i])+','
      #else:
         #sqlc +="NULL,"
sqlc+=");"
print(sqlc)