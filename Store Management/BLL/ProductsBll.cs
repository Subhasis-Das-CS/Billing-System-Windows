using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anystore.BLL
{
    class ProductsBll
    {

        public Int64 id { get; set; }
        public string name { get; set; }
        public string catagory { get; set; }
        public string description { get; set; }
        public decimal rate { get; set; }
        public decimal qty { get; set; }
        public DateTime added_date { get; set; }


    }
}
