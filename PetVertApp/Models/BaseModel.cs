using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVertApp.Models
{
    public class BaseModel
    {
        public int id { get; set; }

        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
}