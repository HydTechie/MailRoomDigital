using System;

using System.Linq;

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
            try
            {
                int executionStatus = 0;  //  1- Complete & Verified
                                          // 2- Completed But not Verified
                                          // 3 - Not Completed and Verified
                                          // 4- Not Completed and Not Verified 
                const string REQUIRED_ONLY = "required";
                const string REQUIRED_WORD = "required and should be a single word";
                const string MAXLENGTH = "should not exceed maxlength";
                const string NOT_A_DATE = "Not a Valid date mm/dd/yyyy";
                const string HAS_SPECIAL_CHARS = "Special Chars not allowed";
                //TODO: write string extensions.. 
                //StringBuilder errors = new StringBuilder();
                //Business Rules 

                // IF engine threshold is 90 
                // TODO: confidence Level?!
                //if (row.?? < engConfig.ConfidenceLevelThreshold)
                //{
                //    this.row.Errors.Add(new BusinessError { Field = "ConfidenceLevel", Message = "Confidence Level is lower than threshold " + engConfig.ConfidenceLevelThreshold });
                //}

                // ia	payer name 	Required 	44	Var Char 	No rules are applicable 
                if (row.IaPayerName.IsNullString())
                {
                    this.Row.Errors.Add(new ValidationError { Field = "iaPayerName", Value = row.IaPayerName, Message = REQUIRED_ONLY });

                }
                else if (!row.IaPayerName.IsMaxLength(44))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "iaPayerName", Message = MAXLENGTH + "44chars" });

                }
                // ib		payer address 1	Required 	44	Var Char 	No rules are applicable 
                if (row.IbPayerAddress1.IsNullString())
                {
                    this.Row.Errors.Add(new ValidationError { Field = "IbPayerAddress1", Value = row.IbPayerAddress1, Message = REQUIRED_ONLY });

                }
                else if (!row.IaPayerName.IsMaxLength(44))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "IbPayerAddress1", Message = MAXLENGTH + "44chars" });

                }
                // ic		payer address 2	Optional 	44	Var Char 	No rules are applicable 
                if (row.IcPayerAddress2.IsNullString())
                {
                    this.Row.Errors.Add(new ValidationError { Field = "IbPayerAddress1", Value = row.IcPayerAddress2, Message = REQUIRED_ONLY });

                }
                else if (!row.IcPayerAddress2.IsMaxLength(44))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "IcPayerAddress2", Message = MAXLENGTH + "44chars" });

                }

                // id		payer city state zipcode 	Required 	44	Var Char 	No rules are applicable 
                if (row.IdPayerCityStateZipcode.IsNullString())
                {
                    this.Row.Errors.Add(new ValidationError { Field = "IdPayerCityStateZipcode", Value = "NULL", Message = REQUIRED_ONLY });

                }
                else if (!row.IdPayerCityStateZipcode.IsMaxLength(44))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "IdPayerCityStateZipcode", Message = MAXLENGTH + "44chars" });

                }
 
                
                // 1	 PAYER TYPE		Required	8	Var Char 	Only one word. 
                // GHP indicates group health plan, FBL indicates FECA BLKLUNG 
                if (row._1PayerType.IsNullString() ||  !row._1PayerType.IsAWord() )
                {
                    this.Row.Errors.Add(new ValidationError { Field = "1_PayerType", Value = row._1PayerType,  Message = REQUIRED_WORD });
                 
                }
                else if (!row._1PayerType.IsMaxLength(8))
                {
                    this.Row.Errors.Add(new BusinessError { Field = "1_PayerType", Message = MAXLENGTH + "8chars" });
                    
                }

                // 1a	Insured I.D number		Required	29	Var Char 	No rules are applicable 
                if (row._1aInsuredIdNumber.IsNullString())
                {
                    this.Row.Errors.Add(new ValidationError { Field = "_1aPatientInsuredId", Message = "_1aPatientInsuredId is required " });
                   
                }
                else if (!row._1PayerType.IsMaxLength(29))
                {
                    this.Row.Errors.Add(new ValidationError { Field = "_1aPatientInsuredId", Message = "InsuredId should not exceed 29 chars" });
                }

                // 2a	Patient’s Name	Last Name 	Conditional	28	Var Char 	
                // Honorofics - (Mrs, Mr...) are not allowed.  
                // If the current field is empty and column 6 is "self", 
                // then 4a-4d should be copied in current fields 2a-2d. 
                if(row._2aLastName.IsNullString() 
                        && row._2cFirstName.IsNullString() 
                        && row._2dMiddleName.IsNullString()
                        )
                {
                    if(row._6PatientRelationshipToInsured != "SELF")
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_2aPatientName", Value="NULL", Message = "2aPatientName is empty and Insured should be SELF" });
                    }
                    else // SELF
                    {
                        row._2aLastName = row._4aLastName;
                        row._2cFirstName = row._4cFirstName;
                        row._2dMiddleName = row._4dMiddleName;
                        row._2bSuffix = row._4bSuffix;
                    } 
                }

                // 3a	Patient's birth date  SEX	MM	Required	2	INT	No rules are applicable 
                string birthdateMMDDYY = row._3aMm.GetValueOrDefault()
                        + "/" + row._3bDd.GetValueOrDefault()
                         + "/" + row._3cYyyy.GetValueOrDefault();

                if (!birthdateMMDDYY.IsDateTime("MM/DD/YYY"))
                {
                    this.Row.Errors.Add(new ValidationError { Field = "3birthdateMMDDYY", Value= birthdateMMDDYY,  Message = NOT_A_DATE });

                }
                //TODO:ask about HOnorofics are not allowed.
                // 4a	Insured’s Name	Last Name 	Required 	29	Var Char 	Honorofics are not allowed 

                if (row._4cFirstName.IsNullString()
                       && row._4dMiddleName.IsNullString()
                       && row._4aLastName.IsNullString()
                       )
                {
                    this.Row.Errors.Add(new ValidationError { Field = "_4cFullName", Value = "NULL", Message = NOT_A_DATE });
                }

                //5a	Patient Address	Street Address	
                //Conditional	28	Var Char 	
                //No special characters are allowed. 
                //If 7a is filled and 5a is left blank then data in 7a should be copied to 5a
                if(!row._7aStreetAddress.IsNullString() && !row._7aStreetAddress.HasAnySpecialChars())
                {
                    // 7a filled and 5a is empty, then its a business error 
                    
                    // (as it should have been copied by the claim form)
                        if(row._5aStreetAddress.IsNullString() ||
                         row._5bCity.IsNullString() ||
                           row._5cState.IsNullString() ||
                           row._5dZipcode.IsNullString() ||
                            !row._5eTelephoneAreacode.HasValue ||
                             row._5fTelephonePhoneNumber.HasValue 
                        )
                    {
                        this.Row.Errors.Add(new BusinessError { Field = "_5aStreetAddress", Value = "NULL", Message = "If 7a is filled and 5a is left blank then data in 7a should be copied to 5a" });
                    }
                  
                }
                else // null
                {
                    //7a	Insured Address	Street Address	Required	28	Var Char 	No special characters are allowed
                    this.Row.Errors.Add(new ValidationError { Field = "_7aStreetAddress", Value = "NULL", Message = REQUIRED_ONLY + " or " + HAS_SPECIAL_CHARS});
                }
                
                if (!row._5aStreetAddress.IsNullString() && row._5aStreetAddress.HasAnySpecialChars())
                {
                    this.Row.Errors.Add(new ValidationError { Field = "_5aStreetAddress", Value = row._5aStreetAddress, Message = REQUIRED_ONLY });
                }

                if (!row._6PatientRelationshipToInsured.IsNullString() 
                    && !row._6PatientRelationshipToInsured.IsMaxLength(6))
                {
                    this.Row.Errors.Add(new ValidationError { Field = "_6PatientRelationshipToInsured", Value = row._6PatientRelationshipToInsured, Message = MAXLENGTH + ": 6chars" });
                }
                //8- Reserved for NUCC Use  // no validations 
                // 9-a	Other Insured details 	Last Name 	
                // Conditional	28	Var Char 	Honorofics are not allowed. 
                // If 11D is filled is yes. Then this field is mandatory
                // Other insurance details...
                if (string.Compare(row._11dAnotherHealthBenefitPlan,"yes", true) == 0 
                    && (row._9ALastName.IsNullString() || row._9CFirstName.IsNullString()
                    || row._9dInsuranceplanName.IsNullString()))
                    {
                    // if yes, but not filled other info.. error 
                    this.Row.Errors.Add(new BusinessError { Field = "_9FullName", Value = "NULL", Message = REQUIRED_ONLY});
                }

                if (row._10bAutoAccident.IsNullString())
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_10bAutoAccident", Value = "NULL", Message = REQUIRED_ONLY });
                }
                // 10b-a		Auto Accident ( Place)	Conditional	2	Var Char 
                // If 10b is yes then 10b(1) should be filled 
                if (string.Compare(row._10bAutoAccident, "yes", true) == 0 && row._10bAAutoAccidentPlace.IsNullString())
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_10bAAutoAccidentPlace", Value = "NULL", Message = REQUIRED_ONLY });
                }

                if (row._10aEmployment.IsNullString())
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_10aEmployment", Value = "NULL", Message = REQUIRED_ONLY });
                }
                if (row._10cOtherAccident.IsNullString())
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_10cOtherAccident", Value = "NULL", Message = REQUIRED_ONLY });
                }


                // 10d Claim codes(Designated by NUCC)       optional    19  Var Char    No special characters are allowed
                if (!row._10dClaimCodes.IsNullString() && row._10dClaimCodes.HasAnySpecialChars())
                {
                    this.Row.Errors.Add(new BusinessError { Field = "_10dClaimCodes", Value = row._10dClaimCodes, Message = HAS_SPECIAL_CHARS });
                }

                // 11	Insured’s Policy Group or FECA Number	
                // Conditional	29	Var Char 	
                // If 4a-4d is filled then 11 has to be filled 
                if(!row._4aLastName.IsNullString() && !row._4cFirstName.IsNullString()
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
                    if(row._11aAMm != row._3aMm || 
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
                if(row._12ASignatureUrl.IsNullString())
                {
                    this.Row.Errors.Add(new ValidationError { Field = "_12ASignatureUrl", Value = "NULL", Message = REQUIRED_ONLY });
                }
                

                // At the end 
                row.ParserErrorCsv = String.Join(",", this.Row.Errors.Select(x => x.ToString()).ToArray());

                int businessErrorCount = this.Row.Errors.Select(x => x.GetType() == typeof(BusinessError)).Count();
                int validationErrorCount = this.Row.Errors.Select(x => x.GetType() == typeof(ValidationError)).Count();

                // Completed and Verified
                if (validationErrorCount == 0 && businessErrorCount == 0)
                {
                    executionStatus = 1;
                }
                // Completed and NOT Verified
                else if (validationErrorCount == 0 && businessErrorCount > 0)
                {
                    executionStatus = 2;
                }

                // NOT Completed and Verified
                else if (validationErrorCount > 0 && businessErrorCount == 0)
                {
                    // 3 - Not Completed and Verified
                    executionStatus = 3;
                }

                // NOT Completed and NOT Verified
                else if (validationErrorCount > 0 && businessErrorCount > 0)
                {
                    // 4- Not Completed and Not Verified 
                    executionStatus = 4;
                }

               // row.ExecutionStatus = executionStatus;
                // execution state reached end...
                IsExecutionCompleted = true;
            }
            catch (Exception e)
            {
                IsExecutionCompleted = null;
                throw new Exception("Error in Executing, look inner exception for details", e);
            }
        }

        //public override Row Row { get; set; }
    }

    public class EngineConfiguration
    {
        public int ConfidenceLevelThreshold { get; set; }
    }

public class BusinessError : Error 
    {

    }

    public class ValidationError : Error
    {

    }
    public abstract class Error
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            if(Value.GetNullIfEmptyString() == null)
            {
                Value = "NULL";
            }
            return "Field:" + Field + "--> Value:" + Value + "; Message:" +  Message;
        }
    }
}
