#pragma checksum "C:\Users\Waver\source\repos\HomeSquareApp\HomeSquareApp\Views\Shared\_SearchBarPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d4779850b6555fe4554a1e134bc6086b8e47b2e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SearchBarPartial), @"mvc.1.0.view", @"/Views/Shared/_SearchBarPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_SearchBarPartial.cshtml", typeof(AspNetCore.Views_Shared__SearchBarPartial))]
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
#line 3 "C:\Users\Waver\source\repos\HomeSquareApp\HomeSquareApp\Views\_ViewImports.cshtml"
using HomeSquareApp.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4779850b6555fe4554a1e134bc6086b8e47b2e4", @"/Views/Shared/_SearchBarPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4fae47ccddbb098a42c7a523a9d8f61a69d7fd6", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SearchBarPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(79, 274, true);
            WriteLiteral(@"
<div>
    <div class=""input-group my-3 my-md-0"">

        <input type=""text"" class=""form-control"" style=""border-top-left-radius:12.5rem;border-bottom-left-radius:12.5rem"" :placeholder=""'Search '+searchCategories"" aria-label=""Search"" aria-describedby=""basic-addon2"">

");
            EndContext();
            BeginContext(418, 270, true);
            WriteLiteral(@"        <button class=""btn btn-sm btn-outline-success dropdown-toggle"" type=""button"" data-bs-toggle=""dropdown"" aria-expanded=""false"" v-text=""searchCategories""></button>
        <ul class=""dropdown-menu dropdown-menu-end"">
            <li><button class=""dropdown-item"" ");
            EndContext();
            BeginContext(689, 127, true);
            WriteLiteral("@click=\"updateSearchCategories\" value=\"All Products\">All Products</button></li>\r\n            <li><button class=\"dropdown-item\" ");
            EndContext();
            BeginContext(817, 117, true);
            WriteLiteral("@click=\"updateSearchCategories\" value=\"Recipes\">Recipes</button></li>\r\n            <li><button class=\"dropdown-item\" ");
            EndContext();
            BeginContext(935, 113, true);
            WriteLiteral("@click=\"updateSearchCategories\" value=\"Foods\">Foods</button></li>\r\n            <li><button class=\"dropdown-item\" ");
            EndContext();
            BeginContext(1049, 98, true);
            WriteLiteral("@click=\"updateSearchCategories\" value=\"Home & Living\">Home & Living</button></li>\r\n        </ul>\r\n");
            EndContext();
            BeginContext(1242, 444, true);
            WriteLiteral(@"        <span class="""" id=""basic-addon2"">
            <button class=""btn btn-success border-0"" style=""border-top-right-radius:12.5rem;border-bottom-right-radius:12.5rem"" type=""button"">
                <svg class=""bi text-white"" width=""16"" height=""24"">
                    <use xlink:href=""/lib/images/bootstrap-icons-1.4.0/bootstrap-icons.svg#search"" />
                </svg>
            </button>
        </span>
    </div>
</div>

");
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
