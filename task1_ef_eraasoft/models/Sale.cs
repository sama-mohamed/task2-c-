using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_ef_eraasoft.models
{
    internal class Sale
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId{ get; set; }
        public int StoreId{ get; set; }
        public DateTime date { get; set; }
    }
}
