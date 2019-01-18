using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVertApp.Models
{
    public class ClientsPetsListViewModel
    {

        public int id { get; set; }
        public string fullname { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public DateTime? createdon { get; set; }

        public string createdbyuserfullname { get; set; }

        public string email { get; set; }
        public List<Pet> Pets { get; set; }



    }
}