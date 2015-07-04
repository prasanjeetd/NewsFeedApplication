using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsFeedApplication.Models.Entities;
using WebMatrix.WebData;
using System.Web.Security;
using RTE;

namespace NewsFeedApplication.Controllers
{
    public class NewsController : Controller
    {
        private NewsFeedEntities db = new NewsFeedEntities();

        //
        // GET: /News/

        [Authorize]
        public ActionResult Index()
        {
            var news = db.News.Include(n => n.Category);
            return View(news.ToList());
        }

        //
        // GET: /News/Details/5

        [Authorize]
        public ActionResult Details(long id = 0)
        {
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        //
        // GET: /News/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");

            Editor Editor1 = new Editor(System.Web.HttpContext.Current, "Editor1");
            Editor1.LoadFormData("Type here...");
            Editor1.MvcInit();
            ViewBag.Editor = Editor1.MvcGetString();

            return View();
        }

        //
        // POST: /News/Create

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId, Title, Descripion")]News news)
        {
            if (ModelState.IsValid)
            {
                MembershipUser user = Membership.GetUser(HttpContext.User.Identity.Name);
                news.CreatedById = (int)WebSecurity.CurrentUserId;

                news.CreatedOn = DateTime.Now;
                db.News.Add(news);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View(news);
        }

        //
        // GET: /News/Edit/5

        [Authorize]
        public ActionResult Edit(long id = 0)
        {
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", news.CategoryId);
            return View(news);
        }

        //
        // POST: /News/Edit/5

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                news.UpdatedBy = (int)WebSecurity.CurrentUserId;
                news.UpdatedOn = DateTime.Now;
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", news.CategoryId);
            return View(news);
        }

        //
        // GET: /News/Delete/5

        [Authorize]
        public ActionResult Delete(long id = 0)
        {
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        //
        // POST: /News/Delete/5

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}