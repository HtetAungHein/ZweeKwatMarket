using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZweeKwat.Models;
using ZweeKwatMarket.Models;

namespace ZweeKwat.Controllers
{
    public class StoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stores
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.Stores.ToList());
        }

        // GET: Stores/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StoreName,OwnerName,NRC,Phone,Email,Address,ImagePath")] Store store, HttpPostedFileBase fileupload)
        {
            //string filename = Path.GetFileNameWithoutExtension(store.ImagePath.FileName);
            //String extension = Path.GetExtension(store.ImagePath.FileName);
            //filename = filename + DateTime.Now.ToString("yymmssfff")+extension;
            //store.ImagePath = "~/images/" + filename;
            //filename = Path.Combine(Server.MapPath("~/images/"), filename);
            //store.ImagePath.SaveAs(filename);
            if (ModelState.IsValid)
            {
                if(fileupload != null)
                {
                    string ImageName = System.IO.Path.GetFileName(fileupload.FileName);
                    string physicalpatch = Server.MapPath("~/images/StoreProfile/" + ImageName);
                    fileupload.SaveAs(physicalpatch);
                    store.ImagePath = ImageName;
                }
                store.ID = Guid.NewGuid();
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(store);
        }

        // GET: Stores/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StoreName,OwnerName,NRC,Phone,Email,Address,ImagePath")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}
