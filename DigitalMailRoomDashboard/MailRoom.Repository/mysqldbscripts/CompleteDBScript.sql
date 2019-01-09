CREATE DATABASE  IF NOT EXISTS `digitalmaildashboard_dev` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `digitalmaildashboard_dev`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: 10.20.125.249    Database: digitalmaildashboard_dev
-- ------------------------------------------------------
-- Server version	5.6.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cms1500_1`
--

DROP TABLE IF EXISTS `cms1500_1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cms1500_1` (
  `ClaimID` varchar(18) NOT NULL DEFAULT '',
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
  `status` int(1) DEFAULT '0',
  PRIMARY KEY (`ClaimID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cms1500_1`
--

LOCK TABLES `cms1500_1` WRITE;
/*!40000 ALTER TABLE `cms1500_1` DISABLE KEYS */;
INSERT INTO `cms1500_1` VALUES ('CQ893400910M56038','HCSC Group','1001 Elookout','Tx 75082','USA','FBL','MCF3489340','de Bruyne,','','Peter','Kevin,',9,10,1993,'Male','Silva,','','Adrino,','Thiago,','Beta Street','Seattle','SA','53245',931,1235426,'Others','Harrison Aveue','Florida','FD','85656',534,8678456,'','','','','','','','','','Yes','No','','Yes','PAR3478583843','FGNBV3456345234',5,10,1987,'Male','LK','RTNBFGJ657860','Bush Care','No','https://address/images/idnumber544',11,26,2018,'No Signature on File',7,9,2015,484,9,12,2017,455,11,12,2011,8,28,2007,'DK','HCSC Cloud care','1G','VBNF4564574','YRT6345',11,12,2011,8,28,2007,'G2 OX 4534452','No',NULL,NULL,9,'EIT.567','BGF.643','MMH.457','MNH.456','','','','','','','','','75423637473','DFGHK34693456','NBDOBN3467458603479','SSN','BLDHN36793',35683464,'No',456,87,400,87,'','','https://address/physiciansignature/idnumber3',12,10,2014,'JUNIPER HOSPITALS','MORING STRAIGHT','TEXAS,TX,75082','563593228','LU5458936D65',271,-389220,'HCSC Group','1001 Elookout','Tx 75082','OF5164533','ZZ61321358',2),('FA345671222M87110','Aetna Insurance','151 Farmington Avenue','Hartford, CT06156','USA','Medicare','PSG1234567','Neymar,','Jr,','Santos,','',12,22,1996,'Male','da Silva,','Jr,','Bruno,','','Rio de Jenero','California','CA','58978',543,4534556,'Spouse','Rio de Jenero','California','CA','58978',543,4534556,'No','Neymar,','Jr,','Santos,','','GUH63483904','','','Obama Care','Yes','Yes','CA','Yes','!PSG345893453','HJD45769903490456',6,21,1998,'Female','B','POPRTY546980','Obama Care','Yes','https://address/images/idnumber543',NULL,NULL,NULL,'https://address/images/idnumber544',5,18,2016,484,2,21,2017,304,5,18,2016,2,23,2017,'DR','United Physiotherapy','GU','QWE345634','FHR456343',6,1,2016,2,27,2017,'LU CT 456346','Yes',436,78,9,'ERT.934','RTO.435','','','','','','','','','','','76708606787','NBMI468456546','FGBNLER8430560346','SSN','NBSK4949409',456457457,'Yes',990,60,500,0,'','','https://address/physiciansignature/',3,25,2017,'ATENA UNIVERSAL HOSPITALS','NEW AVENUE','california,CA,64656','16986654','0B566565',351,1382389,'Aetna Insurance','151 Farmington Avenue','Hartford, CT06156','kd25664465','0B265952',2),('NZ670911017M60694','United Health Group','Bonner Springs','KS 66012','USA','Medicaid','FCB9867091','Messi,','','Andres,','Lionel,',10,17,1985,'Male','Marquinhos,','','Mike,','Robert,','Alpha Street','Texas','TX','89886',976,2423564,'Child','Alpha Street','Texas','TX','89886',976,2423564,'','','','','','','','','','No','Yes','TX','No','FCB456834787','IDF34634523435',6,19,1982,'Male','NM','LDFMG456456','Trump Care','No','No Signature on File',NULL,NULL,NULL,'https://address/images/idnumber544',5,18,2016,484,8,31,2015,304,NULL,NULL,NULL,NULL,NULL,NULL,'DQ','United Physiotherapy','GU','QWE345634','FHR456343',NULL,NULL,NULL,NULL,NULL,NULL,'1G 09084565','No',NULL,NULL,0,'ERT.934','RTO.435','MER.367','QCV.644','','','','','','','','','82354672376','MNPTMN4634634','FNLKMRPT94845567945','EIN','DDLNB9856909',36745673,'Yes',457,98,300,98,'','','https://address/physiciansignature/idnumber2',11,24,2011,'OMEGA HOSPITALS','BRAD STREET','KANSAS, KS 66012','6926234','G2J656545',961,-568578,'United Health Group','Bonner Springs','KS 66012','HS446564','G2465222',2),('OWSG4560103M32578','UNITED HEALTH GROUP','BONNER SPRINGS','','KS 66012','MEDICAID','DSG456','','','','',1,3,1994,'MALE','JUSTIN','BREW','BIBER','','','','','',NULL,NULL,'SELF','8TH AVENUE','New York','NY','10019',555,13355,'','JUSTIN','BREW','BIBER','','FDS466','','','OBAMA CARE','YES','NO','','NO','FA465','MD556',NULL,NULL,NULL,'','G2','DSFS566','FULL BODY CARE','YES','https://address/images/idnumber',10,5,2017,'https://address/images/idnumber',5,5,2017,431,3,2,2017,454,2,5,2017,5,5,2017,'DK','JOHN','1G','FFA555','',3,2,2017,2,5,2017,'1G DFG125 FG55','NO',NULL,NULL,9,'F55.34','N25.36','DF56.93','DA99.56','GS6','SD6.33','FS6.55','SA6.33','','','','','8SDF666','FD4666','FS6644','EIN','PSD56622FA',54663256,'NO',1000,33,300,20,'','','https://address/images/idnumber',2,5,2017,'HLS CARE','5TH AVENUE','RICHMOND KS 5654','PSD3655','',NULL,NULL,'UNITED HEALTH GROUP','BONNER SPRINGS','KS 66012','PFSD566','FS544646',2),('WO580340608M17038','Liberty Mutual Group','175 Berkeley Street','Boston, MA 02116','USA','GHP','PAR3458034','Berge,','','Jake,','Sanders,',6,8,1987,'Female','Kane,','','Harry,','Robert,','Gamma Street','Boston','MC','86536',235,1234626,'Others','Belof street','Ellinois','EL','23464',657,7645634,'','','','','','','','','','No','Yes','EL','Yes','MCF2345634959','NRTYE34543534534',3,17,1998,'Female','OP','DFBNERT678345','Lincoln Care','No','https://address/images/idnumber',12,25,2018,'https://address/images/idnumber534',6,6,2009,431,6,19,2014,444,10,30,2008,2,18,2016,'DQ','Liberty Opthamalogy','G2','DGERT2352353','FTYG56345',10,30,2008,2,18,2016,'1G DFG125 FG65','Yes',456,65,0,'CVB.456','NTY.456','PKL.546','PLK.346','','','','','','','','','89056747783','FNKGHL34683403','NSDONH379495693','SSN','NLKF794505',457345734,'Yes',567,45,550,45,'','','https://address/physiciansignature/idnumber4',5,16,2015,'MITHALI HOSPITALS','FORD STREET','BOSTON,MA,02116','16484546','0B4558666',331,-65226,'Liberty Mutual Group','175 Berkeley Street','Boston, MA 02116','YU6464325','0B15326223',2);
/*!40000 ALTER TABLE `cms1500_1` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cms1500_1_conf`
--

DROP TABLE IF EXISTS `cms1500_1_conf`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cms1500_1_conf` (
  `ClaimID` varchar(18) NOT NULL DEFAULT '',
  `ia_PayerName` float DEFAULT NULL,
  `ib_PayerAddress1` float DEFAULT NULL,
  `ic_PayerAddress2` float DEFAULT NULL,
  `id_Payer_city_state_zipcode` float DEFAULT NULL,
  `1_PAYER_TYPE` float DEFAULT NULL,
  `1a_Insured_Id_number` float DEFAULT NULL,
  `2a_LastName` float DEFAULT NULL,
  `2b_Suffix` float DEFAULT NULL,
  `2c_FirstName` float DEFAULT NULL,
  `2d_MiddleName` float DEFAULT NULL,
  `3a_MM` float DEFAULT NULL,
  `3b_DD` float DEFAULT NULL,
  `3c_YYYY` float DEFAULT NULL,
  `3d_Gender` float DEFAULT NULL,
  `4a_LastName` float DEFAULT NULL,
  `4b_Suffix` float DEFAULT NULL,
  `4c_FirstName` float DEFAULT NULL,
  `4d_MiddleName` float DEFAULT NULL,
  `5a_Street_Address` float DEFAULT NULL,
  `5b_City` float DEFAULT NULL,
  `5c_State` float DEFAULT NULL,
  `5d_Zipcode` float DEFAULT NULL,
  `5e_Telephone_areacode` float DEFAULT NULL,
  `5f_Telephone_phone number` float DEFAULT NULL,
  `6_Patient_Relationship_to_Insured` float DEFAULT NULL,
  `7a_Street_Address` float DEFAULT NULL,
  `7b_City` float DEFAULT NULL,
  `7c_State` float DEFAULT NULL,
  `7d_Zip code` float DEFAULT NULL,
  `7e_Telephone_areacode` float DEFAULT NULL,
  `7f_Telephone_phonenumber` float DEFAULT NULL,
  `8_Reserved_for_NUCC_Use` float DEFAULT NULL,
  `9-a_LastName` float DEFAULT NULL,
  `9-b_Suffix` float DEFAULT NULL,
  `9-c_FirstName` float DEFAULT NULL,
  `9-d_MiddleName` float DEFAULT NULL,
  `9a_other_policies_number` float DEFAULT NULL,
  `9b_Reserved_for_NUCC_Use` float DEFAULT NULL,
  `9c_Reserved_for_NUCC_Use` float DEFAULT NULL,
  `9d_InsuranceplanName` float DEFAULT NULL,
  `10a_employment` float DEFAULT NULL,
  `10b_Auto_Accident` float DEFAULT NULL,
  `10b-a_Auto_Accident_Place` float DEFAULT NULL,
  `10c_Other_Accident` float DEFAULT NULL,
  `10d_Claim_codes` float DEFAULT NULL,
  `11_InsuredsPolicyNumber` float DEFAULT NULL,
  `11a-a_MM` float DEFAULT NULL,
  `11a-b_DD` float DEFAULT NULL,
  `11a-c_YYYY` float DEFAULT NULL,
  `11a-d_Gender` float DEFAULT NULL,
  `11b-a_qualifier` float DEFAULT NULL,
  `11b-b_ClaimID` float DEFAULT NULL,
  `11c_InsurancePlanName` float DEFAULT NULL,
  `11d_Another_Health_Benefit_Plan` float DEFAULT NULL,
  `12-a_Signature_URL` float DEFAULT NULL,
  `12-b-a_MM` float DEFAULT NULL,
  `12-b-b_DD` float DEFAULT NULL,
  `12-b-c_YYYY` float DEFAULT NULL,
  `13_InsuredsAuthorizedSignature_URL` float DEFAULT NULL,
  `14-a_MM` float DEFAULT NULL,
  `14-b_DD` float DEFAULT NULL,
  `14-c_YYYY` float DEFAULT NULL,
  `14-d_qualifier` float DEFAULT NULL,
  `15-a_MM` float DEFAULT NULL,
  `15-b_DD` float DEFAULT NULL,
  `15-c_YYYY` float DEFAULT NULL,
  `15-d_qualifier` float DEFAULT NULL,
  `16-a_MM` float DEFAULT NULL,
  `16-b_DD` float DEFAULT NULL,
  `16-c_YYYY` float DEFAULT NULL,
  `16-a-a_MM` float DEFAULT NULL,
  `16-a-b_DD` float DEFAULT NULL,
  `16-a-c_YYYY` float DEFAULT NULL,
  `17_qualifier` float DEFAULT NULL,
  `17-a_Name` float DEFAULT NULL,
  `17a-a_Qualifier` float DEFAULT NULL,
  `17a-b_ID number` float DEFAULT NULL,
  `17b_ID number` float DEFAULT NULL,
  `18-a_MM` float DEFAULT NULL,
  `18-b_DD` float DEFAULT NULL,
  `18-c_YYYY` float DEFAULT NULL,
  `18-a-a_MM` float DEFAULT NULL,
  `18-a-b_DD` float DEFAULT NULL,
  `18-a-c_YYYY` float DEFAULT NULL,
  `19_Additional_Claim_Information` float DEFAULT NULL,
  `20_YES OR NO` float DEFAULT NULL,
  `20-a_Charges_dollars` float DEFAULT NULL,
  `20-b_charges_cents` float DEFAULT NULL,
  `21_ICD_Indicator` float DEFAULT NULL,
  `21A_Nature_of_Illnes` float DEFAULT NULL,
  `21B_Nature_of_Illnes` float DEFAULT NULL,
  `21C_Nature_of_Illnes` float DEFAULT NULL,
  `21D_Nature_of_Illnes` float DEFAULT NULL,
  `21E_Nature_of_Illnes` float DEFAULT NULL,
  `21F_Nature_of_Illnes` float DEFAULT NULL,
  `21G_Nature_of_Illnes` float DEFAULT NULL,
  `21H_Nature_of_Illnes` float DEFAULT NULL,
  `21I_Nature_of_Illnes` float DEFAULT NULL,
  `21J_Nature_of_Illnes` float DEFAULT NULL,
  `21K_Nature_of_Illnes` float DEFAULT NULL,
  `21L_Nature_of_Illnes` float DEFAULT NULL,
  `22-a_ReSubmissionCode_qualifier` float DEFAULT NULL,
  `22-b_original_ref_No` float DEFAULT NULL,
  `23_PriorAuthorizationNumber` float DEFAULT NULL,
  `24_table_confidence` float DEFAULT NULL,
  `25-a_type` float DEFAULT NULL,
  `25-b_ID_Number` float DEFAULT NULL,
  `26_Patient_Acc_Number` float DEFAULT NULL,
  `27_Accept_Assignment` float DEFAULT NULL,
  `28-a_dollars` float DEFAULT NULL,
  `28-b_cents` float DEFAULT NULL,
  `29-a_dollars` float DEFAULT NULL,
  `29-b_cents` float DEFAULT NULL,
  `30-a_code` float DEFAULT NULL,
  `30-b_qualifier` float DEFAULT NULL,
  `31-a_Signature` float DEFAULT NULL,
  `31-b-a_MM` float DEFAULT NULL,
  `31-b-b_DD` float DEFAULT NULL,
  `31-b-c_YYYY` float DEFAULT NULL,
  `32-a_ProviderName` float DEFAULT NULL,
  `32-b_ProviderAddress` float DEFAULT NULL,
  `32-c_City_State_Zipcode` float DEFAULT NULL,
  `32a_NationalProvider_IdentifierNumber` float DEFAULT NULL,
  `32b_PayerAssignedIdentifier_of_BillingProvider` float DEFAULT NULL,
  `33-a_AreaCode` float DEFAULT NULL,
  `33-b_PhoneNumber` float DEFAULT NULL,
  `33-c_BillingProvider_Name` float DEFAULT NULL,
  `33-d_BillingProvider_Address` float DEFAULT NULL,
  `33-e_Billingprovider_city_state_zipcode` float DEFAULT NULL,
  `33a_NationalProvider_IdentifierNumber` float DEFAULT NULL,
  `33b_PayerAssignedIdentifier_of_BillingProvider` float DEFAULT NULL,
  `overall_table_confidence` float DEFAULT NULL,
  PRIMARY KEY (`ClaimID`),
  CONSTRAINT `cms1500_1_conf_ibfk_1` FOREIGN KEY (`ClaimID`) REFERENCES `cms1500_1` (`ClaimID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cms1500_1_conf`
--

LOCK TABLES `cms1500_1_conf` WRITE;
/*!40000 ALTER TABLE `cms1500_1_conf` DISABLE KEYS */;
INSERT INTO `cms1500_1_conf` VALUES ('CQ893400910M56038',96,96,96,96,96,96,96,0,96,96,96,96,96,96,96,0,98,98,98,98,98,96,96,96,96,96,96,96,96,96,96,0,0,0,0,0,0,0,0,0,84,84,0,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,0,0,66,66,66,66,66,0,0,0,0,0,0,0,0,77,77,77,77,77,77,77,77,77,77,77,77,0,0,76,76,76,76,76,76,76,76,76,76,76,76,76,76,76,76,88),('FA345671222M87110',96,96,96,96,96,96,96,96,96,0,88,88,88,88,86,86,86,0,88,88,88,87,87,87,87,87,87,87,87,87,87,0,84,84,84,0,96,0,0,94,94,94,94,94,94,94,94,94,94,94,94,94,94,94,94,0,0,0,90,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,0,0,0,0,0,0,0,84,84,84,84,84,84,84,84,84,84,84,84,0,0,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,76.34),('NZ670911017M60694',88,88,88,88,88,88,88,0,87,87,87,87,87,87,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,0,0,0,0,0,0,0,0,0,84,84,84,84,84,84,84,84,84,84,84,84,84,84,84,0,0,0,83,83,83,83,83,83,83,83,83,0,0,0,0,0,0,88,88,88,88,88,0,0,0,0,0,0,86,86,0,0,96,96,96,96,96,0,0,0,0,0,0,0,0,94,94,94,94,94,94,94,94,94,94,94,94,0,0,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,78.63),('WO580340608M17038',94,94,94,94,94,94,94,0,94,94,94,94,94,94,94,0,92,92,92,92,92,92,92,92,92,92,92,92,92,92,92,0,0,0,0,0,0,0,0,0,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,0,0,0,0,0,0,0,0,86,86,86,86,86,86,86,86,86,86,86,86,0,0,87,87,87,87,87,87,87,87,87,87,87,87,87,87,87,87,88);
/*!40000 ALTER TABLE `cms1500_1_conf` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cms1500_2`
--

DROP TABLE IF EXISTS `cms1500_2`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cms1500_2` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimID` varchar(18) DEFAULT NULL,
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
  `24E_Diagnostic Pointer` varchar(7) DEFAULT NULL,
  `24F_charges` int(6) DEFAULT NULL,
  `24F(F)_charges` int(2) DEFAULT NULL,
  `24G_Days or Units` float DEFAULT NULL,
  `24H-a_EPSDT code` varchar(2) DEFAULT NULL,
  `24H-b_Yes or no` varchar(1) DEFAULT NULL,
  `24I_Qual` varchar(2) DEFAULT NULL,
  `24J-a_Rendering provider ID` varchar(17) DEFAULT NULL,
  `24j-b_Rendering provider ID` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_claimId` (`ClaimID`),
  CONSTRAINT `cms1500_2_ibfk_1` FOREIGN KEY (`ClaimID`) REFERENCES `cms1500_1` (`ClaimID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cms1500_2`
--

LOCK TABLES `cms1500_2` WRITE;
/*!40000 ALTER TABLE `cms1500_2` DISABLE KEYS */;
INSERT INTO `cms1500_2` VALUES (1,'OWSG4560103M32578',2,23,2018,11,24,2018,13,'Y',345347,54645675,'ABC',70,89,3.78,'AV','','RE','ERYE4363464','FH434523'),(2,'OWSG4560103M32578',1,19,2018,9,30,2018,76,'N',456465,455457,'DE',67,67,1.75,'','Y','ER','DNG5545643','ND564564'),(3,'FA345671222M87110',9,21,16,10,22,16,43,'N',456657,45645234,'ERT.934',90,0,31,'','Y','HJ','RET36456734','VBNF45363'),(4,'FA345671222M87110',10,22,16,11,22,16,54,'Y',967856,87668769,'RTO.435',300,0,30,'S2','','RY','JGJGY546745','TYUG8658'),(5,'NZ670911017M60694',6,19,2016,10,31,2016,56,'N',345233,23409876,'A',3455,56,20,'NU','','TY','ERBD3464','NVJFTY674'),(6,'NZ670911017M60694',9,15,2016,11,30,2016,87,'Y',456342,80904904,'BCDE',4576,67,40,'','Y','MJ','XAS634534','VNTT36564'),(7,'WO580340608M17038',1,20,2015,12,29,2015,98,'Y',568987,45682348,'ABC',9878,98,50,'AV','','WS','VBMV4564','NTY45647'),(8,'WO580340608M17038',9,9,2015,4,27,2015,12,'N',976756,45674587,'DE',1008,67,60,'','Y','PO','NFGCVB456','VBNR5674'),(9,'CQ893400910M56038',10,18,2014,5,23,2014,65,'Y',345645,12453465,'ACD',7867,98,28,'S2','','XD','CVBR64645','VNBFTY45'),(10,'CQ893400910M56038',11,6,2014,9,22,2014,98,'N',444484,45645686,'BE',4567,90,32,'','Y','YT','VBN45654','NBRTY6456');
/*!40000 ALTER TABLE `cms1500_2` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cms1500_2_conf`
--

DROP TABLE IF EXISTS `cms1500_2_conf`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cms1500_2_conf` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimID` varchar(18) DEFAULT NULL,
  `24a-a_MM` float DEFAULT NULL,
  `24a-b_DD` float DEFAULT NULL,
  `24a-c_YYYY` float DEFAULT NULL,
  `24a-d_MM` float DEFAULT NULL,
  `24a-e_DD` float DEFAULT NULL,
  `24a-f_YYYY` float DEFAULT NULL,
  `24b_Place of Service` float DEFAULT NULL,
  `24c_EMG` float DEFAULT NULL,
  `24d-a_CPT/HCPCS` float DEFAULT NULL,
  `24d-b_Modifier` float DEFAULT NULL,
  `24E_Diagnostic Pointer` float DEFAULT NULL,
  `24F_charges` float DEFAULT NULL,
  `24F(F)_charges` float DEFAULT NULL,
  `24G_Days or Units` float DEFAULT NULL,
  `24H-a_EPSDT code` float DEFAULT NULL,
  `24H-b_Yes or no` float DEFAULT NULL,
  `24I_Qual` float DEFAULT NULL,
  `24J-a_Rendering provider ID` float DEFAULT NULL,
  `24j-b_Rendering provider ID` float DEFAULT NULL,
  `total_confidence` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  CONSTRAINT `cms1500_2_conf_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `cms1500_2` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cms1500_2_conf`
--

LOCK TABLES `cms1500_2_conf` WRITE;
/*!40000 ALTER TABLE `cms1500_2_conf` DISABLE KEYS */;
INSERT INTO `cms1500_2_conf` VALUES (1,'OWSG4560103M32578',96,96,96,96,96,96,87,87,87,87,87,82,82,82,82,0,87,87,87,96),(2,'OWSG4560103M32578',96,96,96,96,96,96,96,87,87,87,82,82,82,84,84,0,88,88,88,88),(3,'FA345671222M87110',96,96,96,96,96,96,96,87,87,87,82,82,82,84,84,0,88,88,88,88),(4,'FA345671222M87110',90,90,90,90,90,90,90,90,90,90,90,88,88,88,88,88,0,88,88,88),(5,'NZ670911017M60694',94,94,94,94,94,94,94,94,94,94,94,94,94,94,94,94,0,88,88,88),(6,'NZ670911017M60694',88,89,89,89,89,89,89,89,89,89,89,89,89,89,89,0,92,92,92,92),(7,'CQ893400910M56038',96,93,93,93,93,93,93,93,93,93,93,93,93,93,93,0,87,87,87,87),(8,'CQ893400910M56038',96,92,92,92,92,92,92,92,92,92,92,92,92,92,92,92,0,89,89,89),(9,'WO580340608M17038',98,91,91,91,91,91,91,91,91,91,91,91,91,91,91,0,90,90,90,90),(10,'WO580340608M17038',98,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,0,91,91,91);
/*!40000 ALTER TABLE `cms1500_2_conf` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `serviceinfo`
--

DROP TABLE IF EXISTS `serviceinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `serviceinfo` (
  `ServiceId` int(11) NOT NULL AUTO_INCREMENT,
  `ServiceName` varchar(45) DEFAULT NULL,
  `Host` varchar(45) DEFAULT NULL,
  `UserName` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `SourcePath` varchar(500) DEFAULT NULL,
  `FileNamePattern` varchar(45) DEFAULT NULL,
  `IsRestrictFileSize` bit(1) DEFAULT NULL,
  `FileSizeLimit` decimal(4,0) DEFAULT NULL,
  `PollingMessage` int(11) DEFAULT NULL,
  `IsPollByTime` bit(1) DEFAULT NULL,
  `PollingTime` varchar(45) DEFAULT NULL,
  `PollingFrequency` int(11) DEFAULT NULL,
  `IsMoveAllowedOnProcessing` bit(1) DEFAULT NULL,
  `DirectoryOnProcessing` varchar(100) DEFAULT NULL,
  `IsMoveAllowedOnError` bit(1) DEFAULT NULL,
  `DirectoryOnError` varchar(100) DEFAULT NULL,
  `ServiceStatus` varchar(45) DEFAULT NULL,
  `LastRunDate` datetime DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `IsActive` bit(1) DEFAULT NULL,
  PRIMARY KEY (`ServiceId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `serviceinfo`
--

LOCK TABLES `serviceinfo` WRITE;
/*!40000 ALTER TABLE `serviceinfo` DISABLE KEYS */;
INSERT INTO `serviceinfo` VALUES (1,'CMS 1500','10.20.125.249','root','root','/home/source','*.*','',NULL,100,'','08:00',NULL,'',NULL,'',NULL,'Stopped','2018-12-28 16:00:00',1,'2018-12-28 08:00:00',NULL,NULL,''),(2,'Dental Claims','10.20.125.249','root','root','/home/dental/source','*.*','',5,50,'',NULL,1000,'','/home/dental/processed','','/home/dental/errored','Stopped','2018-12-28 16:00:00',1,'2018-12-28 09:00:00',NULL,NULL,'');
/*!40000 ALTER TABLE `serviceinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stagingclaim_cms1500`
--

DROP TABLE IF EXISTS `stagingclaim_cms1500`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
  `ReviewerId` varchar(50) DEFAULT NULL,
  `ParserStatus` int(1) DEFAULT '0',
  `ReviewStatus` varchar(50) DEFAULT '0',
  `ConfidenceLevel` int(5) DEFAULT '0',
  `ParserErrorCsv` varchar(2000) DEFAULT NULL,
  `sourceId` varchar(10) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ClaimID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stagingclaim_cms1500`
--

LOCK TABLES `stagingclaim_cms1500` WRITE;
/*!40000 ALTER TABLE `stagingclaim_cms1500` DISABLE KEYS */;
INSERT INTO `stagingclaim_cms1500` VALUES ('CQ893400910M56038','HCSC Group','1001 Elookout','Tx 75082','USA','FBL','MCF3489340','de Bruyne,','','Peter','Kevin,',9,10,1993,'Male','Silva,','','Adrino,','Thiago,','Beta Street','Seattle','SA','53245',931,1235426,'Others','Harrison Aveue','Florida','FD','85656',534,8678456,'','','','','','','','','','Yes','No','','Yes','PAR3478583843','FGNBV3456345234',5,10,1987,'Male','LK','RTNBFGJ657860','Bush Care','No','https://address/images/idnumber544',11,26,2018,'No Signature on File',7,9,2015,484,9,12,2017,455,11,12,2011,8,28,2007,'DK','HCSC Cloud care','1G','VBNF4564574','YRT6345',11,12,2011,8,28,2007,'G2 OX 4534452','No',NULL,NULL,9,'EIT.567','BGF.643','MMH.457','MNH.456','','','','','','','','','75423637473','DFGHK34693456','NBDOBN3467458603479','SSN','BLDHN36793',35683464,'No',456,87,400,87,'','','https://address/physiciansignature/idnumber3',12,10,2014,'JUNIPER HOSPITALS','MORING STRAIGHT','TEXAS,TX,75082','563593228','LU5458936D65',271,-389220,'HCSC Group','1001 Elookout','Tx 75082','OF5164533','ZZ61321358','reviewerid1',1,'Pending',88,'[{\"Field\":\"_10bAAutoAccidentPlace\",\"Value\":null,\"Message\":\"REQUIRED Fields is missing\"}]',NULL,'2019-01-03 17:25:36',NULL),('FA345671222M87110','Aetna Insurance','151 Farmington Avenue','Hartford, CT06156','USA','medicare','PSG1234567','Neymar,','Jr,','Santos,',NULL,12,22,1996,'male','da Silva,','Jr,','Bruno,',NULL,'Rio de Jenero','California','CA','58978',543,4534556,'spouse','Rio de Jenero','California','CA','58978',543,4534556,'No','Neymar,','Jr,','Santos,',NULL,'GUH63483904',NULL,NULL,'Obama Care','yes','yes','CA','yes','PSG345893453','HJD45769903490456',6,21,1998,'female','B','POPRTY546980','Obama Care','yes','https://address/images/idnumber543',NULL,NULL,NULL,'https://address/images/idnumber544',5,18,2016,484,2,21,2017,304,5,18,2016,2,23,2017,'DK','United Physiotherapy','GU','QWE345634','FHR456343',6,1,2016,2,27,2017,'LU CT 456346','yes',436,78,9,'ERT.934','RTO.435',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'76708606787','NBMI468456546','FGBNLER8430560346','SSN','NBSK4949409',456457457,'yes',990,60,500,0,NULL,NULL,'https://address/physiciansignature/',3,25,2017,'ATENA UNIVERSAL HOSPITALS','NEW AVENUE','california,CA,64656','16986654','0B566565',351,1382389,'Aetna Insurance','151 Farmington Avenue','Hartford, CT06156','kd25664465','0B265952','reviewerid1',1,'Completed',76,'[]',NULL,'2019-01-03 17:25:55','2019-01-03 20:15:35'),('NZ670911017M60694','United Health Group','Bonner Springs','KS 66012','USA','Medicaid','FCB9867091','Messi,','','Andres,','Lionel,',10,17,1985,'Male','Marquinhos,','','Mike,','Robert,','Alpha Street','Texas','TX','89886',976,2423564,'Child','Alpha Street','Texas','TX','89886',976,2423564,'','','','','','','','','','No','Yes','TX','No','FCB456834787','IDF34634523435',6,19,1982,'Male','NM','LDFMG456456','Trump Care','No','No Signature on File',NULL,NULL,NULL,'https://address/images/idnumber544',5,18,2016,484,8,31,2015,304,NULL,NULL,NULL,NULL,NULL,NULL,'DQ','United Physiotherapy','GU','QWE345634','FHR456343',NULL,NULL,NULL,NULL,NULL,NULL,'1G 09084565','No',NULL,NULL,0,'ERT.934','RTO.435','MER.367','QCV.644','','','','','','','','','82354672376','MNPTMN4634634','FNLKMRPT94845567945','EIN','DDLNB9856909',36745673,'Yes',457,98,300,98,'','','https://address/physiciansignature/idnumber2',11,24,2011,'OMEGA HOSPITALS','BRAD STREET','KANSAS, KS 66012','6926234','G2J656545',961,-568578,'United Health Group','Bonner Springs','KS 66012','HS446564','G2465222','reviewerid1',1,'Pending',79,'[{\"Field\":\"SignatureDate\",\"Value\":\"//\",\"Message\":\"Not a Valid date mm/dd/yyyy\"},{\"Field\":\"_23PriorAuthorizationNumber\",\"Value\":\"MNPTMN4634634\",\"Message\":\"Maximum of 29 digits\"},{\"Field\":\"_25AType\",\"Value\":\"EIN\",\"Message\":\"Only SSN or EIN should be there \"},{\"Field\":\"_27AcceptAssignment\",\"Value\":\"Yes\",\"Message\":\"Valid only YES or NO\"},{\"Field\":\"_33BPhoneNumber\",\"Value\":\"-568578\",\"Message\":\"_33BPhoneNumber without areacode?\"},{\"Field\":\"_24hBYesOrNo\",\"Value\":\"Y\",\"Message\":\"Invalid data,  Only Y is allowed. If 24H-a is filled. Then current field should be empty\"}]',NULL,'2019-01-03 17:26:01',NULL),('OWSG4560103M32578','UNITED HEALTH GROUP','BONNER SPRINGS','','KS 66012','MEDICAID','DSG456','','','','',1,3,1994,'MALE','JUSTIN','BREW','BIBER','','','','','',NULL,NULL,'SELF','8TH AVENUE','New York','NY','10019',555,13355,'','JUSTIN','BREW','BIBER','','FDS466','','','OBAMA CARE','YES','NO','','NO','FA465','MD556',NULL,NULL,NULL,'','G2','DSFS566','FULL BODY CARE','YES','https://address/images/idnumber',10,5,2017,'https://address/images/idnumber',5,5,2017,431,3,2,2017,454,2,5,2017,5,5,2017,'DK','JOHN','1G','FFA555','',3,2,2017,2,5,2017,'1G DFG125 FG55','NO',NULL,NULL,9,'F55.34','N25.36','DF56.93','DA99.56','GS6','SD6.33','FS6.55','SA6.33','','','','','8SDF666','FD4666','FS6644','EIN','PSD56622FA',54663256,'NO',1000,33,300,20,'','','https://address/images/idnumber',2,5,2017,'HLS CARE','5TH AVENUE','RICHMOND KS 5654','PSD3655','',NULL,NULL,'UNITED HEALTH GROUP','BONNER SPRINGS','KS 66012','PFSD566','FS544646','reviewerid1',1,'Pending',-1,'[{\"Field\":\"_2aLastName\",\"Value\":null,\"Message\":\"REQUIRED Fields is missing\"},{\"Field\":\"_2cFirstName\",\"Value\":null,\"Message\":\"REQUIRED Fields is missing\"},{\"Field\":\"_10bAAutoAccidentPlace\",\"Value\":null,\"Message\":\"REQUIRED Fields is missing\"},{\"Field\":\"_32bPayerAssignedIdentifierOfBillingProvider\",\"Value\":null,\"Message\":\"REQUIRED Fields is missing\"}]',NULL,'2019-01-03 17:25:45',NULL),('WO580340608M17038','Liberty Mutual Group','175 Berkeley Street','Boston, MA 02116','USA','GHP','PAR3458034','Berge,','','Jake,','Sanders,',6,8,1987,'Female','Kane,','','Harry,','Robert,','Gamma Street','Boston','MC','86536',235,1234626,'Others','Belof street','Ellinois','EL','23464',657,7645634,'','','','','','','','','','No','Yes','EL','Yes','MCF2345634959','NRTYE34543534534',3,17,1998,'Female','OP','DFBNERT678345','Lincoln Care','No','https://address/images/idnumber',12,25,2018,'https://address/images/idnumber534',6,6,2009,431,6,19,2014,444,10,30,2008,2,18,2016,'DQ','Liberty Opthamalogy','G2','DGERT2352353','FTYG56345',10,30,2008,2,18,2016,'1G DFG125 FG65','Yes',456,65,0,'CVB.456','NTY.456','PKL.546','PLK.346','','','','','','','','','89056747783','FNKGHL34683403','NSDONH379495693','SSN','NLKF794505',457345734,'Yes',567,45,550,45,'','','https://address/physiciansignature/idnumber4',5,16,2015,'MITHALI HOSPITALS','FORD STREET','BOSTON,MA,02116','16484546','0B4558666',331,-65226,'Liberty Mutual Group','175 Berkeley Street','Boston, MA 02116','YU6464325','0B15326223','reviewerid1',1,'Pending',88,'[{\"Field\":\"_23PriorAuthorizationNumber\",\"Value\":\"FNKGHL34683403\",\"Message\":\"Maximum of 29 digits\"},{\"Field\":\"_27AcceptAssignment\",\"Value\":\"Yes\",\"Message\":\"Valid only YES or NO\"},{\"Field\":\"_33BPhoneNumber\",\"Value\":\"-65226\",\"Message\":\"_33BPhoneNumber without areacode?\"},{\"Field\":\"_24hBYesOrNo\",\"Value\":\"Y\",\"Message\":\"Invalid data,  Only Y is allowed. If 24H-a is filled. Then current field should be empty\"}]',NULL,'2019-01-03 17:25:57',NULL);
/*!40000 ALTER TABLE `stagingclaim_cms1500` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stagingclaim_cms1500_detail`
--

DROP TABLE IF EXISTS `stagingclaim_cms1500_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stagingclaim_cms1500_detail` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimID` varchar(18) DEFAULT NULL,
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
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_claimId` (`ClaimID`),
  CONSTRAINT `stagingclaim_cms1500_detail_ibfk_1` FOREIGN KEY (`ClaimID`) REFERENCES `stagingclaim_cms1500` (`ClaimID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=121 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stagingclaim_cms1500_detail`
--

LOCK TABLES `stagingclaim_cms1500_detail` WRITE;
/*!40000 ALTER TABLE `stagingclaim_cms1500_detail` DISABLE KEYS */;
INSERT INTO `stagingclaim_cms1500_detail` VALUES (111,'CQ893400910M56038',10,18,2014,5,23,2014,65,'Y',345645,12453465,'ACD',7867,98,28,'S2','','XD','CVBR64645','VNBFTY45','2019-01-03 17:25:36',NULL),(112,'CQ893400910M56038',11,6,2014,9,22,2014,98,'N',444484,45645686,'BE',4567,90,32,'','Y','YT','VBN45654','NBRTY6456','2019-01-03 17:25:36',NULL),(113,'OWSG4560103M32578',2,23,2018,11,24,2018,13,'Y',345347,54645675,'ABC',70,89,3.78,'AV','','RE','ERYE4363464','FH434523','2019-01-03 17:25:45',NULL),(114,'OWSG4560103M32578',1,19,2018,9,30,2018,76,'N',456465,455457,'DE',67,67,1.75,'','Y','ER','DNG5545643','ND564564','2019-01-03 17:25:45',NULL),(115,'FA345671222M87110',9,21,16,10,22,16,43,'N',456657,45645234,'ERT.',90,0,31,NULL,'Y','HJ','RET36456734','VBNF45363','2019-01-03 17:25:55','2019-01-03 00:00:00'),(116,'FA345671222M87110',10,22,16,11,22,16,54,'Y',967856,87668769,'RTO.',300,0,30,'S2',NULL,'RY','JGJGY546745','TYUG8658','2019-01-03 17:25:55','2019-01-03 00:00:00'),(117,'WO580340608M17038',1,20,2015,12,29,2015,98,'Y',568987,45682348,'ABC',9878,98,50,'AV','','WS','VBMV4564','NTY45647','2019-01-03 17:25:57',NULL),(118,'WO580340608M17038',9,9,2015,4,27,2015,12,'N',976756,45674587,'DE',1008,67,60,'','Y','PO','NFGCVB456','VBNR5674','2019-01-03 17:25:57',NULL),(119,'NZ670911017M60694',6,19,2016,10,31,2016,56,'N',345233,23409876,'A',3455,56,20,'NU','','TY','ERBD3464','NVJFTY674','2019-01-03 17:26:01',NULL),(120,'NZ670911017M60694',9,15,2016,11,30,2016,87,'Y',456342,80904904,'BCDE',4576,67,40,'','Y','MJ','XAS634534','VNTT36564','2019-01-03 17:26:01',NULL);
/*!40000 ALTER TABLE `stagingclaim_cms1500_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'digitalmaildashboard_dev'
--

--
-- Dumping routines for database 'digitalmaildashboard_dev'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-01-03 20:18:03
