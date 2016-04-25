using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Receptbok.DAL;
using Receptbok.Models;
using System.IO;

namespace Receptbok.Controllers
{
    public class ReceptController : Controller
    {
        private ReceptbokContext db = new ReceptbokContext();

        public ActionResult Visa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipes recipes = db.Recipes.Include(i => i.FilePath).SingleOrDefault(i => i.RecipeId == id);
            if (recipes == null)
            {
                return HttpNotFound();
            }
            return View(recipes);
        }

        // GET: Recept
        public ActionResult Index(string searchString)
        {
            var recipes = db.Recipes.Include(r => r.Categories);

            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(s => s.RecipeName.Contains(searchString));
            }

            return View(recipes.ToList());
        }

        // GET: Recept/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipes recipes = db.Recipes.Include(i => i.FilePath).SingleOrDefault(i => i.RecipeId == id);
            if (recipes == null)
            {
                return HttpNotFound();
            }
            return View(recipes);
        }

        // GET: Recept/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Recept/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeId,RecipeName,RecipeInstructions,CategoryId")] Recipes recipes, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var RecipeImage = new FilePath
                    {
                        FileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(upload.FileName),
                        FileType = FileType.RecipeImage
                    };
                    recipes.FilePath = new List<FilePath>();
                    recipes.FilePath.Add(RecipeImage);
                    upload.SaveAs(Path.Combine(Server.MapPath("/Images/Recipes"), RecipeImage.FileName));
                }
                db.Recipes.Add(recipes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", recipes.CategoryId);
            return View(recipes);
        }

        // GET: Recept/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipes recipes = db.Recipes.Find(id);
            if (recipes == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", recipes.CategoryId);
            return View(recipes);
        }

        // POST: Recept/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeId,RecipeName,RecipeInstructions,CategoryId")] Recipes recipes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", recipes.CategoryId);
            return View(recipes);
        }

        // GET: Recept/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipes recipes = db.Recipes.Find(id);
            if (recipes == null)
            {
                return HttpNotFound();
            }
            return View(recipes);
        }

        // POST: Recept/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipes recipes = db.Recipes.Find(id);
            db.Recipes.Remove(recipes);
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
