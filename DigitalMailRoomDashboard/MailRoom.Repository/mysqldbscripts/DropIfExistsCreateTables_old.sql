USE MAILROOM;
DROP TABLE IF EXISTS `stagingclaim_cms1500_detail`;
DROP TABLE IF EXISTS `stagingclaim_cms1500`;

CREATE TABLE IF NOT EXISTS `stagingclaim_cms1500` (
  `ClaimID` int(11) NOT NULL AUTO_INCREMENT,
  ia_PayerName varchar(44) NOT NULL, 
  ib_PayerAddress1 varchar(44) NOT NULL, 
  ic_PayerAddress2 varchar(44), 
  id_PayerCity varchar(44)  , 
  id_PayerState varchar(44)  ,
  id_PayerZipcode varchar(44) ,
  
  `1_PayerType` varchar(8) ,
  `1a_PatientInsuredID` varchar(29) ,
  
  `2a_PatientLastName` varchar(28),
  `2b_Suffix` varchar(28),
  `2c_PatientFirstName` varchar(28),
  `2d_PatientMiddleName` varchar(28),
  
  `3_PatientBirthMM` int  ,
  `3_PatientBirthDD` int  ,
  `3_PatientBirthYYYY` int  ,
    `3_PatientGender` varchar(6),
    
  `4_InsuredLastName` varchar(29) ,
  `4_InsuredSuffix` varchar(29),
  `4_InsuredFirstName` varchar(29) ,
  `4_InsuredMiddleName` varchar(29) ,
  
  `5_PatientAddressStreet` varchar(29),
  `5_PatientAddressCity` varchar(29),
  `5_PatientAddressState` varchar(10),
  `5_PatientZipCode` varchar(10),
  `5_PatientAreaCode` varchar(10),
  `5_PatientTelePhone` varchar(10),
  
  `6_PatientRelationToInsured` varchar(10) ,
  
  `7_InsuredAddressStreet` varchar(29) ,
  `7_InsuredAddressCity` varchar(29)  ,
  `7_InsuredAddressState` varchar(29),
  `7_InsuredZipCode` varchar(10),
	`7_InsuredAreaCode` varchar(10),
  `7_InsuredTelephone` varchar(10),
  
  `8_ReservedNUCC` varchar(50),
  
   `9_OtherInsuredLastName` varchar(29) ,
  `9_OtherInsuredSuffix` varchar(29),
  `9_OtherInsuredFirstName` varchar(29) ,
  `9_OtherInsuredMiddleName` varchar(29) ,
  
  `9a_OtherPolicyGroup` varchar(29),
  
  `9b_OtherReservedNUCC` varchar(29),
  `9c_OtherReservedNUCC` varchar(29),
  
  `9c_OtherInsuranceName` varchar(29),
  
  `10a_PatientConditionEmployment` varchar(3),
  `10b_PatientConditionAuto` varchar(3),
  `10b_PatientConditionPlace` varchar(2),
  `10c_PatientConditionOther` varchar(3),
  
  `10d_ClaimCodes` varchar(29),
  
  `11_InsuredPolicyGroup` varchar(11),
  
  
  `11a_InsuredBirthMM` int  ,
    `11a_InsuredBirthDD` int  ,
      `11a_InsuredBirthYYYY` int  ,
           
  `11a_InsuredGender` varchar(2),
  
   `11b_OtherClaimIdQual` varchar(2),
  `11b_OtherClaimId` varchar(29),
  
  `11c_InsurancePlanName` varchar(29) ,
  

  `11d_IsAnotherHealthPlan` varchar(3)  ,
  
  `12_PatientAuthorizedSignatureImageUrl` varchar(100),
  `12_PatientAuthorizedSignatureMM` int  ,
   `12_PatientAuthorizedSignatureDD` int  ,
    `12_PatientAuthorizedSignatureYYYY` int  ,
    
  `13_InsuredAuthorizedSignatureImageUrl` varchar(100) ,
  
  
  `14_CurrentIllnessMM` int,
  `14_CurrentIllnessDD` int,
  `14_CurrentIllnessYYYY` int,
  
  `14_DateOfCurrentIllnessQual` varchar(3)  ,
  
  `15_OtherDateMM` int,
   `15_OtherDateDD` int,
    `15_OtherDateYYYY` int,
  
  `15_OtherQual` varchar(3),
  
  `16_PatientUnableToWorkStartMM` int,
    `16_PatientUnableToWorkStartDD` int,
      `16_PatientUnableToWorkStartYYYY` int,
      
  `16_PatientUnableToWorkEndMM` int,
   `16_PatientUnableToWorkEndDD` int,
   `16_PatientUnableToWorkEndYYYY` int,
   
   `17_ReferringProviderQual` varchar(2) ,
  `17_ReferringProviderName` varchar(24) ,
  
    `17a_NonNPIReferringProviderQual` varchar(2) ,
  `17a_NonNPIReferringProvider` varchar(17) ,
  
   `17a_NPIReferringProviderQual` varchar(2) ,
  `17a_NPIReferringProvider` varchar(10) ,
  
  `18_HospitalizationStartMM` int,
  `18_HospitalizationStartDD` int,
  `18_HospitalizationStartYYYY` int,
  
  `18_HospitalizationEndMM` int,
  `18_HospitalizationEndDD` int,
  `18_HospitalizationEndYYYY` int,
  
  `19_AdditionalClaimInfo` varchar(70) ,
  
  `20_OutsideLab` varchar(3),
   `20_ChargesDollars` varchar(8) ,
   
    `20_ChargesCents` varchar(2) ,
   
   
   
   
  `21_NatureOfIllnessA` varchar(50),
  `21_NatureOfIllnessB` varchar(50),
  `21_NatureOfIllnessC` varchar(50),
  `21_NatureOfIllnessD` varchar(50),
  `21_NatureOfIllnessE` varchar(50),
  `21_NatureOfIllnessF` varchar(50),
  `21_NatureOfIllnessG` varchar(50),
  `21_NatureOfIllnessH` varchar(50),
  `21_NatureOfIllnessI` varchar(50),
  `21_NatureOfIllnessJ` varchar(50),
  `21_NatureOfIllnessK` varchar(50),
  `21_NatureOfIllnessL` varchar(50),
  `21_ICDIndQual` varchar(1),
  `21_ICDIndValue` varchar(9),
  
  `22_ResubmissionCodeQual` varchar(11),
   `22_OriginalRefNo` varchar(18),
  
  
  
  `23_PriorAuthorizationNumber` varchar(29),
  
  
  `25_FederalTaxId` varchar(15),
  `25_FederalTaxType` varchar(3), 

  
  `26_PatientAccountNumber` int(14),
  `27_AcceptAssignment` varchar(3),
  
  `28_TotalCharges` Decimal(6,2),
  `29_AmountPaid` Decimal(6,2),
  
  `30_NUCCUseQualifier` varchar(100),
  
    `30_NUCCUseCode` varchar(3),
    
  `31_PhysicianSignatureImageUrl` varchar(100),
  
   `31_PhysicianSignatureMM` int(2),
   `31_PhysicianSignatureDD` int(2),
   `31_PhysicianSignatureYYYY` int(4),
  
  `32_ServiceFacilityProviderName` varchar(29),
   `32_ServiceFacilityProviderAddress` varchar(29),
    `32_ServiceFacilityCityStateZipCode` varchar(29),
    
     `32a_ServiceFacilityProviderId` varchar(10),
  
  `32b_ServiceFacilityBillingProviderId` varchar(14),
  
  `33_BillingProviderAreaCode` varchar(3),
  `33_BillingProviderPhone` varchar(10),
   `33_BillingProviderName` varchar(29),
    `33_BillingProviderAddress` varchar(29),
    `33_BillingProviderCityStateZipCode` varchar(29),
   
   
  `33a_BillingProviderNPI` varchar(10),
  `33b_BillingProviderIdentifier` varchar(17),
  
  `ReviewerId` varchar(50),
  `ReviewStatus` int(1) DEFAULT '0',
  `ConfidenceLevel` int(5) DEFAULT '0',
  `ParserErrorCsv` varchar(1000),
  `sourceId` varchar(10),
  `CreatedDate` datetime,
  `ModifiedDate` datetime,
  PRIMARY KEY (`ClaimID`)
) ENGINE=InnoDB AUTO_INCREMENT=201 DEFAULT CHARSET=utf8;

CREATE TABLE `stagingclaim_cms1500_detail` (
  `ClaimDetailID` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimID` int(11),
  -- TODO: InsuredID nubmer or Generated ClaimID by Adharsh team??
  `24a_ServiceStartMM` int,
  `24a_ServiceStartDD` int,
  `24a_ServiceStartYYYY` int,
  
  `24a_ServiceEndMM` int,
   `24a_ServiceEndDD` int,
   `24a_ServiceEndYYYY` int,
   
  `24b_PlaceofService` int ,
  `24c_EMG` varchar(1),
  `24d_CPTHCPCS` int(6),
  `24d_Modifier` int(8),
  `24e_DiagnosisPointer` varchar(4),
  `24f_chargesDollar` int,
    `24f_chargesCents` int,
    
  `24g_DaysOrUnits` varchar(5),
  `24h_EPSDTCode` varchar(5),
  `24h_EPSDTYN` varchar(1),
  
  `24i_Qual` varchar(5),
  `24j_RenderingProviderId` int(17),
  `24j_RenderingProviderNPIId` int(10),
  
  PRIMARY KEY (`ClaimDetailID`),
  KEY `fk_claimId` (`ClaimID`),
  CONSTRAINT `stagingclaim_cms1500_detail_ibfk_1` FOREIGN KEY (`ClaimID`) REFERENCES `stagingclaim_cms1500` (`ClaimID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=402 DEFAULT CHARSET=utf8;

