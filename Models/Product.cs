using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vueproject.Models
{
    public class Product : BaseModel
    {
        public IdentityUser ModifiedBy { get; set; }
        public string ArticleNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public decimal StockBalance { get; set; }
        //public int SubcategoryId { get; set; }
        //public virtual Subcategory Subcategory { get; set; }
        public string EAN { get; set; }
        public string Manufacturer { get; set; }
        public string ManufacturerSku { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public decimal CostPerItem { get; set; }
        public string ProductType { get; set; }
    }
}
