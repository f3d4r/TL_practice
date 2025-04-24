using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class Order
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public DateTime TodayDate { get; set; }
    }
}
