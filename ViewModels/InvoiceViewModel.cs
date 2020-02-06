using System;
using System.Collections.Generic;
using vueproject.Models;

namespace vueproject.ViewModels
{
    public class InvoiceViewModel
    {
        public List<Product> InvoiceProducts { get; set; }
        public string InvoicePdfGuid { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string UserName { get; set; }
        public string MessageText { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
