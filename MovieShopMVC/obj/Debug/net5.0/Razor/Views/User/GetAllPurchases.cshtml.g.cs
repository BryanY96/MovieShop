#pragma checksum "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\User\GetAllPurchases.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e01cfe0e5a000b04acc561909ab1d0937bcb49d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_GetAllPurchases), @"mvc.1.0.view", @"/Views/User/GetAllPurchases.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e01cfe0e5a000b04acc561909ab1d0937bcb49d", @"/Views/User/GetAllPurchases.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6112aabca9b932007558671ce74e32c023ef6c3", @"/Views/_ViewImports.cshtml")]
    public class Views_User_GetAllPurchases : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ApplicationCore.Models.MovieCardResponseModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>Purchased Movies</h2>\r\n<br />\r\n<div>\r\n");
#nullable restore
#line 6 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\User\GetAllPurchases.cshtml"
     foreach (var movie in Model)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\User\GetAllPurchases.cshtml"
   Write(await Html.PartialAsync("_MovieCard", movie));

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\User\GetAllPurchases.cshtml"
                                                     
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ApplicationCore.Models.MovieCardResponseModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
