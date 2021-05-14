#pragma checksum "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a9f45828b8dbeeb601bc60d0c2f16e49fe458a7"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a9f45828b8dbeeb601bc60d0c2f16e49fe458a7", @"/Views/Shared/_CartItemPartial.cshtml")]
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
        priceAfterDiscount = Model.Product.PriceAfterDiscount;
    }

    string price = string.Format("{0:F2}", priceAfterDiscount);
    string[] priceBase = price.Split('.');
    string totalIndividualPrice = string.Format("{0:F2}", priceAfterDiscount * Model.Quantity);
    string[] totalIndividualBase = totalIndividualPrice.Split('.');

#line default
#line hidden
            BeginContext(690, 6, true);
            WriteLiteral("\r\n<div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 696, "\"", 751, 1);
#line 20 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 701, String.Format("cartItem{0}",Model.OrderDetailsID), 701, 50, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(752, 84, true);
            WriteLiteral(" class=\"card shadow-sm rounded-0 rounded-start m-2\">\r\n    <div class=\"d-flex g-0\">\r\n");
            EndContext();
            BeginContext(913, 15, true);
            WriteLiteral("        <button");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 928, "\"", 975, 3);
            WriteAttributeValue("", 938, "app.removeItem(", 938, 15, true);
#line 23 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 953, Model.OrderDetailsID, 953, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 974, ")", 974, 1, true);
            EndWriteAttribute();
            BeginContext(976, 234, true);
            WriteLiteral(" class=\"btn col-1 btn-danger rounded-0 rounded-start\">\r\n            X\r\n        </button>\r\n        <div class=\"d-flex flex-column\">\r\n            <div class=\"d-flex\">\r\n                <div class=\"px-3 col-3 d-flex align-items-center\">\r\n");
            EndContext();
            BeginContext(1265, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(1285, 103, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ae073280fae8458397438df8717a6d55", async() => {
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
            BeginContext(1388, 108, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"pt-3 col-9\">\r\n                    <div class=\"me-3\">\r\n");
            EndContext();
            BeginContext(1552, 82, true);
            WriteLiteral("                        <small class=\"fw-bold text-muted\" style=\"font-size:0.9em\">");
            EndContext();
            BeginContext(1635, 25, false);
#line 35 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
                                                                             Write(Model.Product.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(1660, 174, true);
            WriteLiteral("</small>\r\n                        <div class=\"d-flex align-items-center justify-content-between pt-2 pb-1 my-md-0 \">\r\n                            <small class=\"text-muted\">$ ");
            EndContext();
            BeginContext(1835, 94, false);
#line 37 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
                                                   Write(String.Format("{0} {1} / {2}",priceBase[0],priceBase[1],Model.Product.ServingType.ServingType));

#line default
#line hidden
            EndContext();
            BeginContext(1929, 10, true);
            WriteLiteral("</small>\r\n");
            EndContext();
            BeginContext(2038, 181, true);
            WriteLiteral("                            <div class=\"\">\r\n                                <small class=\"text-muted me-2\">Qty </small>\r\n                                <input type=\"number\" min=\"1\"");
            EndContext();
            BeginWriteAttribute("onchange", " onchange=\"", 2219, "\"", 2286, 3);
            WriteAttributeValue("", 2230, "app.updateItemQuantity(", 2230, 23, true);
#line 41 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 2253, Model.OrderDetailsID, 2253, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 2274, ",this.value)", 2274, 12, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " \r\n                                       value=\"", 2287, "\"", 2351, 1);
#line 42 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 2336, Model.Quantity, 2336, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2352, "\"", 2415, 1);
#line 42 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 2357, String.Format("cartItemQuantity{0}",Model.OrderDetailsID), 2357, 58, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2416, 248, true);
            WriteLiteral("/>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"mx-3 border-top border-muted d-flex align-items-center\">\r\n                <small");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2664, "\"", 2724, 1);
#line 49 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 2669, String.Format("cartItemError{0}",Model.OrderDetailsID), 2669, 55, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2725, 151, true);
            WriteLiteral(" class=\"text-danger\"></small>\r\n                <span class=\"text-muted ms-auto\" style=\"font-family:Bahnschrift; font-size: 18px\"><small>$</small> <span");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2876, "\"", 2941, 1);
#line 50 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 2881, String.Format("productTotalPriceN{0}",Model.OrderDetailsID), 2881, 60, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2942, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2944, 22, false);
#line 50 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
                                                                                                                                                                                      Write(totalIndividualBase[0]);

#line default
#line hidden
            EndContext();
            BeginContext(2966, 14, true);
            WriteLiteral("</span> <small");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2980, "\"", 3045, 1);
#line 50 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
WriteAttributeValue("", 2985, String.Format("productTotalPriceD{0}",Model.OrderDetailsID), 2985, 60, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3046, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3048, 22, false);
#line 50 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_CartItemPartial.cshtml"
                                                                                                                                                                                                                                                                                              Write(totalIndividualBase[1]);

#line default
#line hidden
            EndContext();
            BeginContext(3070, 71, true);
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
