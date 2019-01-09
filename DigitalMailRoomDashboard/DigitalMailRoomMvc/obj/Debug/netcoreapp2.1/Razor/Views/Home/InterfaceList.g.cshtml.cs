#pragma checksum "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\InterfaceList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbcae01ac8f692c48b056cc8b150f4cc6e458183"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_InterfaceList), @"mvc.1.0.view", @"/Views/Home/InterfaceList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/InterfaceList.cshtml", typeof(AspNetCore.Views_Home_InterfaceList))]
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
#line 1 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\_ViewImports.cshtml"
using DigitalMailRoomMvc;

#line default
#line hidden
#line 2 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\_ViewImports.cshtml"
using DigitalMailRoomMvc.Models;

#line default
#line hidden
#line 3 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\_ViewImports.cshtml"
using DigitalMailRoomMvc.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbcae01ac8f692c48b056cc8b150f4cc6e458183", @"/Views/Home/InterfaceList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"145064a4f6277f2f0b565f0ea352fc4d7d379d06", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_InterfaceList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\InterfaceList.cshtml"
  
    ViewData["Title"] = "Service List";
    Layout = "~/Views/Shared/MasterLayout.cshtml";

#line default
#line hidden
            BeginContext(100, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\InterfaceList.cshtml"
  
    var format = "dd-MM-yyyy"; // your datetime format
    var dateTimeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter { DateTimeFormat = format };
    var interfaceList = Newtonsoft.Json.JsonConvert
        .DeserializeObject<List<InterfaceEntity>>("[{\"InterfaceName\":\"CMS 1500\",\"LastModifiedDate\":\"29-11-2018\"},{\"InterfaceName\":\"UB-04\",\"LastModifiedDate\":\"29-11-2018\"},{\"InterfaceName\":\"Dental Claims\",\"LastModifiedDate\":\"29-11-2018\"}]", dateTimeConverter);

#line default
#line hidden
            BeginContext(613, 426, true);
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row"">
        <h2>Service List</h2>
        <table id=""interfaceList"" class=""table table-striped table-bordered display"" style=""width:100%;"">
            <thead>
                <tr>
                    <th></th>
                    <th>Service Name</th>
                    <th>Last Modified Date</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 25 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\InterfaceList.cshtml"
                 foreach (var interfaceItem in interfaceList)
                {

#line default
#line hidden
            BeginContext(1121, 77, true);
            WriteLiteral("                <tr>\r\n                    <td></td>\r\n                    <td>");
            EndContext();
            BeginContext(1199, 27, false);
#line 29 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\InterfaceList.cshtml"
                   Write(interfaceItem.InterfaceName);

#line default
#line hidden
            EndContext();
            BeginContext(1226, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1258, 30, false);
#line 30 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\InterfaceList.cshtml"
                   Write(interfaceItem.LastModifiedDate);

#line default
#line hidden
            EndContext();
            BeginContext(1288, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 32 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\InterfaceList.cshtml"
                }

#line default
#line hidden
            BeginContext(1337, 886, true);
            WriteLiteral(@"            </tbody>
        </table>
        <script>
            //var table = $('#serviceList').DataTable({ ""dom"": 'rt<""bottom""ip><""clear"">' });
            $('#interfaceList').DataTable({
                dom: 'rt<""bottom""ip><""clear"">',
                columnDefs: [{
                    orderable: false,
                    className: 'select-checkbox',
                    targets: 0
                }],
                select: {
                    style: 'single',
                    selector: 'td:first-child'
                },
                order: [[1, 'asc']]
            });
        </script>
    </div>
    <div class=""row"" style=""float:right;padding-top:10px;"">
        <input class=""button"" type=""submit"" name=""submitbutton1"" value=""Edit"" />
        <input class=""button"" type=""submit"" name=""submitbutton2"" value=""Delete"" />
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