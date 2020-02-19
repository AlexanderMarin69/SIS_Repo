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
        public string AssociatedUserId { get; set; }
        public string AssociatedCustomerId { get; set; }
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
        public List<InvoiceProduct> InvoiceProducts { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoicePayDate { get; set; }
        public string InvoiceMessageText{ get; set; }
        public string OptionalReminderFee { get; set; }
        public string InvoiceTypeToSend { get; set; }
        public string InvoiceIsCredit { get; set; }
        public string SendAs { get; set; }

        public string DeliveryFee { get; set; }
        public string InvoiceFee { get; set; }

        public decimal TotalCostWithoutTax { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Tax { get; set; }
        public decimal DecimalRoundUp { get; set; }
    }
}
