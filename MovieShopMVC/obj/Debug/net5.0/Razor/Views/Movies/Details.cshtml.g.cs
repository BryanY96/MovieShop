#pragma checksum "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "373686d29e3bd16802d94f6d0480ddbdd5c1e7c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Details), @"mvc.1.0.view", @"/Views/Movies/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"373686d29e3bd16802d94f6d0480ddbdd5c1e7c6", @"/Views/Movies/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6112aabca9b932007558671ce74e32c023ef6c3", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationCore.Models.MovieDetailsResponseModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cast", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("<div class=\"bg-image\"");
            BeginWriteAttribute("style", " style=\"", 78, "\"", 170, 5);
            WriteAttributeValue("", 86, "background-image:url(", 86, 21, true);
#nullable restore
#line 2 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 107, Model.BackdropUrl, 107, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 125, ");", 125, 2, true);
            WriteAttributeValue(" ", 127, "align-content:center;", 128, 22, true);
            WriteAttributeValue(" ", 149, "background-size:120%", 150, 21, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n    <div class=\"mask\" style=\"background-color: rgba(0, 0, 0, 0.8);\">\r\n        <div class=\"row container-fluid\">\r\n            <div class=\"col-md-3 offset-2\">\r\n                <div>\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 379, "\"", 401, 1);
#nullable restore
#line 7 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 385, Model.PosterUrl, 385, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\"");
            BeginWriteAttribute("alt", " alt=\"", 423, "\"", 441, 1);
#nullable restore
#line 7 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 429, Model.Title, 429, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"col-md-4 text-left\">\r\n                <div>\r\n                    <h1 style=\"color:white\">");
#nullable restore
#line 13 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                       Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <div class=\"col\">\r\n                        <p style=\"color:grey\">\r\n                            ");
#nullable restore
#line 18 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                       Write(Model.Tagline);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                        <p style=\"color:grey\">\r\n                            <b>");
#nullable restore
#line 21 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                          Write(Model.RunTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" m | ");
#nullable restore
#line 21 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                             Write(Model.ReleaseDate.Value.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                        </p>\r\n                    </div>\r\n                    <div class=\"col\">\r\n");
#nullable restore
#line 25 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                         foreach (var genre in Model.Genres)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a href=\"#\" class=\"badge badge-pill badge-secondary\">\r\n                                ");
#nullable restore
#line 28 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                           Write(genre.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n");
#nullable restore
#line 30 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n                <div>\r\n                    <span class=\"badge badge-warning\">");
#nullable restore
#line 34 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                 Write(Model.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n                <div>\r\n                    <p style=\"color:white\">\r\n                        ");
#nullable restore
#line 38 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                   Write(Model.Overview);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                </div>
            </div>

            <div class=""col-3 mt-4"">
                <hr />
                <button type=""button"" class=""btn btn-outline-primary container-fluid bg-transparent"">REVIEW</button>
                <hr />
                <button type=""button"" class=""btn btn-outline-primary container-fluid bg-transparent"">TRAILER</button>
                <hr />
                <button class=""btn btn-light container-fluid mb-1"" type=""submit"">BUY ");
#nullable restore
#line 49 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                                Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</button>
                <button class=""btn btn-light container-fluid mt-1"" type=""submit"">WATCH MOVIE</button>
                <hr />

            </div>
        </div>
    </div>
</div>

<div class=""row mt-3"">
    <div class=""col-5"">
        <ul class=""list-group list-group-flush"">
            <li class=""list-group-item"">MOVIE FACTS</li>
            <li class=""list-group-item"">Release Date <span class=""badge badge-pill badge-dark"">");
#nullable restore
#line 62 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                                          Write(Model.ReleaseDate.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </li>\r\n            <li class=\"list-group-item\">Run Time <span class=\"badge badge-pill badge-dark\">");
#nullable restore
#line 63 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                                      Write(Model.RunTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" m</span> </li>\r\n            <li class=\"list-group-item\">Box Office <span class=\"badge badge-pill badge-dark\">$ ");
#nullable restore
#line 64 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                                          Write(Model.Revenue);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </li>\r\n            <li class=\"list-group-item\">Budget <span class=\"badge badge-pill badge-dark\">$ ");
#nullable restore
#line 65 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                                      Write(Model.Budget);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </li>\r\n        </ul>\r\n    </div>\r\n\r\n    <div class=\"col-4\">\r\n        <ul class=\"col list-group list-group-flush\">\r\n\r\n            <li class=\"list-group-item\"> <b>CAST</b> </li>\r\n");
#nullable restore
#line 73 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
             foreach (var cast in Model.Casts)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"list-group-item\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "373686d29e3bd16802d94f6d0480ddbdd5c1e7c612743", async() => {
                WriteLiteral("<img");
                BeginWriteAttribute("src", " src=\"", 3400, "\"", 3423, 1);
#nullable restore
#line 76 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 3406, cast.ProfilePath, 3406, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"rounded-circle\" style=\"max-width:10%\"");
                BeginWriteAttribute("alt", " alt=\"", 3469, "\"", 3485, 1);
#nullable restore
#line 76 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 3475, cast.Name, 3475, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />");
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
            BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                    WriteLiteral(cast.Id);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n                    ");
#nullable restore
#line 77 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
               Write(cast.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 78 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
               Write(cast.Character);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </li>\r\n");
#nullable restore
#line 80 "F:\Laptop_files\My stuff\求职\Antra_FullStack_Training\Project\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationCore.Models.MovieDetailsResponseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
