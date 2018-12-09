using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLOG.Models;
using System.IO;
using PagedList;
using System.Drawing;
using System.Drawing.Imaging;

namespace BLOG.Controllers
{
    [Authorize(Roles = "Admin")]
    public class POSTsController : Controller
    {
        static int CONST_PAGE = 6; //const number set
        private ApplicationDbContext db = new ApplicationDbContext();
        //by default the posts are "HTTPGET"
        //always have a post with a submit with the controller
        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            int pageSize = CONST_PAGE; //the number of posts you want to display per page for pageList
            int pageNumber = (page ?? 1);
            //null co-alisting operator

            //change the type of list
            //IList<POST> plist = db.POST_TABLE.ToList();

            //if (page == null)
            //{
            //    return View(plist.OrderByDescending(p => p.CREATED).ToPagedList(pageNumber, 5));
            //}
            return View(db.POST_TABLE.ToList().OrderByDescending(p => p.CREATED).ToPagedList(pageNumber, pageSize));
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(string searchStr, int? page)
        {
            //var result = db.POST_TABLE.Where(p => p.BODY.Contains(searchStr))
            //.Union(db.POST_TABLE.Where(p => p.TITLE.Contains(searchStr)))
            //.Union(db.POST_TABLE.Where(p => p.Comments.Any(c => c.BODY.Contains(searchStr))))
            //.Union(db.POST_TABLE.Where(p => p.Comments.Any(c => c.AUTHOR.DisplayName.Contains(searchStr))))
            //.Union(db.POST_TABLE.Where(p => p.Comments.Any(c => c.AUTHOR.FirstName.Contains(searchStr))))
            //.Union(db.POST_TABLE.Where(p => p.Comments.Any(c => c.AUTHOR.LastName.Contains(searchStr))))
            //.Union(db.POST_TABLE.Where(p => p.Comments.Any(c => c.AUTHOR.UserName.Contains(searchStr))))
            //.Union(db.POST_TABLE.Where(p => p.Comments.Any(c => c.AUTHOR.Email.Contains(searchStr))));

            //IList<POST_TABLE> plist = result.ToList();

            var listPosts = db.POST_TABLE.AsQueryable();
            listPosts = listPosts.Where(p => p.TITLE.Contains(searchStr) ||
                                           p.BODY.Contains(searchStr) ||
                                           p.Comments.Any(c => c.BODY.Contains(searchStr) ||
                                                              c.AUTHOR.FirstName.Contains(searchStr) ||
                                                              c.AUTHOR.LastName.Contains(searchStr) ||
                                                              c.AUTHOR.DisplayName.Contains(searchStr) ||
                                                              c.AUTHOR.Email.Contains(searchStr)));

            int pageSize = CONST_PAGE; //the number of posts you want to display per page for pageList
            int pageNumber = (page ?? 1);
            //null co-alisting operator

            //change the type of list
            //IList<POST> plist = db.POST_TABLE.ToList();

            ViewBag.searchStr = searchStr;

            return View(listPosts.OrderByDescending(p => p.CREATED).ToPagedList(pageNumber, pageSize));
        }
        // GET: POSTs
        //Exception to the rule of authroized 
        //[AllowAnonymous]
        //public ActionResult Index()
        //{
        //    return View(db.POST_TABLE.ToList());
        //}

        // GET: POSTs/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POST Post = db.POST_TABLE.Find(id);
            if (Post == null)
            {
                return HttpNotFound();
            }
            return View(Post);
        }
        //Authroize = if user is authenticated, such as any user
        //[Authorize(Roles = "Admin")]
        // GET: POSTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: POSTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CREATED,UPDATED,TITLE,BODY,MEDIA,PUBLISH")] POST Post, HttpPostedFileBase image)
        {
            Post.CREATED = new DateTimeOffset(DateTime.Now);
            Post.UPDATED = new DateTimeOffset(DateTime.Now);
            if (ModelState.IsValid)
            {
                //restricting the valid file formats to images only
                if (ImageValidator.IsWebFriendlyImage(image))
                {
                    using (var reader = new System.IO.BinaryReader(image.InputStream))
                    {
                        reader.BaseStream.Position = 0;
                        Post.MEDIA = reader.ReadBytes(image.ContentLength);
                    }

                    //var fileName = Path.GetFileName(image.FileName);
                    //image.SaveAs(Path.Combine(Server.MapPath("~/images/blog/"), fileName));
                    //Post.MEDIA = "~/images/blog/" + fileName;
                }
                Post.CREATED = new DateTimeOffset(DateTime.Now);

                db.POST_TABLE.Add(Post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Post);
        }

        // GET: POSTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POST Post = db.POST_TABLE.Find(id);
            if (Post == null)
            {
                return HttpNotFound();
            }
            return View(Post);
        }

        // POST: POSTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CREATED,UPDATED,TITLE,BODY,MEDIA,PUBLISH")] POST Post, HttpPostedFileBase image)
        {
            Post.UPDATED = new DateTimeOffset(DateTime.Now);
            if (ModelState.IsValid)
            {

                if (ImageValidator.IsWebFriendlyImage(image))
                {
                    //var fileName = Path.GetFileName(image.FileName);
                    //image.SaveAs(Path.Combine(Server.MapPath("~/images/blog/"), fileName));
                    //Post.MEDIA = "~/images/blog/" + fileName;

                    using (var reader = new System.IO.BinaryReader(image.InputStream))
                    {
                        reader.BaseStream.Position = 0;
                        Post.MEDIA = reader.ReadBytes(image.ContentLength);
                    }

                    //ViewBag.Image = ConvertToBytes(image);
                    //Console.WriteLine();
                }

                db.Entry(Post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Post);

        }

        // GET: POSTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POST Post = db.POST_TABLE.Find(id);
            if (Post == null)
            {
                return HttpNotFound();
            }
            return View(Post);
        }

        // POST: POSTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POST Post = db.POST_TABLE.Find(id);
            db.POST_TABLE.Remove(Post);
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


        private byte[] ConvertToBytes(HttpPostedFileBase image)
        {

            byte[] imageBytes = null;

            BinaryReader reader = new BinaryReader(image.InputStream);

            imageBytes = reader.ReadBytes((int)image.ContentLength);

            return imageBytes;

        }
    }
}
