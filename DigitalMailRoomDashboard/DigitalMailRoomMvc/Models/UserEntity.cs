using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalMailRoomMvc.Models
{
    public class UserEntity
    {
        private string _username;
        [DataType(DataType.Password)]
        private string _password;

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
    }
}
