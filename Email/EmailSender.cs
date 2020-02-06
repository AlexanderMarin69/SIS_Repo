using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using vueproject.ViewModels;

//TODO: npm sendgrid
namespace vueproject.Email
{
    public class EmailSender
    {
        //private readonly string SENDGRID_API_KEY = SG.JkUXkMNZSvmPsaxA8JJCug.p6njfsvHCuOmWiwKCSeyv - jxOZxU5YlNAmAsFGtK0u4

        private CustomAppSettings _appSettings;

        public EmailSender(IOptions<CustomAppSettings> settings)
        {
            _appSettings = settings.Value;
        }

        public async Task Execute(InvoiceViewModel vm)
        {
            var apiKey = _appSettings.SENDGRID_API_KEY;
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(vm.EmailFrom, vm.UserName);
            var to = new EmailAddress(vm.EmailTo, "TestToMustFix");

            string FNR = "2";

            var subject = $"Faktura {FNR}";

            var plainTextContent = vm.MessageText;
            var htmlContent = vm.MessageText;

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
            using (var fileStream = File.OpenRead("C:\\Users\\alexa\\Desktop\\temptemp\\ToDoVueV2-Login_Vue_Identity_V3\\UsersPdfInvoices\\"
               /* + vm.InvoicePdfGuid +*/
               
               + "75c4c9b8-ce5d-4d99-bc8e-6798ae8c7033" + ".pdf"))
            {
                await msg.AddAttachmentAsync(@"Faktura {FNR}" + ".pdf", fileStream);
                var response = await client.SendEmailAsync(msg);
            }



           
        }
    }
}
