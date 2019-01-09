first_row_24 = [111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127,108,128,109,110,129]
second_row_24 = [133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 130, 150 , 131,132, 151]
third_row_24 = [155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 152, 172,153,154,174]
fourth_row_24 = [177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193,175,194,176,177,195]
fifth_row_24 = [199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215,196,216,197,198,217]
sixth_row_24 = [221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237,218,238,219,220,239]

data_24 = [(108, 'q', '81'), (109, 'sdf', '96'), (110, 'fdgsd', '92'), (111, '02', '89'), (112, '21', '95'), (113, '86', '96'), (114, '03', '96'), (115, '22', '96'), (116, '97', '96'), (117, 'HYD', '96'), (118, 'cb', '96'), (119, 'fgjnb', '91'), (120, 'q', '76'), (121, 'a', '94'), (122, 'Zz', '59'), (123, 'p', '91'), (124, 'qwq', '84'), (125, '1C', '92'), (126, '00', '92'), (127, 'jkh', '83'), (128, 'a', '94'), (129, 'reter', '89'), (130, 'WwW', '54'), (131, 'dfd', '92'), (132, 'vcbcb', '87'), (133, '12', '96'), (134, '20', '96'), (135, '87', '96'), (136, '04', '96'), (137, '23', '96'), (138, '98', '96'), (139, 'VSK', '91'), (140, 'vb', '95'), (141, 'vbmnvbnm', '66'), (142, 'Ww', '63'), (143, 'S', '51'), (144, 'x', '88'), (145, 'O', '82'), (146, 'ews', '95'), (147, '2C', '90'), (148, '00', '89'), (149, 'mn,', '83'), (150, 'b', '93'), (151, 'cevbec', '46'), (152, 'e', '59'), (153, 'dfd', '93'), (154, 'Crwere', '36'), (155, '11', '83'), (156, '— 19', '52'), (157, '88', '96'), (158, '— 05 ', '45'), (159, '24', '95'), (160, '99', '96'), (161, 'SEC', '96'), (162, 'CV', '94'), (163, 'vagyujmnb', '29'), (164, 'e', '88'), (165, 'd', '92'), (166, 'Cc', '50'), (167, '', '0'), (168, 'sdsd', '92'), (169, '3C', '91'), (170, '00', '64'), (171, 'hjk', '88'), (172, 'Xx', '61'), (173, 'fdgd', '73'), (174, 'r', '69'), (175, 'CVCV', '91'), (176, 'vcbcvb', '86'), (177, '10', '96'), (178, '18', '96'), (179, '89', '96'), (180, '06', '96'), (181, '25', '93'), (182, '00', '96'), (183, 'BZA', '96'), (184, 'bv', '96'), (185, 'vnbmnvghj', '68'), (186, 'r', '76'), (187, 'f', '92'), (188, 'Vv', '71'), (189, '', '0'), (190, 'CXXC', '60'), (191, '40', '96'), (192, '00', '84'), (193, 'nm.', '87'), (194, 'Zz', '55'), (195, 'vcbcvb', '89'), (196, 't', '92'), (197, 'CVC', '76'), (198, 'rery', '89'), (199, '09', '84'), (200, '17', '96'), (201, '90', '96'), (202, '07', '91'), (203, '26', '96'), (204, '01', '96'), (205, 'ONG', '95'), (206, 'vb', '95'), (207, 'gyuybnmbm', '69'), (208, 't', '92'), (209, '9.', '13'), (210, '', '0'), (211, 'y', '93'), (212, 'dfdf', '91'), (213, '50', '96'), (214, '00', '95'), (215, 'nm.', '72'), (216, 'JC', '30'), (217, 'gfhf', '89'), (218, 'u', '53'), (219, 'XCCV', '90'), (220, 'vvnvb', '51'), (221, '08', '96'), (222, '16', '96'), (223, '91', '93'), (224, '08', '95'), (225, '27', '73'), (226, '02', '79'), (227, 'XYZ', '94'), (228, 'vc', '71'), (229, 'bnmujhbm', '91'), (230, 'VY', '30'), (231, 'h', '40'), (232, 'Nn', '28'), (233, 'ot', '19'), (234, ' XCVXCV', '19'), (235, '6/7', '80'), (236, '00', '48'), (237, '', '0'), (238, 'y', '93'), (239, 'Khikhk', '52')] 




def orderChange(data_list):
    list_one = data_list
    new_list = []
    for i in range(3,20):
        new_list.append(list_one[i])
    
    new_list.append(list_one[0])
    new_list.append(list_one[-2])
    new_list.append(list_one[1])
    new_list.append(list_one[2])
    new_list.append(list_one[-1])
    
    return new_list
    

    
def text_addition(new_list):
    list_one = new_list
    re_list = []
    element =  list_one[9]+list_one[10]+list_one[11]+list_one[12]
    for i in range(0,9):
        re_list.append(list_one[i])
    
    re_list.append(element)
    
    for i in range(13,len(list_one)):
        re_list.append(list_one[i])
    
    return re_list


def conf_addition(new_list):
    list_one = new_list
    re_list = []
    element =  int((int(list_one[9])+int(list_one[10])+int(list_one[11])+int(list_one[12]))/4)
    for i in range(0,9):
        re_list.append(list_one[i])
    
    re_list.append(str(element))
    
    for i in range(13,len(list_one)):
        re_list.append(list_one[i])
    
    return re_list
    

def column_24(claimid,data_24):
    data = data_24
    claim_id = claimid
    data24=[]
    conf24 = []
    imno_24 = []
    
    for image_number, value , conf in data:
        imno_24.append(image_number)
        data24.append(value)
        conf24.append(conf)
    first_row_24 = [111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127,108,128,109,110,129]
    second_row_24 = [133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 130, 150 , 131,132, 151]
    third_row_24 = [155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 152, 172,153,154,174]
    fourth_row_24 = [177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193,175,194,176,177,195]
    fifth_row_24 = [199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215,196,216,197,198,217]
    sixth_row_24 = [221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237,218,238,219,220,239]
    first_row_24_values = []
    first_row_24_confs= []
    
    second_row_24_values = []
    second_row_24_confs= []
    
    third_row_24_values = []
    third_row_24_confs= []
    
    fourth_row_24_values = []
    fourth_row_24_confs= []
    
    fifth_row_24_values = []
    fifth_row_24_confs= []
    
    sixth_row_24_values = []
    sixth_row_24_confs= []
    for x in imno_24:
        if ( x in first_row_24):
            i = imno_24.index(x)
            first_row_24_values.append(data24[i])
            first_row_24_confs.append(conf24[i])
        elif ( x in second_row_24):
            i = imno_24.index(x)
            second_row_24_values.append(data24[i])
            second_row_24_confs.append(conf24[i])
        elif ( x in third_row_24):
            i = imno_24.index(x)
            third_row_24_values.append(data24[i])
            third_row_24_confs.append(conf24[i])
        elif ( x in fourth_row_24):
            i = imno_24.index(x)
            fourth_row_24_values.append(data24[i])
            fourth_row_24_confs.append(conf24[i])
        elif ( x in fifth_row_24):
            i = imno_24.index(x)
            fifth_row_24_values.append(data24[i])
            fifth_row_24_confs.append(conf24[i])
        elif ( x in sixth_row_24):
            i = imno_24.index(x)
            sixth_row_24_values.append(data24[i])
            sixth_row_24_confs.append(conf24[i])
        else:
            pass
            
            
    first_row_24_values = orderChange(first_row_24_values)
    second_row_24_values = orderChange(second_row_24_values)
    third_row_24_values = orderChange(third_row_24_values)
    fourth_row_24_values = orderChange(fourth_row_24_values)
    fifth_row_24_values = orderChange(fifth_row_24_values)
    sixth_row_24_values = orderChange(sixth_row_24_values)
    
    
    first_row_24_confs = orderChange(first_row_24_confs)
    second_row_24_confs = orderChange(second_row_24_confs)
    third_row_24_confs = orderChange(third_row_24_confs)
    fourth_row_24_confs = orderChange(fourth_row_24_confs)
    fifth_row_24_confs = orderChange(fifth_row_24_confs)
    sixth_row_24_confs = orderChange(sixth_row_24_confs)

    
    first_row_24_values = text_addition(first_row_24_values)
    second_row_24_values = text_addition(second_row_24_values)
    third_row_24_values = text_addition(third_row_24_values)
    fourth_row_24_values = text_addition(fourth_row_24_values)
    fifth_row_24_values = text_addition(fifth_row_24_values)
    sixth_row_24_values = text_addition(sixth_row_24_values)
    
    
    
    first_row_24_confs = conf_addition(first_row_24_confs)
    second_row_24_confs = conf_addition(second_row_24_confs)
    third_row_24_confs = conf_addition(third_row_24_confs)
    fourth_row_24_confs = conf_addition(fourth_row_24_confs)
    fifth_row_24_confs = conf_addition(fifth_row_24_confs)
    sixth_row_24_confs = conf_addition(sixth_row_24_confs)
    
    
    values_24 = []
    confss_24 = []
    
    values_24.append(claim_id)
    confss_24.append(claim_id)
    
    values_24.append(first_row_24_values)
    values_24.append(second_row_24_values)
    values_24.append(third_row_24_values)
    values_24.append(fourth_row_24_values)
    values_24.append(fifth_row_24_values)
    values_24.append(sixth_row_24_values)
    
    confss_24.append(first_row_24_confs)
    confss_24.append(second_row_24_confs)
    confss_24.append(third_row_24_confs)
    confss_24.append(fourth_row_24_confs)
    confss_24.append(fifth_row_24_confs)
    confss_24.append(sixth_row_24_confs)
    
    return values_24 , confss_24
   
a , b = column_24('CC69718O0630M60459',data_24)
print(a)
print("-----------------------")
print(b)

            
            
            
        
        
    
    
        
    