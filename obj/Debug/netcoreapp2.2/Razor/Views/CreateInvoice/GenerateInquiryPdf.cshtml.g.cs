#pragma checksum "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98ae6b3eb543b110048dad7c5468a2d5e56c73fe"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98ae6b3eb543b110048dad7c5468a2d5e56c73fe", @"/Views/CreateInvoice/GenerateInquiryPdf.cshtml")]
    public class Views_CreateInvoice_GenerateInquiryPdf : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<vueproject.ViewModels.InvoiceViewModel>
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
            BeginContext(47, 10, true);
            WriteLiteral("\r\n<html>\r\n");
            EndContext();
            BeginContext(57, 2442, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98ae6b3eb543b110048dad7c5468a2d5e56c73fe3069", async() => {
                BeginContext(63, 41, true);
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <title>");
                EndContext();
                BeginContext(105, 23, false);
#line 6 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
      Write(Model.InvoiceTypeToSend);

#line default
#line hidden
                EndContext();
                BeginContext(128, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(130, 8, false);
#line 6 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                               Write(Model.Id);

#line default
#line hidden
                EndContext();
                BeginContext(138, 1702, true);
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
                BeginContext(2200, 292, true);
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
            BeginContext(2499, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(2503, 4394, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98ae6b3eb543b110048dad7c5468a2d5e56c73fe7231", async() => {
                BeginContext(2509, 33, true);
                WriteLiteral("\r\n    <div class=\"invoice-box\">\r\n");
                EndContext();
                BeginContext(4389, 410, true);
                WriteLiteral(@"

        <table class=""table"">
            <tbody>
                <tr>

                    <td class=""title"">
                        <img src=""https://www.sparksuite.com/images/logo.png"" style=""width:100%; max-width:300px;"">
                    </td>

                    <td style=""text-align: left;"">
                        <h3><b>Faktura</b></h3><br>
                        Fakturanummer #");
                EndContext();
                BeginContext(4800, 8, false);
#line 159 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                  Write(Model.Id);

#line default
#line hidden
                EndContext();
                BeginContext(4808, 43, true);
                WriteLiteral("<br>\r\n                        Fakturadatum ");
                EndContext();
                BeginContext(4852, 17, false);
#line 160 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                Write(Model.InvoiceDate);

#line default
#line hidden
                EndContext();
                BeginContext(4869, 43, true);
                WriteLiteral("<br>\r\n                        Fakturadatum ");
                EndContext();
                BeginContext(4913, 20, false);
#line 161 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                Write(Model.InvoicePayDate);

#line default
#line hidden
                EndContext();
                BeginContext(4933, 44, true);
                WriteLiteral("<br>\r\n                        Vår referens: ");
                EndContext();
                BeginContext(4978, 16, false);
#line 162 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                 Write(Model.SenderName);

#line default
#line hidden
                EndContext();
                BeginContext(4994, 135, true);
                WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        Kundnummer ");
                EndContext();
                BeginContext(5130, 24, false);
#line 167 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                              Write(Model.ReceiverCustomerId);

#line default
#line hidden
                EndContext();
                BeginContext(5154, 48, true);
                WriteLiteral("<br>\r\n                        Betalningsvillkor ");
                EndContext();
                BeginContext(5203, 18, false);
#line 168 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                     Write(Model.PaymentTerms);

#line default
#line hidden
                EndContext();
                BeginContext(5221, 45, true);
                WriteLiteral("<br>\r\n                        Dröjsmålsränta ");
                EndContext();
                BeginContext(5267, 34, false);
#line 169 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                  Write(Model.InvoicecPastDuePercentageFee);

#line default
#line hidden
                EndContext();
                BeginContext(5301, 46, true);
                WriteLiteral(" %<br>\r\n                        Leveransdatum ");
                EndContext();
                BeginContext(5348, 18, false);
#line 170 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                 Write(Model.DeliveryDate);

#line default
#line hidden
                EndContext();
                BeginContext(5366, 43, true);
                WriteLiteral("<br>\r\n                        Er referens: ");
                EndContext();
                BeginContext(5410, 27, false);
#line 171 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                Write(Model.ReceiverReferenceName);

#line default
#line hidden
                EndContext();
                BeginContext(5437, 150, true);
                WriteLiteral("\r\n                    </td>\r\n\r\n                    <td style=\"text-align: left;\">\r\n                        Fakturaadress<br>\r\n                        ");
                EndContext();
                BeginContext(5588, 18, false);
#line 176 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.CustomerName);

#line default
#line hidden
                EndContext();
                BeginContext(5606, 30, true);
                WriteLiteral("<br>\r\n                        ");
                EndContext();
                BeginContext(5637, 28, false);
#line 177 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.CustomerInvoiceAddress);

#line default
#line hidden
                EndContext();
                BeginContext(5665, 30, true);
                WriteLiteral("<br>\r\n                        ");
                EndContext();
                BeginContext(5696, 21, false);
#line 178 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.CustomerZipCode);

#line default
#line hidden
                EndContext();
                BeginContext(5717, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(5719, 18, false);
#line 178 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                          Write(Model.CustomerCity);

#line default
#line hidden
                EndContext();
                BeginContext(5737, 30, true);
                WriteLiteral("<br>\r\n                        ");
                EndContext();
                BeginContext(5768, 21, false);
#line 179 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                   Write(Model.CustomerCountry);

#line default
#line hidden
                EndContext();
                BeginContext(5789, 105, true);
                WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n\r\n        <p>");
                EndContext();
                BeginContext(5895, 24, false);
#line 185 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
      Write(Model.InvoiceMessageText);

#line default
#line hidden
                EndContext();
                BeginContext(5919, 456, true);
                WriteLiteral(@"</p>

        <div class=""container"">
            <table class=""table"">
                <thead>
                    <tr style=""text-align:left;"">
                        <th scope=""col"">Artnr</th>
                        <th scope=""col"">Produkt/tjänst</th>
                        <th scope=""col"">Antal Enheter</th>
                        <th scope=""col"">A-pris</th>
                    </tr>
                </thead>
                <tbody>
");
                EndContext();
#line 198 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                     foreach (var p in Model.InvoiceProducts)
                    {

#line default
#line hidden
                BeginContext(6461, 99, true);
                WriteLiteral("                        <tr>\r\n                            <th scope=\"row\" style=\"text-align:left;\">");
                EndContext();
                BeginContext(6561, 15, false);
#line 201 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                                                Write(p.ArticleNumber);

#line default
#line hidden
                EndContext();
                BeginContext(6576, 64, true);
                WriteLiteral("</th>\r\n                            <td style=\"text-align:left;\">");
                EndContext();
                BeginContext(6641, 6, false);
#line 202 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                                                    Write(p.Name);

#line default
#line hidden
                EndContext();
                BeginContext(6647, 39, true);
                WriteLiteral("</td>\r\n                            <td>");
                EndContext();
                BeginContext(6687, 10, false);
#line 203 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                           Write(p.Quantity);

#line default
#line hidden
                EndContext();
                BeginContext(6697, 80, true);
                WriteLiteral("</td>\r\n                            <td>220</td>\r\n                        </tr>\r\n");
                EndContext();
#line 206 "C:\Users\alexa\Desktop\temptemp\ToDoVueV2-Login_Vue_Identity_V3\Views\CreateInvoice\GenerateInquiryPdf.cshtml"
                    }

#line default
#line hidden
                BeginContext(6800, 90, true);
                WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
            BeginContext(6897, 9, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<vueproject.ViewModels.InvoiceViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
