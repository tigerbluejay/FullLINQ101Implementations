using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQProjectionOperators.Classes
{
    internal class Order
    {
        public int OrderID { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
