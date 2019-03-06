using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZweeKwat.Models;

namespace ZweeKwat.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AllStores()
        {
            return View(db.Stores.ToList());
        }

        [Authorize(Roles ="admin")]
        public ActionResult AdminView()
        {
            return View();
        }

        [Authorize(Roles = "seller")]
        public ActionResult SellerView()
        {
            return View();
        }


        public ActionResult AllProducts()
        {
            return View(db.Products.ToList());
        }

        [HttpPost]
        [Authorize(Roles ="user")]
        public ActionResult CheckOut(Guid ID)
        {
            Session["ID"] = ID;

            return Redirect("/CheckOut/CheckOut");
        }

        
    }
}