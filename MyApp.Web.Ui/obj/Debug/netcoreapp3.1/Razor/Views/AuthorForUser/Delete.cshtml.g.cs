#pragma checksum "C:\Users\user\Downloads\ToDoApp\ToDoApp\MyApp.Web.Ui\Views\AuthorForUser\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54d25363a76b27180b26cfb181cc2753d1588b1d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AuthorForUser_Delete), @"mvc.1.0.view", @"/Views/AuthorForUser/Delete.cshtml")]
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
#line 1 "C:\Users\user\Downloads\ToDoApp\ToDoApp\MyApp.Web.Ui\Views\_ViewImports.cshtml"
using MyApp.Web.Ui;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Downloads\ToDoApp\ToDoApp\MyApp.Web.Ui\Views\_ViewImports.cshtml"
using MyApp.Web.Ui.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54d25363a76b27180b26cfb181cc2753d1588b1d", @"/Views/AuthorForUser/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23f217d163e109ab5bbb2286b922f21b7fbab16e", @"/Views/_ViewImports.cshtml")]
    public class Views_AuthorForUser_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Microsoft.AspNetCore.Identity.IdentityUser>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\user\Downloads\ToDoApp\ToDoApp\MyApp.Web.Ui\Views\AuthorForUser\Delete.cshtml"
  

    ViewBag.Title = "Xóa thành viên";

    Layout = "~/Views/Shared/_Layout.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"row\">\n\n    <div class=\"col-sm-12\">\n\n        <h2>");
#nullable restore
#line 15 "C:\Users\user\Downloads\ToDoApp\ToDoApp\MyApp.Web.Ui\Views\AuthorForUser\Delete.cshtml"
       Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\n\n        <hr />\n\n        <div class=\"text-center\">\n\n            <h5>Bạn có chắc muốn xóa thành viên ");
#nullable restore
#line 21 "C:\Users\user\Downloads\ToDoApp\ToDoApp\MyApp.Web.Ui\Views\AuthorForUser\Delete.cshtml"
                                           Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("?</h5>\n\n");
#nullable restore
#line 23 "C:\Users\user\Downloads\ToDoApp\ToDoApp\MyApp.Web.Ui\Views\AuthorForUser\Delete.cshtml"
             using (Html.BeginForm())

            {

                

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\user\Downloads\ToDoApp\ToDoApp\MyApp.Web.Ui\Views\AuthorForUser\Delete.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\user\Downloads\ToDoApp\ToDoApp\MyApp.Web.Ui\Views\AuthorForUser\Delete.cshtml"
           Write(Html.ValidationSummary("", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("                <button type=\"submit\" class=\"btn btn-primary\">Chấp nhận</button>\n");
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 617, "\"", 644, 1);
#nullable restore
#line 33 "C:\Users\user\Downloads\ToDoApp\ToDoApp\MyApp.Web.Ui\Views\AuthorForUser\Delete.cshtml"
WriteAttributeValue("", 624, Url.Action("Index"), 624, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-default\">Không xóa</a>\n");
#nullable restore
#line 34 "C:\Users\user\Downloads\ToDoApp\ToDoApp\MyApp.Web.Ui\Views\AuthorForUser\Delete.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n\n    </div>\n\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Microsoft.AspNetCore.Identity.IdentityUser> Html { get; private set; }
    }
}
#pragma warning restore 1591