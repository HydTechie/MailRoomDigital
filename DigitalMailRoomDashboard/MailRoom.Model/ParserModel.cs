using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MailRoom.Model
{
    // This is necessary for PARSER!
    public partial class Cms15001 : Row
    {
        public override string Key => ClaimId;
    }

    public partial class StagingClaimCms1500 : Row
    {
        public override string Key => ClaimId;
    }
    [NotMapped]
    public class Row
    {
        [NotMapped]
        public virtual string Key { get; }
                   

        [NotMapped]
        public List<Error> Errors = new List<Error>();
        [NotMapped]
        public string ParserErrorCsv = string.Empty;

        [NotMapped]
        public int ExecutionStatus = 0;

    }

    public class BusinessError : Error
    {

    }

    public class ConfidenceError : Error
    {

    }

    public class MandatoryError : Error
    {
        public MandatoryError()
        {
            Message = "REQUIRED Fields is missing";
        }
    }
    public class Error
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public string Message { get; set; }

        //public override string ToString()
        //{
        //    if (string.IsNullOrEmpty(Value))
        //    {
        //        Value = "NULL";
        //    }
        //    return "Field:" + Field + "--> Value:" + Value + "; Message:" + Message;
        //}
    }
}
