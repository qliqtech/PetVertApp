using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVertApp.Models
{

    public class Treatment : BaseModel
    {
        public string symptoms { get; set; }

        public string Diagnosis { get; set; }


        public string DrugsAdministered { get; set; }

        public double Amount { get; set; }

        public string Temperature { get; set; }

        public string treatmenttype { get; set; }

        public int? petid { get; set; }

        public virtual Pet Pet { get; set; }

      
        
        public DateTime? VaccinationDateTime { get; set; }

        public DateTime? ReVaccinationDateTime { get; set; }

        public string vaccinationdrugname { get; set; }
        public string typeofvaccination { get; set; }

    //    public string temperature { get; set; }
        
        public DateTime? DewormingDateTime { get; set; }

        public DateTime? FutureDewormDate { get; set; }

        public string dewormdrug { get; set; }

        public int? userid { get; set; }
        public virtual Users Users { get; set; }

    }

    public class TreatmentDrugs: BaseModel {

        public int treatmentid { get; set; }

        public int drugid { get; set; }

    }


    public class Drugs : BaseModel
    {
        public string drugname { get; set; }

        public string descriptions { get; set; }
        

    }

    public class Vaccinations : BaseModel
    {
        public string vaccinename { get; set; }

        public string Type { get; set; }

        public double amount { get; set; }

        
    }

    public class Deworming : BaseModel
    {
        public string dewormername { get; set; }

        public string Type { get; set; }

        public double amount { get; set; }


    }

}