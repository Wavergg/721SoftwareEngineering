#pragma checksum "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c3e7c443d0512c7cc5fc3b38e6664fdef36b10d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Recipe_Details), @"mvc.1.0.view", @"/Views/Recipe/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Recipe/Details.cshtml", typeof(AspNetCore.Views_Recipe_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3e7c443d0512c7cc5fc3b38e6664fdef36b10d2", @"/Views/Recipe/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbd4935bfe04b891565f35780adde2d735f90d05", @"/Views/_ViewImports.cshtml")]
    public class Views_Recipe_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/css/recipeDetails.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/images/bootstrap-icons-1.4.0/bootstrap-icons.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/lib/images/recipes/waffle.jpg", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("object-fit:contain;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(64, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Details.cshtml"
  
    ViewData["Title"] = @Model + "Recipe Details";

#line default
#line hidden
            BeginContext(125, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("pageSpecificCss", async() => {
                BeginContext(152, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(158, 60, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7915c4c452a9483398a53b06ad63d520", async() => {
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
                BeginContext(218, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(224, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f1286c045f0c4abea63bdcb4e0150add", async() => {
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
                BeginContext(311, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(316, 2236, true);
            WriteLiteral(@"
<div class=""bg-light pb-5"">
    <div class=""container pt-5"">
        <div class=""card d-flex flex-md-row"">
            <section class=""order-md-0 order-1 col-md-6"">
                <div class=""m-5"">
                    <small class=""text-muted"">Lunch | Dinner</small>
                    <h1 class=""fw-bold"">Recipe title can be quite long for this one</h1>
                    <div class=""d-flex"">

                    </div>
                    <p>
                        Lorem Ipsum is rambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
                    </p>
                </div>
                <div class=""d-flex mx-5 mb-5"">
                    <div class=""d-flex flex-column co");
            WriteLiteral(@"l align-items-center"">
                        <div class=""d-flex fw-bold"">
                            <i class=""bi bi-clock""></i>
                            <div class=""ms-2"">
                                Prep Time
                            </div>
                        </div>
                        <div>
                            <span class=""display-5"">10</span> Min
                        </div>
                    </div>
                    <div class=""bg-secondary"" style=""width:2px"">
                    </div>
                    <div class=""d-flex flex-column col align-items-center"">
                        <div class=""d-flex fw-bold"">
                            <i class=""bi bi-egg-fried""></i>
                            <div class=""ms-2"">
                                Servings
                            </div>
                        </div>
                        <div>
                            <span class=""display-5"">2</span>
                        </div>
   ");
            WriteLiteral("                 </div>\r\n                </div>\r\n            </section>\r\n            <section class=\"img-sm-fixed-height order-md-1 order-0 col-md-6 bg-light d-flex align-items-stretch\">\r\n");
            EndContext();
            BeginContext(2685, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(2701, 112, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8b54a486e61f4f6faf33b01603da9ccd", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
#line 56 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Details.cshtml"
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
            BeginContext(2813, 647, true);
            WriteLiteral(@"
            </section>
        </div>
    </div>

    <div class=""container mt-4 d-flex justify-content-center"">
        <div class=""d-flex flex-row btn"" onclick=""alert('You clicked me !')"">
            <div class=""card display-5 p-3"">
                100 Likes
            </div>
            <button class=""btn btn-lg btn-success rounded-0 rounded-end"">
                <i class=""bi bi-hand-thumbs-up""></i>
            </button>
        </div>
    </div>

</div>



<div class=""container my-5 d-md-flex"">
    <div class=""card rounded-3 col-md-5 pt-5"">
        <h2 class=""px-5"">Ingredients</h2>
        <div class=""px-5"">
");
            EndContext();
#line 81 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Details.cshtml"
             for (int i = 0; i < 6; i++)
            {

#line default
#line hidden
            BeginContext(3561, 120, true);
            WriteLiteral("                <div class=\"border-bottom border-muted py-3\">\r\n                    100 tbs tea\r\n                </div>\r\n");
            EndContext();
#line 86 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Details.cshtml"
            }

#line default
#line hidden
            BeginContext(3696, 221, true);
            WriteLiteral("        </div>\r\n        <button class=\"btn btn-success mt-3 rounded-0 rounded-bottom\">Get All Items</button>\r\n    </div>\r\n\r\n    <div class=\"container rounded-3 col-md-6 offset-md-1 mt-5 mt-md-0\">\r\n        <h2>Steps</h2>\r\n");
            EndContext();
            BeginContext(3951, 48, true);
            WriteLiteral("        <div class=\"d-flex flex-column gap-2\">\r\n");
            EndContext();
#line 95 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Details.cshtml"
             for (int i = 0; i < 4; i++)
            {

#line default
#line hidden
            BeginContext(4056, 180, true);
            WriteLiteral("                <div class=\"card pt-5 pb-4 px-4\">\r\n                    <div class=\"position-absolute start-0 top-0 mx-4 mt-3\">\r\n                        <small class=\"fw-bold\">Step ");
            EndContext();
            BeginContext(4238, 3, false);
#line 99 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Details.cshtml"
                                                Write(i+1);

#line default
#line hidden
            EndContext();
            BeginContext(4242, 164, true);
            WriteLiteral("</small>\r\n                    </div>\r\n                    <div>\r\n                        Boil water on the pan\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 105 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Details.cshtml"
            }

#line default
#line hidden
            BeginContext(4421, 38, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
