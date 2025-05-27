using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CognizantPlc.Feature.Forms.Models
{
    public class CustomerEnquiry
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string Enquiry { get; set; }
    }
}