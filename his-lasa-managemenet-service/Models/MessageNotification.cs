using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace his_lasa_managemenet_service.Models
{
    public class MessageNotification
    {
        public string UserName { get; set; }
        public string ContactName { get; set; }
        public string Message { get; set; }
        public string SendDate { get; set; }
    }
}
