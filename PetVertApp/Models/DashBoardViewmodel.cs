using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVertApp.Models
{
    public class DashBoardViewmodel
    {
        public int countclients { get; set; }

        public int countpets { get; set; }

        public int numberoftreatments { get; set; }

        public int upcomingrevaccinationstoday { get; set; }

        public int upcomingredewormingtoday { get; set; }

        

    }
}