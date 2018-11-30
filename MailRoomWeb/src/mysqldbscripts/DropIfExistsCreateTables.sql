


  `ClaimID` varchar(18) NOT NULL,
  `ia_PayerName` varchar(29) DEFAULT NULL,
  `ib_PayerAddress1` varchar(29) DEFAULT NULL,
  `ic_PayerAddress2` varchar(29) DEFAULT NULL,
  `id_Payer_city_state_zipcode` varchar(29) DEFAULT NULL,
  `1_PAYER_TYPE` varchar(8) DEFAULT NULL,
  `1a_Insured_Id_number` varchar(29) DEFAULT NULL,
  `2a_LastName` varchar(14) DEFAULT NULL,
  `2b_Suffix` varchar(14) DEFAULT NULL,
  `2c_FirstName` varchar(14) DEFAULT NULL,
  `2d_MiddleName` varchar(14) DEFAULT NULL,
  `3a_MM` int(2) DEFAULT NULL,
  `3b_DD` int(2) DEFAULT NULL,
  `3c_YYYY` int(4) DEFAULT NULL,
  `3d_Gender` varchar(6) DEFAULT NULL,
  `4a_LastName` varchar(14) DEFAULT NULL,
  `4b_Suffix` varchar(14) DEFAULT NULL,
  `4c_FirstName` varchar(14) DEFAULT NULL,
  `4d_MiddleName` varchar(14) DEFAULT NULL,
  `5a_Street_Address` varchar(28) DEFAULT NULL,
  `5b_City` varchar(24) DEFAULT NULL,
  `5c_State` varchar(3) DEFAULT NULL,
  `5d_Zipcode` varchar(7) DEFAULT NULL,
  `5e_Telephone_areacode` int(3) DEFAULT NULL,
  `5f_Telephone_phone number` int(10) DEFAULT NULL,
  `6_Patient_Relationship_to_Insured` varchar(6) DEFAULT NULL,
  `7a_Street_Address` varchar(28) DEFAULT NULL,
  `7b_City` varchar(24) DEFAULT NULL,
  `7c_State` varchar(3) DEFAULT NULL,
  `7d_Zip code` varchar(7) DEFAULT NULL,
  `7e_Telephone_areacode` int(3) DEFAULT NULL,
  `7f_Telephone_phonenumber` int(10) DEFAULT NULL,
  `8_Reserved_for_NUCC_Use` varchar(50) DEFAULT NULL,
  `9-a_LastName` varchar(14) DEFAULT NULL,
  `9-b_Suffix` varchar(14) DEFAULT NULL,
  `9-c_FirstName` varchar(14) DEFAULT NULL,
  `9-d_MiddleName` varchar(14) DEFAULT NULL,
  `9a_other_policies_number` varchar(28) DEFAULT NULL,
  `9b_Reserved_for_NUCC_Use` varchar(100) DEFAULT NULL,
  `9c_Reserved_for_NUCC_Use` varchar(100) DEFAULT NULL,
  `9d_InsuranceplanName` varchar(28) DEFAULT NULL,
  `10a_employment` varchar(3) DEFAULT NULL,
  `10b_Auto_Accident` varchar(3) DEFAULT NULL,
  `10b-a_Auto_Accident_Place` varchar(2) DEFAULT NULL,
  `10c_Other_Accident` varchar(3) DEFAULT NULL,
  `10d_Claim_codes` varchar(19) DEFAULT NULL,
  `11_InsuredsPolicyNumber` varchar(29) DEFAULT NULL,
  `11a-a_MM` int(2) DEFAULT NULL,
  `11a-b_DD` int(2) DEFAULT NULL,
  `11a-c_YYYY` int(4) DEFAULT NULL,
  `11a-d_Gender` varchar(6) DEFAULT NULL,
  `11b-a_qualifier` varchar(2) DEFAULT NULL,
  `11b-b_ClaimID` varchar(28) DEFAULT NULL,
  `11c_InsurancePlanName` varchar(29) DEFAULT NULL,
  `11d_Another_Health_Benefit_Plan` varchar(3) DEFAULT NULL,
  `12-a_Signature_URL` varchar(100) DEFAULT NULL,
  `12-b-a_MM` int(2) DEFAULT NULL,
  `12-b-b_DD` int(2) DEFAULT NULL,
  `12-b-c_YYYY` int(4) DEFAULT NULL,
  `13_InsuredsAuthorizedSignature_URL` varchar(100) DEFAULT NULL,
  `14-a_MM` int(2) DEFAULT NULL,
  `14-b_DD` int(2) DEFAULT NULL,
  `14-c_YYYY` int(4) DEFAULT NULL,
  `14-d_qualifier` int(3) DEFAULT NULL,
  `15-a_MM` int(2) DEFAULT NULL,
  `15-b_DD` int(2) DEFAULT NULL,
  `15-c_YYYY` int(4) DEFAULT NULL,
  `15-d_qualifier` int(3) DEFAULT NULL,
  `16-a_MM` int(2) DEFAULT NULL,
  `16-b_DD` int(2) DEFAULT NULL,
  `16-c_YYYY` int(4) DEFAULT NULL,
  `16-a-a_MM` int(2) DEFAULT NULL,
  `16-a-b_DD` int(2) DEFAULT NULL,
  `16-a-c_YYYY` int(4) DEFAULT NULL,
  `17_qualifier` varchar(2) DEFAULT NULL,
  `17-a_Name` varchar(24) DEFAULT NULL,
  `17a-a_Qualifier` varchar(2) DEFAULT NULL,
  `17a-b_ID number` varchar(17) DEFAULT NULL,
  `17b_ID number` varchar(10) DEFAULT NULL,
  `18-a_MM` int(2) DEFAULT NULL,
  `18-b_DD` int(2) DEFAULT NULL,
  `18-c_YYYY` int(4) DEFAULT NULL,
  `18-a-a_MM` int(2) DEFAULT NULL,
  `18-a-b_DD` int(2) DEFAULT NULL,
  `18-a-c_YYYY` int(4) DEFAULT NULL,
  `19_Additional_Claim_Information` varchar(71) DEFAULT NULL,
  `20_YES OR NO` varchar(3) DEFAULT NULL,
  `20-a_Charges_dollars` int(8) DEFAULT NULL,
  `20-b_charges_cents` int(2) DEFAULT NULL,
  `21_ICD_Indicator` int(1) DEFAULT NULL,
  `21A_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21B_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21C_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21D_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21E_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21F_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21G_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21H_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21I_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21J_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21K_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21L_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `22-a_ReSubmissionCode_qualifier` varchar(11) DEFAULT NULL,
  `22-b_original_ref_No` varchar(18) DEFAULT NULL,
  `23_PriorAuthorizationNumber` varchar(29) DEFAULT NULL,
  `25-a_type` varchar(3) DEFAULT NULL,
  `25-b_ID_Number` varchar(15) DEFAULT NULL,
  `26_Patient_Acc_Number` int(14) DEFAULT NULL,
  `27_Accept_Assignment` varchar(3) DEFAULT NULL,
  `28-a_dollars` int(6) DEFAULT NULL,
  `28-b_cents` int(2) DEFAULT NULL,
  `29-a_dollars` int(6) DEFAULT NULL,
  `29-b_cents` int(2) DEFAULT NULL,
  `30-a_code` varchar(3) DEFAULT NULL,
  `30-b_qualifier` varchar(100) DEFAULT NULL,
  `31-a_Signature` varchar(100) DEFAULT NULL,
  `31-b-a_MM` int(2) DEFAULT NULL,
  `31-b-b_DD` int(2) DEFAULT NULL,
  `31-b-c_YYYY` int(4) DEFAULT NULL,
  `32-a_ProviderName` varchar(29) DEFAULT NULL,
  `32-b_ProviderAddress` varchar(29) DEFAULT NULL,
  `32-c_City_State_Zipcode` varchar(29) DEFAULT NULL,
  `32a_NationalProvider_IdentifierNumber` varchar(10) DEFAULT NULL,
  `32b_PayerAssignedIdentifier_of_BillingProvider` varchar(14) DEFAULT NULL,
  `33-a_AreaCode` int(3) DEFAULT NULL,
  `33-b_PhoneNumber` int(10) DEFAULT NULL,
  `33-c_BillingProvider_Name` varchar(29) DEFAULT NULL,
  `33-d_BillingProvider_Address` varchar(29) DEFAULT NULL,
  `33-e_Billingprovider_city_state_zipcode` varchar(29) DEFAULT NULL,
  `33a_NationalProvider_IdentifierNumber` varchar(10) DEFAULT NULL,
  `33b_PayerAssignedIdentifier_of_BillingProvider` varchar(17) DEFAULT NULL,
  PRIMARY KEY (`ClaimID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
CREATE TABLE `stagingclaim_cms1500` (
  `ClaimID` varchar(18) NOT NULL,
  `ia_PayerName` varchar(29) DEFAULT NULL,
  `ib_PayerAddress1` varchar(29) DEFAULT NULL,
  `ic_PayerAddress2` varchar(29) DEFAULT NULL,
  `id_Payer_city_state_zipcode` varchar(29) DEFAULT NULL,
  `1_PAYER_TYPE` varchar(8) DEFAULT NULL,
  `1a_Insured_Id_number` varchar(29) DEFAULT NULL,
  `2a_LastName` varchar(14) DEFAULT NULL,
  `2b_Suffix` varchar(14) DEFAULT NULL,
  `2c_FirstName` varchar(14) DEFAULT NULL,
  `2d_MiddleName` varchar(14) DEFAULT NULL,
  `3a_MM` int(2) DEFAULT NULL,
  `3b_DD` int(2) DEFAULT NULL,
  `3c_YYYY` int(4) DEFAULT NULL,
  `3d_Gender` varchar(6) DEFAULT NULL,
  `4a_LastName` varchar(14) DEFAULT NULL,
  `4b_Suffix` varchar(14) DEFAULT NULL,
  `4c_FirstName` varchar(14) DEFAULT NULL,
  `4d_MiddleName` varchar(14) DEFAULT NULL,
  `5a_Street_Address` varchar(28) DEFAULT NULL,
  `5b_City` varchar(24) DEFAULT NULL,
  `5c_State` varchar(3) DEFAULT NULL,
  `5d_Zipcode` varchar(7) DEFAULT NULL,
  `5e_Telephone_areacode` int(3) DEFAULT NULL,
  `5f_Telephone_phone number` int(10) DEFAULT NULL,
  `6_Patient_Relationship_to_Insured` varchar(6) DEFAULT NULL,
  `7a_Street_Address` varchar(28) DEFAULT NULL,
  `7b_City` varchar(24) DEFAULT NULL,
  `7c_State` varchar(3) DEFAULT NULL,
  `7d_Zip code` varchar(7) DEFAULT NULL,
  `7e_Telephone_areacode` int(3) DEFAULT NULL,
  `7f_Telephone_phonenumber` int(10) DEFAULT NULL,
  `8_Reserved_for_NUCC_Use` varchar(50) DEFAULT NULL,
  `9-a_LastName` varchar(14) DEFAULT NULL,
  `9-b_Suffix` varchar(14) DEFAULT NULL,
  `9-c_FirstName` varchar(14) DEFAULT NULL,
  `9-d_MiddleName` varchar(14) DEFAULT NULL,
  `9a_other_policies_number` varchar(28) DEFAULT NULL,
  `9b_Reserved_for_NUCC_Use` varchar(100) DEFAULT NULL,
  `9c_Reserved_for_NUCC_Use` varchar(100) DEFAULT NULL,
  `9d_InsuranceplanName` varchar(28) DEFAULT NULL,
  `10a_employment` varchar(3) DEFAULT NULL,
  `10b_Auto_Accident` varchar(3) DEFAULT NULL,
  `10b-a_Auto_Accident_Place` varchar(2) DEFAULT NULL,
  `10c_Other_Accident` varchar(3) DEFAULT NULL,
  `10d_Claim_codes` varchar(19) DEFAULT NULL,
  `11_InsuredsPolicyNumber` varchar(29) DEFAULT NULL,
  `11a-a_MM` int(2) DEFAULT NULL,
  `11a-b_DD` int(2) DEFAULT NULL,
  `11a-c_YYYY` int(4) DEFAULT NULL,
  `11a-d_Gender` varchar(6) DEFAULT NULL,
  `11b-a_qualifier` varchar(2) DEFAULT NULL,
  `11b-b_ClaimID` varchar(28) DEFAULT NULL,
  `11c_InsurancePlanName` varchar(29) DEFAULT NULL,
  `11d_Another_Health_Benefit_Plan` varchar(3) DEFAULT NULL,
  `12-a_Signature_URL` varchar(100) DEFAULT NULL,
  `12-b-a_MM` int(2) DEFAULT NULL,
  `12-b-b_DD` int(2) DEFAULT NULL,
  `12-b-c_YYYY` int(4) DEFAULT NULL,
  `13_InsuredsAuthorizedSignature_URL` varchar(100) DEFAULT NULL,
  `14-a_MM` int(2) DEFAULT NULL,
  `14-b_DD` int(2) DEFAULT NULL,
  `14-c_YYYY` int(4) DEFAULT NULL,
  `14-d_qualifier` int(3) DEFAULT NULL,
  `15-a_MM` int(2) DEFAULT NULL,
  `15-b_DD` int(2) DEFAULT NULL,
  `15-c_YYYY` int(4) DEFAULT NULL,
  `15-d_qualifier` int(3) DEFAULT NULL,
  `16-a_MM` int(2) DEFAULT NULL,
  `16-b_DD` int(2) DEFAULT NULL,
  `16-c_YYYY` int(4) DEFAULT NULL,
  `16-a-a_MM` int(2) DEFAULT NULL,
  `16-a-b_DD` int(2) DEFAULT NULL,
  `16-a-c_YYYY` int(4) DEFAULT NULL,
  `17_qualifier` varchar(2) DEFAULT NULL,
  `17-a_Name` varchar(24) DEFAULT NULL,
  `17a-a_Qualifier` varchar(2) DEFAULT NULL,
  `17a-b_ID number` varchar(17) DEFAULT NULL,
  `17b_ID number` varchar(10) DEFAULT NULL,
  `18-a_MM` int(2) DEFAULT NULL,
  `18-b_DD` int(2) DEFAULT NULL,
  `18-c_YYYY` int(4) DEFAULT NULL,
  `18-a-a_MM` int(2) DEFAULT NULL,
  `18-a-b_DD` int(2) DEFAULT NULL,
  `18-a-c_YYYY` int(4) DEFAULT NULL,
  `19_Additional_Claim_Information` varchar(71) DEFAULT NULL,
  `20_YES OR NO` varchar(3) DEFAULT NULL,
  `20-a_Charges_dollars` int(8) DEFAULT NULL,
  `20-b_charges_cents` int(2) DEFAULT NULL,
  `21_ICD_Indicator` int(1) DEFAULT NULL,
  `21A_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21B_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21C_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21D_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21E_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21F_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21G_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21H_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21I_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21J_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21K_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `21L_Nature_of_Illnes` varchar(7) DEFAULT NULL,
  `22-a_ReSubmissionCode_qualifier` varchar(11) DEFAULT NULL,
  `22-b_original_ref_No` varchar(18) DEFAULT NULL,
  `23_PriorAuthorizationNumber` varchar(29) DEFAULT NULL,
  `25-a_type` varchar(3) DEFAULT NULL,
  `25-b_ID_Number` varchar(15) DEFAULT NULL,
  `26_Patient_Acc_Number` int(14) DEFAULT NULL,
  `27_Accept_Assignment` varchar(3) DEFAULT NULL,
  `28-a_dollars` int(6) DEFAULT NULL,
  `28-b_cents` int(2) DEFAULT NULL,
  `29-a_dollars` int(6) DEFAULT NULL,
  `29-b_cents` int(2) DEFAULT NULL,
  `30-a_code` varchar(3) DEFAULT NULL,
  `30-b_qualifier` varchar(100) DEFAULT NULL,
  `31-a_Signature` varchar(100) DEFAULT NULL,
  `31-b-a_MM` int(2) DEFAULT NULL,
  `31-b-b_DD` int(2) DEFAULT NULL,
  `31-b-c_YYYY` int(4) DEFAULT NULL,
  `32-a_ProviderName` varchar(29) DEFAULT NULL,
  `32-b_ProviderAddress` varchar(29) DEFAULT NULL,
  `32-c_City_State_Zipcode` varchar(29) DEFAULT NULL,
  `32a_NationalProvider_IdentifierNumber` varchar(10) DEFAULT NULL,
  `32b_PayerAssignedIdentifier_of_BillingProvider` varchar(14) DEFAULT NULL,
  `33-a_AreaCode` int(3) DEFAULT NULL,
  `33-b_PhoneNumber` int(10) DEFAULT NULL,
  `33-c_BillingProvider_Name` varchar(29) DEFAULT NULL,
  `33-d_BillingProvider_Address` varchar(29) DEFAULT NULL,
  `33-e_Billingprovider_city_state_zipcode` varchar(29) DEFAULT NULL,
  `33a_NationalProvider_IdentifierNumber` varchar(10) DEFAULT NULL,
  `33b_PayerAssignedIdentifier_of_BillingProvider` varchar(17) DEFAULT NULL,
  
  `ReviewerId` varchar(50),
  `ReviewStatus` int(1) DEFAULT '0',
  `ConfidenceLevel` int(5) DEFAULT '0',
  `ParserErrorCsv` varchar(2000),
  `sourceId` varchar(10),
  `CreatedDate` datetime,
  `ModifiedDate` datetime,
  
  PRIMARY KEY (`ClaimID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `stagingclaim_cms1500_detail` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `24-X_Claim Id` varchar(18) DEFAULT NULL,
  `24a-a_MM` int(2) DEFAULT NULL,
  `24a-b_DD` int(2) DEFAULT NULL,
  `24a-c_YYYY` int(2) DEFAULT NULL,
  `24a-d_MM` int(2) DEFAULT NULL,
  `24a-e_DD` int(2) DEFAULT NULL,
  `24a-f_YYYY` int(2) DEFAULT NULL,
  `24b_Place of Service` int(2) DEFAULT NULL,
  `24c_EMG` varchar(1) DEFAULT NULL,
  `24d-a_CPT/HCPCS` int(6) DEFAULT NULL,
  `24d-b_Modifier` int(8) DEFAULT NULL,
  `24E_Diagnostic Pointer` varchar(4) DEFAULT NULL,
  `24F_charges` int(6) DEFAULT NULL,
  `24F(F)_charges` int(2) DEFAULT NULL,
  `24G_Days or Units` float DEFAULT NULL,
  `24H-a_EPSDT code` varchar(2) DEFAULT NULL,
  `24H-b_Yes or no` varchar(1) DEFAULT NULL,
  `24I_Qual` varchar(2) DEFAULT NULL,
  `24J-a_Rendering provider ID` varchar(17) DEFAULT NULL,
  `24j-b_Rendering provider ID` varchar(10) DEFAULT NULL,
  
  `CreatedDate` datetime,
  `ModifiedDate` datetime,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
