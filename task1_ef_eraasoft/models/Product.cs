using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_ef_eraasoft.models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int  Quantity { get; set; }
        public decimal price { get; set; }
        public int SaleId{ get; set; }
        public string Description { get; set; }

    }
}
