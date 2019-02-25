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
    public class ClientsController : Controller
    {
        private PetDBContext db = new PetDBContext();

        private UserHelper userhelper = new UserHelper();

        ClientsHelper clienthelper = new ClientsHelper();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            ClientsPetsListViewModel viewmodel = new ClientsPetsListViewModel();

            viewmodel.Pets = db.Pet.Where(ss => ss.clientsid == id).ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Clients clients = db.Clients.Find(id);

         

            if (clients == null)
            {
                return HttpNotFound();
            }

            viewmodel.id = clients.id;

            viewmodel.email = clients.email;

            viewmodel.fullname = clients.fullname;

            viewmodel.address = clients.address;

            viewmodel.phone = clients.phone;

            viewmodel.createdon = clients.CreatedOn;

        //    viewmodel.createdbyuserfullname = userhelper.getuserdetailsbyid(clients.CreatedBy).fullname;
            
            return View(viewmodel);
        }








        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Clients clients)
        {
            if (ModelState.IsValid)
            {
                clients.CreatedOn = DateTime.Now;

                clients.CreatedBy = userhelper.getuserdetails(User.Identity.Name).id;

                clients.IsActive = true;

                clients.IsDeleted = false;


                db.Clients.Add(clients);
                db.SaveChanges();

                return Redirect("/Pets/Create?clientid="+clients.id);

                //return RedirectToAction("Index");
            }

            return View(clients);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fullname,address,phone,email,IsDeleted,IsActive,CreatedBy,CreatedOn,DeletedOn,UpdatedOn")] Clients clients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clients);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clients clients = db.Clients.Find(id);
            db.Clients.Remove(clients);
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
