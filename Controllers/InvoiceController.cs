using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vueproject.DB;
using vueproject.Models;
using vueproject.ViewModels;

namespace vueproject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : Controller
    {
        private vueprojectDatabaseContext ctx;
        public InvoiceController(vueprojectDatabaseContext context)
        {
            ctx = context;

        }
        [HttpPost]
        public async Task<IActionResult> CreateNewInvoice(CreateCustomerViewModel vm)
        {
            var existingCustomerId = ctx.Customers.Where(x => x.CustomerId == vm.CustomerId).FirstOrDefault();
            if (existingCustomerId != null)
            {
                var ErrorMessage = "Det finns redan en produkt med detta kundnummret, välj ett annat.";
                return Ok(ErrorMessage);
            }
            else
            {
                try
                {
                    var NewCustomer = new Customer();
                    NewCustomer.Name = vm.Name;
                    NewCustomer.CustomerId = vm.CustomerId;
                    NewCustomer.InvoiceAddress = vm.InvoiceAddress;
                    NewCustomer.SecondInvoiceAddress = vm.SecondInvoiceAddress;
                    NewCustomer.ZipCode = vm.ZipCode;
                    NewCustomer.City = vm.City;
                    NewCustomer.Country = vm.Country;
                    NewCustomer.OrganisationNumber = vm.OrganisationNumber;
                    NewCustomer.Fax = vm.Fax;
                    NewCustomer.PhoneNumber = vm.PhoneNumber;
                    NewCustomer.SecondPhoneNumber = vm.SecondPhoneNumber;
                    NewCustomer.EmailAddress = vm.EmailAddress;
                    NewCustomer.WebAddress = vm.WebAddress;
                    NewCustomer.Description = vm.Description;

                    ctx.Customers.Add(NewCustomer);
                    await ctx.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw e;
                }
                return Ok();
            }

        }

        //[HttpPost]
        //public async Task<IActionResult> UpdateExistingCustomer(CreateCustomerViewModel vm)
        //{
        //    var CustomerToUpdate = ctx.Customers.Where(x => x.CustomerId == vm.CustomerId).FirstOrDefault();
        //    try
        //    {
        //        CustomerToUpdate.Name = vm.Name;
        //        CustomerToUpdate.CustomerId = vm.CustomerId;
        //        CustomerToUpdate.InvoiceAddress = vm.InvoiceAddress;
        //        CustomerToUpdate.SecondInvoiceAddress = vm.SecondInvoiceAddress;
        //        CustomerToUpdate.ZipCode = vm.ZipCode;
        //        CustomerToUpdate.City = vm.City;
        //        CustomerToUpdate.Country = vm.Country;
        //        CustomerToUpdate.OrganisationNumber = vm.OrganisationNumber;
        //        CustomerToUpdate.PhoneNumber = vm.PhoneNumber;
        //        CustomerToUpdate.SecondPhoneNumber = vm.SecondPhoneNumber;
        //        CustomerToUpdate.Fax = vm.Fax;
        //        CustomerToUpdate.EmailAddress = vm.EmailAddress;
        //        CustomerToUpdate.WebAddress = vm.WebAddress;
        //        CustomerToUpdate.Description = vm.Description;

        //        ctx.Customers.Update(CustomerToUpdate).State = EntityState.Modified;
        //        await ctx.SaveChangesAsync();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    return Ok();
        //}

        //[HttpPost]
        //public async Task<IActionResult> DeleteCustomer(GetCustomerByCustomerIdViewModel vm)
        //{
        //    var CustomerById = await ctx.Customers.Where(x => x.CustomerId == vm.CustomerId).FirstOrDefaultAsync();
        //    try
        //    {
        //        ctx.Customers.Remove(CustomerById);
        //        await ctx.SaveChangesAsync();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    return Ok();
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllCustomers()
        //{
        //    var allCustomers = await ctx.Customers.ToListAsync();
        //    return Ok(allCustomers);
        //}
        //[HttpPost]
        //public async Task<IActionResult> GetCustomerByCustomerId(GetCustomerByCustomerIdViewModel vm)
        //{
        //    var CustomerById = await ctx.Customers.Where(x => x.CustomerId == vm.CustomerId).FirstOrDefaultAsync();
        //    return Ok(CustomerById);
        //}

        //[HttpPost]
        //public async Task<IActionResult> SearchCustomers(SearchViewModel vm)
        //{
        //    //TODO: does it 3 times??
        //    var SearchResultCustomers = await ctx.Customers.Where(x => x.Name.Contains(vm.SearchWords)).ToListAsync();
        //    return Ok(SearchResultCustomers);
        //}
    }
}