#pragma checksum "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2bb848acbbd622b69fd8fa5d79b7a6e0cd933f71"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Dashboard.cshtml", typeof(AspNetCore.Views_Home_Dashboard))]
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
#line 1 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\_ViewImports.cshtml"
using DigitalMailRoomMvc;

#line default
#line hidden
#line 2 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\_ViewImports.cshtml"
using DigitalMailRoomMvc.Models;

#line default
#line hidden
#line 1 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
using MailRoom.Model;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2bb848acbbd622b69fd8fa5d79b7a6e0cd933f71", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30a1188e53dcf6ee5406a2b293ac0d4101bed957", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MailRoom.Model.Dashboard>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
            BeginContext(102, 37, true);
            WriteLiteral("<script>\r\n\r\n    var dashboardData =  ");
            EndContext();
            BeginContext(141, 60, false);
#line 8 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                     Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model)));

#line default
#line hidden
            EndContext();
            BeginContext(202, 1961, true);
            WriteLiteral(@";
</script>
<div class=""container-fluid row"">
    <div class=""col-xs-12 dashBoardContent"">
        <div class=""row"">
            <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-8"">
                <div class=""row"">
                    <div class=""col-xs-12 col-lg-12"">
                        <h5>OVERALL PROGRESS</h5>
                    </div>
                    <div class=""col-xs-12 col-lg-12"">
                        <div class=""row"">
                            <div id=""overallVerificationRequiredContainer"" class=""col-xs-12 col-sm-4 col-lg-4 dashboardRow"">
                                <script type=""text/javascript"">
                                    loadChartsInDashboard('1', dashboardData, $(window).height())
                                </script>
                            </div>
                            <div id=""overallRollBackContainer"" class=""col-xs-12 col-sm-4 col-lg-4 dashboardRow"">
                                <script>
                                    loadChar");
            WriteLiteral(@"tsInDashboard('2', dashboardData, $(window).height())
                                </script>
                            </div>
                            <div id=""overallOptionalVerificationContainer"" class=""col-xs-12 col-sm-4 col-lg-4 dashboardRow"">
                                <script>
                                    loadChartsInDashboard('3', dashboardData, $(window).height())
                                </script>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-lg-12"">
                        <h6>CMS 1500</h6>
                    </div>

                    <div class=""col-xs-12 col-lg-12"">
                        <div class=""row container-fluid"">
                            <div class=""col-xs-12 col-sm-12 col-md-4 col-lg-4"" style=""padding-right:35px;""");
            EndContext();
            BeginWriteAttribute("onclick", " \r\n                                 onclick=\"", 2163, "\"", 2331, 3);
            WriteAttributeValue("", 2208, "location.href=\'", 2208, 15, true);
#line 46 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 2223, Url.Action("FullList", "Home", new { @claimType ="CMS", @reviewerId ="reviewerid1", @reviewStauts = 0  } ), 2223, 107, false);

#line default
#line hidden
            WriteAttributeValue("", 2330, "\'", 2330, 1, true);
            EndWriteAttribute();
            BeginContext(2332, 3, true);
            WriteLiteral(">\r\n");
            EndContext();
            BeginContext(2569, 563, true);
            WriteLiteral(@"                                <div class=""row container-fluid"" style=""cursor:pointer;border-radius:10px;background-color: #F0F0F0;"">
                                    <div class=""col-lg-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;"">
                                        Verification Required
                                    </div>
                                    <div class=""col-lg-12"" style=""padding-bottom:-10px;"">
                                        <h1 class=""centerAlignmentForText"">");
            EndContext();
            BeginContext(3133, 26, false);
#line 56 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                      Write(Model.ClaimsCMS100["TODO"]);

#line default
#line hidden
            EndContext();
            BeginContext(3159, 223, true);
            WriteLiteral("</h1>\r\n                                    </div>\r\n                                    <div class=\"col-lg-12\" style=\"padding-bottom:-10px;\">\r\n                                        <h5 class=\"centerAlignmentForText\">Total ");
            EndContext();
            BeginContext(3383, 37, false);
#line 59 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                            Write(Model.TotalClaimsCountByCMS1500PerDay);

#line default
#line hidden
            EndContext();
            BeginContext(3420, 271, true);
            WriteLiteral(@" are assigned today.</h5>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-xs-12 col-sm-12 col-md-4 col-lg-4"" style=""padding-right:25px;padding-left:25px;""");
            EndContext();
            BeginWriteAttribute("onclick", "\r\n                                  onclick=\"", 3691, "\"", 3859, 3);
            WriteAttributeValue("", 3736, "location.href=\'", 3736, 15, true);
#line 64 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 3751, Url.Action("FullList", "Home", new { @claimType ="CMS", @reviewerId ="reviewerid1", @reviewStatus = 2  } ), 3751, 107, false);

#line default
#line hidden
            WriteAttributeValue("", 3858, "\'", 3858, 1, true);
            EndWriteAttribute();
            BeginContext(3860, 3, true);
            WriteLiteral(">\r\n");
            EndContext();
            BeginContext(4097, 506, true);
            WriteLiteral(@"                                <div class=""row container-fluid"" style=""border-radius:10px;background-color: #F0F0F0;"">
                                    <div class=""col-lg-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;"">
                                        Roll Back
                                    </div>
                                    <div class=""col-lg-12"">
                                        <h1 class=""centerAlignmentForText"">");
            EndContext();
            BeginContext(4604, 30, false);
#line 74 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                      Write(Model.ClaimsCMS100["ROLLBACK"]);

#line default
#line hidden
            EndContext();
            BeginContext(4634, 193, true);
            WriteLiteral("</h1>\r\n                                    </div>\r\n                                    <div class=\"col-lg-12\">\r\n                                        <h5 class=\"centerAlignmentForText\">Total ");
            EndContext();
            BeginContext(4828, 37, false);
#line 77 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                            Write(Model.TotalClaimsCountByCMS1500PerDay);

#line default
#line hidden
            EndContext();
            BeginContext(4865, 252, true);
            WriteLiteral(" are assigned today.</h5>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"col-xs-12 col-sm-12 col-md-4 col-lg-4\" style=\"padding-left:35px;\"");
            EndContext();
            BeginWriteAttribute("onclick", "\r\n                                  onclick=\"", 5117, "\"", 5284, 3);
            WriteAttributeValue("", 5162, "location.href=\'", 5162, 15, true);
#line 82 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 5177, Url.Action("FullList", "Home", new { @claimType ="CMS", @reviewerId ="reviewerid1", @reviewStatus =1  } ), 5177, 106, false);

#line default
#line hidden
            WriteAttributeValue("", 5283, "\'", 5283, 1, true);
            EndWriteAttribute();
            BeginContext(5285, 3, true);
            WriteLiteral(">\r\n");
            EndContext();
            BeginContext(5522, 518, true);
            WriteLiteral(@"                                <div class=""row container-fluid"" style=""border-radius:10px;background-color: #F0F0F0;"">
                                    <div class=""col-lg-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;"">
                                        Optional Verification
                                    </div>
                                    <div class=""col-lg-12"">
                                        <h1 class=""centerAlignmentForText"">");
            EndContext();
            BeginContext(6041, 31, false);
#line 92 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                      Write(Model.ClaimsCMS100["COMPLETED"]);

#line default
#line hidden
            EndContext();
            BeginContext(6072, 193, true);
            WriteLiteral("</h1>\r\n                                    </div>\r\n                                    <div class=\"col-lg-12\">\r\n                                        <h5 class=\"centerAlignmentForText\">Total ");
            EndContext();
            BeginContext(6266, 37, false);
#line 95 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                            Write(Model.TotalClaimsCountByCMS1500PerDay);

#line default
#line hidden
            EndContext();
            BeginContext(6303, 602, true);
            WriteLiteral(@" are assigned today.</h5>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-lg-12"">
                        <h6>UB-04</h6>
                    </div>
                    <div class=""col-xs-12 col-lg-12"">
                        <div class=""row container-fluid"">
                            <div class=""col-xs-12 col-sm-12 col-md-4 col-lg-4"" style=""padding-right:35px;"">
");
            EndContext();
            BeginContext(7139, 518, true);
            WriteLiteral(@"                                <div class=""row container-fluid"" style=""border-radius:10px;background-color: #F0F0F0;"">
                                    <div class=""col-lg-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;"">
                                        Verification Required
                                    </div>
                                    <div class=""col-lg-12"">
                                        <h1 class=""centerAlignmentForText"">");
            EndContext();
            BeginContext(7658, 24, false);
#line 118 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                      Write(Model.ClaimsUB04["TODO"]);

#line default
#line hidden
            EndContext();
            BeginContext(7682, 193, true);
            WriteLiteral("</h1>\r\n                                    </div>\r\n                                    <div class=\"col-lg-12\">\r\n                                        <h5 class=\"centerAlignmentForText\">Total ");
            EndContext();
            BeginContext(7876, 34, false);
#line 121 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                            Write(Model.TotalClaimsCountByUB04PerDay);

#line default
#line hidden
            EndContext();
            BeginContext(7910, 274, true);
            WriteLiteral(@" are assigned today.</h5>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-xs-12 col-sm-12 col-md-4 col-lg-4"" style=""padding-right:25px;padding-left:25px;"">
");
            EndContext();
            BeginContext(8418, 506, true);
            WriteLiteral(@"                                <div class=""row container-fluid"" style=""border-radius:10px;background-color: #F0F0F0;"">
                                    <div class=""col-lg-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;"">
                                        Roll Back
                                    </div>
                                    <div class=""col-lg-12"">
                                        <h1 class=""centerAlignmentForText"">");
            EndContext();
            BeginContext(8925, 28, false);
#line 135 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                      Write(Model.ClaimsUB04["ROLLBACK"]);

#line default
#line hidden
            EndContext();
            BeginContext(8953, 193, true);
            WriteLiteral("</h1>\r\n                                    </div>\r\n                                    <div class=\"col-lg-12\">\r\n                                        <h5 class=\"centerAlignmentForText\">Total ");
            EndContext();
            BeginContext(9147, 34, false);
#line 138 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                            Write(Model.TotalClaimsCountByUB04PerDay);

#line default
#line hidden
            EndContext();
            BeginContext(9181, 255, true);
            WriteLiteral(" are assigned today.</h5>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"col-xs-12 col-sm-12 col-md-4 col-lg-4\" style=\"padding-left:35px;\">\r\n");
            EndContext();
            BeginContext(9670, 518, true);
            WriteLiteral(@"                                <div class=""row container-fluid"" style=""border-radius:10px;background-color: #F0F0F0;"">
                                    <div class=""col-lg-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;"">
                                        Optional Verification
                                    </div>
                                    <div class=""col-lg-12"">
                                        <h1 class=""centerAlignmentForText"">");
            EndContext();
            BeginContext(10189, 29, false);
#line 152 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                      Write(Model.ClaimsUB04["COMPLETED"]);

#line default
#line hidden
            EndContext();
            BeginContext(10218, 193, true);
            WriteLiteral("</h1>\r\n                                    </div>\r\n                                    <div class=\"col-lg-12\">\r\n                                        <h5 class=\"centerAlignmentForText\">Total ");
            EndContext();
            BeginContext(10412, 34, false);
#line 155 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                            Write(Model.TotalClaimsCountByUB04PerDay);

#line default
#line hidden
            EndContext();
            BeginContext(10446, 614, true);
            WriteLiteral(@" are assigned today.</h5>
                                    </div>
                                </div>
                            </div>
                        </div>


                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-lg-12"">
                        <h6>DENTAL CLAIMS</h6>
                    </div>
                    <div class=""col-xs-12 col-lg-12"">
                        <div class=""row container-fluid"">
                            <div class=""col-xs-12 col-sm-12 col-md-4 col-lg-4"" style=""padding-right:35px;"">
");
            EndContext();
            BeginContext(11295, 518, true);
            WriteLiteral(@"                                <div class=""row container-fluid"" style=""border-radius:10px;background-color: #F0F0F0;"">
                                    <div class=""col-lg-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;"">
                                        Verification Required
                                    </div>
                                    <div class=""col-lg-12"">
                                        <h1 class=""centerAlignmentForText"">");
            EndContext();
            BeginContext(11814, 24, false);
#line 180 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                      Write(Model.ClaimsPK83["TODO"]);

#line default
#line hidden
            EndContext();
            BeginContext(11838, 193, true);
            WriteLiteral("</h1>\r\n                                    </div>\r\n                                    <div class=\"col-lg-12\">\r\n                                        <h5 class=\"centerAlignmentForText\">Total ");
            EndContext();
            BeginContext(12032, 34, false);
#line 183 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                            Write(Model.TotalClaimsCountByPK83PerDay);

#line default
#line hidden
            EndContext();
            BeginContext(12066, 274, true);
            WriteLiteral(@" are assigned today.</h5>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-xs-12 col-sm-12 col-md-4 col-lg-4"" style=""padding-right:25px;padding-left:25px;"">
");
            EndContext();
            BeginContext(12575, 506, true);
            WriteLiteral(@"                                <div class=""row container-fluid"" style=""border-radius:10px;background-color: #F0F0F0;"">
                                    <div class=""col-lg-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;"">
                                        Roll Back
                                    </div>
                                    <div class=""col-lg-12"">
                                        <h1 class=""centerAlignmentForText"">");
            EndContext();
            BeginContext(13082, 28, false);
#line 197 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                      Write(Model.ClaimsPK83["ROLLBACK"]);

#line default
#line hidden
            EndContext();
            BeginContext(13110, 193, true);
            WriteLiteral("</h1>\r\n                                    </div>\r\n                                    <div class=\"col-lg-12\">\r\n                                        <h5 class=\"centerAlignmentForText\">Total ");
            EndContext();
            BeginContext(13304, 34, false);
#line 200 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                            Write(Model.TotalClaimsCountByPK83PerDay);

#line default
#line hidden
            EndContext();
            BeginContext(13338, 255, true);
            WriteLiteral(" are assigned today.</h5>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"col-xs-12 col-sm-12 col-md-4 col-lg-4\" style=\"padding-left:35px;\">\r\n");
            EndContext();
            BeginContext(13828, 518, true);
            WriteLiteral(@"                                <div class=""row container-fluid"" style=""border-radius:10px;background-color: #F0F0F0;"">
                                    <div class=""col-lg-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;"">
                                        Optional Verification
                                    </div>
                                    <div class=""col-lg-12"">
                                        <h1 class=""centerAlignmentForText"">");
            EndContext();
            BeginContext(14347, 29, false);
#line 214 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                      Write(Model.ClaimsPK83["COMPLETED"]);

#line default
#line hidden
            EndContext();
            BeginContext(14376, 193, true);
            WriteLiteral("</h1>\r\n                                    </div>\r\n                                    <div class=\"col-lg-12\">\r\n                                        <h5 class=\"centerAlignmentForText\">Total ");
            EndContext();
            BeginContext(14570, 34, false);
#line 217 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                                                                            Write(Model.TotalClaimsCountByPK83PerDay);

#line default
#line hidden
            EndContext();
            BeginContext(14604, 1360, true);
            WriteLiteral(@" are assigned today.</h5>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-4"">
                <div class=""row"">
                    <div class=""col-xs-12"">
                        <h6 class=""centerAlignmentForText"">MY PERFORMANCE</h6>
                    </div>

                    <div id=""allocatedVsCompletedContainer"" class=""col-xs-12 metricChartRow"">
                        <script>
                            loadChartsInDashboard('13', dashboardData, $(window).height())
                        </script>
                    </div>

                    <div class=""col-xs-12"">
                        <h4 class=""centerAlignmentForText"">Important Links</h4>
                    </div>
                    <div class=""col-xs-12"">
                        <div id=");
            WriteLiteral(@"""importantLinksContainer"" class=""col-xs-12 metricLinkRow"" style=""border-radius:10px;background-color:#F0F0F0;height:100%;"">
                            <br />https://www.unitedstateszipcodes.org/
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MailRoom.Model.Dashboard> Html { get; private set; }
    }
}
#pragma warning restore 1591
