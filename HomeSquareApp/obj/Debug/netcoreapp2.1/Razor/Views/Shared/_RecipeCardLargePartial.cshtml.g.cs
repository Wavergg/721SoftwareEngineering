#pragma checksum "C:\Users\Waver\source\repos\HomeSquareApp\HomeSquareApp\Views\Shared\_RecipeCardLargePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9b83714ce3dc5e7e2c3da8889fd8e28bf9dc5ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__RecipeCardLargePartial), @"mvc.1.0.view", @"/Views/Shared/_RecipeCardLargePartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_RecipeCardLargePartial.cshtml", typeof(AspNetCore.Views_Shared__RecipeCardLargePartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9b83714ce3dc5e7e2c3da8889fd8e28bf9dc5ed", @"/Views/Shared/_RecipeCardLargePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a5520fbc05a94fac60d7e61edcbd77a4127b62e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__RecipeCardLargePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Recipe", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-id", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger text-white form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(16, 2082, true);
            WriteLiteral(@"
<div class=""card m-md-3 m-1 border-0"" style=""box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2)"">
    <div class=""card-header"" style=""height:240px; background: url(lib/images/waffle.jpg) no-repeat center;background-size: cover;"">
    </div>
    <div class=""m-2"">
        <div class=""d-flex justify-content-between"">
            <small class=""text-secondary"">Breakfast | Lunch</small>
            <span>
                <small class=""text-muted align-items-center"">
                    <svg class=""bi"" width=""16"" height=""16"">
                        <use xlink:href=""/lib/images/bootstrap-icons-1.4.0/bootstrap-icons.svg#hand-thumbs-up"" />
                    </svg>
                    2
                </small>
            </span>
        </div>
        <p class=""cardRecipe-title mb-0"">Waffle with maple syrup</p>
        <small>&mdash; Author Name</small>
        <p>lorem ipsum dolor amet sit.lorem ipsum dolor amet sit.lorem ipsum dolor amet sit.lorem ipsum dolor amet sit.lorem ipsum dolor amet sit.lorem ipsu");
            WriteLiteral(@"m dolor amet sit.lorem ipsum dolor amet sit.</p>
        <div class=""mb-3 d-flex justify-content-md-start justify-content-between"">
            <div class=""col-md-3"">
                <span class=""small fw-bold text-secondary"">Cook & Prep Time</span><br />
                <small class=""text-muted align-items-center"">
                    <svg class=""bi"" width=""16"" height=""16"">
                        <use xlink:href=""/lib/images/bootstrap-icons-1.4.0/bootstrap-icons.svg#clock"" />
                    </svg>
                    10 mins
                </small>
            </div>
            <div class=""col-md-3"">
                <span class=""small fw-bold text-secondary"">Servings</span><br />
                <small class=""text-muted align-items-center"">
                    <svg class=""bi"" width=""16"" height=""16"">
                        <use xlink:href=""/lib/images/bootstrap-icons-1.4.0/bootstrap-icons.svg#egg-fried"" />
                    </svg>
                    2
                </small>
  ");
            WriteLiteral("          </div>\r\n        </div>\r\n");
            EndContext();
            BeginContext(2203, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(2211, 128, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "acb0104ce2ca47d8b4bce12ac21c6fba", async() => {
                BeginContext(2323, 12, true);
                WriteLiteral("Go to Recipe");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)__tagHelperAttribute_2.Value;
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
            BeginContext(2339, 22, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
