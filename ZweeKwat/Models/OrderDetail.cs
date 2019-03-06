using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZweeKwatMarket.Models
{
    public class OrderDetail
    {
        public Guid ID { get; set; }
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int SubTotal { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

        public OrderDetail()
        {

        }


    }
}