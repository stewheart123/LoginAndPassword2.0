using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoginAndPassword2.Models;

namespace LoginAndPassword2.Controllers
{
    public class megaListsController : Controller
    {
        private Entities db = new Entities();

         // GET: megaLists
        public ActionResult Index()
        {

            // example query that filters only ambience over 3
            //var query = db.megaLists
            //                     .Where(s => s.ambience > 3);
            //return View(query);
            // example that matches ambience to value set in url request

            string testrequest = Request.QueryString.ToString();
            if (testrequest == "")
            {
                return View(db.megaLists.ToList());
            }

            else
            {
                var query = db.megaLists

                  .Where(s => s.ambience.ToString() == testrequest);
                return View(query);
            }
        }

        // GET: megaLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            megaList megaList = db.megaLists.Find(id);
            if (megaList == null)
            {
                return HttpNotFound();
            }
            return View(megaList);
        }

        // GET: megaLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: megaLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "restaurant_id,restaurant_name,restaurant_location,ranking,service,service_comment,value,value_comment,ambience,ambience_comment,menu,menu_comment,eco_friendly,eco_friendly_comment,would_go_again,tempt_me_back")] megaList megaList)
        {
            if (ModelState.IsValid)
            {
                db.megaLists.Add(megaList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(megaList);
        }

        // GET: megaLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            megaList megaList = db.megaLists.Find(id);
            if (megaList == null)
            {
                return HttpNotFound();
            }
            return View(megaList);
        }

        // POST: megaLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "restaurant_id,restaurant_name,restaurant_location,ranking,service,service_comment,value,value_comment,ambience,ambience_comment,menu,menu_comment,eco_friendly,eco_friendly_comment,would_go_again,tempt_me_back")] megaList megaList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(megaList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(megaList);
        }

        // GET: megaLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            megaList megaList = db.megaLists.Find(id);
            if (megaList == null)
            {
                return HttpNotFound();
            }
            return View(megaList);
        }

        // POST: megaLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            megaList megaList = db.megaLists.Find(id);
            db.megaLists.Remove(megaList);
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
