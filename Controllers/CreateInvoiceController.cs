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
using System.Net;
using System.IO.Compression;
using Microsoft.AspNetCore.Hosting;

namespace vueproject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreateInvoiceController : Controller
    {
        private readonly EmailSender mail;
        private vueprojectDatabaseContext ctx;
        private readonly UserManager<IdentityUser> _userManager;
        private IHostingEnvironment _appEnvironment;


        public CreateInvoiceController(
            IHostingEnvironment appEnvironment,
            UserManager<IdentityUser> userManager,
            EmailSender Email,
            vueprojectDatabaseContext context)
        {
            mail = Email;
            ctx = context;
            _userManager = userManager;
            _appEnvironment = appEnvironment;

        }

        //TODO: use viewmodel to send data to this controller insted of post method from page as below (old mvc code)
        public async Task<IActionResult> SendInvoiceViaMail()
        {
            try
            {
                await mail.Execute("hello");

                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IActionResult> GenerateInvoicePdf(PdfGuidViewModel InvoicePdfGuidToGet)
        {


            //var userId = _userManager.GetUserId(User);
            //var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            //Where(x => x.ModifiedBy == user);


            //maybe send id and get from database, put in vm and send vm

            //var userData = _userManager.FindByNameAsync(User.Identity.Name).Result;
            //var userData = await _userManager.GetUserAsync(User);
            //var user = ctx.ApplicationUsers.Where(x => x.UserId == userData.Id).FirstOrDefault();

            var Invoice = ctx.Invoices.Where(x => x.InvoicePdfGuid == InvoicePdfGuidToGet.PdfGuid).FirstOrDefault();
            var InvoiceProductsToGet = ctx.InvoiceProducts.Where(x => x.AssociatedInvoicePdfGuid == Invoice.InvoicePdfGuid).ToList();
            Invoice.InvoiceProducts = InvoiceProductsToGet;

            var InvoicePdfGuid = Invoice.InvoicePdfGuid;
            var filePath = Invoice.FilePath;
            

            //var NewInvoice = new Invoice();
            //NewInvoice.InvoicePdfGuid = vm.InvoicePdfGuid;

            //NewInvoice.AssociatedUserId = user.UserId;
            //NewInvoice.AssociatedCustomerId = vm.AssociatedCustomerId;

            //NewInvoice.EmailFrom = user.EmailAddress;
            //NewInvoice.EmailTo = Customer.EmailAddress;

            //NewInvoice.CustomerInvoiceAddress = Customer.InvoiceAddress;
            //NewInvoice.CustomerZipCode = Customer.ZipCode;
            //NewInvoice.CustomerCity = Customer.City;
            //NewInvoice.CustomerCountry = Customer.Country;

            //NewInvoice.UserPhoneNumber = user.PhoneNumber;
            //NewInvoice.UserFax = user.Fax;
            //NewInvoice.UserPlusGiro = user.PlusGiro;
            //NewInvoice.UserBankGiro = user.BankGiro;
            //NewInvoice.UserOrgNr = user.OrgNr;
            //NewInvoice.UserMomsRegNr = user.MomsRegNr;

            //NewInvoice.UserInvoiceAddress = user.InvoiceAddress;
            //NewInvoice.UserZipCode = user.ZipCode;
            //NewInvoice.UserCity = user.City;
            //NewInvoice.UserCountry = user.Country;

            //NewInvoice.InvoiceDate = vm.InvoiceDate;
            //NewInvoice.InvoicePayDate = vm.InvoicePayDate;
            //NewInvoice.DeliveryDate = vm.DeliveryDate;
            //NewInvoice.InvoicecPastDuePercentageFee = user.InvoicecPastDuePercentageFee;
            //NewInvoice.PaymentTerms = user.PaymentTerms;
            //NewInvoice.SenderName = user.FirstName + " " + user.LastName;
            //NewInvoice.CustomerName = Customer.Name;
            //NewInvoice.ReceiverCustomerId = vm.AssociatedCustomerId;
            //NewInvoice.ReceiverReferenceName = Customer.CustomerReference;

            //NewInvoice.InvoiceMessageText = vm.InvoiceMessageText;

            //NewInvoice.SendAs = vm.SendAs;
            //NewInvoice.InvoiceTypeToSend = vm.InvoiceTypeToSend;
            //NewInvoice.InvoiceIsCredit = vm.InvoiceIsCredit;

            //NewInvoice.OptionalReminderFee = vm.OptionalReminderFee;
            //NewInvoice.DeliveryFee = vm.DeliveryFee;
            //NewInvoice.InvoiceFee = vm.InvoiceFee;

            //NewInvoice.InvoiceProducts = vm.InvoiceProducts;



            //decimal TotalFees = NewInvoice.DeliveryFee + NewInvoice.InvoiceFee + NewInvoice.OptionalReminderFee;
            //decimal TotalFeesWithTax = TotalFees * Convert.ToDecimal(1.25);

            //decimal TotalProductsCostWithOutTax = vm.InvoiceProductsTotalCost;
            //decimal TotalProductsCostWithTax = vm.InvoiceProductsTotalCost * Convert.ToDecimal(1.25);

            //decimal TotalPayWithoutTax = TotalFees + vm.InvoiceProductsTotalCost;


            ////   TAX LOGIC ----------------- TAX LOGIC -------- TAX LOGIC ----------------- TAX LOGIC
            //// tax = TotalFees - TotalFeesWITHTAX     +++++++   InvoiceProductsTotalCost - InvoiceProductsTotalCostWITHTAX 
            //var FeesDiff = TotalFeesWithTax - TotalFees;
            //var InvoicePriceDiff = TotalProductsCostWithTax - vm.InvoiceProductsTotalCost;
            //decimal Tax = FeesDiff + InvoicePriceDiff;
            //NewInvoice.Tax = Tax;
            ////   TAX LOGIC ----------------- TAX LOGIC -------- TAX LOGIC ----------------- TAX LOGIC


            //NewInvoice.TotalCostWithoutTax = TotalFees + TotalProductsCostWithOutTax;

            //var TotalCostNotRounded = TotalFeesWithTax + TotalProductsCostWithTax;

            //decimal TotalCostRounded = Math.Round(TotalCostNotRounded);


            //// DecimalRoundUp ====  diff between ToPayWithTax  ROUND(ToPayWithTax)
            //decimal DecimalToAbs = TotalCostNotRounded - TotalCostRounded;
            //NewInvoice.DecimalRoundUp = Math.Abs(DecimalToAbs);

            //NewInvoice.TotalCost = Math.Round(TotalCostNotRounded);












            return new ViewAsPdf("GenerateInquiryPdf", Invoice)
            {
                FileName = InvoicePdfGuid,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Orientation.Portrait,
                PageMargins = { Left = 0, Right = 0 },
                SaveOnServerPath = filePath
            };
        }

        //public IActionResult PrintInvoicePdf()
        //{

        //var ello = new ViewAsPdf("PrintInvoicePdf") {
        //};

        //return ello;

        //return Ok(new PartialViewAsPdf("PrintInvoicePdf")
        //{
        //    PageSize = Rotativa.AspNetCore.Options.Size.A4,
        //    FileName = "PDF Doc.pdf"

        //});

        //var demoViewPortrait = new ViewAsPdf("PrintInvoicePdf")
        //{
        //    FileName = "Invoice.pdf",
        //    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
        //    PageSize = Rotativa.AspNetCore.Options.Size.A4,
        //    PageMargins = { Left = 0, Right = 0 },
        //    ContentType = "application/pdf"

        //};

        //return demoViewPortrait;

        //    string FilePath = "C:\\Users\alexa\\Desktop\temptemp\\ToDoVueV2-Login_Vue_Identity_V3\\UsersPdfInvoicesedf4a6cd-e17d-4a81-848d-412e24ede11d.pdf";
        //    WebClient User = new WebClient();
        //    Byte[] FileBuffer = User.DownloadData(FilePath);
        //    if (FileBuffer != null)
        //    {
        //        Response.ContentType = "application/pdf";
              
        //    }
        //    return Ok();
        //}

        public IActionResult PrintInvoicePdf()
        {
            //string rootPath = _appEnvironment.WebRootPath;   
            string rootPath = _appEnvironment.WebRootPath;
            //string hello = "C:\\Users\\alexa\\Desktop\\temptemp\\ToDoVueV2-Login_Vue_Identity_V3\\UsersPdfInvoices\\";
            byte[] bytes;

            //using (var ms = new MemoryStream())
            //{
            //    using (var imagezip = new ZipArchive(ms, ZipArchiveMode.Create, true))
            //        imagezip.CreateEntryFromFile($"{rootPath}/" + "/UsersPdfInvoices/edf4a6cd-e17d-4a81-848d-412e24ede11d.pdf", "edf4a6cd-e17d-4a81-848d-412e24ede11d.pdf", CompressionLevel.Fastest);
            //    ms.Position = 0;
            //    bytes = ms.ToArray();
            //}
            //return File(bytes, "application/zip", "YoursPDF.zip");

            using (var ms = new MemoryStream())
            {
                using (var imagezip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                    imagezip.CreateEntryFromFile($"{rootPath}/" + "UsersPdfInvoices/edf4a6cd-e17d-4a81-848d-412e24ede11d", "edf4a6cd-e17d-4a81-848d-412e24ede11d" + ".pdf", CompressionLevel.Fastest);
                ms.Position = 0;
                bytes = ms.ToArray();
            }
            return File(bytes, "application/zip", "image.zip");
        }
    }
}