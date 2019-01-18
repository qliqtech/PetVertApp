using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetVertApp.Models;
using PetVertApp.Helpers;

namespace PetVertApp.Controllers
{

    [Authorize]
    public class PetsController : Controller
    {
        private PetDBContext db = new PetDBContext();

        private UserHelper userhelper = new UserHelper();
        // GET: Pets
        public ActionResult Index()
        {
            var pet = db.Pet.Include(p => p.client);
            return View(pet.ToList());
        }

        // GET: Pets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pet.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Pets/Create
        public ActionResult Create(int clientid)
        {
            ViewBag.clientsid = clientid;



            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pet pet)
        {
         
                
                pet.CreatedOn = DateTime.Now;

                pet.CreatedBy = userhelper.getuserdetails(User.Identity.Name).id;

                pet.IsActive = true;

                pet.IsDeleted = false;


                db.Pet.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
         //   }

      //      ViewBag.clientsid = new SelectList(db.Clients, "id", "fullname", pet.clientsid);
     //       return View(pet);
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pet.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.clientsid = new SelectList(db.Clients, "id", "fullname", pet.clientsid);
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,gender,age,type,breed,color,clientsid,IsDeleted,IsActive,CreatedBy,CreatedOn,DeletedOn,UpdatedOn")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clientsid = new SelectList(db.Clients, "id", "fullname", pet.clientsid);
            return View(pet);
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pet.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = db.Pet.Find(id);
            db.Pet.Remove(pet);
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
