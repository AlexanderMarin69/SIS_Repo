using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.IO;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using vueproject.ViewModels;
using vueproject.Email;
using vueproject.DB;
using Microsoft.AspNetCore.Identity;
using vueproject.Models;

namespace vueproject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreateInvoiceController : Controller
    {
        private readonly EmailSender mail;
        private vueprojectDatabaseContext ctx;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateInvoiceController(UserManager<IdentityUser> userManager, EmailSender Email, vueprojectDatabaseContext context)
        {
            mail = Email;
            ctx = context;
            _userManager = userManager;
        }

        //TODO: use viewmodel to send data to this controller insted of post method from page as below (old mvc code)
        public async Task<IActionResult> SendInvoiceViaMail(InvoiceViewModel vm)
        {
            try
            {
                await mail.Execute(vm);

                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public async Task<IActionResult> GenerateInvoicePdf(InvoiceViewModel vm)
        {
            string fileName = Guid.NewGuid().ToString();

            //TODO: change filepath to server path when saving the inquiry pdf below
            var filePath = Path.Combine(@"C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\UsersPdfInvoices", fileName + ".pdf");
            
                    //var userId = _userManager.GetUserId(User);
                    //var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                    //Where(x => x.ModifiedBy == user);

                    var NewInvoice = new Invoice();
            NewInvoice.DateCreated = DateTime.Now;
            //NewInvoice.EmailFrom = vm.EmailFrom; due to changed viewmodel.........
            //NewInvoice.EmailTo = vm.EmailTo;
            NewInvoice.InvoicePdfGuid = fileName;
            NewInvoice.InvoiceProducts = vm.InvoiceProducts;
            NewInvoice.MessageText = vm.MessageText;
           //NewInvoice.UserName = "TestUserName";
            
            //TODO: real invoice has receiveraddress deliver adress etc etc, add by time after testing
            
            ctx.Invoices.Add(NewInvoice);
            ctx.SaveChanges();

            return new ViewAsPdf("GenerateInquiryPdf")
            {
                FileName = fileName,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Orientation.Portrait,
                PageMargins = { Left = 0, Right = 0 },
                SaveOnServerPath = filePath
            };
        }
    }
}