using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using vueproject.DB;
using vueproject.ViewModels;

//TODO: npm sendgrid
namespace vueproject.Email
{
    public class EmailSender : Controller
    {
        //private readonly string SENDGRID_API_KEY = SG.JkUXkMNZSvmPsaxA8JJCug.p6njfsvHCuOmWiwKCSeyv - jxOZxU5YlNAmAsFGtK0u4

        private CustomAppSettings _appSettings;
        private vueprojectDatabaseContext ctx;
        private readonly UserManager<IdentityUser> _userManager;

        public EmailSender(
            IOptions<CustomAppSettings> settings,
            vueprojectDatabaseContext context,
              UserManager<IdentityUser> userManager)
        {
            _appSettings = settings.Value;
            _userManager = userManager;
            ctx = context;
        }

        public async Task Execute()
        {
            var usr = await _userManager.GetUserAsync(User);
            var user = ctx.ApplicationUsers.Where(x => x.UserId == usr.Id).FirstOrDefault();

            var InvoiceToSend = ctx.Invoices.OrderByDescending(x => x.DateCreated).FirstOrDefault();

            var apiKey = _appSettings.SENDGRID_API_KEY;
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(InvoiceToSend.EmailFrom, "someUserNameFIXXX");
            var to = new EmailAddress(InvoiceToSend.EmailTo, "TestToMustFix");

          

            var subject = InvoiceToSend.InvoiceTypeToSend;

            var plainTextContent = InvoiceToSend.InvoiceMessageText;
            var htmlContent = InvoiceToSend.InvoiceMessageText;

            var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                plainTextContent,
                htmlContent
                );


            //pathToAttachment = `${ __dirname}/ attachment.pdf`;
            //attachment = fs.readFileSync(pathToAttachment).toString("base64");


            //var file = Convert.ToBase64String(bytes);
            //msg.AddAttachment("file.txt", file);


            //TODO: Provide guid via viewmodel instead of "file.txt."     
                          //Maybe not ".pdf" because guid file does not have .pdf maybe
            using (var fileStream = File.OpenRead("C:\\Users\\alexa\\Desktop\\temptemp\\ToDoVueV2-Login_Vue_Identity_V3\\UsersPdfInvoices\\" + InvoiceToSend.InvoicePdfGuid + ".pdf", "application/pdf"))
            {
                await msg.AddAttachmentAsync("Faktura 1" + ".pdf", fileStream);
                var response = await client.SendEmailAsync(msg);
            }



           
        }
    }
}
