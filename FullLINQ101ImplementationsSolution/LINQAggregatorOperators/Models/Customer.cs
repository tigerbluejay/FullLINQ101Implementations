using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAggregatorOperators.Models
{
    internal class Customer
    {
        public int CustomerID { get; set; }

        public List<Order> Orders { get; set; }
    }
}
