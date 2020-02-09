using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vueproject.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public IdentityUser Customer { get; set; }
        public List<Product> InvoiceProducts { get; set; }
        public string InvoicePdfGuid { get; set; }
        public string MessageText { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
