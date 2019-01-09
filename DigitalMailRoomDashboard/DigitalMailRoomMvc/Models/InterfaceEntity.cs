using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalMailRoomMvc.Models
{
    public class InterfaceEntity
    {
        private string _interfaceName;
        private DateTime _lastModifiedDate;
        private string _host;
        private string _userName;
        private string _password;
        private string _sourcePath;
        private string _fileNamePattern;
        private bool _restrictFileSize;
        private int _fileSizeLimit;
        private bool _isPollByTime;
        private int _pollingFrequency;
        private string _pollingTime;
        private int _pollingMessages;
        private bool _isMoveAllowed;
        private bool _isDeleteAllowed;
        private bool _isMoveErroredAllowed;
        private bool _isDeleteErroredAllowed;
        private string _moveToPath;
        private string _moveErroredToPath;
        private bool _canProcessSubDirectories;
        public string InterfaceName { get => _interfaceName; set => _interfaceName = value; }
        public DateTime LastModifiedDate { get => _lastModifiedDate; set => _lastModifiedDate = value; }
        public string Host { get => _host; set => _host = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public string SourcePath { get => _sourcePath; set => _sourcePath = value; }
        public string FileNamePattern { get => _fileNamePattern; set => _fileNamePattern = value; }
        public bool RestrictFileSize { get => _restrictFileSize; set => _restrictFileSize = value; }
        public int FileSizeLimit { get => _fileSizeLimit; set => _fileSizeLimit = value; }
        public bool IsPollByTime { get => _isPollByTime; set => _isPollByTime = value; }
        public int PollingFrequency { get => _pollingFrequency; set => _pollingFrequency = value; }
        public string PollingTime { get => _pollingTime; set => _pollingTime = value; }
        public int PollingMessages { get => _pollingMessages; set => _pollingMessages = value; }
        public bool IsMoveAllowed { get => _isMoveAllowed; set => _isMoveAllowed = value; }
        public bool IsDeleteAllowed { get => _isDeleteAllowed; set => _isDeleteAllowed = value; }
        public bool IsMoveErroredAllowed { get => _isMoveErroredAllowed; set => _isMoveErroredAllowed = value; }
        public bool IsDeleteErroredAllowed { get => _isDeleteErroredAllowed; set => _isDeleteErroredAllowed = value; }
        public string MoveToPath { get => _moveToPath; set => _moveToPath = value; }
        public string MoveErroredToPath { get => _moveErroredToPath; set => _moveErroredToPath = value; }
        public bool CanProcessSubDirectories { get => _canProcessSubDirectories; set => _canProcessSubDirectories = value; }
    }
}
