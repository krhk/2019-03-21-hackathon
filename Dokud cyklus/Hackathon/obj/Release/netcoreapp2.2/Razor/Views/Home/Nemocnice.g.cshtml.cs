#pragma checksum "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc42e61d753f1eeb00ad4d0810101abf7c22547a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Nemocnice), @"mvc.1.0.view", @"/Views/Home/Nemocnice.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Nemocnice.cshtml", typeof(AspNetCore.Views_Home_Nemocnice))]
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
#line 1 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\_ViewImports.cshtml"
using Hackathon;

#line default
#line hidden
#line 2 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\_ViewImports.cshtml"
using Hackathon.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc42e61d753f1eeb00ad4d0810101abf7c22547a", @"/Views/Home/Nemocnice.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d1280e001f064c3d40730d8c27d96fc536eaf7c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Nemocnice : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Hackathon.Models.Nemocnice>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
  
    ViewData["Title"] = "Nemocnice";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(142, 107, true);
            WriteLiteral("\r\n<h1>Nemocnice</h1>\r\n\r\n<table class=\"table\" id=\"table\">\r\n    <thead>\r\n    <tr>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(250, 39, false);
#line 14 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
       Write(Html.DisplayNameFor(model => model.Typ));

#line default
#line hidden
            EndContext();
            BeginContext(289, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(333, 42, false);
#line 17 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
       Write(Html.DisplayNameFor(model => model.Urceni));

#line default
#line hidden
            EndContext();
            BeginContext(375, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(419, 45, false);
#line 20 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
       Write(Html.DisplayNameFor(model => model.NazevObce));

#line default
#line hidden
            EndContext();
            BeginContext(464, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(508, 54, false);
#line 23 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
       Write(Html.DisplayNameFor(model => model.NazevPoskytovatele));

#line default
#line hidden
            EndContext();
            BeginContext(562, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(606, 41, false);
#line 26 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
       Write(Html.DisplayNameFor(model => model.Ulice));

#line default
#line hidden
            EndContext();
            BeginContext(647, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(691, 49, false);
#line 29 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
       Write(Html.DisplayNameFor(model => model.CiscloPopisne));

#line default
#line hidden
            EndContext();
            BeginContext(740, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(784, 51, false);
#line 32 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
       Write(Html.DisplayNameFor(model => model.OrdinacniHodiny));

#line default
#line hidden
            EndContext();
            BeginContext(835, 65, true);
            WriteLiteral("\r\n        </th>\r\n        \r\n    </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 38 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
     foreach (var item in Model) {

#line default
#line hidden
            BeginContext(936, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(985, 38, false);
#line 41 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
           Write(Html.DisplayFor(modelItem => item.Typ));

#line default
#line hidden
            EndContext();
            BeginContext(1023, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1079, 41, false);
#line 44 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
           Write(Html.DisplayFor(modelItem => item.Urceni));

#line default
#line hidden
            EndContext();
            BeginContext(1120, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1176, 44, false);
#line 47 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
           Write(Html.DisplayFor(modelItem => item.NazevObce));

#line default
#line hidden
            EndContext();
            BeginContext(1220, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1276, 53, false);
#line 50 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
           Write(Html.DisplayFor(modelItem => item.NazevPoskytovatele));

#line default
#line hidden
            EndContext();
            BeginContext(1329, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1385, 40, false);
#line 53 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
           Write(Html.DisplayFor(modelItem => item.Ulice));

#line default
#line hidden
            EndContext();
            BeginContext(1425, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1481, 48, false);
#line 56 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
           Write(Html.DisplayFor(modelItem => item.CiscloPopisne));

#line default
#line hidden
            EndContext();
            BeginContext(1529, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1585, 50, false);
#line 59 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
           Write(Html.DisplayFor(modelItem => item.OrdinacniHodiny));

#line default
#line hidden
            EndContext();
            BeginContext(1635, 49, true);
            WriteLiteral("\r\n            </td>\r\n           \r\n        </tr>\r\n");
            EndContext();
#line 63 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Nemocnice.cshtml"
    }

#line default
#line hidden
            BeginContext(1691, 26, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1736, 410, true);
                WriteLiteral(@"
    <script type=""text/javascript"" charset=""utf8"" src=""https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js""></script>
    <script type=""text/javascript"" charset=""utf8"" src=""https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js""></script>
    <script>
        $(document).ready(function () {
            $('#table').DataTable({ ""renderer"": ""bootstrap"" });
        });
    </script>
");
                EndContext();
            }
            );
            BeginContext(2149, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(2171, 256, true);
                WriteLiteral(@"
    <link rel=""stylesheet"" type=""text/css"" href=""https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.1/css/bootstrap.css"">
    <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css"">
");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Hackathon.Models.Nemocnice>> Html { get; private set; }
    }
}
#pragma warning restore 1591
