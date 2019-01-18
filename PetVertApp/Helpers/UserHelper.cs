using PetVertApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVertApp.Helpers
{
    public class UserHelper
    {

        PetDBContext db = new PetDBContext();
        public Users getuserdetails(string useremail) {

            return db.User.SingleOrDefault(ss => ss.email == useremail);
        }

        public Users getuserdetailsbyid(int? id)
        {

            return db.User.SingleOrDefault(ss => ss.id == id);
        }


        public bool Login(string email, string password) {

            int count = db.User.Where(ss => ss.email == email && ss.password == password).Count();

            if (count > 0) {

                return true;
            }

            return false;
        }

        

    }
}