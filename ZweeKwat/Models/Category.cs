using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZweeKwatMarket.Models
{
    public class Category
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

        public Category()
        {

        }
    }
}