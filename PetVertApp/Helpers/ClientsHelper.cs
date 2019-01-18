using PetVertApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVertApp.Helpers
{

   
    public class ClientsHelper
    {

        PetDBContext db = new PetDBContext();
        public Clients getclientdetailsbyid(int id) {



            return db.Clients.SingleOrDefault(ss => ss.id == id);

        }

    }
}