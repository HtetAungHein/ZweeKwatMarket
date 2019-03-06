using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZweeKwat.Models;
using ZweeKwatMarket.Models;

namespace ZweeKwat.Controllers
{
    public class CheckOutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CheckOut
        public ActionResult CheckOut()
        {
            Guid id = (Guid)Session["ID"];
            var item = db.Products.Find(id);
            return View(item);
        }

        [HttpPost]

        public ActionResult CheckOut(Customer customer)
        {
            customer.ID = Guid.NewGuid();
            db.Customers.Add(customer);
            db.SaveChanges();

            Guid id = (Guid)Session["ID"];
            var item = db.Products.Find(id);
            Order order = new Order();
            order.ID = Guid.NewGuid();
            order.Date = DateTime.UtcNow.AddHours(6).AddMinutes(30);
            order.CustomerID = customer.ID;
            order.SubTotal = item.Price;
            order.Taxes = item.Price * 0.05;
            order.DeliveryFee = 2000;
            db.Orders.Add(order);
            db.SaveChanges();

            OrderDetail ord = new OrderDetail();
            ord.ID = Guid.NewGuid();
            ord.OrderID = order.ID;
            ord.ProductID = item.ID;
            ord.Quantity = 1;
            ord.Price = item.Price;
            ord.SubTotal = item.Price * 1;
            db.OrderDetails.Add(ord);
            db.SaveChanges();
            return Redirect("/Home/");

        }
    }
}