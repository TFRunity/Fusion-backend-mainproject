#pragma checksum "C:\Users\Печенька\source\repos\Fusion\Fusion\Views\Account\AdminArea.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23a39cb6f067be4f5a69cf398ca93c218b4dbec8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_AdminArea), @"mvc.1.0.view", @"/Views/Account/AdminArea.cshtml")]
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
#line 1 "C:\Users\Печенька\source\repos\Fusion\Fusion\Views\_ViewImports.cshtml"
using Fusion;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Печенька\source\repos\Fusion\Fusion\Views\_ViewImports.cshtml"
using Fusion.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Печенька\source\repos\Fusion\Fusion\Views\_ViewImports.cshtml"
using Fusion.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Печенька\source\repos\Fusion\Fusion\Views\_ViewImports.cshtml"
using Fusion.DatabaseMethods;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Печенька\source\repos\Fusion\Fusion\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23a39cb6f067be4f5a69cf398ca93c218b4dbec8", @"/Views/Account/AdminArea.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"988daae7174b7b9143ed2dec7442a97031fbbb10", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_AdminArea : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div>\r\n    <div>\r\n        <a class=\"text-decoration-none\"");
            BeginWriteAttribute("href", " href=\"", 57, "\"", 92, 1);
#nullable restore
#line 3 "C:\Users\Печенька\source\repos\Fusion\Fusion\Views\Account\AdminArea.cshtml"
WriteAttributeValue("", 64, Url.Action("Index","Roles"), 64, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <h3>\r\n                Панель разработчика, управление ролями\r\n            </h3>\r\n        </a>\r\n    </div>\r\n    <div>\r\n        <a class=\"text-decoration-none\"");
            BeginWriteAttribute("href", " href=\"", 265, "\"", 303, 1);
#nullable restore
#line 10 "C:\Users\Печенька\source\repos\Fusion\Fusion\Views\Account\AdminArea.cshtml"
WriteAttributeValue("", 272, Url.Action("List","Moderator"), 272, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <h3>\r\n                Панель разработчика, управление людьми\r\n            </h3>\r\n        </a>\r\n    </div>\r\n</div>");
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
