#pragma checksum "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63b964d7c90a3293f4e073734e5531ee48461bbb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ServiceConfiguration), @"mvc.1.0.view", @"/Views/Home/ServiceConfiguration.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ServiceConfiguration.cshtml", typeof(AspNetCore.Views_Home_ServiceConfiguration))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63b964d7c90a3293f4e073734e5531ee48461bbb", @"/Views/Home/ServiceConfiguration.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"145064a4f6277f2f0b565f0ea352fc4d7d379d06", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ServiceConfiguration : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DigitalMailRoomMvc.Models.ServiceEntity>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
  
    ViewData["Title"] = "Service List";
    Layout = "~/Views/Shared/MasterLayout.cshtml";

#line default
#line hidden
            BeginContext(148, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 8 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
            BeginContext(182, 450, true);
            WriteLiteral(@"    <div class=""container-fluid"">
        <div class=""row"">
            <h2>Service Configuration</h2><br />
        </div>
        <div class=""row container-fluid"" style=""border:1px solid rgb(80, 191, 230);padding-left:30px;padding-top:10px;padding-bottom:10px;"">

            <div class=""row"">
                <div class=""col-sm-12 col-md-4 col-lg-4"">
                    <label style=""width:30%;"">Service Name</label>
                    ");
            EndContext();
            BeginContext(633, 35, false);
#line 19 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
               Write(Html.TextBoxFor(a => a.ServiceName));

#line default
#line hidden
            EndContext();
            BeginContext(668, 172, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-sm-12 col-md-4 col-lg-4\">\r\n                    <label style=\"width:30%;\">Source Path</label>\r\n                    ");
            EndContext();
            BeginContext(841, 34, false);
#line 23 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
               Write(Html.TextBoxFor(a => a.SourcePath));

#line default
#line hidden
            EndContext();
            BeginContext(875, 178, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-sm-12 col-md-4 col-lg-4\">\r\n                    <label style=\"width:30%;\">File Name Pattern</label>\r\n                    ");
            EndContext();
            BeginContext(1054, 39, false);
#line 27 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
               Write(Html.TextBoxFor(a => a.FileNamePattern));

#line default
#line hidden
            EndContext();
            BeginContext(1093, 236, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <br />\r\n            <div class=\"row\">\r\n                <div class=\"col-sm-12 col-md-4 col-lg-4\">\r\n                    <label style=\"width:30%;\">Host</label>\r\n                    ");
            EndContext();
            BeginContext(1330, 28, false);
#line 34 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
               Write(Html.TextBoxFor(a => a.Host));

#line default
#line hidden
            EndContext();
            BeginContext(1358, 169, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-sm-12 col-md-4 col-lg-4\">\r\n                    <label style=\"width:30%;\">Username</label>\r\n                    ");
            EndContext();
            BeginContext(1528, 32, false);
#line 38 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
               Write(Html.TextBoxFor(a => a.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(1560, 169, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-sm-12 col-md-4 col-lg-4\">\r\n                    <label style=\"width:30%;\">Password</label>\r\n                    ");
            EndContext();
            BeginContext(1730, 32, false);
#line 42 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
               Write(Html.TextBoxFor(a => a.Password));

#line default
#line hidden
            EndContext();
            BeginContext(1762, 250, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <br />\r\n            <div class=\"row\">\r\n                <div class=\"col-sm-12 col-md-4 col-lg-4\">\r\n                    <label style=\"width:30%;\">Restrict File Size</label>\r\n                    ");
            EndContext();
            BeginContext(2013, 52, false);
#line 49 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
               Write(Html.RadioButtonFor(a => a.RestrictFileSize, "true"));

#line default
#line hidden
            EndContext();
            BeginContext(2065, 50, true);
            WriteLiteral(" Yes&nbsp;&nbsp;&nbsp;&nbsp;\r\n                    ");
            EndContext();
            BeginContext(2116, 53, false);
#line 50 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
               Write(Html.RadioButtonFor(a => a.RestrictFileSize, "false"));

#line default
#line hidden
            EndContext();
            BeginContext(2169, 179, true);
            WriteLiteral(" No\r\n                </div>\r\n                <div class=\"col-sm-12 col-md-4 col-lg-4\">\r\n                    <label style=\"width:30%;\">File Size Limit</label>\r\n                    ");
            EndContext();
            BeginContext(2349, 106, false);
#line 54 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
               Write(Html.TextBoxFor(a => a.FileSizeLimit, "", (Model.RestrictFileSize) ? null : new { disabled = "disabled" }));

#line default
#line hidden
            EndContext();
            BeginContext(2455, 177, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-sm-12 col-md-4 col-lg-4\">\r\n                    <label style=\"width:30%;\">Polling Messages</label>\r\n                    ");
            EndContext();
            BeginContext(2633, 39, false);
#line 58 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
               Write(Html.TextBoxFor(a => a.PollingMessages));

#line default
#line hidden
            EndContext();
            BeginContext(2672, 644, true);
            WriteLiteral(@"
                </div>
            </div>
            <br />
            <div class=""row"">
                <div class=""col-sm-12 col-md-4 col-lg-4"" style=""padding-right:100px;"">
                    <div class=""row"" style=""border:1px solid rgb(80, 191, 230);border-radius:6px 6px 0px 0px;"">
                        <div class=""col-sm-12"" style=""padding-top:5px;padding-bottom:5px;background-color:rgb(80, 191, 230);"">
                            <label style=""width:30%;"">Polling Interval</label>
                        </div>
                        <div class=""col-sm-12"" style=""padding-bottom:10px;"">
                            ");
            EndContext();
            BeginContext(3317, 48, false);
#line 69 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
                       Write(Html.RadioButtonFor(a => a.IsPollByTime, "true"));

#line default
#line hidden
            EndContext();
            BeginContext(3365, 67, true);
            WriteLiteral(" Poll by Time&nbsp;&nbsp;&nbsp;&nbsp;\r\n                            ");
            EndContext();
            BeginContext(3433, 49, false);
#line 70 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
                       Write(Html.RadioButtonFor(a => a.IsPollByTime, "false"));

#line default
#line hidden
            EndContext();
            BeginContext(3482, 242, true);
            WriteLiteral(" Poll by Frequency\r\n                        </div>\r\n                        <div class=\"col-sm-12\" style=\"padding-bottom:10px;\">\r\n                            <label style=\"width:40%;\">Polling Time (hh:mm)</label>\r\n                            ");
            EndContext();
            BeginContext(3725, 100, false);
#line 74 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
                       Write(Html.TextBoxFor(a => a.PollingTime, "", (Model.IsPollByTime) ? null : new { disabled = "disabled" }));

#line default
#line hidden
            EndContext();
            BeginContext(3825, 226, true);
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-12\" style=\"padding-bottom:10px;\">\r\n                            <label style=\"width:40%;\">Polling Frequency (ms)</label>\r\n                            ");
            EndContext();
            BeginContext(4052, 106, false);
#line 78 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
                       Write(Html.TextBoxFor(a => a.PollingFrequency, "", (!Model.IsPollByTime) ? null : new { disabled = "disabled" }));

#line default
#line hidden
            EndContext();
            BeginContext(4158, 633, true);
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""col-sm-12 col-md-4 col-lg-4"" style=""padding-right:100px;"">
                    <div class=""row"" style=""border:1px solid rgb(80, 191, 230);border-radius:6px 6px 0px 0px;"">
                        <div class=""col-sm-12"" style=""padding-top:5px;padding-bottom:5px;background-color:rgb(80, 191, 230);"">
                            <label style=""width:30%;"">After Processing</label>
                        </div>
                        <div class=""col-sm-12"" style=""padding-bottom:10px;"">
                            ");
            EndContext();
            BeginContext(4792, 49, false);
#line 88 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
                       Write(Html.RadioButtonFor(a => a.IsMoveAllowed, "true"));

#line default
#line hidden
            EndContext();
            BeginContext(4841, 59, true);
            WriteLiteral(" Move&nbsp;&nbsp;&nbsp;&nbsp;\r\n                            ");
            EndContext();
            BeginContext(4901, 50, false);
#line 89 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
                       Write(Html.RadioButtonFor(a => a.IsMoveAllowed, "false"));

#line default
#line hidden
            EndContext();
            BeginContext(4951, 228, true);
            WriteLiteral(" Delete\r\n                        </div>\r\n                        <div class=\"col-sm-12\" style=\"padding-bottom:10px;\">\r\n                            <label style=\"width:40%;\">Move to Directory</label>\r\n                            ");
            EndContext();
            BeginContext(5180, 100, false);
#line 93 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
                       Write(Html.TextBoxFor(a => a.MoveToPath, "", (Model.IsMoveAllowed) ? null : new { disabled = "disabled" }));

#line default
#line hidden
            EndContext();
            BeginContext(5280, 625, true);
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""col-sm-12 col-md-4 col-lg-4"" style=""padding-right:100px;"">
                    <div class=""row"" style=""border:1px solid rgb(80, 191, 230);border-radius:6px 6px 0px 0px;"">
                        <div class=""col-sm-12"" style=""padding-top:5px;padding-bottom:5px;background-color:rgb(80, 191, 230);"">
                            <label style=""width:30%;"">On Error</label>
                        </div>
                        <div class=""col-sm-12"" style=""padding-bottom:10px;"">
                            ");
            EndContext();
            BeginContext(5906, 56, false);
#line 103 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
                       Write(Html.RadioButtonFor(a => a.IsMoveErroredAllowed, "true"));

#line default
#line hidden
            EndContext();
            BeginContext(5962, 59, true);
            WriteLiteral(" Move&nbsp;&nbsp;&nbsp;&nbsp;\r\n                            ");
            EndContext();
            BeginContext(6022, 57, false);
#line 104 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
                       Write(Html.RadioButtonFor(a => a.IsMoveErroredAllowed, "false"));

#line default
#line hidden
            EndContext();
            BeginContext(6079, 228, true);
            WriteLiteral(" Delete\r\n                        </div>\r\n                        <div class=\"col-sm-12\" style=\"padding-bottom:10px;\">\r\n                            <label style=\"width:40%;\">Move to Directory</label>\r\n                            ");
            EndContext();
            BeginContext(6308, 114, false);
#line 108 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
                       Write(Html.TextBoxFor(a => a.MoveErroredToPath, "", (Model.IsMoveErroredAllowed) ? null : new { disabled = "disabled" }));

#line default
#line hidden
            EndContext();
            BeginContext(6422, 423, true);
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
            </div>
            <div class=""row"" style=""float:right;padding-top:10px;padding-right:50px;"">
                <input class=""button"" type=""submit"" name=""submitbutton1"" value=""Save"" />
                <input class=""button"" type=""submit"" name=""submitbutton2"" value=""Reset"" />
            </div>
        </div>
    </div>
");
            EndContext();
#line 119 "D:\work\POCs\SVN\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\ServiceConfiguration.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DigitalMailRoomMvc.Models.ServiceEntity> Html { get; private set; }
    }
}
#pragma warning restore 1591
