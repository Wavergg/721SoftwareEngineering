#pragma checksum "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24459a84dab76e92dcc78380417098c56e1923cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProductCardLongStripPartial), @"mvc.1.0.view", @"/Views/Shared/_ProductCardLongStripPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_ProductCardLongStripPartial.cshtml", typeof(AspNetCore.Views_Shared__ProductCardLongStripPartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24459a84dab76e92dcc78380417098c56e1923cd", @"/Views/Shared/_ProductCardLongStripPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbd4935bfe04b891565f35780adde2d735f90d05", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProductCardLongStripPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeSquareApp.Models.Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("object-fit: contain;height:220px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("link-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-id", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-size:16px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-success product-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("pb-3 position-relative"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "HandleOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-begin", new global::Microsoft.AspNetCore.Html.HtmlString("app.disableSubmit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_15 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-complete", new global::Microsoft.AspNetCore.Html.HtmlString("app.cardOrderAdded"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_16 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-url", new global::Microsoft.AspNetCore.Html.HtmlString("/Order/HandleOrder"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(37, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
   
    //string priceAfterDiscount = string.Format("{0:F2}",(Model.ProductPrice - (Model.ProductPrice * Model.ProductDiscount)));
    double currentPrice = 0;
    if(Model.ProductStatus.ProductStatusName == "Sale" && Model.SaleEndDateTime >= DateTime.Now && Model.SaleStartDateTime <= DateTime.Now)
    {
        currentPrice = Model.PriceAfterDiscount;
    } else
    {
        currentPrice = Model.ProductPrice;
    }
    string formatPriceAfterDiscount = string.Format("{0:F2}", currentPrice);
    string[] priceBase = formatPriceAfterDiscount.Split('.');

    //TEMP CHANGE IT LATER, NOT EFFICIENT TO PERFORM CALCULATION FOR EVERYTHING
    double TOTAL_REVIEW_COUNT = Model.ReviewFiveStarsCount + Model.ReviewFourStarsCount + Model.ReviewThreeStarsCount + Model.ReviewTwoStarsCount + Model.ReviewOneStarsCount;
    double AVERAGE_REVIEW_SCORE = (Model.ReviewFiveStarsCount * 5 + Model.ReviewFourStarsCount * 4 + Model.ReviewThreeStarsCount * 3 + Model.ReviewTwoStarsCount * 2 + Model.ReviewOneStarsCount) / TOTAL_REVIEW_COUNT;
    double SCORE_ROUNDED = Math.Round(AVERAGE_REVIEW_SCORE) - 1;

#line default
#line hidden
            BeginContext(1156, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1179, 72, true);
            WriteLiteral("<div class=\"card pt-3 d-flex flex-column justify-content-between\">\r\n    ");
            EndContext();
            BeginContext(1251, 1775, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa13f8baa9114c018f6f665e95f97216", async() => {
                BeginContext(1350, 108, true);
                WriteLiteral("\r\n        <div class=\"p-3 align-items-center d-flex justify-content-center position-relative\">\r\n            ");
                EndContext();
                BeginContext(1458, 159, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a48b814483774036a9ffbcfc25d5ba12", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
                BeginWriteTagHelperAttribute();
                WriteLiteral("~/lib/images/products/");
#line 26 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                                WriteLiteral(Model.ImageUrl);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 26 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
AddHtmlAttributeValue("", 1512, Model.ProductName, 1512, 18, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#line 26 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
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
                BeginContext(1617, 69, true);
                WriteLiteral("\r\n            <div class=\"position-absolute bottom-0 start-0 ms-2\">\r\n");
                EndContext();
#line 33 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                 if (TOTAL_REVIEW_COUNT != 0)
                {
                    

#line default
#line hidden
#line 35 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                     for (int i = 0; i < 5; i++)
                    {
                        string className = "fa fa-star ";
                        if (i <= SCORE_ROUNDED)
                        {
                            className += "checked";
                        }

#line default
#line hidden
                BeginContext(2467, 29, true);
                WriteLiteral("                        <span");
                EndContext();
                BeginWriteAttribute("class", " class=\"", 2496, "\"", 2514, 1);
#line 42 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
WriteAttributeValue("", 2504, className, 2504, 10, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2515, 34, true);
                WriteLiteral(" style=\"font-size:12px;\"></span>\r\n");
                EndContext();
#line 43 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                    }

#line default
#line hidden
#line 43 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                     
                }

#line default
#line hidden
                BeginContext(2591, 36, true);
                WriteLiteral("            </div>\r\n        </div>\r\n");
                EndContext();
#line 47 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
         if (Model.ProductStatus.ProductStatusName == "Sale" && Model.SaleEndDateTime >= DateTime.Now && Model.SaleStartDateTime <= DateTime.Now)
        {

#line default
#line hidden
                BeginContext(2785, 158, true);
                WriteLiteral("            <div class=\"alert alert-success p-0 px-2 rounded-0\" style=\"position: absolute; left: -1px; top: 0px;\">\r\n                <small class=\"alert-link\">");
                EndContext();
                BeginContext(2945, 25, false);
#line 50 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                                      Write(Model.ProductDiscount*100);

#line default
#line hidden
                EndContext();
                BeginContext(2971, 36, true);
                WriteLiteral(" % OFF</small>\r\n            </div>\r\n");
                EndContext();
#line 52 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
        }

#line default
#line hidden
                BeginContext(3018, 4, true);
                WriteLiteral("    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 24 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                                                                         WriteLiteral(Model.ProductID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3026, 143, true);
            WriteLiteral("\r\n    <div class=\"product-details pt-1 flex-fill px-3\">\r\n        <div class=\"text-start text-md-center\" style=\"min-height:55px;\">\r\n            ");
            EndContext();
            BeginContext(3169, 177, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d0921fcb1544476a0f5976675423ad1", async() => {
                BeginContext(3292, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(3311, 17, false);
#line 57 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
           Write(Model.ProductName);

#line default
#line hidden
                EndContext();
                BeginContext(3328, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3346, 98, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"d-flex align-items-start mt-1 mt-lg-3\">\r\n            <div>\r\n");
            EndContext();
#line 62 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                 if (Model.ProductStock != 0)
                {

#line default
#line hidden
            BeginContext(3510, 84, true);
            WriteLiteral("                    <span class=\"product-price\">$</span><span class=\"product-price\">");
            EndContext();
            BeginContext(3595, 12, false);
#line 64 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                                                                               Write(priceBase[0]);

#line default
#line hidden
            EndContext();
            BeginContext(3607, 42, true);
            WriteLiteral("</span><sup class=\"product-price-decimal\">");
            EndContext();
            BeginContext(3650, 12, false);
#line 64 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                                                                                                                                      Write(priceBase[1]);

#line default
#line hidden
            EndContext();
            BeginContext(3662, 8, true);
            WriteLiteral("</sup>\r\n");
            EndContext();
#line 65 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                     if (Model.ProductStatus.ProductStatusName == "Sale" && Model.SaleEndDateTime >= DateTime.Now && Model.SaleStartDateTime <= DateTime.Now)
                    {

#line default
#line hidden
            BeginContext(3852, 105, true);
            WriteLiteral("                        <p>\r\n                            Was <span class=\"product-price-before-special\">$");
            EndContext();
            BeginContext(3958, 43, false);
#line 68 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                                                                       Write(String.Format("{0:F2}", Model.ProductPrice));

#line default
#line hidden
            EndContext();
            BeginContext(4001, 39, true);
            WriteLiteral("</span>\r\n                        </p>\r\n");
            EndContext();
#line 70 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                    }

#line default
#line hidden
#line 70 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                     
                }
                else
                {

#line default
#line hidden
            BeginContext(4123, 77, true);
            WriteLiteral("                    <span class=\"product-price-decimal\">Out of Stock</span>\r\n");
            EndContext();
#line 75 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                }

#line default
#line hidden
            BeginContext(4219, 95, true);
            WriteLiteral("            </div>\r\n            <div class=\"ms-auto\">\r\n                <span class=\"fw-normal\">");
            EndContext();
            BeginContext(4315, 27, false);
#line 78 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                                   Write(Model.ProductServingContent);

#line default
#line hidden
            EndContext();
            BeginContext(4342, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(4344, 29, false);
#line 78 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                                                                Write(Model.ServingType.ServingType);

#line default
#line hidden
            EndContext();
            BeginContext(4373, 61, true);
            WriteLiteral("</span>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    ");
            EndContext();
            BeginContext(4434, 1099, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02d401b2983e410dbcf446922e0ab2a5", async() => {
                BeginContext(4697, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(4803, 125, true);
                WriteLiteral("        <div class=\"px-3 my-2 d-md-flex align-items-center text-center\">\r\n\r\n            <input name=\"productID\" type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4928, "\"", 4952, 1);
#line 87 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
WriteAttributeValue("", 4936, Model.ProductID, 4936, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4953, 129, true);
                WriteLiteral(" />\r\n            <label class=\"text-muted\" style=\"font-size:14px;\">QTY</label>\r\n            <input name=\"quantity\" type=\"number\" ");
                EndContext();
                BeginContext(5084, 40, false);
#line 89 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                                             Write(Model.ProductStock > 0 ? "" : "disabled");

#line default
#line hidden
                EndContext();
                BeginContext(5125, 132, true);
                WriteLiteral(" placeholder=\"1\" min=\"1\" value=\"1\" class=\"mx-2 w-25\" />\r\n\r\n            <button type=\"submit\" onclick=\"app.orderFormSubmitBtn(this)\" ");
                EndContext();
                BeginContext(5259, 40, false);
#line 91 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Shared\_ProductCardLongStripPartial.cshtml"
                                                                     Write(Model.ProductStock > 0 ? "" : "disabled");

#line default
#line hidden
                EndContext();
                BeginContext(5300, 226, true);
                WriteLiteral(" class=\"ms-auto my-3 my-md-0 btn btn-success rounded-pill float-md-end\">Add To Cart</button>\r\n        </div>\r\n        <small class=\"w-100 position-absolute bottom-0 justify-content-center text-center text-white\"></small>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_15);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_16);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5533, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeSquareApp.Models.Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
