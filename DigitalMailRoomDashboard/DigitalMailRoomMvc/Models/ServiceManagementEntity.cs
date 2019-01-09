using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalMailRoomMvc.Models
{
    public class ServiceManagementEntity
    {
        private string _serviceName;
        private DateTime _lastRunDate;
        private int _received;
        private int _processed;
        private int _errored;
        private string _status;
        public int Received { get => _received; set => _received = value; }
        public int Processed { get => _processed; set => _processed = value; }
        public int Errored { get => _errored; set => _errored = value; }
        public string ServiceName { get => _serviceName; set => _serviceName = value; }
        public DateTime LastRunDate { get => _lastRunDate; set => _lastRunDate = value; }
        public string Status { get => _status; set => _status = value; }
    }
}
