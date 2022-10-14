using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQGroupingOperators.Models
{
    internal class Customer
    {
        public string CompanyName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
