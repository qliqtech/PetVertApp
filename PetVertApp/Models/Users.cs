using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVertApp.Models
{
    public class Users : BaseModel
    {

        public string email { get; set; }
     //   public string username { get; set; }

        public string password { get; set; }
       
        
        /// <summary>
        /// superadmin, doctor
        /// </summary>
        public string usertype { get; set; }

        public string fullname { get; set; }

        public bool resetpasswordonlogin { get; set; }

        public string phonenumber { get; set; }


    }
}