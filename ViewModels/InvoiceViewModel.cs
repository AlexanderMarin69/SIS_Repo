using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using vueproject.Models;

namespace vueproject.ViewModels
{
    public class InvoiceViewModel
    {
        //To Get Data
        public string AssociatedUserId { get; set; }
        public string AssociatedCustomerId { get; set; }

        public int Id { get; set; }
        public List<Product> InvoiceProducts { get; set; }
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
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoicePayDate { get; set; }
        public string InvoiceMessageText { get; set; }
        public string InvoicecPastDuePercentageFee { get; set; }
    }
}
