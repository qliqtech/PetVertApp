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
    public class TreatmentsController : Controller
    {
        private PetDBContext db = new PetDBContext();

        private UserHelper userhelper = new UserHelper();

        // GET: Treatments
        public ActionResult Index(int id)
        {
            var treatment = db.Treatment.Where(ss=>ss.petid == id).Include(t => t.Pet);
            return View(treatment.ToList());
        }



        // GET: Treatments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatment.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // GET: Treatments/Create
        public ActionResult Create(int id)
        {
            var info = db.Pet.SingleOrDefault(ss => ss.id == id);

            ViewBag.petname = info.name;

            ViewBag.petid = info.id;

            ViewBag.clientid = info.clientsid;
           // ViewBag.petid = new SelectList(db.Pet.Where(ss=>ss.id == id), "id", "name");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Treatment treatment)
        {
            treatment.CreatedOn = DateTime.Now;

            treatment.CreatedBy = userhelper.getuserdetails(User.Identity.Name).id;

            treatment.IsActive = true;

            treatment.IsDeleted = false;

            if (treatment.treatmenttype == "deworming") {

                treatment.DewormingDateTime = DateTime.Now;

            }

            

            if (treatment.treatmenttype == "vaccination")
            {

                treatment.VaccinationDateTime = DateTime.Now;

            }

            treatment.userid = userhelper.getuserdetails(User.Identity.Name).id;

            if (ModelState.IsValid)
            {
                db.Treatment.Add(treatment);
                db.SaveChanges();

                TempData["success"] = "Pet Treated Successfully";

                return RedirectToAction("Create/"+treatment.petid, "TreatMents");
              //  return RedirectToAction("Index");
            }

            ViewBag.petid = new SelectList(db.Pet, "id", "name", treatment.petid);
            return View(treatment);
        }

        // GET: Treatments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatment.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            ViewBag.petid = new SelectList(db.Pet, "id", "name", treatment.petid);
            return View(treatment);
        }

        // POST: Treatments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,symptoms,Diagnosis,DrugsAdministered,Amount,Temperature,treatmenttype,petid,userid,IsDeleted,IsActive,CreatedBy,CreatedOn,DeletedOn,UpdatedOn")] Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.petid = new SelectList(db.Pet, "id", "name", treatment.petid);
            return View(treatment);
        }

        // GET: Treatments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatment.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // POST: Treatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Treatment treatment = db.Treatment.Find(id);
            db.Treatment.Remove(treatment);
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
