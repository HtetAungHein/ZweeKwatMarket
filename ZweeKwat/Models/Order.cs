using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZweeKwatMarket.Models
{
    public class Order
    {
        public Guid ID { get; set; }
        public Guid CustomerID { get; set; }
        public DateTime Date { get; set; }
        public double SubTotal { get; set; }
        public double Taxes { get; set; }
        public double DeliveryFee { get; set; }
        public double ServiceCharges { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {

        }
    }
}