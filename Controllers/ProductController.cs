using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vueproject.DB;
using vueproject.Models;
using vueproject.ViewModels;

namespace vueproject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {

        private vueprojectDatabaseContext ctx;
        private readonly UserManager<IdentityUser> _userManager;

        public ProductController(vueprojectDatabaseContext context,
             UserManager<IdentityUser> UserManager)
        {
            ctx = context;
            _userManager = UserManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewProduct(CreateNewProductViewModel vm)
        {
            var userData = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var user = ctx.ApplicationUsers.Where(x => x.UserId == userData.Id).FirstOrDefault();

            var existingProductSku = ctx.Products.Where(x => x.ArticleNumber == vm.ArticleNumber).FirstOrDefault();
            if (existingProductSku != null)
            {
                var ErrorMessage = "Det finns redan en produkt med detta artikelnumret, välj ett annat artikelnumer.";
                return Ok(ErrorMessage);
            }
            else
            {
                try
                {
                    var NewProduct = new Product();
                    NewProduct.Name = vm.Name;
                    NewProduct.ArticleNumber = vm.ArticleNumber;
                    NewProduct.DateUpdated = DateTime.Now;
                    NewProduct.DateCreated = DateTime.Now;
                    NewProduct.Price = vm.Price;
                    NewProduct.EAN = vm.EAN;
                    NewProduct.Manufacturer = vm.Manufacturer;
                    NewProduct.ManufacturerSku = vm.ManufacturerSku;
                    NewProduct.Supplier = vm.Manufacturer;
                    NewProduct.Description = vm.Description;
                    NewProduct.CostPerItem = vm.CostPerItem;
                    NewProduct.StockBalance = vm.StockBalance;
                    NewProduct.ProductType = vm.ProductType;
                    NewProduct.AssociatedUserId = user.UserId;

                    ctx.Products.Add(NewProduct);
                    await ctx.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw e;
                }
                return Ok();
            }

        }

        [HttpPost]
        public async Task<IActionResult> UpdateExistingProduct(CreateNewProductViewModel vm)
        {
            var ProductToUpdate = ctx.Products.Where(x => x.ArticleNumber == vm.ArticleNumber).FirstOrDefault();
            try
            {
                ProductToUpdate.Name = vm.Name;
                ProductToUpdate.ArticleNumber = vm.ArticleNumber;
                ProductToUpdate.DateUpdated = DateTime.Now;
                ProductToUpdate.Price = vm.Price;
                ProductToUpdate.EAN = vm.EAN;
                ProductToUpdate.Manufacturer = vm.Manufacturer;
                ProductToUpdate.ManufacturerSku = vm.ManufacturerSku;
                ProductToUpdate.Supplier = vm.Manufacturer;
                ProductToUpdate.Description = vm.Description;
                ProductToUpdate.CostPerItem = vm.CostPerItem;
                ProductToUpdate.StockBalance = vm.StockBalance;
                ProductToUpdate.ProductType = vm.ProductType;

                ctx.Products.Update(ProductToUpdate).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(CreateNewProductViewModel vm)
        {
            var ProductToDelete = ctx.Products.Where(x => x.ArticleNumber == vm.ArticleNumber).FirstOrDefault();
            try
            {
                ctx.Products.Remove(ProductToDelete);
                await ctx.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var userData = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var user = ctx.ApplicationUsers.Where(x => x.UserId == userData.Id).FirstOrDefault();

            var allProducts = await ctx.Products.Where(x => x.AssociatedUserId == user.UserId).ToListAsync();
            return Ok(allProducts);
        }
        [HttpPost]
        public async Task<IActionResult> GetProductById(GetProductByIdViewModel vm)
        {
            var ProductById = await ctx.Products.Where(x => x.Id == vm.id).FirstOrDefaultAsync();
            return Ok(ProductById);
        }
        
             [HttpPost]
        public async Task<IActionResult> SearchProducts(SearchViewModel vm)
        {
            //TODO: does it 3 times??
            var SearchResultProducts = await ctx.Products.Where(x => x.Name.Contains(vm.SearchWords) || x.ArticleNumber.Contains(vm.SearchWords)).ToListAsync();
            return Ok(SearchResultProducts);
        }

    }
}