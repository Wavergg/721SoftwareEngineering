#pragma checksum "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "058b94b784f49fa4e95336964a4b959cf95ee074"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Recipe_Index), @"mvc.1.0.view", @"/Views/Recipe/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Recipe/Index.cshtml", typeof(AspNetCore.Views_Recipe_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"058b94b784f49fa4e95336964a4b959cf95ee074", @"/Views/Recipe/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbd4935bfe04b891565f35780adde2d735f90d05", @"/Views/_ViewImports.cshtml")]
    public class Views_Recipe_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<HomeSquareApp.Models.Recipe>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/css/recipeCard.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_RecipeCardThumbnailPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Index.cshtml"
  
    ViewData["Title"] = "Recipe";

#line default
#line hidden
            BeginContext(140, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("pageSpecificCss", async() => {
                BeginContext(167, 101, true);
                WriteLiteral("\r\n    <script src=\"https://kit.fontawesome.com/ea080c442b.js\" crossorigin=\"anonymous\"></script>\r\n    ");
                EndContext();
                BeginContext(268, 57, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ac843a5796ed4b6498fa1c1e81bc175b", async() => {
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
                BeginContext(325, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(330, 2131, true);
            WriteLiteral(@"
<div class=""mb-5"">
    <div class=""bg-dark"" style=""position:relative"">
        <div class=""card-header"" style=""height:360px;opacity:0.4; background: url(/lib/images/banner/diy-food-background-5.jpg) no-repeat center;background-size: cover;"">
        </div>

        <div class=""text-white w-100 h-100 d-flex align-items-center"" style=""font-size:1.5rem;position:absolute;top:0"">
            <div class=""container"">
                <div class=""col-lg-7"">
                    <h1 class="""">Our Recipes</h1>
                    <p class=""d-none d-md-block"">
                        From classic kiwi recipes to dishes from all around the world,<br /> That cater for all diet, budgets, and taste.
                    </p>
                    <div class=""input-group my-3 text-center"">
                        <input class=""w-75"" id=""searchRecipeInput"" type=""text"" placeholder=""Search Recipe"">
                        <button class=""btn btn-success"" style="""" type=""button"">
                            <svg class=""");
            WriteLiteral(@"bi text-white"" width=""16"" height=""24"">
                                <use xlink:href=""./lib/images/bootstrap-icons-1.4.0/bootstrap-icons.svg#search"" />
                            </svg>
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div class=""text-white"" style=""height:10px;"">
        </div>
    </div>
    <div class=""container-fluid pt-5 bg-white"">
        <div class=""d-md-flex justify-content-center gx-2"">
            <button class=""m-2 btn btn-light text-dark border-secondary rounded-pill"">Meals and Courses</button>
            <button class=""m-2 btn btn-light text-dark border-secondary rounded-pill"">Occasion</button>
            <button class=""m-2 btn btn-light text-dark border-secondary rounded-pill"">All Recipes</button>
            <button class=""m-2 btn btn-light text-dark border-secondary rounded-pill"">Diet and Lifestyle</button>
        </div>
        <div class=""d-md-flex justify-content-center mt-5""");
            WriteLiteral(">\r\n            <h1 class=\"fw-bold\">Recipes</h1>\r\n        </div>\r\n        <hr />\r\n\r\n");
            EndContext();
#line 51 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Index.cshtml"
         if (signInManager.IsSignedIn(User)) {

#line default
#line hidden
            BeginContext(2509, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(2521, 100, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af5086f5c6584792acedec5db67b08dc", async() => {
                BeginContext(2576, 41, true);
                WriteLiteral("<i class=\"fas fa-plus\"></i> Add My Recipe");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2621, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 53 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2634, 89, true);
            WriteLiteral("        <div id=\"recipeCardList\" class=\"row row-cols-1 row-cols-lg-3 g-2 g-lg-3 mt-3 \">\r\n");
            EndContext();
#line 55 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Index.cshtml"
             for (int i = 0; i < Model.Count(); i++)
            {

#line default
#line hidden
            BeginContext(2792, 85, true);
            WriteLiteral("                <div class=\"col d-flex justify-content-center\">\r\n                    ");
            EndContext();
            BeginContext(2877, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b42ae4f5921a437cb61aadc262cf070a", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#line 58 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model[i];

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2939, 26, true);
            WriteLiteral("\r\n                </div>\r\n");
            EndContext();
#line 60 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(2980, 18, true);
            WriteLiteral("        </div>\r\n\r\n");
            EndContext();
#line 63 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Index.cshtml"
         if(ViewData["PaginationCount"] != null) {

#line default
#line hidden
            BeginContext(3050, 44, true);
            WriteLiteral("            <div class=\"text-center my-3\">\r\n");
            EndContext();
            BeginContext(3162, 103, true);
            WriteLiteral("                <button class=\"btn btn-success rounded-pill\">More Recipe</button>\r\n            </div>\r\n");
            EndContext();
#line 68 "C:\Users\Waver\source\repos\HomeSquareApp\721SoftwareEngineering\HomeSquareApp\Views\Recipe\Index.cshtml"
         }

#line default
#line hidden
            BeginContext(3277, 24, true);
            WriteLiteral("    </div>\r\n</div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3319, 742, true);
                WriteLiteral(@"
    <script>
        //Recipe Carousel
        //--------------------------------------------------------
        var owlRecipe = $('.owl-carouselRecipe');
        //Initialization
        owlRecipe.owlCarousel({
            loop: true,
            margin: 150,
            items: 1,
        }
        );
        // Go to the next item
        $('.recipeNextBtn').click(function () {
            owlRecipe.trigger('next.owl.carousel');
        })
        // Go to the previous item
        $('.recipePrevBtn').click(function () {
            // With optional speed parameter
            // Parameters has to be in square bracket '[]'
            owlRecipe.trigger('prev.owl.carousel', [300]);
        })
    </script>
");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> signInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<HomeSquareApp.Models.Recipe>> Html { get; private set; }
    }
}
#pragma warning restore 1591
