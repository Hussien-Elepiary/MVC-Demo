#pragma checksum "F:\BackEnd\MVC\MVC-Demo\MVCDemo-Sln\Demo.Pl\Views\Account\CheckYourInbox.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55b8cd5ea6ee7e0911ea75f2f21d620ef4cc00fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_CheckYourInbox), @"mvc.1.0.view", @"/Views/Account/CheckYourInbox.cshtml")]
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
#line 1 "F:\BackEnd\MVC\MVC-Demo\MVCDemo-Sln\Demo.Pl\Views\_ViewImports.cshtml"
using Demo.PL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\BackEnd\MVC\MVC-Demo\MVCDemo-Sln\Demo.Pl\Views\_ViewImports.cshtml"
using Demo.PL.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\BackEnd\MVC\MVC-Demo\MVCDemo-Sln\Demo.Pl\Views\_ViewImports.cshtml"
using Demo.DAL.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\BackEnd\MVC\MVC-Demo\MVCDemo-Sln\Demo.Pl\Views\_ViewImports.cshtml"
using Demo.BLL.Interfaces;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55b8cd5ea6ee7e0911ea75f2f21d620ef4cc00fd", @"/Views/Account/CheckYourInbox.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec175e4f4ced20d28ea70e676d129b8aae75a95c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_CheckYourInbox : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "F:\BackEnd\MVC\MVC-Demo\MVCDemo-Sln\Demo.Pl\Views\Account\CheckYourInbox.cshtml"
  
    ViewData["Title"] = "CheckYourInbox";
    Layout = "~/Views/Shared/_AuthLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Check Your Inbox</h1>

<div class=""main-agileinfo"">
    <div class=""agileits-top"">
        <div class=""body"">
            <div>
                Password reset link has been sent to your email. Please check your inbox :)
            </div>
        </div>
    </div>
</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
