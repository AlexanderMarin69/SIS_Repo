using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vueproject.ViewModels
{
    public class CreateNewProductViewModel
    {
        public string Name { get; set; }
        public string ArticleNumber { get; set; }
        public decimal Price { get; set; }
        public string EAN { get; set; }
        public string ManufacturerSku { get; set; }
        public string Manufacturer { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public decimal CostPerItem { get; set; }
        public decimal StockBalance { get; set; }
        public string ProductType { get; set; }
    }
}
