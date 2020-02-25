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


namespace vueproject.Email
{
    public class EmailSender
    {
        //private readonly string SENDGRID_API_KEY = SG.JkUXkMNZSvmPsaxA8JJCug.p6njfsvHCuOmWiwKCSeyv - jxOZxU5YlNAmAsFGtK0u4

        private CustomAppSettings _appSettings;
        private vueprojectDatabaseContext ctx;
        public EmailSender(
            IOptions<CustomAppSettings> settings,
            vueprojectDatabaseContext context
            )
        {
            _appSettings = settings.Value;
            ctx = context;
        }

        public async Task Execute(string PdfGuidMannen)
        {

            //commented out code does work for some reason, code below that works, copied from bitsoflifehelsingborg proejct

            //var apiKey = _appSettings.SENDGRID_API_KEY;
            //var client = new SendGridClient(apiKey);

            //var from = new EmailAddress(InvoiceToSend.EmailFrom, "someUserNameFIXXX");
            //var to = new EmailAddress(InvoiceToSend.EmailTo, "TestToMustFix");



            //var subject = InvoiceToSend.InvoiceTypeToSend;

            //var plainTextContent = InvoiceToSend.InvoiceMessageText;
            //var htmlContent = InvoiceToSend.InvoiceMessageText;

            //var msg = MailHelper.CreateSingleEmail(
            //    from,
            //    to,
            //    subject,
            //    plainTextContent,
            //    htmlContent
            //    );





            //pathToAttachment = `${ __dirname}/ attachment.pdf`;
            //attachment = fs.readFileSync(pathToAttachment).toString("base64");

            //var file = Convert.ToBase64String(bytes);
            //msg.AddAttachment("file.txt", file);

            //TODO: Provide guid via viewmodel instead of "file.txt."     
            //Maybe not ".pdf" because guid file does not have .pdf maybe




           //this code works, its from bitsoflifehelsingborg

                var InvoiceToSend = ctx.Invoices.Where(x => x.InvoicePdfGuid == PdfGuidMannen).FirstOrDefault();

            

            var apiKey = _appSettings.SENDGRID_API_KEY;
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(InvoiceToSend.EmailFrom, InvoiceToSend.SenderName);
            var to = new EmailAddress(InvoiceToSend.EmailTo, InvoiceToSend.CustomerName);

            var subject = InvoiceToSend.InvoiceTypeToSend;

            //works only if message not null or "",
         
                var plainTextContent = InvoiceToSend.InvoiceMessageText;
                var htmlContent = InvoiceToSend.InvoiceMessageText;
                var msg = MailHelper.CreateSingleEmail(
               from,
               to,
               subject,
               plainTextContent,
               htmlContent
               );
                //var response = await client.SendEmailAsync(msg);
                using (var fileStream = File.OpenRead(InvoiceToSend.FilePath))
                {
                    await msg.AddAttachmentAsync("Faktura" + ".pdf", fileStream);
                    var response = await client.SendEmailAsync(msg);
                }
            
        }
    }
}
