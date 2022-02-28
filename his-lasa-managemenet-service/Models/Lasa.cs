using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace his_lasa_managemenet_service.Models
{
    public class Lasa
    {
        public long? item_id { set; get; }
        public long SalesItemId { set; get; }
        public string Name { set; get; }

        public Nullable<DateTime> modified { set; get; }
        public bool? is_lasa { set; get; }
    }
}
