using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZweeKwatMarket.Models
{
    public class Customer
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Customer()
        {

        }
    }
}