#pragma checksum "C:\Users\Waver\source\repos\HomeSquareApp\HomeSquareApp\Views\Deals\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7db12f1ab023ae3415631f8c11a7f6ac480f1ecd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Deals_Index), @"mvc.1.0.view", @"/Views/Deals/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Deals/Index.cshtml", typeof(AspNetCore.Views_Deals_Index))]
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
#line 1 "C:\Users\Waver\source\repos\HomeSquareApp\HomeSquareApp\Views\_ViewImports.cshtml"
using HomeSquareApp;

#line default
#line hidden
#line 2 "C:\Users\Waver\source\repos\HomeSquareApp\HomeSquareApp\Views\_ViewImports.cshtml"
using HomeSquareApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7db12f1ab023ae3415631f8c11a7f6ac480f1ecd", @"/Views/Deals/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a5520fbc05a94fac60d7e61edcbd77a4127b62e", @"/Views/_ViewImports.cshtml")]
    public class Views_Deals_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/OwlCarousel2/assets/owl.carousel.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/OwlCarousel2/assets/owl.theme.default.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/css/productCard.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/images/banner/banner3.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("min-height:215px;width:100%; object-fit:cover;object-position: 25% center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ProductCardLongStripPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Waver\source\repos\HomeSquareApp\HomeSquareApp\Views\Deals\Index.cshtml"
  
    ViewData["Title"] = "Deals";

#line default
#line hidden
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("pageSpecificCss", async() => {
                BeginContext(68, 123, true);
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css\">\r\n\r\n");
                EndContext();
                BeginContext(214, 4, true);
                WriteLiteral("    ");
                EndContext();
                BeginContext(218, 73, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "afc44f7a7d7c4d718e81dec6faff19ca", async() => {
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
                BeginContext(291, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(297, 78, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9d07edeac9804c3fa72a4dc120d6b8ed", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(375, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(383, 58, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1b141544d4dc4c5091c80fe3535c90e5", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(441, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(446, 67, true);
            WriteLiteral("\r\n<div class=\"mb-5\">\r\n    <div style=\"position:relative\">\r\n        ");
            EndContext();
            BeginContext(513, 126, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d6597acda34948ca8c5ae73c73497fe6", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(639, 1416, true);
            WriteLiteral(@"
    </div>
    <div class=""container-fluid pt-5 bg-white"">
        <div class=""text-md-center"">
            <button class=""m-2 btn btn-light text-dark border-secondary rounded-pill"">All Products</button>
            <button class=""m-2 btn btn-light text-dark border-secondary rounded-pill"">Easter Sale</button>
            <button class=""m-2 btn btn-light text-dark border-secondary rounded-pill"">Golden Week Sale</button>
            <button class=""m-2 btn btn-light text-dark border-secondary rounded-pill"">Special This Week</button>
        </div>
    </div>
    
    <div class=""m-5"">

        <div class=""d-md-flex justify-content-between align-items-center"">
            <h1 style=""font-size:32px"">Latest Deals</h1>
            <button class=""btn btn-dark"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#collapseFilter"" aria-expanded=""false"" aria-controls=""collapseFilter"">
                <svg class=""bi"" width=""16"" height=""24"" fill=""currentColor"">
                    <use xlink:href=""./l");
            WriteLiteral(@"ib/images/bootstrap-icons-1.4.0/bootstrap-icons.svg#filter"" />
                </svg>
                Filter
            </button>
        </div>
        <div class=""collapse mt-2"" id=""collapseFilter"">
            <div class=""card card-body"">

            </div>
        </div>
        <div class=""position-relative"">
            <div class=""mt-3 owl-carousel owl-carouselDeals"">
");
            EndContext();
#line 46 "C:\Users\Waver\source\repos\HomeSquareApp\HomeSquareApp\Views\Deals\Index.cshtml"
                 for (int i = 0; i < 8; i++)
                {

#line default
#line hidden
            BeginContext(2120, 51, true);
            WriteLiteral("                    <div>\r\n                        ");
            EndContext();
            BeginContext(2171, 47, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e7909a67fad94b2cb32f64cb2fef4846", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2218, 30, true);
            WriteLiteral("\r\n                    </div>\r\n");
            EndContext();
#line 51 "C:\Users\Waver\source\repos\HomeSquareApp\HomeSquareApp\Views\Deals\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(2267, 471, true);
            WriteLiteral(@"            </div>
            <button style=""z-index:2"" class=""dealsPrevBtn position-absolute end-100 top-50 btn bg-transparent text-dark"">
                <span class=""fa fa-chevron-left""></span>
            </button>
            <button style=""z-index:2"" class=""dealsNextBtn position-absolute start-100 top-50 btn bg-transparent text-dark"">
                <span class=""fa fa-chevron-right""></span>
            </button>
        </div>
    </div>
</div>


");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2756, 1015, true);
                WriteLiteral(@"
    <script>
        //Recipe Carousel
        //--------------------------------------------------------
        var owlDeals = $('.owl-carouselDeals');
        //Initialization
        owlDeals.owlCarousel({
            loop: true,
            margin: 10,
            
            nav: false,
            responsive: {
                0: {
                    items: 1,
                },
                577: {
                    items: 3,
                },
                769: {
                    items: 5,
                },
            }
        }
        );
        // Go to the next item
        $('.dealsNextBtn').click(function () {
            owlDeals.trigger('next.owl.carousel');
        })
        // Go to the previous item
        $('.dealsPrevBtn').click(function () {
            // With optional speed parameter
            // Parameters has to be in square bracket '[]'
            owlDeals.trigger('prev.owl.carousel', [300]);
        })
    </script>
");
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
