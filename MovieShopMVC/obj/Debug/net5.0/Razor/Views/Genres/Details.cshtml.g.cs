#pragma checksum "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Genres\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e42b2e4b69b6a9e4bd82694054e7cbb0eb9d73b7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Genres_Details), @"mvc.1.0.view", @"/Views/Genres/Details.cshtml")]
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
#nullable restore
#line 1 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\_ViewImports.cshtml"
using MovieShopMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\_ViewImports.cshtml"
using MovieShopMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e42b2e4b69b6a9e4bd82694054e7cbb0eb9d73b7", @"/Views/Genres/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6112aabca9b932007558671ce74e32c023ef6c3", @"/Views/_ViewImports.cshtml")]
    public class Views_Genres_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationCore.Models.GenreResponseModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Genres\Details.cshtml"
  
    ViewData["Title"] = "GenreDetails Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"rounded\">\r\n    <div class=\"container-fluid bg-light\">\r\n        <div class=\"row\">\r\n\r\n");
#nullable restore
#line 12 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Genres\Details.cshtml"
             foreach (var movie in Model.Movies)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-6 col-lg-3 col-sm-4 col-xl-2\">\r\n                    <!-- the first one (col-6) by default is for the smallest screen size-->\r\n                    ");
#nullable restore
#line 16 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Genres\Details.cshtml"
               Write(await Html.PartialAsync("_MovieCard", movie));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n                </div>\r\n");
#nullable restore
#line 18 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Genres\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationCore.Models.GenreResponseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591