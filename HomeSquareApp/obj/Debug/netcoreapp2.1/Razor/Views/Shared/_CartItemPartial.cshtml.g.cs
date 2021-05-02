#pragma checksum "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47f2717d6a3c2bbc86c9470f0e28194e79337e06"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CartItemPartial), @"mvc.1.0.view", @"/Views/Shared/_CartItemPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_CartItemPartial.cshtml", typeof(AspNetCore.Views_Shared__CartItemPartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47f2717d6a3c2bbc86c9470f0e28194e79337e06", @"/Views/Shared/_CartItemPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbd4935bfe04b891565f35780adde2d735f90d05", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CartItemPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeSquareApp.Models.OrderDetails>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
  

    //check is sale and sale period
    double priceAfterDiscount = Model.Product.ProductPrice;
    if (Model.Product.ProductStatus.ProductStatusName == "Sale"
        && Model.Product.SaleStartDateTime <= DateTime.Now
        && Model.Product.SaleEndDateTime >= DateTime.Now)
    {
        priceAfterDiscount = Model.Product.ProductPrice - (Model.Product.ProductPrice * (Model.Product.ProductDiscount == null ? 0 : (double)Model.Product.ProductDiscount));
    }

    string price = string.Format("{0:F2}", priceAfterDiscount);
    string[] priceBase = price.Split('.');
    string totalIndividualPrice = string.Format("{0:F2}", priceAfterDiscount * Model.Quantity);
    string[] totalIndividualBase = totalIndividualPrice.Split('.');

#line default
#line hidden
            BeginContext(801, 6, true);
            WriteLiteral("\r\n<div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 807, "\"", 862, 1);
#line 20 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 812, String.Format("cartItem{0}",Model.OrderDetailsID), 812, 50, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(863, 84, true);
            WriteLiteral(" class=\"card shadow-sm rounded-0 rounded-start m-2\">\r\n    <div class=\"d-flex g-0\">\r\n");
            EndContext();
            BeginContext(1024, 15, true);
            WriteLiteral("        <button");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1039, "\"", 1086, 3);
            WriteAttributeValue("", 1049, "app.removeItem(", 1049, 15, true);
#line 23 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 1064, Model.OrderDetailsID, 1064, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 1085, ")", 1085, 1, true);
            EndWriteAttribute();
            BeginContext(1087, 234, true);
            WriteLiteral(" class=\"btn col-1 btn-danger rounded-0 rounded-start\">\r\n            X\r\n        </button>\r\n        <div class=\"d-flex flex-column\">\r\n            <div class=\"d-flex\">\r\n                <div class=\"px-3 col-3 d-flex align-items-center\">\r\n");
            EndContext();
            BeginContext(1376, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(1396, 103, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3e256fd371794efd9f541ac663ca963e", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
            WriteLiteral("~/lib/images/products/");
#line 30 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
                                                          WriteLiteral(Model.Product.ImageUrl);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 30 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1499, 108, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"pt-3 col-9\">\r\n                    <div class=\"me-3\">\r\n");
            EndContext();
            BeginContext(1663, 82, true);
            WriteLiteral("                        <small class=\"fw-bold text-muted\" style=\"font-size:0.9em\">");
            EndContext();
            BeginContext(1746, 25, false);
#line 35 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
                                                                             Write(Model.Product.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(1771, 174, true);
            WriteLiteral("</small>\r\n                        <div class=\"d-flex align-items-center justify-content-between pt-2 pb-1 my-md-0 \">\r\n                            <small class=\"text-muted\">$ ");
            EndContext();
            BeginContext(1946, 94, false);
#line 37 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
                                                   Write(String.Format("{0} {1} / {2}",priceBase[0],priceBase[1],Model.Product.ServingType.ServingType));

#line default
#line hidden
            EndContext();
            BeginContext(2040, 10, true);
            WriteLiteral("</small>\r\n");
            EndContext();
            BeginContext(2149, 181, true);
            WriteLiteral("                            <div class=\"\">\r\n                                <small class=\"text-muted me-2\">Qty </small>\r\n                                <input type=\"number\" min=\"1\"");
            EndContext();
            BeginWriteAttribute("onchange", " onchange=\"", 2330, "\"", 2397, 3);
            WriteAttributeValue("", 2341, "app.updateItemQuantity(", 2341, 23, true);
#line 41 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 2364, Model.OrderDetailsID, 2364, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 2385, ",this.value)", 2385, 12, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " \r\n                                       value=\"", 2398, "\"", 2462, 1);
#line 42 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 2447, Model.Quantity, 2447, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2463, "\"", 2526, 1);
#line 42 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 2468, String.Format("cartItemQuantity{0}",Model.OrderDetailsID), 2468, 58, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2527, 248, true);
            WriteLiteral("/>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"mx-3 border-top border-muted d-flex align-items-center\">\r\n                <small");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2775, "\"", 2835, 1);
#line 49 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 2780, String.Format("cartItemError{0}",Model.OrderDetailsID), 2780, 55, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2836, 151, true);
            WriteLiteral(" class=\"text-danger\"></small>\r\n                <span class=\"text-muted ms-auto\" style=\"font-family:Bahnschrift; font-size: 18px\"><small>$</small> <span");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2987, "\"", 3052, 1);
#line 50 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 2992, String.Format("productTotalPriceN{0}",Model.OrderDetailsID), 2992, 60, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3053, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3055, 22, false);
#line 50 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
                                                                                                                                                                                      Write(totalIndividualBase[0]);

#line default
#line hidden
            EndContext();
            BeginContext(3077, 14, true);
            WriteLiteral("</span> <small");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3091, "\"", 3156, 1);
#line 50 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 3096, String.Format("productTotalPriceD{0}",Model.OrderDetailsID), 3096, 60, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3157, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3159, 22, false);
#line 50 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
                                                                                                                                                                                                                                                                                              Write(totalIndividualBase[1]);

#line default
#line hidden
            EndContext();
            BeginContext(3181, 71, true);
            WriteLiteral("</small></span>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeSquareApp.Models.OrderDetails> Html { get; private set; }
    }
}
#pragma warning restore 1591
