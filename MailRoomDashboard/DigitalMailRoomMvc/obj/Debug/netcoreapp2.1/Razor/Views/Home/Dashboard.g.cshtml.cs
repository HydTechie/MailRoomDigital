#pragma checksum "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12d4b1a3a0e538e7f1922794220e707621be9567"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12d4b1a3a0e538e7f1922794220e707621be9567", @"/Views/Home/Dashboard.cshtml")]
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
            BeginContext(107, 38, true);
            WriteLiteral("<script>\r\n \r\n    var dashboardData =  ");
            EndContext();
            BeginContext(147, 60, false);
#line 10 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
                     Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model)));

#line default
#line hidden
            EndContext();
            BeginContext(208, 1477, true);
            WriteLiteral(@";
</script>
<div class=""container-fluid"">
    <div class=""col-xs-12 dashBoardContent"">
        <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-8"">
            <div class=""col-xs-12"">
                <h5>OVERALL PROGRESS</h5>
            </div>
            <div class=""col-xs-12"">
                <div id=""overallVerificationRequiredContainer"" class=""col-xs-12 col-sm-4 dashboardRow"">
                    <script type=""text/javascript"">
                       
                        loadChartsInDashboard('1', dashboardData, $(window).height())
                    </script>
                </div>
                <div id=""overallRollBackContainer"" class=""col-xs-12 col-sm-4 dashboardRow"">
                    <script>
                        loadChartsInDashboard('2', dashboardData, $(window).height())
                    </script>
                </div>
                <div id=""overallOptionalVerificationContainer"" class=""col-xs-12 col-sm-4 dashboardRow"">
                    <script>
         ");
            WriteLiteral(@"               loadChartsInDashboard('3', dashboardData, $(window).height())
                    </script>
                </div>
            </div>

            <div class=""col-xs-12"">
                <h6>CMS 1500</h6>
            </div>
            <div class=""col-xs-12"">

                <div id=""cmsVerificationRequiredContainer"" style=""cursor:pointer;border-radius:15px;background-color: #F0F0F0;"" class=""col-xs-12 col-sm-4 dashboardRow""");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1685, "\"", 1742, 3);
            WriteAttributeValue("", 1695, "location.href=\'", 1695, 15, true);
#line 42 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 1710, Url.Action("FullList", "Home"), 1710, 31, false);

#line default
#line hidden
            WriteAttributeValue("", 1741, "\'", 1741, 1, true);
            EndWriteAttribute();
            BeginContext(1743, 2763, true);
            WriteLiteral(@">
                    <script>
                        loadChartsInDashboard('4', dashboardData, $(window).height())
                    </script>
                    <div class=""col-sm-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;margin-top:5px;"">
                        Verification Required
                    </div>
                    <div class=""col-sm-12"">
                        <h1 class=""centerAlignmentForText"">10</h1>
                    </div>
                    <div class=""col-sm-12"">
                        <h5 class=""centerAlignmentForText"">Total 40 are assigned today.</h5>
                    </div>
                </div>
                <div id=""cmsRollBackContainer"" style=""cursor:pointer;border-radius:15px;background-color: #F0F0F0;"" class=""col-xs-12 col-sm-4 dashboardRow"">
                    <script>
                        loadChartsInDashboard('5', dashboardData, $(window).height())
                    </script>
       ");
            WriteLiteral(@"             <div class=""col-sm-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;margin-top:5px;"">
                        Roll Back
                    </div>
                    <div class=""col-sm-12"">
                        <h1 class=""centerAlignmentForText"">0</h1>
                    </div>
                    <div class=""col-sm-12"">
                        <h5 class=""centerAlignmentForText"">Total 10 are assigned today.</h5>
                    </div>
                </div>
                <div id=""cmsOptionalVerificationContainer"" style=""cursor:pointer;border-radius:15px;background-color: #F0F0F0;"" class=""col-xs-12 col-sm-4 dashboardRow"">
                    <script>
                        loadChartsInDashboard('6', dashboardData, $(window).height())
                    </script>
                    <div class=""col-sm-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;margin-top:5px;"">
             ");
            WriteLiteral(@"           Optional Verification
                    </div>
                    <div class=""col-sm-12"">
                        <h1 class=""centerAlignmentForText"">30</h1>
                    </div>
                    <div class=""col-sm-12"">
                        <h5 class=""centerAlignmentForText"">Total 40 are assigned today.</h5>
                    </div>
                </div>
            </div>
            <div class=""col-xs-12"">

                <h6>UB-04</h6>

            </div>
            <div class=""col-xs-12"">
                <div id=""ub04VerificationRequiredContainer"" style=""cursor:pointer;border-radius:15px;background-color: #F0F0F0;"" class=""col-xs-12 col-sm-4 dashboardRow"">
");
            EndContext();
            BeginContext(4666, 719, true);
            WriteLiteral(@"                    <div class=""col-sm-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;margin-top:5px;"">
                        Verification Required
                    </div>
                    <div class=""col-sm-12"">
                        <h1 class=""centerAlignmentForText"">20</h1>
                    </div>
                    <div class=""col-sm-12"">
                        <h5 class=""centerAlignmentForText"">Total 60 are assigned today.</h5>
                    </div>
                </div>
                <div id=""ub04RollBackContainer"" style=""cursor:pointer;border-radius:15px;background-color: #F0F0F0;"" class=""col-xs-12 col-sm-4 dashboardRow"">
");
            EndContext();
            BeginContext(5545, 718, true);
            WriteLiteral(@"                    <div class=""col-sm-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;margin-top:5px;"">
                        Roll Back
                    </div>
                    <div class=""col-sm-12"">
                        <h1 class=""centerAlignmentForText"">5</h1>
                    </div>
                    <div class=""col-sm-12"">
                        <h5 class=""centerAlignmentForText"">Total 20 are assigned today.</h5>
                    </div>
                </div>
                <div id=""ub04OptionalVerificationContainer"" style=""cursor:pointer;border-radius:15px;background-color: #F0F0F0;"" class=""col-xs-12 col-sm-4 dashboardRow"">
");
            EndContext();
            BeginContext(6423, 887, true);
            WriteLiteral(@"                    <div class=""col-sm-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;margin-top:5px;"">
                        Optional Verification
                    </div>
                    <div class=""col-sm-12"">
                        <h1 class=""centerAlignmentForText"">30</h1>
                    </div>
                    <div class=""col-sm-12"">
                        <h5 class=""centerAlignmentForText"">Total 40 are assigned today.</h5>
                    </div>
                </div>
            </div>
            <div class=""col-xs-12"">

                <h6>DENTAL CLAIMS</h6>

            </div>
            <div class=""col-xs-12"">
                <div id=""dcVerificationRequiredContainer"" style=""cursor:pointer;border-radius:15px;background-color: #F0F0F0;"" class=""col-xs-12 col-sm-4 dashboardRow"">
");
            EndContext();
            BeginContext(7471, 717, true);
            WriteLiteral(@"                    <div class=""col-sm-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;margin-top:5px;"">
                        Verification Required
                    </div>
                    <div class=""col-sm-12"">
                        <h1 class=""centerAlignmentForText"">20</h1>
                    </div>
                    <div class=""col-sm-12"">
                        <h5 class=""centerAlignmentForText"">Total 50 are assigned today.</h5>
                    </div>
                </div>
                <div id=""dcRollBackContainer"" style=""cursor:pointer;border-radius:15px;background-color: #F0F0F0;"" class=""col-xs-12 col-sm-4 dashboardRow"">
");
            EndContext();
            BeginContext(8349, 717, true);
            WriteLiteral(@"                    <div class=""col-sm-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;margin-top:5px;"">
                        Roll Back
                    </div>
                    <div class=""col-sm-12"">
                        <h1 class=""centerAlignmentForText"">10</h1>
                    </div>
                    <div class=""col-sm-12"">
                        <h5 class=""centerAlignmentForText"">Total 20 are assigned today.</h5>
                    </div>
                </div>
                <div id=""dcOptionalVerificationContainer"" style=""cursor:pointer;border-radius:15px;background-color: #F0F0F0;"" class=""col-xs-12 col-sm-4 dashboardRow"">
");
            EndContext();
            BeginContext(9227, 1499, true);
            WriteLiteral(@"                    <div class=""col-sm-12 centerAlignmentForText"" style=""color: #484b4f;font:Segoe UI;font-size:14px;font-weight:bold;margin-top:5px;"">
                        Optional Verification
                    </div>
                    <div class=""col-sm-12"">
                        <h1 class=""centerAlignmentForText"">20</h1>
                    </div>
                    <div class=""col-sm-12"">
                        <h5 class=""centerAlignmentForText"">Total 20 are assigned today.</h5>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-4"">
            <div class=""col-xs-12"">
                <h6 class=""centerAlignmentForText"">MY PERFORMANCE</h6>
            </div>

            <div id=""allocatedVsCompletedContainer"" class=""col-xs-12 metricChartRow"">
                <script>
                    loadChartsInDashboard('13', dashboardData, $(window).height())
                </script>
           ");
            WriteLiteral(@" </div>

            <div class=""col-xs-12"">
                <h4 class=""centerAlignmentForText"">Important Links</h4>
            </div>
            <div class=""col-xs-12"">
                <div id=""importantLinksContainer"" class=""col-xs-12 metricLinkRow"" style=""border-radius:10px;background-color:#F0F0F0;height:100%;"">
                    <br />https://www.unitedstateszipcodes.org/
                </div>
            </div>

        </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MailRoom.Model.Dashboard> Html { get; private set; }
    }
}
#pragma warning restore 1591
