using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace his_lasa_managemenet_service.Models.ViewModel
{
    public class DataTabelLasa
    {
        public long item_id { set; get; }
        public long SalesItemId { set; get; }
       
        public Nullable<DateTime> modified { set; get; }
        public bool is_lasa { set; get; }
    }
}
