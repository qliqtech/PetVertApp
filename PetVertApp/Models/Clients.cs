using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVertApp.Models
{
    public class Clients: BaseModel
    {
        public string fullname { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

    }
}