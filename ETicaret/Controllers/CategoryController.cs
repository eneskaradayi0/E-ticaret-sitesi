using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETicaret.Entity;

namespace ETicaret.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)//
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Category category)//iclude=istediği şeyşeryleri çağırıyot
        {
            if (ModelState.IsValid)//geçerli mi konrol eder
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");//home sayfaına dödürür
            }

            return View(category);//kategorinin dolduruması için döner
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)//boşsa
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);//hata verir
            }
            Category category = db.Categories.Find(id);//dbye bakar ıd sahip kategroiyi kadeder yoksa hata verir
            if (category == null)//kategori boşsa
            {
                return HttpNotFound();
            }
            return View(category);//kategorinin dolduruması için döner
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Category category)//ınculede bağlanır
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;//dataya kaydedilmesini söyler
                db.SaveChanges();
                return RedirectToAction("Index");//ana sayfa
            }
            return View(category);
        }

        
        public ActionResult Delete(int? id)//silme işlemi
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);//db alır ve kategori yoksa hata gönderir
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);//silme işlemi için döndürür
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);//db alır konrol eder yoksa hata verir
            db.Categories.Remove(category);//db kaldırır
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)//???
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}