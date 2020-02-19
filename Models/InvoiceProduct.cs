using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vueproject.Models
{
    public class InvoiceProduct
    {
        //used to get simplified product model from vuex to create references on invoice creation
        public string Name { get; set; }
        public string ArticleNumber { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string AssociatedUserId { get; set; }
        public string AssociatedInvoicePdfGuid { get; set; }

    }
}
