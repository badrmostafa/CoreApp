#pragma checksum "F:\Badr\Education\ASP.NET MVC Core\CoreApp\Views\Home\Message.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d155b6efac06445ee5113d7c98dc9b4725ab1c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Message), @"mvc.1.0.view", @"/Views/Home/Message.cshtml")]
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
#line 1 "F:\Badr\Education\ASP.NET MVC Core\CoreApp\Views\_ViewImports.cshtml"
using CoreApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Badr\Education\ASP.NET MVC Core\CoreApp\Views\_ViewImports.cshtml"
using CoreApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\Badr\Education\ASP.NET MVC Core\CoreApp\Views\_ViewImports.cshtml"
using CoreApp.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\Badr\Education\ASP.NET MVC Core\CoreApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\Badr\Education\ASP.NET MVC Core\CoreApp\Views\_ViewImports.cshtml"
using CoreApp.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\Badr\Education\ASP.NET MVC Core\CoreApp\Views\_ViewImports.cshtml"
using CoreApp.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d155b6efac06445ee5113d7c98dc9b4725ab1c1", @"/Views/Home/Message.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b83608b006c76a90b4d0c8d83512602469d687e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Message : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ContactUs>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"<!-- ======= Testimonials Section ======= -->
<section id=""testimonials"" class=""testimonials"">
    <div class=""container"" data-aos=""fade-up"">

        <div class=""section-title"">
            <h2>Show Messages</h2>
        </div>

        
        <div class=""owl-carousel testimonials-carousel"" data-aos=""fade-up"" data-aos-delay=""100"">
");
#nullable restore
#line 13 "F:\Badr\Education\ASP.NET MVC Core\CoreApp\Views\Home\Message.cshtml"
             foreach (ContactUs contacts in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"testimonial-item\">\r\n                    <h5>");
#nullable restore
#line 16 "F:\Badr\Education\ASP.NET MVC Core\CoreApp\Views\Home\Message.cshtml"
                   Write(contacts.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p>\r\n                        <i class=\"bx bxs-quote-alt-left quote-icon-left\"></i>\r\n                        ");
#nullable restore
#line 19 "F:\Badr\Education\ASP.NET MVC Core\CoreApp\Views\Home\Message.cshtml"
                   Write(contacts.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <i class=\"bx bxs-quote-alt-right quote-icon-right\"></i>\r\n                    </p>\r\n                    <h3>");
#nullable restore
#line 22 "F:\Badr\Education\ASP.NET MVC Core\CoreApp\Views\Home\Message.cshtml"
                   Write(contacts.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                    <h4>");
#nullable restore
#line 23 "F:\Badr\Education\ASP.NET MVC Core\CoreApp\Views\Home\Message.cshtml"
                   Write(contacts.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                </div>\r\n");
#nullable restore
#line 25 "F:\Badr\Education\ASP.NET MVC Core\CoreApp\Views\Home\Message.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        \r\n\r\n    </div>\r\n</section><!-- End Testimonials Section -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ContactUs>> Html { get; private set; }
    }
}
#pragma warning restore 1591
