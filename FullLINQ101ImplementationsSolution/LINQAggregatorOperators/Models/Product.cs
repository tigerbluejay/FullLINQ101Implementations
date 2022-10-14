using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAggregatorOperators.Models
{
    internal class Product
    {
        public string Category { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
