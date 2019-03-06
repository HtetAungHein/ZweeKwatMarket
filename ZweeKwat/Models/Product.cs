using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZweeKwatMarket.Models
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Guid CategoryID { get; set; }
        public int Quantity { get; set; }
        public Guid StoreID { get; set; }
        public string ImagePath { get; set; }

        public Category Category { get; set; }
        public Store Store { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Product()
        {

        }

    }
}