#pragma checksum "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Checkout\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cfd377fdc7e96bd57ff8f6c886d586cfd898ff0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Checkout_Index), @"mvc.1.0.view", @"/Views/Checkout/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Checkout/Index.cshtml", typeof(AspNetCore.Views_Checkout_Index))]
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
#line 1 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\_ViewImports.cshtml"
using HomeSquareApp;

#line default
#line hidden
#line 2 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\_ViewImports.cshtml"
using HomeSquareApp.Models;

#line default
#line hidden
#line 3 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\_ViewImports.cshtml"
using HomeSquareApp.ViewModels;

#line default
#line hidden
#line 4 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfd377fdc7e96bd57ff8f6c886d586cfd898ff0b", @"/Views/Checkout/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbd4935bfe04b891565f35780adde2d735f90d05", @"/Views/_ViewImports.cshtml")]
    public class Views_Checkout_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/css/checkOut.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("checkoutForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("bg-white py-5 px-3 px-md-5 checkOut-Card"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("checkoutForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/js/checkout.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Checkout\Index.cshtml"
  
    ViewData["Title"] = "Checkout";

#line default
#line hidden
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("pageSpecificCss", async() => {
                BeginContext(71, 125, true);
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css\">\r\n    ");
                EndContext();
                BeginContext(196, 55, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bce7db958a0a483282fdb531044794ca", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(251, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(256, 75, true);
            WriteLiteral("\r\n\r\n\r\n\r\n<div class=\"container py-5 text-dark\" id=\"checkoutFormContainer\">\r\n");
            EndContext();
            BeginContext(377, 161, true);
            WriteLiteral("    <h1 style=\"font-size:22px\">Checkout <span class=\"text-muted\">(2 Items)</span></h1>\r\n    <div class=\"d-md-flex\">\r\n        <div class=\"col-md-8\">\r\n            ");
            EndContext();
            BeginContext(538, 7956, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e18a83e2ad6411ea15f2cb6a0e28c91", async() => {
                BeginContext(631, 331, true);
                WriteLiteral(@"
                <span id=""progressBarCheckoutPrompt"">1/2</span>
                <div class=""progress mb-3"" style=""height: 1px;"">
                    <div id=""progressCheckout"" class=""progress-bar"" role=""progressbar"" style=""width: 50%;"" aria-valuenow=""50"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                </div>

");
                EndContext();
                BeginContext(1008, 2166, true);
                WriteLiteral(@"                <div class=""step step-1 active"">

                    <h2 class=""fw-bold"">Select Delivery Options</h2>
                    <div class=""d-md-flex gap-md-2 mt-5"">
                        <div class=""radio-Card col-md-6"">
                            <input id=""delivery"" name=""deliveryOptions"" type=""radio"" checked>
                            <label for=""deliveryOptions"" class="" h-100 d-flex flex-column "">
                                <span class=""mx-4 mt-4 radio-Card-Header"">Delivery</span>
                                <span class=""mt-3 mx-4"">We will deliver the items to your door</span>
                            </label>
                        </div>
                        <div class=""radio-Card col-md-6 mt-md-0 mt-2"">
                            <input id=""pickup"" name=""deliveryOptions"" type=""radio"">
                            <label for=""deliveryOptions"" class="" h-100 d-flex flex-column "">
                                <span class=""mx-4 mt-4 radio-Card-Header"">Pickup");
                WriteLiteral(@"</span>
                                <span class=""mt-3 mx-4"">Pick up your items on our store</span>
                            </label>
                        </div>
                    </div>

                    <h2 class=""fw-bold mt-5"">Your Details</h2>
                    <div class=""row g-2 mt-3"">
                        <div class=""mb-3 col-6"">
                            <label for=""inputFirstName"" class=""form-label"">First Name</label>
                            <input type=""text"" class=""bg-light rounded-pill form-control"" id=""inputFirstName"" aria-describedby=""firstName"">
                        </div>
                        <div class=""mb-3 col-6"">
                            <label for=""inputLastName"" class=""form-label"">Last Name</label>
                            <input type=""text"" class=""bg-light rounded-pill form-control"" id=""inputLastName"" aria-describedby=""lastName"">
                        </div>
                    </div>
                    <div class=""mb-3"">
       ");
                WriteLiteral("                 <label for=\"inputEmail\" class=\"form-label\">Email</label>\r\n                        <input type=\"email\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 3174, "\"", 3208, 3);
                WriteAttributeValue("", 3188, "cantoso", 3188, 7, true);
                WriteAttributeValue("", 3195, "@", 3195, 1, true);
                WriteAttributeValue("", 3197, "hotmail.com", 3197, 11, true);
                EndWriteAttribute();
                BeginContext(3209, 434, true);
                WriteLiteral(@" class=""bg-light rounded-pill form-control"" id=""inputEmail"" aria-describedby=""email"">
                    </div>
                    <div class=""mb-3"">
                        <label for=""inputPhone"" class=""form-label"">Phone Number</label>
                        <input type=""tel"" placeholder=""+6427272990"" class=""bg-light rounded-pill form-control"" id=""inputPhone"" aria-describedby=""phoneNumber"">
                    </div>

");
                EndContext();
                BeginContext(3706, 1764, true);
                WriteLiteral(@"                    <div id=""DeliveryInfo"">
                        <h2 class=""fw-bold mt-5"">Delivery Information</h2>
                        <div class=""mb-3"">
                            <label for=""inputAddress"" class=""form-label"">Delivery Address</label>
                            <input type=""text"" class=""bg-light rounded-pill form-control"" id=""inputAddress"" aria-describedby=""address"">
                        </div>
                        <div class=""row g-2 mt-3"">
                            <div class=""mb-3 col-6"">
                                <label for=""inputSuburb"" class=""form-label"">Suburb</label>
                                <input type=""text"" class=""bg-light rounded-pill form-control"" id=""inputSuburb"" aria-describedby=""suburb"">
                            </div>
                            <div class=""mb-3 col-4"">
                                <label for=""inputZipCode"" class=""form-label"">ZipCode</label>
                                <input type=""number"" placeholder=""0000");
                WriteLiteral(@""" class=""bg-light rounded-pill form-control"" id=""inputZipCode"" aria-describedby=""zipCode"">
                            </div>
                            <div class=""mb-3 col-2"">
                                <label for=""inputUnitNumber"" class=""form-label"">Unit #</label>
                                <input type=""text"" placeholder=""000"" class=""bg-light rounded-pill form-control"" id=""inputUnitNumber"" aria-describedby=""unitNumber"">
                            </div>
                        </div>
                    </div>
                    <div class=""mt-3"">
                        <button type=""button"" class=""btn btn-success float-end w-25 next-btn"">Next</button>
                    </div>
                </div>
");
                EndContext();
                BeginContext(5514, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(5562, 2668, true);
                WriteLiteral(@"                <div class=""step step-2"">
                    <h2 class=""fw-bold"">Payment</h2>
                    <label for=""fname"">Accepted Cards</label>
                    <div class=""icon-container"">
                        <i class=""fa fa-cc-visa"" style=""color:navy;""></i>
                        <i class=""fa fa-cc-amex"" style=""color:blue;""></i>
                        <i class=""fa fa-cc-mastercard"" style=""color:red;""></i>
                        <i class=""fa fa-cc-discover"" style=""color:orange;""></i>
                    </div>

                    <div class=""mt-4 mb-3"">
                        <label for=""inputCardName"" class=""form-label"">Name on Card</label>
                        <input type=""text"" name=""cardName"" class=""bg-light rounded-pill form-control"" id=""inputCardName"" aria-describedby=""cardName"">
                    </div>
                    <div class=""mb-3"">
                        <label for=""inputCreditCardNumber"" class=""form-label"">Credit card number</label>
           ");
                WriteLiteral(@"             <input type=""text"" name=""creditCardNumber"" placeholder=""1111-2222-3333-4444"" class=""bg-light rounded-pill form-control"" id=""inputCreditCardNumber"" aria-describedby=""creditCardNumber"">
                    </div>
                    <div class=""mb-3"">
                        <div class=""d-flex"">
                            <div class=""flex-fill"">
                                <label for=""inputExpiryDate"" class=""form-label"">Expiry Date</label>

                                <div class=""d-flex gap-2"">
                                    <input type=""text"" style=""width:60px"" name=""expiryMonth"" placeholder=""MM"" class=""bg-light rounded-3 form-control"" id=""inputExpiryDate"" aria-describedby=""expiryMonth"">
                                    <span style=""font-size:22px"">/</span>
                                    <input type=""text"" style=""width:60px"" name=""expiryYear"" placeholder=""YY"" class=""bg-light rounded-3 form-control"" id=""inputExpiryYear"" aria-describedby=""expiryYear"">
               ");
                WriteLiteral(@"                 </div>
                            </div>
                            <div class=""mb-3"">
                                <label for=""inputCVV"" class=""form-label"">CVV</label>
                                <input type=""text"" style=""width:60px"" name=""CVV"" placeholder=""000"" class=""bg-light rounded-3 form-control"" id=""inputCVV"" aria-describedby=""CVV"">
                            </div>
                        </div>
                    </div>

                    <div class=""mt-3"">
                        <button type=""button"" class=""btn btn-light float-start w-25 prev-btn"">Prev</button>
");
                EndContext();
                BeginContext(8279, 152, true);
                WriteLiteral("                        <button type=\"submit\" class=\"btn btn-dark float-end\">Submit Order</button>\r\n                    </div>\r\n                </div>\r\n");
                EndContext();
                BeginContext(8475, 12, true);
                WriteLiteral("            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(8494, 656, true);
            WriteLiteral(@"
        </div>
        <div class=""col-md-4 bg-light px-lg-5 px-3 py-4 ms-md-3 mt-4 mt-md-0"">
            <h2>Order Summary</h2>
            <hr />
            <div class=""d-flex"">
                <table class=""table table-borderless table-responsive"">
                    <thead>
                        <tr>
                            <th scope=""col"" class=""text-muted"">Qty</th>
                            <th scope=""col"" class=""text-muted"">Product</th>
                            <th scope=""col"" class=""text-muted"">Price</th>
                        </tr>
                    </thead>
                   
                    <tbody>
");
            EndContext();
            BeginContext(9205, 1130, true);
            WriteLiteral(@"                        <tr>
                            <td class=""text-muted text-nowrap"">100 X</td>
                            <td>Lorem Ipsum has been the industry's standard dummy text ever since the 1500s</td>
                            <td class=""text-nowrap""><small>$</small> 1000 <small>00</small></td>
                        </tr>
                        <tr>
                            <td class=""text-muted text-nowrap"">100 X</td>
                            <td>Lorem Ipsum has been the industry's standard dummy text ever since the 1500s</td>
                            <td class=""text-nowrap""><small>$</small> 1000 <small>00</small></td>
                        <tr>
                            <td class=""text-muted text-nowrap"">100 X</td>
                            <td>Lorem Ipsum has been the industry's standard dummy text ever since the 1500s</td>
                            <td class=""text-nowrap""><small>$</small> 1000 <small>00</small></td>
                        </tr>
        ");
            WriteLiteral("            </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(10352, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(10358, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8d79315c80fa49e09d0028cb0a2ac9e7", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(10402, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
