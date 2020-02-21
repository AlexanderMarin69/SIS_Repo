using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vueproject.ViewModels
{
    public class UpdateUserViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string PaymentTerms { get; set; }
        public string InvoicecPastDuePercentageFee { get; set; }
        public string EmailAddress { get; set; }
        public string InvoiceAddress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string PlusGiro { get; set; }
        public string BankGiro { get; set; }
        public string OrgNr { get; set; }
        public string MomsRegNr { get; set; }
    }
}
