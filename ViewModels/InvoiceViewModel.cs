using System;
using System.Collections.Generic;
using vueproject.Models;

namespace vueproject.ViewModels
{
    public class InvoiceViewModel
    {
        public List<Product> InvoiceProducts { get; set; }

        //just make invoice in db and then later gett all this from db?


        //E-MAIL DISTRIBUTION
        public string InvoicePdfGuid { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        
        //CUSTOMER DETAILS
        public string CustomerInvoiceAddress { get; set; }
        public string CustomerZipCode { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }

        //USER DETAILS
        public string UserInvoiceAddress { get; set; }
        public string UserZipCode { get; set; }
        public string UserCity { get; set; }
        public string UserCountry { get; set; }

        //GENERIC INVOICE DETAILS
        public DateTime DateCreated { get; set; }
        public string MessageText { get; set; }
    }
}
