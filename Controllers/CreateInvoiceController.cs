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


            //maybe send id and get from database, put in vm and send vm


            //var NewInvoice = new Invoice();
            ////NewInvoice.DateCreated = DateTime.Now;
            ////NewInvoice.EmailFrom = vm.EmailFrom; due to changed viewmodel.........
            ////NewInvoice.EmailTo = vm.EmailTo;
            //NewInvoice.InvoicePdfGuid = fileName;
            //NewInvoice.InvoiceMessageText = vm.InvoiceMessageText;
            ////NewInvoice.UserName = "TestUserName";
            ///













            

            return new ViewAsPdf("GenerateInquiryPdf", vm)
            {
                FileName = fileName,
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