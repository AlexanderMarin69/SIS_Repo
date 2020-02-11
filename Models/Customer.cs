using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vueproject.Models
{
    public class Customer : BaseModel
    {
        public string AssociatedUser { get; set; }
        public string CustomerId { get; set; }
        public string InvoiceAddress { get; set; }
        public string SecondInvoiceAddress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string OrganisationNumber { get; set; }
        public string Fax { get; set; }
        public string PhoneNumber { get; set; }
        public string SecondPhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string WebAddress { get; set; }
        public string Description { get; set; }
    }
}
