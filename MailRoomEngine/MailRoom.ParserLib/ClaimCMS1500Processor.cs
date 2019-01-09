using MailRoom.Model;
using MailRoom.ParserLib.Constant;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MailRoom.ParserLib
{

    public class ClaimCMS1500Processor : IProcessor
    {
        public bool? IsExecutionCompleted = false;
        Cms15001 row;
        EngineConfiguration engConfig;
        public ClaimCMS1500Processor(Cms15001 dirtyClaim, EngineConfiguration engineConfig)
        {
            row = dirtyClaim;
            engConfig = engineConfig;
        }
        public bool? IsCompleted
        {
            get
            {
                return IsExecutionCompleted;
            }

        }

        public Row Row
        {
            get
            {
                return (Row)row;
            }

        }

        public void Execute()
        {
            int executionStatus = -1;  //  1- Complete & Verified
                                       // 2- Completed But not Verified
                                       // 3 - Not Completed and Verified
                                       // 4- Not Completed and Not Verified 
                                       // -1 - ERROR 
            try
            {
                #region MANDATORY FIELDS CHECK 
                // #1. Check Mandatory fields are filled or not?
                PropertyInfo[] cms1500_1Properties = typeof(Cms15001).GetProperties();
                foreach (PropertyInfo property in cms1500_1Properties)
                {
                    foreach (var attrib in property.CustomAttributes)
                    {
                        var fieldValue = property.GetValue(row);
                        // if it has required attribute, then if value is null or invalid, add error
                        if (attrib.AttributeType == typeof(System.ComponentModel.DataAnnotations.RequiredAttribute))
                        {

                            if (property.PropertyType == typeof(string))
                            {
                                if (fieldValue == null || fieldValue.ToString().IsNullString())
                                {
                                    this.Row.Errors.Add(new MandatoryError { Field = property.Name });
                                }
                            }
                            if (property.PropertyType == typeof(int?) || property.PropertyType == typeof(int))
                            {
                                int value = 0;
                                if (fieldValue == null || (!Int32.TryParse(fieldValue.ToString(), out value) && value > 0))
                                {
                                    this.Row.Errors.Add(new MandatoryError { Field = property.Name });
                                }
                            }
                        }
                    }
                }
                #region 24TH COLUMN
                // FOR DETAILS 24columns also...
                foreach (var child in row.Cms15002)
                {
                    PropertyInfo[] cms1500_2Properties = typeof(Cms15002).GetProperties();
                    foreach (PropertyInfo property in cms1500_2Properties)
                    {
                        foreach (var attrib in property.CustomAttributes)
                        {
                            var fieldValue = property.GetValue(child);
                            if (attrib.AttributeType == typeof(System.ComponentModel.DataAnnotations.RequiredAttribute))
                            {

                                if (property.PropertyType == typeof(string))
                                {
                                    if (fieldValue == null || fieldValue.ToString().IsNullString())
                                    {
                                        this.Row.Errors.Add(new MandatoryError { Field = property.Name });
                                    }
                                }
                                if (property.PropertyType == typeof(int?) || property.PropertyType == typeof(int))
                                {
                                    int value = 0;
                                    if (fieldValue == null || (!Int32.TryParse(fieldValue.ToString(), out value) && value > 0))
                                    {
                                        this.Row.Errors.Add(new MandatoryError { Field = property.Name });
                                    }
                                }
                            }
                        }

                    }
                }
                #endregion

                int mandatoryErrorCount = this.Row.Errors.Select(x => x.GetType() == typeof(MandatoryError)).Count();

                // if Mandatory errors exist, skip rest of the verification
                if (mandatoryErrorCount > 0)
                {
                    SetFinalStatus();
                    return; // exit
                }
                #endregion

                #region CONFIDENCE LEVEL CHECK      
                // Check the confidence Level 
                PropertyInfo[] properties = typeof(Cms15001Conf).GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    // if not numbers, skip
                    if (property.PropertyType != typeof(float))
                        continue;
                    var percentage = property.GetValue(row.Cms15001Conf);
                    if (Convert.ToDouble(percentage) < engConfig.ConfidenceLevelThreshold)
                    {
                        this.Row.Errors.Add(new ConfidenceError { Field = property.Name, Value = percentage.ToString(), Message = "Low Confidence" });
                        //executionStatus = 2;
                        //break;// atleast one field confidence is less than threshold, then break!
                    }
                }
                #endregion

                #region BUSINESS RULES CHECK
                // ib		payer address 1	Required 	44	Var Char 	No rules are applicable 
                if (!row.IaPayerName.IsNullString())
                {
                    if (!row.IaPayerName.IsMaxLength(44))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "IbPayerAddress1", Message = ConstantStore.MAXLENGTH + "44 CHARACTERS" });
                    }
                }
                else
                {
                    this.Row.Errors.Add(new BusinessError { Field = "IbPayerAddress1", Message = "Payer Name is Mandatory." });
                }
                if (!row.IcPayerAddress2.IsNullString())
                {
                    if (!row.IcPayerAddress2.IsMaxLength(44))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "IcPayerAddress2", Message = ConstantStore.MAXLENGTH + "44 CHARACTERS" });

                    }
                }
                // id		payer city state zipcode 	Required 	44	Var Char 	No rules are applicable 
                if (!row.IdPayerCityStateZipcode.IsMaxLength(44))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "IdPayerCityStateZipcode", Message = ConstantStore.MAXLENGTH + "44 CHARACTERS" });
                }

                // 1	 PAYER TYPE		Required	8	Var Char 	Only one word. 
                if (!row._1PayerType.IsNullString())
                {
                    if (!row._1PayerType.IsAWord())
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "1_PayerType", Value = row._1PayerType, Message = ConstantStore.REQUIRED_WORD });

                    }
                    else if (!row._1PayerType.IsMaxLength(8))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "1_PayerType", Message = ConstantStore.MAXLENGTH + "8 CHARACTERS" });
                    }
                }
                else
                {
                    this.Row.Errors.Add(new BusinessError { Field = "1_PayerType", Value = row._1PayerType, Message = "Payer Type" + ConstantStore.IS_REQUIRED });
                }

                // 1a	Insured I.D number		Required	29	Var Char 	No rules are applicable 
                if (!row._1aInsuredIdNumber.IsNullString())
                {
                    if (!row._1aInsuredIdNumber.IsMaxLength(29))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_1aInsuredIdNumber", Message = "Insured Id should not exceed 29 characters." });
                    }
                }
                else
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_1aInsuredIdNumber", Message = "Insured Id" + ConstantStore.IS_REQUIRED });
                }
                #endregion BusinessRulesCovered


                // 2a	Patient’s Name	Last Name 	Conditional	28	Var Char 	
                // Honorofics - (Mrs, Mr...) are not allowed.  
                // If the current field is empty and column 6 is "self", 
                // then 4a-4d should be copied in current fields 2a-2d. 
                if (row._2aLastName.IsNullString() && row._2bSuffix.IsNullString()
                        && row._2cFirstName.IsNullString()
                        && row._2dMiddleName.IsNullString()
                        )
                {
                    if (row._6PatientRelationshipToInsured != "SELF")
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_2aPatientName", Value = "NULL", Message = "2aPatientName is empty and relationship to insured should be SELF" });
                    }
                    else // SELF
                    {
                        row._2aLastName = row._4aLastName;
                        row._2cFirstName = row._4cFirstName;
                        row._2dMiddleName = row._4dMiddleName;
                        row._2bSuffix = row._4bSuffix;
                    }
                }
                else
                {
                    if (!row._2aLastName.IsNullString())
                    {
                        if (!row._2aLastName.IsMaxLength(28))
                        {
                            this.Row.Errors.Add(new BusinessError { Field = "_2aLastName", Message = ConstantStore.MAXLENGTH + "28 characters." });
                        }
                    }
                    if (!row._2bSuffix.IsNullString())
                    {
                        if (!row._2bSuffix.IsMaxLength(28))
                        {
                            this.Row.Errors.Add(new BusinessError { Field = "_2bSuffix", Message = ConstantStore.MAXLENGTH + "28 characters." });
                        }
                    }
                    if (!row._2cFirstName.IsNullString())
                    {
                        if (!row._2cFirstName.IsMaxLength(28))
                        {
                            this.Row.Errors.Add(new BusinessError { Field = "_2cFirstName", Message = ConstantStore.MAXLENGTH + "28 characters." });
                        }
                    }
                    if (!row._2dMiddleName.IsNullString())
                    {
                        if (!row._2dMiddleName.IsMaxLength(28))
                        {
                            this.Row.Errors.Add(new BusinessError { Field = "_2dMiddleName", Message = ConstantStore.MAXLENGTH + "28 characters." });
                        }
                    }
                }

                // 3a	Patient's birth date  SEX	MM	Required	2	INT	No rules are applicable 
                string birthdateMMDDYY = row._3aMm.GetValueOrDefault()
                        + "/" + row._3bDd.GetValueOrDefault()
                         + "/" + row._3cYyyy.GetValueOrDefault();
                try
                {
                    birthdateMMDDYY.IsDateTime("M/d/yyyy");
                }
                catch (Exception ex)
                {
                    this.Row.Errors.Add(new BusinessError { Field = "3birthdateMMDDYY", Value = birthdateMMDDYY, Message = ConstantStore.NOT_A_DATE });
                }

                if (!row._3dGender.IsNullString())
                {
                    if (!row._3dGender.IsMaxLength(6))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_3dGender", Value = row._3dGender, Message = ConstantStore.MAXLENGTH + "6 characters." });
                    }
                }
                //TODO:ask about HOnorofics are not allowed.
                // 4a	Insured’s Name	Last Name 	Required 	29	Var Char 	Honorofics are not allowed 

                if (!row._4aLastName.IsMaxLength(29))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_4aLastName", Value = row._4aLastName, Message = ConstantStore.MAXLENGTH + "29 characters." });
                }
                if (!row._4bSuffix.IsNullString())
                {
                    if (!row._4bSuffix.IsMaxLength(29))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_4bSuffix", Value = row._4bSuffix, Message = ConstantStore.MAXLENGTH + "29 characters." });
                    }
                }
                if (!row._4cFirstName.IsMaxLength(29))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_4cFirstName", Value = row._4cFirstName, Message = ConstantStore.MAXLENGTH + "29 characters." });
                }
                if (!row._4dMiddleName.IsNullString())
                {
                    if (!row._4dMiddleName.IsMaxLength(29))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_4dMiddleName", Value = row._4dMiddleName, Message = ConstantStore.MAXLENGTH + "29 characters." });
                    }
                }

                //5a	Patient Address	Street Address	
                //Conditional	28	Var Char 	
                //No special characters are allowed. 
                //If 7a is filled and 5a is left blank then data in 7a should be copied to 5a
                if (!row._7aStreetAddress.IsNullString() && !row._7aStreetAddress.HasAnySpecialChars())
                {
                    // 7a filled and 5a is empty, then its a business error 

                    // (as it should have been copied by the claim form)
                    if (row._5aStreetAddress.IsNullString() ||
                     row._5bCity.IsNullString() ||
                       row._5cState.IsNullString() ||
                       row._5dZipcode.IsNullString() ||
                        !row._5eTelephoneAreacode.HasValue ||
                         !row._5fTelephonePhoneNumber.HasValue
                    )
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_5aStreetAddress", Value = "NULL", Message = "If 7a is filled and 5a is left blank then data in 7a should be copied to 5a" });
                    }

                }
                else // null
                {
                    //7a	Insured Address	Street Address	Required	28	Var Char 	No special characters are allowed
                    this.Row.Errors.Add(new BusinessError { Field = "_7aStreetAddress", Value = "NULL", Message = ConstantStore.IS_REQUIRED + " or " + ConstantStore.HAS_SPECIAL_CHARS });
                }

                if (!row._5aStreetAddress.IsNullString() && row._5aStreetAddress.HasAnySpecialChars())
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_5aStreetAddress", Value = row._5aStreetAddress, Message = ConstantStore.IS_REQUIRED });
                }

                if (!row._6PatientRelationshipToInsured.IsNullString()
                    && !row._6PatientRelationshipToInsured.IsMaxLength(6))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_6PatientRelationshipToInsured", Value = row._6PatientRelationshipToInsured, Message = ConstantStore.MAXLENGTH + ": 6chars" });
                }
                //8- Reserved for NUCC Use  // no validations 
                // 9-a	Other Insured details 	Last Name 	
                // Conditional	28	Var Char 	Honorofics are not allowed. 
                // If 11D is filled is yes. Then this field is mandatory
                // Other insurance details...
                if (string.Compare(row._11dAnotherHealthBenefitPlan, "yes", true) == 0
                    && (row._9ALastName.IsNullString() || row._9CFirstName.IsNullString()
                    || row._9dInsuranceplanName.IsNullString()))
                {
                    // if yes, but not filled other info.. error 
                    this.Row.Errors.Add(new BusinessError { Field = "_9FullName", Value = "NULL", Message = ConstantStore.IS_REQUIRED });
                }

                if (row._10bAutoAccident.IsNullString())
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_10bAutoAccident", Value = "NULL", Message = ConstantStore.IS_REQUIRED });
                }
                // 10b-a		Auto Accident ( Place)	Conditional	2	Var Char 
                // If 10b is yes then 10b(1) should be filled 
                if (string.Compare(row._10bAutoAccident, "yes", true) == 0 && row._10bAAutoAccidentPlace.IsNullString())
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_10bAAutoAccidentPlace", Value = "NULL", Message = ConstantStore.IS_REQUIRED });
                }

                if (row._10aEmployment.IsNullString())
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_10aEmployment", Value = "NULL", Message = ConstantStore.IS_REQUIRED });
                }
                if (row._10cOtherAccident.IsNullString())
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_10cOtherAccident", Value = "NULL", Message = ConstantStore.IS_REQUIRED });
                }


                // 10d Claim codes(Designated by NUCC)       optional    19  Var Char    No special characters are allowed
                if (!row._10dClaimCodes.IsNullString() && row._10dClaimCodes.HasAnySpecialChars())
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_10dClaimCodes", Value = row._10dClaimCodes, Message = ConstantStore.HAS_SPECIAL_CHARS });
                }

                // 11	Insured’s Policy Group or FECA Number	
                // Conditional	29	Var Char 	
                // If 4a-4d is filled then 11 has to be filled 
                if (!row._4aLastName.IsNullString() && !row._4cFirstName.IsNullString()
                    && row._11InsuredsPolicyNumber.IsNullString()
                    )
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_11InsuredsPolicyNumber", Value = "NULL", Message = "If 4a-4d is filled then 11 has to be filled" });
                }
                // WARNING.. THIS IS VALIDATION, NOT SUPPOSED TO FILL ANY DATA!!!
                // 11a-a	Insured’s Date of Birth and Sex	MM	
                // Conditional	2	INT	If 4 is filled and 6 is "self", 
                // then 3a-3d should be same as 11a-a to 11a-d. else it can be left blank
                if (!row._4aLastName.IsNullString() && !row._4cFirstName.IsNullString()
                    && row._6PatientRelationshipToInsured == "SELF")
                {
                    if (row._11aAMm != row._3aMm ||
                    row._11aBDd != row._3bDd ||
                    row._11aCYyyy != row._3cYyyy ||
                    row._11aDGender != row._3dGender)
                    {// throw business error!

                        this.Row.Errors.Add(new BusinessError { Field = "11aStreetAddress", Value = "NULL", Message = "If 4 is filled and 6 is SELF, then 3a-3d should be same as 11a-a to 11a-d" });
                    }
                }


                // 12-a	Patient’s or Authorized Person’s Signature	Signature 	
                // Required 	100	Var Char 	
                // If left blank please input " No Signature on File". 
                // Else " SOF", "Signature on File" or legal signature ( hand written). 
                // If hand written then the link to the image has to be given. 
                if (row._12ASignatureUrl.IsNullString())
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_12ASignatureUrl", Value = "NULL", Message = ConstantStore.IS_REQUIRED });
                }
                var tempSignDate = row._12BAMm + "/" + row._12BBDd + "/" + row._12BCYyyy;
                if (row._12BAMm.HasValue && row._12BBDd.HasValue && row._12BCYyyy.HasValue)
                {
                    if (!tempSignDate.IsDateTime("M/d/y"))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "SignatureDate", Value = tempSignDate, Message = ConstantStore.NOT_A_DATE });
                    }
                }
                if (row._13InsuredsAuthorizedSignatureUrl.IsNullString())
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_13InsuredsAuthorizedSignatureUrl", Value = "NULL", Message = ConstantStore.IS_REQUIRED });
                }


                var tempDateCurrentIllness = row._14AMm + "/" + row._14BDd + "/" + row._14CYyyy;
                if (!tempDateCurrentIllness.IsDateTime("M/d/yyyy"))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "DateOfCurrentIllness", Value = tempSignDate, Message = ConstantStore.NOT_A_DATE });
                }
                var _14DFullQualifierList = new List<int> { 431, 484 };
                // 14 - d        qualifier Required    3   INT Only 431 or 484 is allowed
                if (!row._14DQualifier.HasValue || !_14DFullQualifierList.Contains(row._14DQualifier.Value) || !_14DFullQualifierList.Contains(row._14DQualifier.Value))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_14DQualifier", Value = row._14DQualifier.ToString(), Message = "Qualifier is Invalid. Only 431 or 484 is allowed." });
                }

                // 15-a	other date	MM	Required	2	INT	No business rule needed 

                var OtherDate = row._15AMm + "/" + row._15BDd + "/" + row._15CYyyy;
                if (OtherDate != "//" && !OtherDate.IsDateTime("M/d/yyyy"))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "15OtherDate", Value = OtherDate, Message = ConstantStore.NOT_A_DATE });
                }
                var tempQualifier = new List<int> { 454, 304, 453, 439, 455, 471, 090, 091, 444 };
                // 15-d		qualifier	Required	3	INT	454, 304, 453, 439, 455, 471,090,091,444 are allowed
                if (!row._15DQualifier.HasValue || !tempQualifier.Contains(row._15DQualifier.Value))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_15DQualifier", Value = row._15DQualifier.ToString(), Message = "Qualifier is Invalid. Only one among 454, 304, 453, 439, 455, 471, 090, 091, 444 is allowed." });
                }

                // 16-a,b,c	Dates patient unable to work (from date)	MM	Optional	2	INT	No business rule needed 

                var patientUnableWorkFrom = row._16AMm + "/" + row._16BDd + "/" + row._16CYyyy;
                if (patientUnableWorkFrom != "//" && !patientUnableWorkFrom.IsDateTime("M/d/yyyy"))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "patientUnableWorkFrom", Value = patientUnableWorkFrom, Message = ConstantStore.NOT_A_DATE });
                }

                // 16-a,b,c	Dates patient unable to work (from date)	MM	Optional	2	INT	No business rule needed 

                var patientUnableWorkTo = row._16AAMm + "/" + row._16ABDd + "/" + row._16ACYyyy;
                if (patientUnableWorkTo != "//" && !patientUnableWorkTo.IsDateTime("M/d/yyyy"))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "patientUnableWorkTo", Value = patientUnableWorkTo, Message = ConstantStore.NOT_A_DATE });
                }

                // 17  Enter name of referring physician or provider.qualifier 
                // Required    2   Var Char    Only DN, DK, DQ

                var _17Qualifier = new List<string> { "DN", "DK", "DQ" };

                if (row._17Qualifier.IsNullString() || !_17Qualifier.Contains(row._17Qualifier))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_17Qualifier", Value = row._17Qualifier.ToString(), Message = "Qualifier is Invalid. Valid values are DN or DK or DQ." });
                }

                if (row._17AName.IsNullString() || row._17AName.HasAnySpecialChars())
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_17AName", Value = row._17AName.ToString(), Message = "_17AName is Invalid" });
                }

                // 17a-a		Qualifier	Conditional	2	Var Char 	
                // If 17b is empty then current field has to be filled. Only following characters  0B, 1G,G2, LU are allowed
                var _17aAQualifier = new List<string> { "0B", "1G", "G2", "LU" };
                // 17b	NPI of the referring provider	ID number	Optional	10	Var Char 
                // No business rule needed 

                if (row._17bIdNumber.IsNullString() && (row._17aAQualifier.IsNullString() || _17aAQualifier.Contains(row._17aAQualifier)))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_17aAQualifier", Value = row._15DQualifier.ToString(), Message = "_17aAQualifier is required, as 17b is empty " });
                }
                else // sensible qualifier
                {
                    // 17a-b		ID number	Conditional	17	Var Char 	
                    // if 17a-a is filled then current field has to be filled 
                    if (row._17aBIdNumber.IsNullString())
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_17aBIdNumber", Value = row._17aBIdNumber.ToString(), Message = "_17aAQualifier is valid but _17aBIdNumber is empty" });
                    }
                }

                // 18-a	Hospitalization dates related to current services (from date)	MM	Optional	2	INT	No business rule needed 
                var currentServiceFrom = row._18AMm + "/" + row._18BDd + "/" + row._18CYyyy;
                if (currentServiceFrom != "//" && !currentServiceFrom.IsDateTime("M/d/yyyy"))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "currentServiceFrom", Value = currentServiceFrom, Message = ConstantStore.NOT_A_DATE });
                }

                var currentServiceTo = row._18AAMm + "/" + row._18ABDd + "/" + row._18ACYyyy;
                if (currentServiceTo != "//" && !currentServiceTo.IsDateTime("M/d/yyyy"))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "currentServiceTo", Value = currentServiceTo, Message = ConstantStore.NOT_A_DATE });
                }
                var _19QualifierCodes = new List<string> { "LU", "N5", "SY", "X5", "ZZ" };

                var _19ReportingTypeCodes = new List<string>
                { "03","04","05","06","07","08","09","10",
                    "11","13","15","21","A3",
                 "A4","AM","AS","B2","B3","B4","BR","BS","BT","CB","CK","CT","D2",
                 "DA","DB","DG","DS","EB","DJ","HC","HR","I5","IR","M1","MT","NN",
                  "OB","OC","OD","OE","OX","OZ","P4","P5","PE","PN","PO","PQ","PY",
                  "PZ","RB","RR","RT","RX","SG","V5","XP" };

                var _19TransmissionCodes = new List<string> { "AA", "BM" };

                /*
                 * 19	Additional Claim Information		Required 	71	Var Char 

                 Only spaces alphabets and numbers are allowed. 
                 Only the codes in "codes for 19 sheet should be there". 
                 
                 
               
                 All claim codes in this field should follow the first 2(below) rules
                 */
                /*
                 If first 3 letters are "PWK" then following 2 (4,5) 
                letters should be only only from "reporting type codes". 
                 */
                var claimCodes = row._19AdditionalClaimInformation.Split(' ');
                foreach (var claimcode in claimCodes)
                {
                    //   If first 2 letters are qualifier codes then  no rules apply Users 
                    // can write multiple claim ID each one seperated by a space.

                    if (claimcode.Length >= 2 &&
                    _19QualifierCodes.Contains(claimcode.Substring(0, 2).ToUpper())
                    )
                    {
                        // no rules
                    }

                    else if (claimcode.Length >= 5 &&
                    claimcode.Substring(0, 3).ToUpper() == "PWK")
                    {
                        //if not part of reportingcode...then error 
                        if (!_19ReportingTypeCodes.Contains(claimcode.Substring(3, 2).ToUpper()))
                        {
                            this.Row.Errors.Add(new BusinessError { Field = "_19AdditionalClaimInformation", Value = claimcode, Message = "First 3 three letters PWK, but not found valid reporting code" });
                        }
                        else // valid report code 
                        {

                            // The next following letters should be only transmission codes.
                            if (!_19TransmissionCodes.Contains(claimcode.Substring(5, 2).ToUpper()))
                            {
                                this.Row.Errors.Add(new BusinessError { Field = "_19AdditionalClaimInformation", Value = claimcode, Message = "First 3 three letters PWK, 2 letters reporting but not found valid transmission code" });
                            }

                        }
                    }

                } // end of foreach 


                // 20	Outside Lab	YES OR NO 	Optional	3	Var Char 
                // No business rule needed 

                // 20-a		Charges (dollars)	Conditional	8	INT	
                //If yes in 20 column then this has to be filled. Only digits are allowed 
                // 20-b		charges (cents)	conditional	2	int	
                // If yes in 20 column then this has to be filled. Only digits are allowed 

                if (row._20YesOrNo.ToUpper() == "YES")
                {
                    var OutsideCharges = row._20AChargesDollars + "." + row._20BChargesCents;
                    var outsideAmount = 0.00;
                    // not a proper amount
                    if (!double.TryParse(OutsideCharges, out outsideAmount))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "OutsideCharges", Value = OutsideCharges, Message = "OutsideCharges are not valid" });
                    }
                }
                // only 9 and 0 are allowed
                var _21ICDCollection = new List<int> { 0, 9 };
                if (row._21IcdIndicator.HasValue && !_21ICDCollection.Contains(row._21IcdIndicator.Value))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "OutsideCharges", Value = row._21IcdIndicator.Value.ToString(), Message = "only 9 and 0 are allowed" });
                }

                // 21		full form	Required	9	Var Char 	If 9, then ICD-9-CM else if 0 then ICD-10-CM
                if (row._21IcdIndicator.HasValue)
                {
                    //TODO: FULLFORM column missing 
                    //if (row._21IcdIndicator == 9 && row._21)
                    //{
                    //    this.Row.Errors.Add(new BusinessError { Field = "OutsideCharges", Value = row._21IcdIndicator.Value.ToString(), Message = "only 9 and 0 are allowed" });
                    //}

                }

                /*
                 22-a	Resubmission Code	qualifier	optional	11	Var Char 	
                 The first character should be 7 or 8. It can be followed by a maximum of 10 digits 
22-b		original ref.no	conditional	18	Var Char 	
No business rule needed 

                 */
                // null or 7/8 start char
                if (!row._22AReSubmissionCodeQualifier.IsNullString() && (row._22AReSubmissionCodeQualifier.Substring(0, 1) != "7"
                    && row._22AReSubmissionCodeQualifier.Substring(0, 1) != "8"))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_22AReSubmissionCodeQualifier", Value = row._22AReSubmissionCodeQualifier, Message = "The first character should be 7 or 8" });
                }
                else if (!row._22AReSubmissionCodeQualifier.IsMaxLength(11))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_22AReSubmissionCodeQualifier", Value = row._22AReSubmissionCodeQualifier, Message = "It can be followed by a maximum of 10 digits" });
                }

                if (!row._22BOriginalRefNo.IsNullString() && !row._22BOriginalRefNo.IsMaxLength(18))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_22BOriginalRefNo", Value = row._22BOriginalRefNo, Message = "Maximum of 18 digits" });
                }

                // 23	Prior Authorization Number		Required 	29	Var Char 	
                // No business rule needed 
                if (!row._23PriorAuthorizationNumber.IsMaxLength(29))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_23PriorAuthorizationNumber", Value = row._23PriorAuthorizationNumber, Message = "Maximum of 29 digits" });
                }
                // Made ClaimID is unique across the process, so  24InsuredId number ignored.

                // 25-a	Federal Tax ID 	type	Required 	3	Var Char 	
                // Only SSN or EIN should be there 

                if (row._25AType.ToUpper() != "SSN" && row._25BIdNumber.ToUpper() != "EIN")
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_25AType", Value = row._25AType, Message = "Only SSN or EIN should be there " });
                }

                if (!row._25BIdNumber.IsMaxLength(15))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_25BIdNumber", Value = row._25BIdNumber, Message = "Max 15 digits" });
                }

                // 26	Patient Account Number 		Required 	14	Int	No business rule needed 

                if (!row._26PatientAccNumber.Value.ToString().IsMaxLength(15))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_26PatientAccNumber", Value = row._26PatientAccNumber.Value.ToString(), Message = "Max 15 digits" });
                }

                // 27	Accept Assignment 		Required 	3	Var Char 	Either Yes or No
                var _27AcceptAssignmentArray = new List<string> { "yes", "no" };
                if (!_27AcceptAssignmentArray.Contains(row._27AcceptAssignment.ToLower()))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_27AcceptAssignment", Value = row._27AcceptAssignment, Message = "Valid values are Yes or No." });
                }

                // 28-a	Total Charges (Total Claim Amount)	dollars 	
                // Required	6	INT	No business rule needed 
                // 28-b		cents	Required 	2	INT	No business rule needed 
                var totalClaimAmount = row._28ADollars + "." + row._28BCents;
                var tcAmount = 0.00;
                // not a proper amount
                if (!double.TryParse(totalClaimAmount, out tcAmount))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "TotalClaimAmount", Value = totalClaimAmount, Message = "TotalClaimAmount is not valid" });
                }

                // 29-a	Amount Paid	dollars 	Optional	6	INT	No business rule needed 
                // 29-b		cents	Optional	2	INT	No business rule needed 
                var paidAmount = row._28ADollars + "." + row._28BCents;
                var pAmount = 0.00;
                // not a proper amount
                if (!double.TryParse(paidAmount, out pAmount))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "paidAmount", Value = totalClaimAmount, Message = "paidAmount is not valid" });
                }
                // 30-a, 30-b should not be filled

                // 31-a	Patient’s or Authorized Person’s Signature	Signature 	
                // Required 	100	Var Char 	 " SOF", "Signature on File" or legal signature ( hand written). If hand written then the link to the image has to be given. 
                var patientSignDate = row._31BAMm + "/" + row._31BBDd + "/" + row._31BCYyyy;
                if (!patientSignDate.IsDateTime("M/d/yyyy"))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "patientSignDate", Value = patientSignDate, Message = ConstantStore.NOT_A_DATE });
                }

                // 32-a	service facility location	provider name 	
                // Required 	29	Var Char 	No rules are applicable 

                // 32-b		 provider address 	Required 	29	Var Char 	
                // No rules are applicable 

                // 32-c		 city state zipcode 	
                // Required 	29	Var Char 	No rules are applicable 

                // 32a		National Provider Identifier number	
                // Required	10	Var Char 	10 digit number cannot be left blank
                if (!row._32aNationalProviderIdentifierNumber.IsMaxLength(10))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_32aNationalProviderIdentifierNumber", Value = row._32aNationalProviderIdentifierNumber, Message = "Max 10 digits" });
                }
                // 32b		Payer-assigned identifier of the Billing Provider	
                // Required	14	Var Char 	first 2 letters should be only 0B, G2, LU
                var tempProvider = row._32bPayerAssignedIdentifierOfBillingProvider.Substring(0, 2);
                var temparray = new List<string> { "0B", "G2", "LU" };
                if (!temparray.Contains(tempProvider) ||
                    !row._32bPayerAssignedIdentifierOfBillingProvider.IsMaxLength(14))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_32bPayerAssignedIdentifierOfBillingProvider", Value = row._32bPayerAssignedIdentifierOfBillingProvider, Message = "Invalid data" });
                }
                /*
                 33-a	billing provider Info	Area Code	Conditional	3	Int	No rules are applicable 
33-b		Phone Number	Optional	10	Int	No rules are applicable 
33-c		billing provider name 	Required 	29	Var Char 	No rules are applicable 
33-d		billing provider address 	Required 	29	Var Char 	No rules are applicable 
33-e		billing provider city state zipcode 	Required 	29	Var Char 	No rules are applicable 
                 */
                if (row._33AAreaCode.HasValue && !row._33AAreaCode.Value.ToString().IsMaxLength(3))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_33AAreaCode", Value = row._33AAreaCode.Value.ToString(), Message = "Max 3 digits" });
                }
                //else if (row._33BPhoneNumber.HasValue)
                //{
                //    this.Row.Errors.Add(new BusinessError { Field = "_33BPhoneNumber", Value = row._33BPhoneNumber.Value.ToString(), Message = "_33BPhoneNumber without areacode?" });
                //}

                //33a		National Provider Identifier number	Required	10	Var Char 	No rules are applicable 
                if (!row._33aNationalProviderIdentifierNumber.IsMaxLength(10))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_33aNationalProviderIdentifierNumber", Value = row._33aNationalProviderIdentifierNumber, Message = "Max 10 digits" });
                }

                //  33b		Payer-assigned identifier of the Billing Provider	Required	17	
                // Var Char    first 2 letters should be only 0B, G2, ZZ
                var tempProvider1 = row._33bPayerAssignedIdentifierOfBillingProvider.Substring(0, 2);
                var temparray1 = new List<string> { "0B", "G2", "ZZ" };
                if (!temparray1.Contains(tempProvider1) ||
                    !row._33bPayerAssignedIdentifierOfBillingProvider.IsMaxLength(17))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_332bPayerAssignedIdentifierOfBillingProvider", Value = row._33bPayerAssignedIdentifierOfBillingProvider, Message = "first 2 letters should be only 0B, G2, ZZ" });
                }
                // c,d,e
                if (!row._33CBillingProviderName.IsMaxLength(29))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_33CBillingProviderName", Value = row._33CBillingProviderName, Message = "Max 29 digits" });
                }

                if (!row._33DBillingProviderAddress.IsMaxLength(29))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_33DBillingProviderAddress", Value = row._33DBillingProviderAddress, Message = "Max 29 digits" });
                }

                if (!row._33EBillingproviderCityStateZipcode.IsMaxLength(29))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_33EBillingproviderCityStateZipcode", Value = row._33EBillingproviderCityStateZipcode, Message = "Max 29 digits" });
                }


                // 24 column Table business rules 
                foreach (var detailRow in row.Cms15002)
                {
                    // 24-X	Insured ID Number 		Required 	29	Var Char 	
                    // the value should be same as the value in 24 column of CMS1500 TABLE 
                    var _24aFrom = detailRow._24aAMm + "/" + detailRow._24aBDd + "/" + detailRow._24aCYyyy;
                    if (_24aFrom != "//" && !_24aFrom.IsDateTime("M/d/y"))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "currentServiceFrom", Value = _24aFrom, Message = ConstantStore.NOT_A_DATE });
                    }

                    var _24aTo = detailRow._24aDMm + "/" + detailRow._24aEDd + "/" + detailRow._24aFYyyy;
                    if (_24aTo != "//" && !_24aTo.IsDateTime("M/d/y"))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "currentServiceTo", Value = _24aTo, Message = ConstantStore.NOT_A_DATE });
                    }

                    // 24b	Place of Service		Required	2	INT	Only 2 digits 
                    if (!detailRow._24bPlaceOfService.HasValue ||
                            (detailRow._24bPlaceOfService.HasValue && !detailRow._24bPlaceOfService.Value.ToString().IsMaxLength(2)))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_24bPlaceOfService", Value = detailRow._24bPlaceOfService.Value.ToString(), Message = "Only 2 digits" });
                    }

                    var _24CQualifierList = new List<string> { "Y", "N" };
                    // 24c	EMG		Optional	1	Var char	Only letter Y or N is allowed
                    if (detailRow._24cEmg.IsNullString() || !_24CQualifierList.Contains(detailRow._24cEmg))

                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_24cEmg", Value = detailRow._24cEmg, Message = "Only letter Y or N is allowed" });
                    }

                    // 24d-a	CPT/HCPCS		Required 	6	INT	No business rule needed 
                    if (detailRow._24dACptHcpcs.HasValue && !detailRow._24dACptHcpcs.Value.ToString().IsMaxLength(6))

                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_24dACptHcpcs", Value = detailRow._24dACptHcpcs.Value.ToString(), Message = "Max 6 digits" });
                    }

                    // 24d-b	Modifier		Required	8	int	
                    // Count of number of digits should only be a even number. 
                    if (detailRow._24dBModifier.HasValue && detailRow._24dBModifier.Value.ToString().Length % 2 != 0)

                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_24dBModifier", Value = detailRow._24dBModifier.Value.ToString(), Message = "Count of number of digits should only be a even number" });
                    }

                    //TODO: 24E	Diagnostic Pointer 		Required 	4	Var char	

                    // The ending alphabets of  the fields from 21-A  to 21-L 
                    // which are filled have to written. Maximum of only 4 characters. 

                    PropertyInfo[] cms1500_1Properties2 = typeof(Cms15001).GetProperties();
                    foreach (PropertyInfo property in cms1500_1Properties2)
                    {
                        foreach (var attrib in property.CustomAttributes)
                        {
                            var fieldValue = property.GetValue(row);
                            // if it has Display attribute, then if value is null or invalid, add error
                            if (attrib.AttributeType == typeof(System.ComponentModel.DataAnnotations.DisplayAttribute))
                            {
                                //Minimum of 4 characters(Apart from Dot).Maximum of 7 characters((Apart from Dot)). 
                                // After 3rd character there must be a dot(.).Always starts with Alphabets, 
                                // except "U" Alphabet

                                if (property.PropertyType == typeof(string) && fieldValue != null)
                                {
                                    // first letter should be alphabet
                                    var IsfirstLetter = char.IsLetter(fieldValue.ToString().FirstOrDefault());
                                    if (
                                        !fieldValue.ToString().IsNullString()
                                        && (!fieldValue.ToString().IsMaxLength(8) //Maximum of 7 + dot characters
                                        || fieldValue.ToString().IndexOf(".") != 3
                                        || (!IsfirstLetter)
                                        || (IsfirstLetter && fieldValue.ToString().FirstOrDefault() == 'U')
                                        )
                                        )
                                    {
                                        this.Row.Errors.Add(new BusinessError { Field = property.Name, Value = fieldValue.ToString(), Message = "Minimum of 4 characters(Apart from Dot).Maximum of 7 characters((Apart from Dot))" });
                                    }
                                }

                            }
                        }

                    }


                    //  charges Optional    6   INT No business rule needed
                    // 24F/24ff	charges 		Optional	6	INT	No business rule needed 
                    var _24FAmountstring = detailRow._24fCharges + "." + detailRow._24fFCharges;
                    var _24FAmount = 0.00;
                    // not a proper amount
                    if (!double.TryParse(_24FAmountstring, out _24FAmount))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "TotalClaimAmount", Value = _24FAmountstring, Message = "_24FAmount  is not valid" });
                    }

                    // 24G	Days or Units 		Optional	3	Float 	
                    // No business rule needed 

                    /*
                    24H-a	EPSDT Family plan 	EPSDT code 	oPTIONAL	2	
                    Var char	AV, S2, ST, NU are allowed
                    24H-b		Yes or no	Conditional	1	Var char	
                    Only Y is allowed. Fi 24H-a is filled. Then current field should be empty
                     * */

                    var _24Hvalues = new List<string> { "AV", "S2", "ST", "NU" };
                    if ((!detailRow._24hAEpsdtCode.IsNullString()))
                    {
                        if (!_24Hvalues.Contains(detailRow._24hAEpsdtCode))
                        {
                            this.Row.Errors.Add(new BusinessError { Field = "_24hAEpsdtCode", Value = detailRow._24hAEpsdtCode, Message = "Invalid data, possible values AV, S2, ST, NU are allowed" });
                        }

                    }
                    else //sensible data 
                    {
                        // Only Y is allowed. if 24H-a is filled. Then current field should be empty
                        if (!detailRow._24hBYesOrNo.IsNullString())
                        {
                            if (detailRow._24hBYesOrNo.ToLower() != "y")
                                this.Row.Errors.Add(new BusinessError { Field = "_24hBYesOrNo", Value = detailRow._24hBYesOrNo, Message = "Invalid data, Only Y is allowed." });
                        }
                    }

                    /*  

              

                    */

                    //  24I Qual        Optional    2   Var char No business rule needed
                    if (!detailRow._24iQual.IsNullString() && !detailRow._24iQual.IsMaxLength(2))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_24iQual", Value = detailRow._24iQual, Message = "Max 2 chars" });

                    }
                    //24J-a	Rendering provider ID 		Optional	17	Var char	No business rule needed 
                    if (!detailRow._24jARenderingProviderId.IsNullString() && !detailRow._24jARenderingProviderId.IsMaxLength(17))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_24jARenderingProviderId", Value = detailRow._24jARenderingProviderId, Message = "Max 17 chars" });

                    }
                    //   24j-b	Rendering provider ID 		Optional	10	Var char	No business rule needed 
                    if (!detailRow._24jBRenderingProviderId.IsNullString() && !detailRow._24jBRenderingProviderId.IsMaxLength(17))
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_24jBRenderingProviderId", Value = detailRow._24jBRenderingProviderId, Message = "Max 17 chars" });

                    }
                } //end for // 24 column Table business rules 


                // At the end of all validations
                SetFinalStatus();
            }
            catch (Exception e)
            {
                SetFinalStatus(e);
                // Suppress exception for continuation
                //throw new Exception("Error in Executing, look inner exception for details", e);
            }
            finally
            {
                // execution state reached end...
                IsExecutionCompleted = true;
            }
        }

        public void SetFinalStatus(Exception e = null)
        {
            int executionStatus = -1;

            // if there is an exception, ignore all errors, set -1
            if (e != null)
            {
                row.ParserErrorCsv = e.Message;
                row.ExecutionStatus = executionStatus;
                // execution state reached end...
                IsExecutionCompleted = true;
                return;// exit
            }

            // At the end 
            //row.ParserErrorCsv = String.Join(",", this.Row.Errors.Select(x => x.ToString()).ToArray());
            row.ParserErrorCsv = JsonConvert.SerializeObject(this.Row.Errors);

            int mandatoryErrorCount = this.Row.Errors.Select(x => x.GetType() == typeof(MandatoryError)).Count();
            int confidenceErrorCount = this.Row.Errors.Select(x => x.GetType() == typeof(ConfidenceError)).Count();
            int businessErrorCount = this.Row.Errors.Select(x => x.GetType() == typeof(BusinessError)).Count();


            /*
             Key	Value 	Form Category
-1	Parser Error	 
1	Incomplete Form; Roll back required 	Roll back
2	Mandatory fields are filled; low confidence score; No business rule violation 	Verification required 
3	Mandatory fields are filled; high confidence score; business rule violation are present	Verification required 
4	Mandatory fields are filled; low confidence score; business rule violation are present  	Verification required 
5	Mandatory fields are filled; high confidence score; no business rule violation	Optional Verification
6	User validated the data 	 

                 */

            if (mandatoryErrorCount > 0)
            {
                executionStatus = 1; //1	Incomplete Form; Roll back required 	Roll back

            }

            //2	Mandatory fields are filled; low confidence score; 
            // No business rule violation 	Verification required 
            if (mandatoryErrorCount == 0 && businessErrorCount == 0
                && confidenceErrorCount > 0)
            {
                executionStatus = 2;

            }

            // 3	Mandatory fields are filled; high confidence score; 
            // business rule violation are present	Verification required 
            if (mandatoryErrorCount == 0 && confidenceErrorCount == 0
                && businessErrorCount > 0)
            {
                executionStatus = 3;

            }

            // 4   Mandatory fields are filled; low confidence score; 
            // business rule violation are present Verification required
            if (mandatoryErrorCount == 0 && confidenceErrorCount > 0
                && businessErrorCount > 0)
            {
                // 3 - Not Completed and Verified
                executionStatus = 4;

            }

            // 5	Mandatory fields are filled; high confidence score; 
            // no business rule violation	Optional Verification
            if (mandatoryErrorCount == 0 && confidenceErrorCount == 0
                && businessErrorCount == 0)
            {
                // 4- Not Completed and Not Verified 
                executionStatus = 5;
            }

            row.ExecutionStatus = executionStatus;
            // execution state reached end...
            IsExecutionCompleted = true;

        }
    }




}
