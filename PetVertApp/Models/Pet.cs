using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVertApp.Models
{
    public class Pet: BaseModel
    {
        public string name { get; set; }

        public string gender { get; set; }

        public string age { get; set; }
        public string type { get; set; }

        public string breed { get; set; }

        public string color { get; set; }

        public int clientsid { get; set; }

        public virtual Clients client { get; set; }

        
    }
}