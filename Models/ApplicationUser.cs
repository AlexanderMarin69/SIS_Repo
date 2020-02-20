using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vueproject.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PaymentTerms { get; set; }
        public string InvoicecPastDuePercentageFee { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<Customer> Customers { get; set; }
        public string EmailAddress { get; set; }
        public string InvoiceAddress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
