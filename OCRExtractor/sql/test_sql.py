import mysql.connector

mydb = mysql.connector.connect(host="10.56.184.116",user="myuser",passwd="mypass",database="cms1500db")

mycursor = mydb.cursor()

sql = "INSERT INTO `cms1500_1_conf`(`ClaimID`, `ia_PayerName`, `ib_PayerAddress1`, `ic_PayerAddress2`, `id_Payer_city_state_zipcode`, `1_PAYER_TYPE`, `1a_Insured_Id_number`, `2a_LastName`, `2b_Suffix`, `2c_FirstName`, `2d_MiddleName`, `3a_MM`, `3b_DD`, `3c_YYYY`, `3d_Gender`, `4a_LastName`, `4b_Suffix`, `4c_FirstName`, `4d_MiddleName`, `5a_Street_Address`, `5b_City`, `5c_State`, `5d_Zipcode`, `5e_Telephone_areacode`, `5f_Telephone_phone number`, `6_Patient_Relationship_to_Insured`, `7a_Street_Address`, `7b_City`, `7c_State`, `7d_Zip code`, `7e_Telephone_areacode`, `7f_Telephone_phonenumber`, `8_Reserved_for_NUCC_Use`, `9-a_LastName`, `9-b_Suffix`, `9-c_FirstName`, `9-d_MiddleName`, `9a_other_policies_number`, `9b_Reserved_for_NUCC_Use`, `9c_Reserved_for_NUCC_Use`, `9d_InsuranceplanName`, `10a_employment`, `10b_Auto_Accident`, `10b-a_Auto_Accident_Place`, `10c_Other_Accident`, `10d_Claim_codes`, `11_InsuredsPolicyNumber`, `11a-a_MM`, `11a-b_DD`, `11a-c_YYYY`, `11a-d_Gender`, `11b-a_qualifier`, `11b-b_ClaimID`, `11c_InsurancePlanName`, `11d_Another_Health_Benefit_Plan`, `12-a_Signature_URL`, `12-b-a_MM`, `12-b-b_DD`, `12-b-c_YYYY`, `13_InsuredsAuthorizedSignature_URL`, `14-a_MM`, `14-b_DD`, `14-c_YYYY`, `14-d_qualifier`, `15-a_MM`, `15-b_DD`, `15-c_YYYY`, `15-d_qualifier`, `16-a_MM`, `16-b_DD`, `16-c_YYYY`, `16-a-a_MM`, `16-a-b_DD`, `16-a-c_YYYY`, `17_qualifier`, `17-a_Name`, `17a-a_Qualifier`, `17a-b_ID number`, `17b_ID number`, `18-a_MM`, `18-b_DD`, `18-c_YYYY`, `18-a-a_MM`, `18-a-b_DD`, `18-a-c_YYYY`, `19_Additional_Claim_Information`, `20_YES OR NO`, `20-a_Charges_dollars`, `20-b_charges_cents`, `21_ICD_Indicator`, `21A_Nature_of_Illnes`, `21B_Nature_of_Illnes`, `21C_Nature_of_Illnes`, `21D_Nature_of_Illnes`, `21E_Nature_of_Illnes`, `21f_Nature_of_Illnes`, `21G_Nature_of_Illnes`, `21H_Nature_of_Illnes`, `21I_Nature_of_Illnes`, `21J_Nature_of_Illnes`, `21K_Nature_of_Illnes`, `21L_Nature_of_Illnes`, `22-a_ReSubmissionCode_qualifier`, `22-b_original_ref_No`, `23_PriorAuthorizationNumber`, `25-a_type`, `25-b_ID_Number`, `26_Patient_Acc_Number`, `27_Accept_Assignment`, `28-a_dollars`, `28-b_cents`, `29-a_dollars`, `29-b_cents`, `30-a_code`, `30-b_qualifier`, `31-a_Signature`, `31-b-a_MM`, `31-b-b_DD`, `31-b-c_YYYY`, `32-a_ProviderName`, `32-b_ProviderAddress`, `32-c_City_State_Zipcode`, `32a_NationalProvider_IdentifierNumber`, `32b_PayerAssignedIdentifier_of_BillingProvider`, `33-a_AreaCode`, `33-b_PhoneNumber`, `33-c_BillingProvider_Name`, `33-d_BillingProvider_Address`, `33-e_Billingprovider_city_state_zipcode`, `33a_NationalProvider_IdentifierNumber`, `33b_PayerAssignedIdentifier_of_BillingProvider`) VALUES (%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)"
 
    
new_val = ['CC69718O0630M12873', '  123', '567', '478', '086', 'Medicare', '569718', 'Sagar Sadhu', '', '', '', 'O06', '30', '1996', 'Male', 'Praharsha K', '', '', '', 'Chandanagar', 'Hyderabad', 'TS', '500072', '040', '2345879', 'Other', 'KPHB', 'Hyderabad', 'TS', '500084', '040', '2122456', 'No', 'Naveen M', '', '', '', 'Himani L', 'No', 'Yes', 'Arogya Sree', 'Yes', 'No', 'TS', 'No', 'Yes', '9/68', '9', '21', '1996', 'Male', '', 'Yes', 'Health Bheema', 'Yes', 'Saagar Sadhu', '23-', '10', '2018', 'Sagar Sadhu', '3', '23', '3453', 'sdf', 'd', '2', '30', '5678', '3', '23', '3456', '23', '23', '3434', '', 'gsfdgfdg', 'fd', 'sdfafdS', 'fdsqsdf ', '2', '23', '4555', '2', '', '5456', 'asdfgsdbsfdva', 'Yes', '6756', 'OO', 'casfd', 'sadfsad', 'sadfsa', 'rete', 'sdfsa', 'sdfsda', 'SXxCDVC', 'vbv', 'afhigh', 'uailk', 'nm,', '5v', '5', 'bbb', 'rtvvb', '546546', '969717', 'SSN', '123456', 'Yes', '217', '', '100', '00', '.', '', 'Sagar Sadhu', '11.', '08', '-2018', 'Hyderabad', 'New York', 'Los Angeles', 'mahesh', 'suresh', 'asd', 'ewrerfdsf', '. ', 'xcvxcssdf', 'wetsdfcvxcvx', 'ramesh', 'Shiva']
new_conf =['CC69718O0630M60459', '96', '89', '96', '96', '100', '92', '96', None, None, None, '63', '96', '95', '100', '92', None, None, None, '92', '96', '95', '96', '96', '96', '100', '91', '96', '94', '72', '96', '65', '95', '92', None, None, None, '91', '95', '96', '91', '100', '100', '96', '100', '94', '81', '73', '93', '96', '100', '0', '95', '90', '100', '61', '92', '96', '95', '96', '96', '95', '96', '95', '92', '91', '96', '96', '93', '94', '96', '96', '96', '96', '0', '92', '94', '33', '85', '96', '96', '96', '96', '0', '95', '91', '100', '87', '78', '92', '90', '91', '95', '92', '90', '35', '86', '54', '19', '74', '57', '88', '95', '66', '96', '88', '100', '95', '100', '76', '0', '96', '68', '13', '0', '96', '91', '96', '89', '96', '96', '96', '91', '96', '96', '88', '72', '44', '92', '92', '96']
mycursor.execute(sql, new_conf)
mydb.commit()
print("1 record inserted, ID:", mycursor.lastrowid)