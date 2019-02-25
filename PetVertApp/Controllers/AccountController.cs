using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PetVertApp.Models;
using System.Web.Security;
using PetVertApp.Helpers;

namespace PetVertApp.Controllers
{
   // [Authorize]
    public class AccountController : Controller
    {
      

        private UserHelper userhelper;

        private PetDBContext db = new PetDBContext();

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated) {


                return RedirectToAction("DashBoard");
                
            }


            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel) {

            if (ModelState.IsValid) {

                userhelper = new UserHelper();

                if (userhelper.Login(viewModel.Email, PasswordEncryptionHelper.EncodePassword(viewModel.Password)))
                {


                    FormsAuthentication.SetAuthCookie(viewModel.Email, viewModel.RememberMe);


                    return RedirectToAction("DashBoard");
                }

                viewModel.Password = "";
                return View(viewModel);
                //    return RedirectToAction("Index", "Clients");
            }




            return View();
        }

        public ActionResult LogOff()
        {


            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        [Authorize]
        public ActionResult DashBoard()
        {

            var numofclients = db.Clients.Count();

            var numofpets = db.Pet.Count();
            
            DashBoardViewmodel viewModel = new DashBoardViewmodel();

            viewModel.Clients = db.Clients.Select(x =>
                        new SelectListItem
                        {
                            Value = x.id.ToString(),
                            Text = x.fullname
                        });

            viewModel.countclients = db.Clients.Count();

            viewModel.countpets = db.Pet.Count();

            viewModel.numberoftreatments = db.Treatment.Count();
            
            return View(viewModel);
        }


    }
}