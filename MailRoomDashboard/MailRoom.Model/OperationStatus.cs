﻿using System;
using System.Diagnostics;

namespace MailRoom.Model
{
    [DebuggerDisplay("Status: {Status}")]
    public class OperationStatus
    {
        public bool Status { get; set; }
        public int RecordsAffected { get; set; }
        public string Message { get; set; }
        public Object OperationID { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        public string ExceptionInnerMessage { get; set; }
        public string ExceptionInnerStackTrace { get; set; }
        public OperationStatus()
        {
            Status = true;
        }
        public static OperationStatus CreateFromException(string message, Exception ex)
        {
            OperationStatus opStatus = new OperationStatus
            {
                Status = false,
                Message = message,
                OperationID = null
            };

            if (ex != null)
            {
                opStatus.ExceptionMessage = ex.Message;
                opStatus.ExceptionStackTrace = ex.StackTrace;
                opStatus.ExceptionInnerMessage = (ex.InnerException == null) ? null : ex.InnerException.Message;
                opStatus.ExceptionInnerStackTrace = (ex.InnerException == null) ? null : ex.InnerException.StackTrace;
            }
            return opStatus;
        }
    }

    public class GenericClaim
    {
        public string ClaimId {get; set;}
        public string PayerName { get; set; }
        public string ConfidenceScore { get; set; }
        public string ReviewStatus { get; set; }
        public string ParserStatus { get; set; }
        public string CreatedDate { get; set; }
        public string ReviewerId { get; set; }


    }

    public class QueryParams
    {
        public string reviewerId;
        public int reviewStauts;
        public string claimType;
    }

}
