using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalMailRoomMvc.Models
{
    public class ClaimEntity
    {
        private int _patientId;
        private int _claimId;
        private int _columnsToVerify;
        private int _confidenceScore;
        private DateTime _submissionDate;
        private DateTime _extractedDate;
        public int PatientId { get => _patientId; set => _patientId = value; }
        public int ClaimId { get => _claimId; set => _claimId = value; }
        public int ColumnsToVerify { get => _columnsToVerify; set => _columnsToVerify = value; }
        public int ConfidenceScore { get => _confidenceScore; set => _confidenceScore = value; }
        public DateTime SubmissionDate { get => _submissionDate; set => _submissionDate = value; }
        public DateTime ExtractedDate { get => _extractedDate; set => _extractedDate = value; }
    }
}
