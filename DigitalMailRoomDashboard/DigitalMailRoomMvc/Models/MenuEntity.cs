using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalMailRoomMvc.Models
{
    public class MenuEntity
    {
        private string _menuName;
        private string _actionName;
        private string _controllerName;

        public string MenuName { get => _menuName; set => _menuName = value; }
        public string ActionName { get => _actionName; set => _actionName = value; }
        public string ControllerName { get => _controllerName; set => _controllerName = value; }
    }
}
