-- CREATE DATABASE cms1500;

-- USE cms1500;
USE MAILROOM;
DROP TABLE IF EXISTS `cms1500_2`;
DROP TABLE IF EXISTS `cms1500_1`;

CREATE table cms1500_1(`ClaimID` varchar(18),`ia_PayerName` varchar(29),`ib_PayerAddress1` varchar(29),`ic_PayerAddress2` varchar(29),`id_Payer_city_state_zipcode` varchar(29),`1_PAYER_TYPE` varchar(8),`1a_Insured_Id_number` varchar(29),`2a_LastName` varchar(14),`2b_Suffix` varchar(14),`2c_FirstName` varchar(14),`2d_MiddleName` varchar(14),`3a_MM` int(2),`3b_DD` int(2),`3c_YYYY` int(4),`3d_Gender` varchar(6),`4a_LastName` varchar(14),`4b_Suffix` varchar(14),`4c_FirstName` varchar(14),`4d_MiddleName` varchar(14),`5a_Street_Address` varchar(28),`5b_City` varchar(24),`5c_State` varchar(3),`5d_Zipcode` varchar(7),`5e_Telephone_areacode` int(3),`5f_Telephone_phone number` int(10),`6_Patient_Relationship_to_Insured` varchar(6),`7a_Street_Address` varchar(28),`7b_City` varchar(24),`7c_State` varchar(3),`7d_Zip code` varchar(7),`7e_Telephone_areacode` int(3),`7f_Telephone_phonenumber` int(10),`8_Reserved_for_NUCC_Use` varchar(50),`9-a_LastName` varchar(14),`9-b_Suffix` varchar(14),`9-c_FirstName` varchar(14),`9-d_MiddleName` varchar(14),`9a_other_policies_number` varchar(28),`9b_Reserved_for_NUCC_Use` varchar(100),`9c_Reserved_for_NUCC_Use` varchar(100),`9d_InsuranceplanName` varchar(28),`10a_employment` varchar(3),`10b_Auto_Accident` varchar(3),`10b-a_Auto_Accident_Place` varchar(2),`10c_Other_Accident` varchar(3),`10d_Claim_codes` varchar(19),`11_InsuredsPolicyNumber` varchar(29),`11a-a_MM` int(2),`11a-b_DD` int(2),`11a-c_YYYY` int(4),`11a-d_Gender` varchar(6),`11b-a_qualifier` varchar(2),`11b-b_ClaimID` varchar(28),`11c_InsurancePlanName` varchar(29),`11d_Another_Health_Benefit_Plan` varchar(3),`12-a_Signature_URL` varchar(100),`12-b-a_MM` int(2),`12-b-b_DD` int(2),`12-b-c_YYYY` int(4),`13_InsuredsAuthorizedSignature_URL` varchar(100),`14-a_MM` int(2),`14-b_DD` int(2),`14-c_YYYY` int(4),`14-d_qualifier` int(3),`15-a_MM` int(2),`15-b_DD` int(2),`15-c_YYYY` int(4),`15-d_qualifier` int(3),`16-a_MM` int(2),`16-b_DD` int(2),`16-c_YYYY` int(4),`16-a-a_MM` int(2),`16-a-b_DD` int(2),`16-a-c_YYYY` int(4),`17_qualifier` varchar(2),`17-a_Name` varchar(24),`17a-a_Qualifier` varchar(2),`17a-b_ID number` varchar(17),`17b_ID number` varchar(10),`18-a_MM` int(2),`18-b_DD` int(2),`18-c_YYYY` int(4),`18-a-a_MM` int(2),`18-a-b_DD` int(2),`18-a-c_YYYY` int(4),`19_Additional_Claim_Information` varchar(71),`20_YES OR NO` varchar(3),`20-a_Charges_dollars` int(8),`20-b_charges_cents` int(2),`21_ICD_Indicator` int(1),`21A_Nature_of_Illnes` varchar(7),`21B_Nature_of_Illnes` varchar(7),`21C_Nature_of_Illnes` varchar(7),`21D_Nature_of_Illnes` varchar(7),`21E_Nature_of_Illnes` varchar(7),`21F_Nature_of_Illnes` varchar(7),`21G_Nature_of_Illnes` varchar(7),`21H_Nature_of_Illnes` varchar(7),`21I_Nature_of_Illnes` varchar(7),`21J_Nature_of_Illnes` varchar(7),`21K_Nature_of_Illnes` varchar(7),`21L_Nature_of_Illnes` varchar(7),`22-a_ReSubmissionCode_qualifier` varchar(11),`22-b_original_ref_No` varchar(18),`23_PriorAuthorizationNumber` varchar(29),`25-a_type` varchar(3),`25-b_ID_Number` varchar(15),`26_Patient_Acc_Number` int(14),`27_Accept_Assignment` varchar(3),`28-a_dollars` int(6),`28-b_cents` int(2),`29-a_dollars` int(6),`29-b_cents` int(2),`30-a_code` varchar(3),`30-b_qualifier` varchar(100),`31-a_Signature` varchar(100),`31-b-a_MM` int(2),`31-b-b_DD` int(2),`31-b-c_YYYY` int(4),`32-a_ProviderName` varchar(29),`32-b_ProviderAddress` varchar(29),`32-c_City_State_Zipcode` varchar(29),`32a_NationalProvider_IdentifierNumber` varchar(10),`32b_PayerAssignedIdentifier_of_BillingProvider` varchar(14),`33-a_AreaCode` int(3),`33-b_PhoneNumber` int(10),`33-c_BillingProvider_Name` varchar(29),`33-d_BillingProvider_Address` varchar(29),`33-e_Billingprovider_city_state_zipcode` varchar(29),`33a_NationalProvider_IdentifierNumber` varchar(10),`33b_PayerAssignedIdentifier_of_BillingProvider` varchar(17),PRIMARY KEY (`ClaimID`)) DEFAULT CHARSET=utf8;



INSERT INTO `cms1500_1`(`ClaimID`, `ia_PayerName`, `ib_PayerAddress1`, `ic_PayerAddress2`, `id_Payer_city_state_zipcode`, `1_PAYER_TYPE`, `1a_Insured_Id_number`, `2a_LastName`, `2b_Suffix`, `2c_FirstName`, `2d_MiddleName`, `3a_MM`, `3b_DD`, `3c_YYYY`, `3d_Gender`, `4a_LastName`, `4b_Suffix`, `4c_FirstName`, `4d_MiddleName`, `5a_Street_Address`, `5b_City`, `5c_State`, `5d_Zipcode`, `5e_Telephone_areacode`, `5f_Telephone_phone number`, `6_Patient_Relationship_to_Insured`, `7a_Street_Address`, `7b_City`, `7c_State`, `7d_Zip code`, `7e_Telephone_areacode`, `7f_Telephone_phonenumber`, `8_Reserved_for_NUCC_Use`, `9-a_LastName`, `9-b_Suffix`, `9-c_FirstName`, `9-d_MiddleName`, `9a_other_policies_number`, `9b_Reserved_for_NUCC_Use`, `9c_Reserved_for_NUCC_Use`, `9d_InsuranceplanName`, `10a_employment`, `10b_Auto_Accident`, `10b-a_Auto_Accident_Place`, `10c_Other_Accident`, `10d_Claim_codes`, `11_InsuredsPolicyNumber`, `11a-a_MM`, `11a-b_DD`, `11a-c_YYYY`, `11a-d_Gender`, `11b-a_qualifier`, `11b-b_ClaimID`, `11c_InsurancePlanName`, `11d_Another_Health_Benefit_Plan`, `12-a_Signature_URL`, `12-b-a_MM`, `12-b-b_DD`, `12-b-c_YYYY`, `13_InsuredsAuthorizedSignature_URL`, `14-a_MM`, `14-b_DD`, `14-c_YYYY`, `14-d_qualifier`, `15-a_MM`, `15-b_DD`, `15-c_YYYY`, `15-d_qualifier`, `16-a_MM`, `16-b_DD`, `16-c_YYYY`, `16-a-a_MM`, `16-a-b_DD`, `16-a-c_YYYY`, `17_qualifier`, `17-a_Name`, `17a-a_Qualifier`, `17a-b_ID number`, `17b_ID number`, `18-a_MM`, `18-b_DD`, `18-c_YYYY`, `18-a-a_MM`, `18-a-b_DD`, `18-a-c_YYYY`, `19_Additional_Claim_Information`, `20_YES OR NO`, `20-a_Charges_dollars`, `20-b_charges_cents`, `21_ICD_Indicator`, `21A_Nature_of_Illnes`, `21B_Nature_of_Illnes`, `21C_Nature_of_Illnes`, `21D_Nature_of_Illnes`, `21E_Nature_of_Illnes`, `21F_Nature_of_Illnes`, `21G_Nature_of_Illnes`, `21H_Nature_of_Illnes`, `21I_Nature_of_Illnes`, `21J_Nature_of_Illnes`, `21K_Nature_of_Illnes`, `21L_Nature_of_Illnes`, `22-a_ReSubmissionCode_qualifier`, `22-b_original_ref_No`, `23_PriorAuthorizationNumber`, `25-a_type`, `25-b_ID_Number`, `26_Patient_Acc_Number`, `27_Accept_Assignment`, `28-a_dollars`, `28-b_cents`, `29-a_dollars`, `29-b_cents`, `30-a_code`, `30-b_qualifier`, `31-a_Signature`, `31-b-a_MM`, `31-b-b_DD`, `31-b-c_YYYY`, `32-a_ProviderName`, `32-b_ProviderAddress`, `32-c_City_State_Zipcode`, `32a_NationalProvider_IdentifierNumber`, `32b_PayerAssignedIdentifier_of_BillingProvider`, `33-a_AreaCode`, `33-b_PhoneNumber`, `33-c_BillingProvider_Name`, `33-d_BillingProvider_Address`, `33-e_Billingprovider_city_state_zipcode`, `33a_NationalProvider_IdentifierNumber`, `33b_PayerAssignedIdentifier_of_BillingProvider`) VALUES ('OWSG4560103M32578', 'UNITED HEALTH GROUP','BONNER SPRINGS','','KS 66012','MEDICAID','DSG456','','','','',1,3,1994,'MALE','JUSTIN','BREW','BIBER','','','','','',NULL,NULL,'SELF','8TH AVENUE','New York','NY','10019',555,13355,'','JUSTIN','BREW','BIBER','','FDS466','','','OBAMA CARE','YES','NO','','NO','FA465','MD556',NULL,NULL,NULL,'','G2','DSFS566','FULL BODY CARE','YES','https://address/images/idnumber',10,5,2017,'https://address/images/idnumber',5,5,2017,431,3,2,2017,454,2,5,2017,5,5,2017,'DK','JOHN','1G','FFA555','',3,2,2017,2,5,2017,'1G DFG125 FG55','NO',NULL,NULL,9,'F55.34','N25.36','DF56.93','DA99.56','GS6','SD6.33','FS6.55','SA6.33','','','','','8SDF666','FD4666','FS6644','EIN','PSD56622FA',54663256,'NO',1000,33,300,20,'','','https://address/images/idnumber',2,5,2017,'HLS CARE','5TH AVENUE','RICHMOND KS 5654','PSD3655','',NULL,NULL,'UNITED HEALTH GROUP','BONNER SPRINGS','KS 66012','PFSD566','FS544646');


INSERT INTO `cms1500_1`(`ClaimID`, `ia_PayerName`, `ib_PayerAddress1`, `ic_PayerAddress2`, `id_Payer_city_state_zipcode`, `1_PAYER_TYPE`, `1a_Insured_Id_number`, `2a_LastName`, `2b_Suffix`, `2c_FirstName`, `2d_MiddleName`, `3a_MM`, `3b_DD`, `3c_YYYY`, `3d_Gender`, `4a_LastName`, `4b_Suffix`, `4c_FirstName`, `4d_MiddleName`, `5a_Street_Address`, `5b_City`, `5c_State`, `5d_Zipcode`, `5e_Telephone_areacode`, `5f_Telephone_phone number`, `6_Patient_Relationship_to_Insured`, `7a_Street_Address`, `7b_City`, `7c_State`, `7d_Zip code`, `7e_Telephone_areacode`, `7f_Telephone_phonenumber`, `8_Reserved_for_NUCC_Use`, `9-a_LastName`, `9-b_Suffix`, `9-c_FirstName`, `9-d_MiddleName`, `9a_other_policies_number`, `9b_Reserved_for_NUCC_Use`, `9c_Reserved_for_NUCC_Use`, `9d_InsuranceplanName`, `10a_employment`, `10b_Auto_Accident`, `10b-a_Auto_Accident_Place`, `10c_Other_Accident`, `10d_Claim_codes`, `11_InsuredsPolicyNumber`, `11a-a_MM`, `11a-b_DD`, `11a-c_YYYY`, `11a-d_Gender`, `11b-a_qualifier`, `11b-b_ClaimID`, `11c_InsurancePlanName`, `11d_Another_Health_Benefit_Plan`, `12-a_Signature_URL`, `12-b-a_MM`, `12-b-b_DD`, `12-b-c_YYYY`, `13_InsuredsAuthorizedSignature_URL`, `14-a_MM`, `14-b_DD`, `14-c_YYYY`, `14-d_qualifier`, `15-a_MM`, `15-b_DD`, `15-c_YYYY`, `15-d_qualifier`, `16-a_MM`, `16-b_DD`, `16-c_YYYY`, `16-a-a_MM`, `16-a-b_DD`, `16-a-c_YYYY`, `17_qualifier`, `17-a_Name`, `17a-a_Qualifier`, `17a-b_ID number`, `17b_ID number`, `18-a_MM`, `18-b_DD`, `18-c_YYYY`, `18-a-a_MM`, `18-a-b_DD`, `18-a-c_YYYY`, `19_Additional_Claim_Information`, `20_YES OR NO`, `20-a_Charges_dollars`, `20-b_charges_cents`, `21_ICD_Indicator`, `21A_Nature_of_Illnes`, `21B_Nature_of_Illnes`, `21C_Nature_of_Illnes`, `21D_Nature_of_Illnes`, `21E_Nature_of_Illnes`, `21F_Nature_of_Illnes`, `21G_Nature_of_Illnes`, `21H_Nature_of_Illnes`, `21I_Nature_of_Illnes`, `21J_Nature_of_Illnes`, `21K_Nature_of_Illnes`, `21L_Nature_of_Illnes`, `22-a_ReSubmissionCode_qualifier`, `22-b_original_ref_No`, `23_PriorAuthorizationNumber`, `25-a_type`, `25-b_ID_Number`, `26_Patient_Acc_Number`, `27_Accept_Assignment`, `28-a_dollars`, `28-b_cents`, `29-a_dollars`, `29-b_cents`, `30-a_code`, `30-b_qualifier`, `31-a_Signature`, `31-b-a_MM`, `31-b-b_DD`, `31-b-c_YYYY`, `32-a_ProviderName`, `32-b_ProviderAddress`, `32-c_City_State_Zipcode`, `32a_NationalProvider_IdentifierNumber`, `32b_PayerAssignedIdentifier_of_BillingProvider`, `33-a_AreaCode`, `33-b_PhoneNumber`, `33-c_BillingProvider_Name`, `33-d_BillingProvider_Address`, `33-e_Billingprovider_city_state_zipcode`, `33a_NationalProvider_IdentifierNumber`, `33b_PayerAssignedIdentifier_of_BillingProvider`) VALUES ('FA345671222M87110', 'Aetna Insurance','151 Farmington Avenue','Hartford, CT06156','USA','Medicare','PSG1234567','Neymar,','Jr,','Santos,','',12,22,1996,'Male','da Silva,','Jr,','Bruno,','','Rio de Jenero','California','CA','58978',543,4534556,'Spouse','Rio de Jenero','California','CA','58978',543,4534556,'','Neymar,','Jr,','Santos,','','GUH63483904','','','Obama Care','Yes','Yes','CA','Yes','PSG345893453','HJD45769903490456',12,23,1995,'Male','BV','POPRTY546980','Obama Care','Yes','No Signature on File',NULL,NULL,NULL,'No Signature on File',1,23,2017,431,7,29,2017,454,12,23,2018,10,23,2009,'DN','Aetna Radiology','OB','ASF45680','RTY3463464',12,23,2018,10,23,2009,'LU CT 456346','Yes',435,78,9,'A46.945','RTY.565','QWE.235','ERT.345','ERT.967','','','','','','','','76708606787','NBMI468456546','FGBNLER8430560346','SSN','NBSK4949409',456457457,'Yes',900,60,490,60,'','','https://address/physiciansignature/idnumber1',10,4,2010,'ATENA UNIVERSAL HOSPITALS','NEW AVENUE','california,CA,64656','16986654','0B566565',351,555-2678,'Aetna Insurance','151 Farmington Avenue','Hartford, CT06156','kd25664465','0B265952');
INSERT INTO `cms1500_1`(`ClaimID`, `ia_PayerName`, `ib_PayerAddress1`, `ic_PayerAddress2`, `id_Payer_city_state_zipcode`, `1_PAYER_TYPE`, `1a_Insured_Id_number`, `2a_LastName`, `2b_Suffix`, `2c_FirstName`, `2d_MiddleName`, `3a_MM`, `3b_DD`, `3c_YYYY`, `3d_Gender`, `4a_LastName`, `4b_Suffix`, `4c_FirstName`, `4d_MiddleName`, `5a_Street_Address`, `5b_City`, `5c_State`, `5d_Zipcode`, `5e_Telephone_areacode`, `5f_Telephone_phone number`, `6_Patient_Relationship_to_Insured`, `7a_Street_Address`, `7b_City`, `7c_State`, `7d_Zip code`, `7e_Telephone_areacode`, `7f_Telephone_phonenumber`, `8_Reserved_for_NUCC_Use`, `9-a_LastName`, `9-b_Suffix`, `9-c_FirstName`, `9-d_MiddleName`, `9a_other_policies_number`, `9b_Reserved_for_NUCC_Use`, `9c_Reserved_for_NUCC_Use`, `9d_InsuranceplanName`, `10a_employment`, `10b_Auto_Accident`, `10b-a_Auto_Accident_Place`, `10c_Other_Accident`, `10d_Claim_codes`, `11_InsuredsPolicyNumber`, `11a-a_MM`, `11a-b_DD`, `11a-c_YYYY`, `11a-d_Gender`, `11b-a_qualifier`, `11b-b_ClaimID`, `11c_InsurancePlanName`, `11d_Another_Health_Benefit_Plan`, `12-a_Signature_URL`, `12-b-a_MM`, `12-b-b_DD`, `12-b-c_YYYY`, `13_InsuredsAuthorizedSignature_URL`, `14-a_MM`, `14-b_DD`, `14-c_YYYY`, `14-d_qualifier`, `15-a_MM`, `15-b_DD`, `15-c_YYYY`, `15-d_qualifier`, `16-a_MM`, `16-b_DD`, `16-c_YYYY`, `16-a-a_MM`, `16-a-b_DD`, `16-a-c_YYYY`, `17_qualifier`, `17-a_Name`, `17a-a_Qualifier`, `17a-b_ID number`, `17b_ID number`, `18-a_MM`, `18-b_DD`, `18-c_YYYY`, `18-a-a_MM`, `18-a-b_DD`, `18-a-c_YYYY`, `19_Additional_Claim_Information`, `20_YES OR NO`, `20-a_Charges_dollars`, `20-b_charges_cents`, `21_ICD_Indicator`, `21A_Nature_of_Illnes`, `21B_Nature_of_Illnes`, `21C_Nature_of_Illnes`, `21D_Nature_of_Illnes`, `21E_Nature_of_Illnes`, `21F_Nature_of_Illnes`, `21G_Nature_of_Illnes`, `21H_Nature_of_Illnes`, `21I_Nature_of_Illnes`, `21J_Nature_of_Illnes`, `21K_Nature_of_Illnes`, `21L_Nature_of_Illnes`, `22-a_ReSubmissionCode_qualifier`, `22-b_original_ref_No`, `23_PriorAuthorizationNumber`, `25-a_type`, `25-b_ID_Number`, `26_Patient_Acc_Number`, `27_Accept_Assignment`, `28-a_dollars`, `28-b_cents`, `29-a_dollars`, `29-b_cents`, `30-a_code`, `30-b_qualifier`, `31-a_Signature`, `31-b-a_MM`, `31-b-b_DD`, `31-b-c_YYYY`, `32-a_ProviderName`, `32-b_ProviderAddress`, `32-c_City_State_Zipcode`, `32a_NationalProvider_IdentifierNumber`, `32b_PayerAssignedIdentifier_of_BillingProvider`, `33-a_AreaCode`, `33-b_PhoneNumber`, `33-c_BillingProvider_Name`, `33-d_BillingProvider_Address`, `33-e_Billingprovider_city_state_zipcode`, `33a_NationalProvider_IdentifierNumber`, `33b_PayerAssignedIdentifier_of_BillingProvider`) VALUES ('NZ670911017M60694', 'United Health Group','Bonner Springs','KS 66012','USA','Medicaid','FCB9867091','Messi,','','Andres,','Lionel,',10,17,1985,'Male','Marquinhos,','','Mike,','Robert,','Alpha Street','Texas','TX','89886',976,2423564,'Child','Alpha Street','Texas','TX','89886',976,2423564,'','','','','','','','','','No','Yes','TX','No','FCB456834787','IDF34634523435',6,19,1982,'Male','NM','LDFMG456456','Trump Care','No','No Signature on File',NULL,NULL,NULL,'https://address/images/idnumber544',5,18,2016,484,8,31,2015,304,NULL,NULL,NULL,NULL,NULL,NULL,'DQ','United Physiotherapy','GU','QWE345634','FHR456343',NULL,NULL,NULL,NULL,NULL,NULL,'1G 09084565','No',NULL,NULL,0,'ERT.934','RTO.435','MER.367','QCV.644','','','','','','','','','82354672376','MNPTMN4634634','FNLKMRPT94845567945','EIN','DDLNB9856909',36745673,'Yes',457,98,300,98,'','','https://address/physiciansignature/idnumber2',11,24,2011,'OMEGA HOSPITALS','BRAD STREET','KANSAS, KS 66012','6926234','G2J656545',961,321-568899,'United Health Group','Bonner Springs','KS 66012','HS446564','G2465222');


INSERT INTO `cms1500_1`(`ClaimID`, `ia_PayerName`, `ib_PayerAddress1`, `ic_PayerAddress2`, `id_Payer_city_state_zipcode`, `1_PAYER_TYPE`, `1a_Insured_Id_number`, `2a_LastName`, `2b_Suffix`, `2c_FirstName`, `2d_MiddleName`, `3a_MM`, `3b_DD`, `3c_YYYY`, `3d_Gender`, `4a_LastName`, `4b_Suffix`, `4c_FirstName`, `4d_MiddleName`, `5a_Street_Address`, `5b_City`, `5c_State`, `5d_Zipcode`, `5e_Telephone_areacode`, `5f_Telephone_phone number`, `6_Patient_Relationship_to_Insured`, `7a_Street_Address`, `7b_City`, `7c_State`, `7d_Zip code`, `7e_Telephone_areacode`, `7f_Telephone_phonenumber`, `8_Reserved_for_NUCC_Use`, `9-a_LastName`, `9-b_Suffix`, `9-c_FirstName`, `9-d_MiddleName`, `9a_other_policies_number`, `9b_Reserved_for_NUCC_Use`, `9c_Reserved_for_NUCC_Use`, `9d_InsuranceplanName`, `10a_employment`, `10b_Auto_Accident`, `10b-a_Auto_Accident_Place`, `10c_Other_Accident`, `10d_Claim_codes`, `11_InsuredsPolicyNumber`, `11a-a_MM`, `11a-b_DD`, `11a-c_YYYY`, `11a-d_Gender`, `11b-a_qualifier`, `11b-b_ClaimID`, `11c_InsurancePlanName`, `11d_Another_Health_Benefit_Plan`, `12-a_Signature_URL`, `12-b-a_MM`, `12-b-b_DD`, `12-b-c_YYYY`, `13_InsuredsAuthorizedSignature_URL`, `14-a_MM`, `14-b_DD`, `14-c_YYYY`, `14-d_qualifier`, `15-a_MM`, `15-b_DD`, `15-c_YYYY`, `15-d_qualifier`, `16-a_MM`, `16-b_DD`, `16-c_YYYY`, `16-a-a_MM`, `16-a-b_DD`, `16-a-c_YYYY`, `17_qualifier`, `17-a_Name`, `17a-a_Qualifier`, `17a-b_ID number`, `17b_ID number`, `18-a_MM`, `18-b_DD`, `18-c_YYYY`, `18-a-a_MM`, `18-a-b_DD`, `18-a-c_YYYY`, `19_Additional_Claim_Information`, `20_YES OR NO`, `20-a_Charges_dollars`, `20-b_charges_cents`, `21_ICD_Indicator`, `21A_Nature_of_Illnes`, `21B_Nature_of_Illnes`, `21C_Nature_of_Illnes`, `21D_Nature_of_Illnes`, `21E_Nature_of_Illnes`, `21F_Nature_of_Illnes`, `21G_Nature_of_Illnes`, `21H_Nature_of_Illnes`, `21I_Nature_of_Illnes`, `21J_Nature_of_Illnes`, `21K_Nature_of_Illnes`, `21L_Nature_of_Illnes`, `22-a_ReSubmissionCode_qualifier`, `22-b_original_ref_No`, `23_PriorAuthorizationNumber`, `25-a_type`, `25-b_ID_Number`, `26_Patient_Acc_Number`, `27_Accept_Assignment`, `28-a_dollars`, `28-b_cents`, `29-a_dollars`, `29-b_cents`, `30-a_code`, `30-b_qualifier`, `31-a_Signature`, `31-b-a_MM`, `31-b-b_DD`, `31-b-c_YYYY`, `32-a_ProviderName`, `32-b_ProviderAddress`, `32-c_City_State_Zipcode`, `32a_NationalProvider_IdentifierNumber`, `32b_PayerAssignedIdentifier_of_BillingProvider`, `33-a_AreaCode`, `33-b_PhoneNumber`, `33-c_BillingProvider_Name`, `33-d_BillingProvider_Address`, `33-e_Billingprovider_city_state_zipcode`, `33a_NationalProvider_IdentifierNumber`, `33b_PayerAssignedIdentifier_of_BillingProvider`) VALUES ('WO580340608M17038', 'Liberty Mutual Group','175 Berkeley Street','Boston, MA 02116','USA','GHP','PAR3458034','Berge,','','Jake,','Sanders,',6,8,1987,'Female','Kane,','','Harry,','Robert,','Gamma Street','Boston','MC','86536',235,1234626,'Others','Belof street','Ellinois','EL','23464',657,7645634,'','','','','','','','','','No','Yes','EL','Yes','MCF2345634959','NRTYE34543534534',3,17,1998,'Female','OP','DFBNERT678345','Lincoln Care','No','https://address/images/idnumber',12,25,2018,'https://address/images/idnumber534',6,6,2009,431,6,19,2014,444,10,30,2008,2,18,2016,'DQ','Liberty Opthamalogy','G2','DGERT2352353','FTYG56345',10,30,2008,2,18,2016,'1G DFG125 FG65','Yes',456,65,0,'CVB.456','NTY.456','PKL.546','PLK.346','','','','','','','','','89056747783','FNKGHL34683403','NSDONH379495693','SSN','NLKF794505',457345734,'Yes',567,45,550,45,'','','https://address/physiciansignature/idnumber4',5,16,2015,'MITHALI HOSPITALS','FORD STREET','BOSTON,MA,02116','16484546','0B4558666',331,256-65482,'Liberty Mutual Group','175 Berkeley Street','Boston, MA 02116','YU6464325','0B15326223');

INSERT INTO `cms1500_1`(`ClaimID`, `ia_PayerName`, `ib_PayerAddress1`, `ic_PayerAddress2`, `id_Payer_city_state_zipcode`, `1_PAYER_TYPE`, `1a_Insured_Id_number`, `2a_LastName`, `2b_Suffix`, `2c_FirstName`, `2d_MiddleName`, `3a_MM`, `3b_DD`, `3c_YYYY`, `3d_Gender`, `4a_LastName`, `4b_Suffix`, `4c_FirstName`, `4d_MiddleName`, `5a_Street_Address`, `5b_City`, `5c_State`, `5d_Zipcode`, `5e_Telephone_areacode`, `5f_Telephone_phone number`, `6_Patient_Relationship_to_Insured`, `7a_Street_Address`, `7b_City`, `7c_State`, `7d_Zip code`, `7e_Telephone_areacode`, `7f_Telephone_phonenumber`, `8_Reserved_for_NUCC_Use`, `9-a_LastName`, `9-b_Suffix`, `9-c_FirstName`, `9-d_MiddleName`, `9a_other_policies_number`, `9b_Reserved_for_NUCC_Use`, `9c_Reserved_for_NUCC_Use`, `9d_InsuranceplanName`, `10a_employment`, `10b_Auto_Accident`, `10b-a_Auto_Accident_Place`, `10c_Other_Accident`, `10d_Claim_codes`, `11_InsuredsPolicyNumber`, `11a-a_MM`, `11a-b_DD`, `11a-c_YYYY`, `11a-d_Gender`, `11b-a_qualifier`, `11b-b_ClaimID`, `11c_InsurancePlanName`, `11d_Another_Health_Benefit_Plan`, `12-a_Signature_URL`, `12-b-a_MM`, `12-b-b_DD`, `12-b-c_YYYY`, `13_InsuredsAuthorizedSignature_URL`, `14-a_MM`, `14-b_DD`, `14-c_YYYY`, `14-d_qualifier`, `15-a_MM`, `15-b_DD`, `15-c_YYYY`, `15-d_qualifier`, `16-a_MM`, `16-b_DD`, `16-c_YYYY`, `16-a-a_MM`, `16-a-b_DD`, `16-a-c_YYYY`, `17_qualifier`, `17-a_Name`, `17a-a_Qualifier`, `17a-b_ID number`, `17b_ID number`, `18-a_MM`, `18-b_DD`, `18-c_YYYY`, `18-a-a_MM`, `18-a-b_DD`, `18-a-c_YYYY`, `19_Additional_Claim_Information`, `20_YES OR NO`, `20-a_Charges_dollars`, `20-b_charges_cents`, `21_ICD_Indicator`, `21A_Nature_of_Illnes`, `21B_Nature_of_Illnes`, `21C_Nature_of_Illnes`, `21D_Nature_of_Illnes`, `21E_Nature_of_Illnes`, `21F_Nature_of_Illnes`, `21G_Nature_of_Illnes`, `21H_Nature_of_Illnes`, `21I_Nature_of_Illnes`, `21J_Nature_of_Illnes`, `21K_Nature_of_Illnes`, `21L_Nature_of_Illnes`, `22-a_ReSubmissionCode_qualifier`, `22-b_original_ref_No`, `23_PriorAuthorizationNumber`, `25-a_type`, `25-b_ID_Number`, `26_Patient_Acc_Number`, `27_Accept_Assignment`, `28-a_dollars`, `28-b_cents`, `29-a_dollars`, `29-b_cents`, `30-a_code`, `30-b_qualifier`, `31-a_Signature`, `31-b-a_MM`, `31-b-b_DD`, `31-b-c_YYYY`, `32-a_ProviderName`, `32-b_ProviderAddress`, `32-c_City_State_Zipcode`, `32a_NationalProvider_IdentifierNumber`, `32b_PayerAssignedIdentifier_of_BillingProvider`, `33-a_AreaCode`, `33-b_PhoneNumber`, `33-c_BillingProvider_Name`, `33-d_BillingProvider_Address`, `33-e_Billingprovider_city_state_zipcode`, `33a_NationalProvider_IdentifierNumber`, `33b_PayerAssignedIdentifier_of_BillingProvider`) VALUES ('CQ893400910M56038', 'HCSC Group','1001 Elookout','Tx 75082','USA','FBL','MCF3489340','de Bruyne,','','Peter','Kevin,',9,10,1993,'Male','Silva,','','Adrino,','Thiago,','Beta Street','Seattle','SA','53245',931,1235426,'Others','Harrison Aveue','Florida','FD','85656',534,8678456,'','','','','','','','','','Yes','No','','Yes','PAR3478583843','FGNBV3456345234',5,10,1987,'Male','LK','RTNBFGJ657860','Bush Care','No','https://address/images/idnumber544',11,26,2018,'No Signature on File',7,9,2015,484,9,12,2017,455,11,12,2011,8,28,2007,'DK','HCSC Cloud care','1G','VBNF4564574','YRT6345',11,12,2011,8,28,2007,'G2 OX 4534452','No',NULL,NULL,9,'EIT.567','BGF.643','MMH.457','MNH.456','','','','','','','','','75423637473','DFGHK34693456','NBDOBN3467458603479','SSN','BLDHN36793',35683464,'No',456,87,400,87,'','','https://address/physiciansignature/idnumber3',12,10,2014,'JUNIPER HOSPITALS','MORING STRAIGHT','TEXAS,TX,75082','563593228','LU5458936D65',271,541-389761,'HCSC Group','1001 Elookout','Tx 75082','OF5164533','ZZ61321358');

CREATE TABLE cms1500_2( `ID` int(11) NOT NULL AUTO_INCREMENT, `ClaimID` varchar(18),`24a-a_MM` int(2),`24a-b_DD` int(2),`24a-c_YYYY` int(2),`24a-d_MM` int(2),`24a-e_DD` int(2),`24a-f_YYYY` int(2),`24b_Place of Service` int(2),`24c_EMG` varchar(1),`24d-a_CPT/HCPCS` int(6),`24d-b_Modifier` int(8),`24E_Diagnostic Pointer` varchar(4),`24F_charges` int(6),`24F(F)_charges` int(2),`24G_Days or Units` float(3),`24H-a_EPSDT code` varchar(2),`24H-b_Yes or no` varchar(1),`24I_Qual` varchar(2),`24J-a_Rendering provider ID` varchar(17),`24j-b_Rendering provider ID` varchar(10), 
  FOREIGN KEY fk_claimId(`ClaimID`)
   REFERENCES cms1500_1(`ClaimID`)
   ON DELETE cascade
ON UPDATE cascade,
PRIMARY KEY (`ID`)) DEFAULT CHARSET=utf8;

INSERT INTO `cms1500_2`(`ClaimID`, `24a-a_MM`, `24a-b_DD`, `24a-c_YYYY`, `24a-d_MM`, `24a-e_DD`, `24a-f_YYYY`, `24b_Place of Service`, `24c_EMG`, `24d-a_CPT/HCPCS`, `24d-b_Modifier`, `24E_Diagnostic Pointer`, `24F_charges`, `24F(F)_charges`, `24G_Days or Units`, `24H-a_EPSDT code`, `24H-b_Yes or no`, `24I_Qual`, `24J-a_Rendering provider ID`, `24j-b_Rendering provider ID`) VALUES ('OWSG4560103M32578',2,23,2018,11,24,2018,13,'Y',345347,54645675,'ABC',70,89,3.78,'AV','','RE','ERYE4363464','FH434523');

INSERT INTO `cms1500_2`(`ClaimID`, `24a-a_MM`, `24a-b_DD`, `24a-c_YYYY`, `24a-d_MM`, `24a-e_DD`, `24a-f_YYYY`, `24b_Place of Service`, `24c_EMG`, `24d-a_CPT/HCPCS`, `24d-b_Modifier`, `24E_Diagnostic Pointer`, `24F_charges`, `24F(F)_charges`, `24G_Days or Units`, `24H-a_EPSDT code`, `24H-b_Yes or no`, `24I_Qual`, `24J-a_Rendering provider ID`, `24j-b_Rendering provider ID`) VALUES ('OWSG4560103M32578',1,19,2018,9,30,2018,76,'N',456465,455457,'DE',67,67,1.75,'','Y','ER','DNG5545643','ND564564');

INSERT INTO `cms1500_2`(`ClaimID`, `24a-a_MM`, `24a-b_DD`, `24a-c_YYYY`, `24a-d_MM`, `24a-e_DD`, `24a-f_YYYY`, `24b_Place of Service`, `24c_EMG`, `24d-a_CPT/HCPCS`, `24d-b_Modifier`, `24E_Diagnostic Pointer`, `24F_charges`, `24F(F)_charges`, `24G_Days or Units`, `24H-a_EPSDT code`, `24H-b_Yes or no`, `24I_Qual`, `24J-a_Rendering provider ID`, `24j-b_Rendering provider ID`) VALUES ('FA345671222M87110',4,1,2017,9,30,2017,43,'N',456657,45645234,'AB',90,99,59,'S2','','HJ','RET36456734','VBNF45363');

INSERT INTO `cms1500_2`(`ClaimID`, `24a-a_MM`, `24a-b_DD`, `24a-c_YYYY`, `24a-d_MM`, `24a-e_DD`, `24a-f_YYYY`, `24b_Place of Service`, `24c_EMG`, `24d-a_CPT/HCPCS`, `24d-b_Modifier`, `24E_Diagnostic Pointer`, `24F_charges`, `24F(F)_charges`, `24G_Days or Units`, `24H-a_EPSDT code`, `24H-b_Yes or no`, `24I_Qual`, `24J-a_Rendering provider ID`, `24j-b_Rendering provider ID`) VALUES ('FA345671222M87110',5,10,2017,10,21,2017,54,'Y',967856,87668769,'CDE',45,99,65,'ST','','RY','JGJGY546745','TYUG8658');

INSERT INTO `cms1500_2`(`ClaimID`, `24a-a_MM`, `24a-b_DD`, `24a-c_YYYY`, `24a-d_MM`, `24a-e_DD`, `24a-f_YYYY`, `24b_Place of Service`, `24c_EMG`, `24d-a_CPT/HCPCS`, `24d-b_Modifier`, `24E_Diagnostic Pointer`, `24F_charges`, `24F(F)_charges`, `24G_Days or Units`, `24H-a_EPSDT code`, `24H-b_Yes or no`, `24I_Qual`, `24J-a_Rendering provider ID`, `24j-b_Rendering provider ID`) VALUES ('NZ670911017M60694',6,19,2016,10,31,2016,56,'N',345233,23409876,'A',3455,56,20,'NU','','TY','ERBD3464','NVJFTY674');

INSERT INTO `cms1500_2`(`ClaimID`, `24a-a_MM`, `24a-b_DD`, `24a-c_YYYY`, `24a-d_MM`, `24a-e_DD`, `24a-f_YYYY`, `24b_Place of Service`, `24c_EMG`, `24d-a_CPT/HCPCS`, `24d-b_Modifier`, `24E_Diagnostic Pointer`, `24F_charges`, `24F(F)_charges`, `24G_Days or Units`, `24H-a_EPSDT code`, `24H-b_Yes or no`, `24I_Qual`, `24J-a_Rendering provider ID`, `24j-b_Rendering provider ID`) VALUES ('NZ670911017M60694',9,15,2016,11,30,2016,87,'Y',456342,80904904,'BCDE',4576,67,40,'','Y','MJ','XAS634534','VNTT36564');

INSERT INTO `cms1500_2`(`ClaimID`, `24a-a_MM`, `24a-b_DD`, `24a-c_YYYY`, `24a-d_MM`, `24a-e_DD`, `24a-f_YYYY`, `24b_Place of Service`, `24c_EMG`, `24d-a_CPT/HCPCS`, `24d-b_Modifier`, `24E_Diagnostic Pointer`, `24F_charges`, `24F(F)_charges`, `24G_Days or Units`, `24H-a_EPSDT code`, `24H-b_Yes or no`, `24I_Qual`, `24J-a_Rendering provider ID`, `24j-b_Rendering provider ID`) VALUES ('WO580340608M17038',1,20,2015,12,29,2015,98,'Y',568987,45682348,'ABC',9878,98,50,'AV','','WS','VBMV4564','NTY45647');

INSERT INTO `cms1500_2`(`ClaimID`, `24a-a_MM`, `24a-b_DD`, `24a-c_YYYY`, `24a-d_MM`, `24a-e_DD`, `24a-f_YYYY`, `24b_Place of Service`, `24c_EMG`, `24d-a_CPT/HCPCS`, `24d-b_Modifier`, `24E_Diagnostic Pointer`, `24F_charges`, `24F(F)_charges`, `24G_Days or Units`, `24H-a_EPSDT code`, `24H-b_Yes or no`, `24I_Qual`, `24J-a_Rendering provider ID`, `24j-b_Rendering provider ID`) VALUES ('WO580340608M17038',9,9,2015,4,27,2015,12,'N',976756,45674587,'DE',1008,67,60,'','Y','PO','NFGCVB456','VBNR5674');

INSERT INTO `cms1500_2`(`ClaimID`, `24a-a_MM`, `24a-b_DD`, `24a-c_YYYY`, `24a-d_MM`, `24a-e_DD`, `24a-f_YYYY`, `24b_Place of Service`, `24c_EMG`, `24d-a_CPT/HCPCS`, `24d-b_Modifier`, `24E_Diagnostic Pointer`, `24F_charges`, `24F(F)_charges`, `24G_Days or Units`, `24H-a_EPSDT code`, `24H-b_Yes or no`, `24I_Qual`, `24J-a_Rendering provider ID`, `24j-b_Rendering provider ID`) VALUES ('CQ893400910M56038',10,18,2014,5,23,2014,65,'Y',345645,12453465,'ACD',7867,98,28,'S2','','XD','CVBR64645','VNBFTY45');

INSERT INTO `cms1500_2`(`ClaimID`, `24a-a_MM`, `24a-b_DD`, `24a-c_YYYY`, `24a-d_MM`, `24a-e_DD`, `24a-f_YYYY`, `24b_Place of Service`, `24c_EMG`, `24d-a_CPT/HCPCS`, `24d-b_Modifier`, `24E_Diagnostic Pointer`, `24F_charges`, `24F(F)_charges`, `24G_Days or Units`, `24H-a_EPSDT code`, `24H-b_Yes or no`, `24I_Qual`, `24J-a_Rendering provider ID`, `24j-b_Rendering provider ID`) VALUES ('CQ893400910M56038',11,6,2014,9,22,2014,98,'N',444484,45645686,'BE',4567,90,32,'','Y','YT','VBN45654','NBRTY6456');



