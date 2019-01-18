using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetVertApp.Models
{
    public class DashBoardViewmodel
    {
        public int countclients { get; set; }

        public int countpets { get; set; }

        public IEnumerable<SelectListItem> Clients { get; set; }

        [Required]
        [Display(Name = "Client Name")]
        public int clientid { get; set; }

        [Display(Name = "Client Name")]
        public int id { get; set; }

        public int numberoftreatments { get; set; }

        public int upcomingrevaccinationstoday { get; set; }

        public int upcomingredewormingtoday { get; set; }

        

    }
}