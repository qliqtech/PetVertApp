using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVertApp.Models
{
    public class TreatMentViewModel
    {
        public string symptoms { get; set; }

        public string treatmenttype { get; set; }
        public string Diagnosis { get; set; }

        public DateTime? VaccinationDateTime { get; set; }

        public DateTime? ReVaccinationDateTime { get; set; }

        public string vaccinationdrugname { get; set; }
        public string typeofvaccination { get; set;}

        public string temperature { get; set; }
        
        public int petid { get; set; }

        public string DrugsAdministered { get; set; }
        public double Amount { get; set; }

        public DateTime? DewormingDateTime { get; set; }

        public DateTime? FutureDewormDate { get; set; }

        public string dewormdrug { get; set; }

    }
}