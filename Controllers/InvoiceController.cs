﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;
        public InvoiceController(vueprojectDatabaseContext context,
            UserManager<IdentityUser> UserManager)
        {
            _userManager = UserManager;
            ctx = context;

        }
        [HttpPost]
        public async Task<IActionResult> CreateNewInvoice(InvoiceViewModel vm)
        {
            var userData = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var user = ctx.ApplicationUsers.Where(x => x.UserId == userData.Id).FirstOrDefault();

            var Customer = ctx.Customers.Where(x => x.CustomerId == vm.AssociatedCustomerId).FirstOrDefault();

            try
            {

                var NewInvoice = new Invoice();
                NewInvoice.InvoicePdfGuid = Guid.NewGuid().ToString();

                NewInvoice.AssociatedUserId = user.UserId;
                NewInvoice.AssociatedCustomerId = vm.AssociatedCustomerId;

                NewInvoice.EmailFrom = user.EmailAddress;
                NewInvoice.EmailTo = Customer.EmailAddress;

                NewInvoice.CustomerInvoiceAddress = Customer.InvoiceAddress;
                NewInvoice.CustomerZipCode = Customer.ZipCode;
                NewInvoice.CustomerCity = Customer.City;
                NewInvoice.CustomerCountry = Customer.Country;

                NewInvoice.UserInvoiceAddress = user.InvoiceAddress;
                NewInvoice.UserZipCode = user.ZipCode;
                NewInvoice.UserCity = user.City;
                NewInvoice.UserCountry = user.Country;

                NewInvoice.InvoiceDate = vm.InvoiceDate;
                NewInvoice.InvoicePayDate = vm.InvoicePayDate;
                NewInvoice.DeliveryDate = vm.DeliveryDate;
                NewInvoice.InvoicecPastDuePercentageFee = user.InvoicecPastDuePercentageFee;
                NewInvoice.PaymentTerms = user.PaymentTerms;
                NewInvoice.SenderName = user.FirstName + " " + user.LastName;
                NewInvoice.CustomerName = Customer.Name;
                NewInvoice.ReceiverCustomerId = vm.AssociatedCustomerId;
                NewInvoice.ReceiverReferenceName = Customer.CustomerReference;

                NewInvoice.InvoiceMessageText = vm.InvoiceMessageText;

                NewInvoice.SendAs = vm.SendAs;
                NewInvoice.InvoiceTypeToSend = vm.InvoiceTypeToSend;
                NewInvoice.InvoiceIsCredit = vm.InvoiceIsCredit;

                NewInvoice.OptionalReminderFee = vm.OptionalReminderFee;
                NewInvoice.DeliveryFee = vm.DeliveryFee;
                NewInvoice.InvoiceFee = vm.InvoiceFee;



                decimal TotalFees = NewInvoice.DeliveryFee + NewInvoice.InvoiceFee + NewInvoice.OptionalReminderFee;
                decimal TotalFeesWithTax = TotalFees * Convert.ToDecimal(1.25);

                decimal TotalProductsCostWithOutTax = vm.InvoiceProductsTotalCost;
                decimal TotalProductsCostWithTax = vm.InvoiceProductsTotalCost * Convert.ToDecimal(1.25);

                decimal TotalPayWithoutTax = TotalFees + vm.InvoiceProductsTotalCost;


                //   TAX LOGIC ----------------- TAX LOGIC -------- TAX LOGIC ----------------- TAX LOGIC
                // tax = TotalFees - TotalFeesWITHTAX     +++++++   InvoiceProductsTotalCost - InvoiceProductsTotalCostWITHTAX 
                var FeesDiff = TotalFeesWithTax - TotalFees;
                var InvoicePriceDiff = TotalProductsCostWithTax - vm.InvoiceProductsTotalCost;
                decimal Tax = FeesDiff + InvoicePriceDiff;
                NewInvoice.Tax = Tax;
                //   TAX LOGIC ----------------- TAX LOGIC -------- TAX LOGIC ----------------- TAX LOGIC


                NewInvoice.TotalCostWithoutTax = TotalFees + TotalProductsCostWithOutTax;

                var TotalCostNotRounded = TotalFeesWithTax + TotalProductsCostWithTax;

                decimal TotalCostRounded = Math.Round(TotalCostNotRounded);


                // DecimalRoundUp ====  diff between ToPayWithTax  ROUND(ToPayWithTax)
                decimal DecimalToAbs = TotalCostNotRounded - TotalCostRounded;
                NewInvoice.DecimalRoundUp = Math.Abs(DecimalToAbs);

                NewInvoice.TotalCost = Math.Round(TotalCostNotRounded);

                ///// COST LOGIC NOT WORKING PROPERLY




                //decimal SumsToCombine = NewInvoice.Tax + vm.OptionalReminderFee + vm.InvoiceProductsTotalCost;
                //var TotalInvoiceCosts = SumsToCombine;

                //var GatheredSum = NewInvoice.InvoiceFee + NewInvoice.DeliveryFee + TotalInvoiceCosts;
                //var multiplied = GatheredSum * Convert.ToDecimal(1.25);
                //NewInvoice.Tax = GatheredSum - multiplied;

                //NewInvoice.TotalCost = Math.Round(TotalInvoiceCosts);

                //NewInvoice.TotalCostWithoutTax = TotalInvoiceCosts - NewInvoice.Tax;

                //NewInvoice.DecimalRoundUp = TotalInvoiceCosts - Math.Round(TotalInvoiceCosts);



                ctx.Invoices.Add(NewInvoice);
                await ctx.SaveChangesAsync();

                var NewInvoiceProducts = new List<InvoiceProduct>();
                NewInvoiceProducts = vm.InvoiceProducts;
                foreach (InvoiceProduct p in NewInvoiceProducts)
                {
                    p.AssociatedInvoicePdfGuid = NewInvoice.InvoicePdfGuid;
                    p.AssociatedUserId = user.UserId;
                    ctx.InvoiceProducts.Add(p);

                }
                await ctx.SaveChangesAsync();


            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok();
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