#pragma checksum "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a82b0e304580520c6330b6072175dcf5f458402"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CreateInvoice_GenerateInquiryPdf), @"mvc.1.0.view", @"/Views/CreateInvoice/GenerateInquiryPdf.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CreateInvoice/GenerateInquiryPdf.cshtml", typeof(AspNetCore.Views_CreateInvoice_GenerateInquiryPdf))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a82b0e304580520c6330b6072175dcf5f458402", @"/Views/CreateInvoice/GenerateInquiryPdf.cshtml")]
    public class Views_CreateInvoice_GenerateInquiryPdf : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<vueproject.Models.Invoice>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 10, true);
            WriteLiteral("\r\n<html>\r\n");
            EndContext();
            BeginContext(44, 2442, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0a82b0e304580520c6330b6072175dcf5f4584023056", async() => {
                BeginContext(50, 41, true);
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <title>");
                EndContext();
                BeginContext(92, 23, false);
#line 6 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
      Write(Model.InvoiceTypeToSend);

#line default
#line hidden
                EndContext();
                BeginContext(115, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(117, 8, false);
#line 6 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                               Write(Model.Id);

#line default
#line hidden
                EndContext();
                BeginContext(125, 1702, true);
                WriteLiteral(@"</title>
    <link href=""https://fonts.googleapis.com/css?family=Roboto&display=swap"" rel=""stylesheet"">
    <link href=""https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh"" crossorigin=""anonymous"">
    <style>
    .invoice-box {
        max-width: 800px;
        margin: auto;
        padding: 30px;
        font-size: 16px;
        line-height: 24px;
        font-family: 'Roboto', 'Helvetica', Helvetica, Arial, sans-serif;
        color: #555;
    }

    /*.invoice-box table {
        width: 100%;
        line-height: inherit;
        text-align: left;
    }

    .invoice-box table td {
        padding: 5px;
        vertical-align: top;
    }

    .invoice-box table tr td:nth-child(2) {
        text-align: right;
    }

    .invoice-box table tr.top table td {
        padding-bottom: 20px;
    }

    .invoice-box table tr.top table td.title {
        font-s");
                WriteLiteral(@"ize: 45px;
        line-height: 45px;
        color: #333;
    }

    .invoice-box table tr.information table td {
        padding-bottom: 40px;
    }

    .invoice-box table tr.heading td {
        background: #eee;
        border-bottom: 1px solid #ddd;
        font-weight: bold;
    }

    .invoice-box table tr.details td {
        padding-bottom: 20px;
    }

    .invoice-box table tr.item td{
        border-bottom: 1px solid #eee;
    }

    .invoice-box table tr.item.last td {
        border-bottom: none;
    }

    .invoice-box table tr.total td:nth-child(2) {
        border-top: 2px solid #eee;
        font-weight: bold;
    }*/

");
                EndContext();
                BeginContext(2187, 292, true);
                WriteLiteral(@"
    /** RTL **/
    /*.rtl {
        direction: rtl;
        font-family: Tahoma, 'Roboto', 'Helvetica', Helvetica, Arial, sans-serif;
    }

    .rtl table {
        text-align: right;
    }

    .rtl table tr td:nth-child(2) {
        text-align: left;
    }*/
    </style>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2486, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(2490, 7076, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0a82b0e304580520c6330b6072175dcf5f4584027217", async() => {
                BeginContext(2496, 33, true);
                WriteLiteral("\r\n    <div class=\"invoice-box\">\r\n");
                EndContext();
                BeginContext(4376, 409, true);
                WriteLiteral(@"

        <table class=""table"">
            <tbody>
                <tr>

                    <td class=""title"">
                        <img src=""https://www.sparksuite.com/images/logo.png"" style=""width:100%; max-width:300px;"">
                    </td>

                    <td style=""text-align: left;"">
                        <h3><b>Faktura</b></h3><br>
                        Fakturanummer ");
                EndContext();
#line 159 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                       if (Model.Id == 0)
                        {

#line default
#line hidden
                BeginContext(4831, 13, true);
                WriteLiteral("<p>#17748</p>");
                EndContext();
#line 160 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                      }
                        else
                        {

#line default
#line hidden
                BeginContext(4904, 32, true);
                WriteLiteral("                            <p>#");
                EndContext();
                BeginContext(4937, 8, false);
#line 163 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                           Write(Model.Id);

#line default
#line hidden
                EndContext();
                BeginContext(4945, 4, true);
                WriteLiteral("</p>");
                EndContext();
#line 163 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                             }

#line default
#line hidden
                BeginContext(4950, 43, true);
                WriteLiteral("<br>\r\n                        Fakturadatum ");
                EndContext();
                BeginContext(4994, 17, false);
#line 164 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                Write(Model.InvoiceDate);

#line default
#line hidden
                EndContext();
                BeginContext(5011, 43, true);
                WriteLiteral("<br>\r\n                        Fakturadatum ");
                EndContext();
                BeginContext(5055, 20, false);
#line 165 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                Write(Model.InvoicePayDate);

#line default
#line hidden
                EndContext();
                BeginContext(5075, 44, true);
                WriteLiteral("<br>\r\n                        Vår referens: ");
                EndContext();
                BeginContext(5120, 16, false);
#line 166 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                 Write(Model.SenderName);

#line default
#line hidden
                EndContext();
                BeginContext(5136, 135, true);
                WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        Kundnummer ");
                EndContext();
                BeginContext(5272, 24, false);
#line 171 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                              Write(Model.ReceiverCustomerId);

#line default
#line hidden
                EndContext();
                BeginContext(5296, 48, true);
                WriteLiteral("<br>\r\n                        Betalningsvillkor ");
                EndContext();
                BeginContext(5345, 18, false);
#line 172 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                     Write(Model.PaymentTerms);

#line default
#line hidden
                EndContext();
                BeginContext(5363, 45, true);
                WriteLiteral("<br>\r\n                        Dröjsmålsränta ");
                EndContext();
                BeginContext(5409, 34, false);
#line 173 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                  Write(Model.InvoicecPastDuePercentageFee);

#line default
#line hidden
                EndContext();
                BeginContext(5443, 44, true);
                WriteLiteral("<br>\r\n                        Leveransdatum ");
                EndContext();
                BeginContext(5488, 18, false);
#line 174 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                 Write(Model.DeliveryDate);

#line default
#line hidden
                EndContext();
                BeginContext(5506, 43, true);
                WriteLiteral("<br>\r\n                        Er referens: ");
                EndContext();
                BeginContext(5550, 27, false);
#line 175 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                Write(Model.ReceiverReferenceName);

#line default
#line hidden
                EndContext();
                BeginContext(5577, 150, true);
                WriteLiteral("\r\n                    </td>\r\n\r\n                    <td style=\"text-align: left;\">\r\n                        Fakturaadress<br>\r\n                        ");
                EndContext();
                BeginContext(5728, 18, false);
#line 180 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.CustomerName);

#line default
#line hidden
                EndContext();
                BeginContext(5746, 30, true);
                WriteLiteral("<br>\r\n                        ");
                EndContext();
                BeginContext(5777, 28, false);
#line 181 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.CustomerInvoiceAddress);

#line default
#line hidden
                EndContext();
                BeginContext(5805, 30, true);
                WriteLiteral("<br>\r\n                        ");
                EndContext();
                BeginContext(5836, 21, false);
#line 182 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.CustomerZipCode);

#line default
#line hidden
                EndContext();
                BeginContext(5857, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(5859, 18, false);
#line 182 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                          Write(Model.CustomerCity);

#line default
#line hidden
                EndContext();
                BeginContext(5877, 30, true);
                WriteLiteral("<br>\r\n                        ");
                EndContext();
                BeginContext(5908, 21, false);
#line 183 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.CustomerCountry);

#line default
#line hidden
                EndContext();
                BeginContext(5929, 105, true);
                WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n\r\n        <p>");
                EndContext();
                BeginContext(6035, 24, false);
#line 189 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
      Write(Model.InvoiceMessageText);

#line default
#line hidden
                EndContext();
                BeginContext(6059, 508, true);
                WriteLiteral(@"</p>

        <div class=""container"">
            <table class=""table"">
                <thead>
                    <tr style=""text-align:left;"">
                        <th scope=""col"">Artnr</th>
                        <th scope=""col"">Produkt/tjänst</th>
                        <th scope=""col"">Antal enheter</th>
                        <th scope=""col"">A-pris</th>
                        <th scope=""col"">Summa</th>
                    </tr>
                </thead>
                <tbody>
");
                EndContext();
#line 203 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                     foreach (var p in Model.InvoiceProducts)
                    {

#line default
#line hidden
                BeginContext(6653, 99, true);
                WriteLiteral("                        <tr>\r\n                            <th scope=\"row\" style=\"text-align:left;\">");
                EndContext();
                BeginContext(6753, 15, false);
#line 206 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                                                Write(p.ArticleNumber);

#line default
#line hidden
                EndContext();
                BeginContext(6768, 64, true);
                WriteLiteral("</th>\r\n                            <td style=\"text-align:left;\">");
                EndContext();
                BeginContext(6833, 6, false);
#line 207 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                                    Write(p.Name);

#line default
#line hidden
                EndContext();
                BeginContext(6839, 39, true);
                WriteLiteral("</td>\r\n                            <td>");
                EndContext();
                BeginContext(6879, 10, false);
#line 208 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                           Write(p.Quantity);

#line default
#line hidden
                EndContext();
                BeginContext(6889, 39, true);
                WriteLiteral("</td>\r\n                            <td>");
                EndContext();
                BeginContext(6929, 7, false);
#line 209 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                           Write(p.Price);

#line default
#line hidden
                EndContext();
                BeginContext(6936, 44, true);
                WriteLiteral(" kr</td>\r\n                            <td>\r\n");
                EndContext();
#line 211 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                  
                                    var price = @p.Price;
                                    var quantity = @p.Quantity;
                                    var sum = @p.Quantity * @p.Price;
                                

#line default
#line hidden
                BeginContext(7246, 32, true);
                WriteLiteral("                                ");
                EndContext();
                BeginContext(7279, 3, false);
#line 216 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                           Write(sum);

#line default
#line hidden
                EndContext();
                BeginContext(7282, 71, true);
                WriteLiteral(" kr\r\n                            </td>\r\n                        </tr>\r\n");
                EndContext();
#line 219 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                    }

#line default
#line hidden
                BeginContext(7376, 567, true);
                WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>



    <div class=""container fixed-bottom"">
        <table class=""table"">
            <thead>
                <tr style=""text-align:left;"">
                    <th scope=""col"">Exkl. moms</th>
                    <th scope=""col"">Moms 25%</th>
                    <th scope=""col"">Öresavr</th>
                    <th scope=""col"">Att betala</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td style=""text-align:left;"">");
                EndContext();
                BeginContext(7944, 25, false);
#line 239 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                            Write(Model.TotalCostWithoutTax);

#line default
#line hidden
                EndContext();
                BeginContext(7969, 59, true);
                WriteLiteral(" kr</td>\r\n                    <td style=\"text-align:left;\">");
                EndContext();
                BeginContext(8029, 9, false);
#line 240 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                            Write(Model.Tax);

#line default
#line hidden
                EndContext();
                BeginContext(8038, 59, true);
                WriteLiteral(" kr</td>\r\n                    <td style=\"text-align:left;\">");
                EndContext();
                BeginContext(8098, 20, false);
#line 241 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                            Write(Model.DecimalRoundUp);

#line default
#line hidden
                EndContext();
                BeginContext(8118, 62, true);
                WriteLiteral(" kr</td>\r\n                    <td style=\"text-align:left;\"><b>");
                EndContext();
                BeginContext(8181, 15, false);
#line 242 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                               Write(Model.TotalCost);

#line default
#line hidden
                EndContext();
                BeginContext(8196, 270, true);
                WriteLiteral(@" kr </b></td>
                </tr>
            </tbody>
        </table>

        <table class=""table"">

            <tbody>
                <tr>
                    <td style=""text-align:left;"">
                        Adress <br />
                        ");
                EndContext();
                BeginContext(8467, 16, false);
#line 253 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.SenderName);

#line default
#line hidden
                EndContext();
                BeginContext(8483, 33, true);
                WriteLiteral(" <br />\r\n                        ");
                EndContext();
                BeginContext(8517, 24, false);
#line 254 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.UserInvoiceAddress);

#line default
#line hidden
                EndContext();
                BeginContext(8541, 33, true);
                WriteLiteral(" <br />\r\n                        ");
                EndContext();
                BeginContext(8575, 17, false);
#line 255 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.UserZipCode);

#line default
#line hidden
                EndContext();
                BeginContext(8592, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(8594, 14, false);
#line 255 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                      Write(Model.UserCity);

#line default
#line hidden
                EndContext();
                BeginContext(8608, 33, true);
                WriteLiteral(" <br />\r\n                        ");
                EndContext();
                BeginContext(8642, 17, false);
#line 256 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.UserCountry);

#line default
#line hidden
                EndContext();
                BeginContext(8659, 146, true);
                WriteLiteral("\r\n\r\n                    </td>\r\n                    <td style=\"text-align:left;\">\r\n                        Telefon <br />\r\n                        ");
                EndContext();
                BeginContext(8806, 21, false);
#line 261 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.UserPhoneNumber);

#line default
#line hidden
                EndContext();
                BeginContext(8827, 33, true);
                WriteLiteral(" <br />\r\n                        ");
                EndContext();
                BeginContext(8861, 13, false);
#line 262 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.UserFax);

#line default
#line hidden
                EndContext();
                BeginContext(8874, 32, true);
                WriteLiteral("<br />\r\n                        ");
                EndContext();
                BeginContext(8907, 15, false);
#line 263 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.EmailFrom);

#line default
#line hidden
                EndContext();
                BeginContext(8922, 145, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td style=\"text-align:left;\">\r\n                        Plusgiro <br />\r\n                        ");
                EndContext();
                BeginContext(9068, 18, false);
#line 267 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.UserPlusGiro);

#line default
#line hidden
                EndContext();
                BeginContext(9086, 73, true);
                WriteLiteral(" <br />\r\n                        Bankgiro<br />\r\n                        ");
                EndContext();
                BeginContext(9160, 18, false);
#line 269 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.UserBankGiro);

#line default
#line hidden
                EndContext();
                BeginContext(9178, 159, true);
                WriteLiteral(" <br />\r\n                    </td>\r\n                    <td style=\"text-align:left;\">\r\n                        Organisationsnr <br />\r\n                        ");
                EndContext();
                BeginContext(9338, 15, false);
#line 273 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.UserOrgNr);

#line default
#line hidden
                EndContext();
                BeginContext(9353, 76, true);
                WriteLiteral(" <br />\r\n                        Momsreg.nr <br />\r\n                        ");
                EndContext();
                BeginContext(9430, 19, false);
#line 275 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.UserMomsRegNr);

#line default
#line hidden
                EndContext();
                BeginContext(9449, 110, true);
                WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n\r\n\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(9566, 9, true);
            WriteLiteral("\r\n</html>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<vueproject.Models.Invoice> Html { get; private set; }
    }
}
#pragma warning restore 1591
