using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Invoice
    {
        public Invoice()
        {

        }

        public bool IsFinalized { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
