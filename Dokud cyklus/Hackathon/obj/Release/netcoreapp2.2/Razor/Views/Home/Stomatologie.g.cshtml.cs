#pragma checksum "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "640c2b5cdcfcac32bc56d8c6cbb70469c6e9e747"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Stomatologie), @"mvc.1.0.view", @"/Views/Home/Stomatologie.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Stomatologie.cshtml", typeof(AspNetCore.Views_Home_Stomatologie))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"640c2b5cdcfcac32bc56d8c6cbb70469c6e9e747", @"/Views/Home/Stomatologie.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d1280e001f064c3d40730d8c27d96fc536eaf7c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Stomatologie : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Hackathon.Models.Stomatologie>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
  
    ViewData["Title"] = "Stomatologie";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(148, 124, true);
            WriteLiteral("\r\n<h1>Stomatologie</h1>\r\n\r\n\r\n<table class=\"table\" id=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(273, 42, false);
#line 15 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
           Write(Html.DisplayNameFor(model => model.Oblast));

#line default
#line hidden
            EndContext();
            BeginContext(315, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(371, 41, false);
#line 18 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
           Write(Html.DisplayNameFor(model => model.Datum));

#line default
#line hidden
            EndContext();
            BeginContext(412, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(468, 47, false);
#line 21 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
           Write(Html.DisplayNameFor(model => model.JmenoLekare));

#line default
#line hidden
            EndContext();
            BeginContext(515, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(571, 45, false);
#line 24 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
           Write(Html.DisplayNameFor(model => model.NazevObce));

#line default
#line hidden
            EndContext();
            BeginContext(616, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(672, 41, false);
#line 27 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
           Write(Html.DisplayNameFor(model => model.Ulice));

#line default
#line hidden
            EndContext();
            BeginContext(713, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(769, 49, false);
#line 30 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
           Write(Html.DisplayNameFor(model => model.CiscloPopisne));

#line default
#line hidden
            EndContext();
            BeginContext(818, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(874, 43, false);
#line 33 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
           Write(Html.DisplayNameFor(model => model.Telefon));

#line default
#line hidden
            EndContext();
            BeginContext(917, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(973, 51, false);
#line 36 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
           Write(Html.DisplayNameFor(model => model.OrdinacniHodiny));

#line default
#line hidden
            EndContext();
            BeginContext(1024, 65, true);
            WriteLiteral("\r\n            </th>\r\n\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 42 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1138, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1199, 41, false);
#line 46 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
               Write(Html.DisplayFor(modelItem => item.Oblast));

#line default
#line hidden
            EndContext();
            BeginContext(1240, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1308, 40, false);
#line 49 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
               Write(Html.DisplayFor(modelItem => item.Datum));

#line default
#line hidden
            EndContext();
            BeginContext(1348, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1416, 46, false);
#line 52 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
               Write(Html.DisplayFor(modelItem => item.JmenoLekare));

#line default
#line hidden
            EndContext();
            BeginContext(1462, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1530, 44, false);
#line 55 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
               Write(Html.DisplayFor(modelItem => item.NazevObce));

#line default
#line hidden
            EndContext();
            BeginContext(1574, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1642, 40, false);
#line 58 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
               Write(Html.DisplayFor(modelItem => item.Ulice));

#line default
#line hidden
            EndContext();
            BeginContext(1682, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1750, 48, false);
#line 61 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
               Write(Html.DisplayFor(modelItem => item.CiscloPopisne));

#line default
#line hidden
            EndContext();
            BeginContext(1798, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1866, 42, false);
#line 64 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
               Write(Html.DisplayFor(modelItem => item.Telefon));

#line default
#line hidden
            EndContext();
            BeginContext(1908, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1976, 50, false);
#line 67 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
               Write(Html.DisplayFor(modelItem => item.OrdinacniHodiny));

#line default
#line hidden
            EndContext();
            BeginContext(2026, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 70 "C:\Users\Lukáš\source\repos\lukastrkan\Hackathon2019\Hackathon\Views\Home\Stomatologie.cshtml"
        }

#line default
#line hidden
            BeginContext(2081, 26, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2130, 410, true);
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
            BeginContext(2543, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(2569, 256, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Hackathon.Models.Stomatologie>> Html { get; private set; }
    }
}
#pragma warning restore 1591
