using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLOG.Models;
using Microsoft.AspNet.Identity;

namespace BLOG.Controllers
{
    [Authorize]
    public class COMMENTsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: COMMENTs
        public ActionResult Index()
        {
            var cOMMENT_TABLE = db.COMMENT_TABLE.Include(c => c.AUTHOR).Include(c => c.POST);
            return View(cOMMENT_TABLE.ToList());
        }

        // GET: COMMENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENT cOMMENT = db.COMMENT_TABLE.Find(id);
            if (cOMMENT == null)
            {
                return HttpNotFound();
            }
            return View(cOMMENT);
        }

        // GET: COMMENTs/Create
        public ActionResult Create()
        {
            ViewBag.AUTHORID = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.POSTID = new SelectList(db.POST_TABLE, "ID", "TITLE");
            return View();
        }

        // POST: COMMENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,POSTID,BODY")] COMMENT cOMMENT)
        {
            if (ModelState.IsValid)
            {
                cOMMENT.AUTHORID = User.Identity.GetUserId();
                cOMMENT.CREATED = new DateTimeOffset(DateTime.Now);

                //sends data created to the cOMMENT instance
                db.COMMENT_TABLE.Add(cOMMENT);
                db.SaveChanges();

                return RedirectToAction("Details", "POSTs", new { id = cOMMENT.POSTID });
            }

            ViewBag.AUTHORID = new SelectList(db.Users, "ID", "FirstName", cOMMENT.AUTHORID);
            ViewBag.POSTID = new SelectList(db.POST_TABLE, "ID", "TITLE", cOMMENT.POSTID);
            return View(cOMMENT);
        }

        // GET: COMMENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENT cOMMENT = db.COMMENT_TABLE.Find(id);
            if (cOMMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.AUTHORID = new SelectList(db.Users, "Id", "FirstName", cOMMENT.AUTHORID);
            ViewBag.POSTID = new SelectList(db.POST_TABLE, "ID", "TITLE", cOMMENT.POSTID);
            return View(cOMMENT);
        }

        // POST: COMMENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,POSTID,CREATED,BODY,AUTHORID")] COMMENT cOMMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AUTHORID = new SelectList(db.Users, "Id", "FirstName", cOMMENT.AUTHORID);
            ViewBag.POSTID = new SelectList(db.POST_TABLE, "ID", "TITLE", cOMMENT.POSTID);
            return View(cOMMENT);
        }

        // GET: COMMENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENT cOMMENT = db.COMMENT_TABLE.Find(id);
            if (cOMMENT == null)
            {
                return HttpNotFound();
            }
            return View(cOMMENT);
        }

        // POST: COMMENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COMMENT cOMMENT = db.COMMENT_TABLE.Find(id);
            db.COMMENT_TABLE.Remove(cOMMENT);
            db.SaveChanges();
            return RedirectToAction("Details", "Posts", new { id = cOMMENT.POSTID }); //change redirect to the direction earlier previousluy mentioned
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
