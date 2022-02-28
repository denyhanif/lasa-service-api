using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace his_lasa_managemenet_service.Models
{
    public class User
    {
        public int user_id { set; get; }
        public string user_name { set; get; }
        public string password { set; get; }

        public string full_name { set; get; }
    }
}
