#pragma checksum "D:\Ravi Kiran_1\SVN\digitalmailroomportal\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dfe163e5c07851a0178007eeedfcc0eec6f293f6"
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
#line 1 "D:\Ravi Kiran_1\SVN\digitalmailroomportal\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\_ViewImports.cshtml"
using DigitalMailRoomMvc;

#line default
#line hidden
#line 2 "D:\Ravi Kiran_1\SVN\digitalmailroomportal\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\_ViewImports.cshtml"
using DigitalMailRoomMvc.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfe163e5c07851a0178007eeedfcc0eec6f293f6", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30a1188e53dcf6ee5406a2b293ac0d4101bed957", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\Ravi Kiran_1\SVN\digitalmailroomportal\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
            BeginContext(45, 1348, true);
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""col-xs-12 dashBoardContent"">
        <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-8"">
            <div class=""col-xs-12"">
                <h5>OVERALL PROGRESS</h5>
            </div>
            <div class=""col-xs-12"">
                <div id=""overallVerificationRequiredContainer"" class=""col-xs-12 col-sm-4 dashboardRow"">
                    <script type=""text/javascript"">
                        loadChartsInDashboard('1', $(window).height())
                    </script>
                </div>
                <div id=""overallRollBackContainer"" class=""col-xs-12 col-sm-4 dashboardRow"">
                    <script>
                        loadChartsInDashboard('2', $(window).height())
                    </script>
                </div>
                <div id=""overallOptionalVerificationContainer"" class=""col-xs-12 col-sm-4 dashboardRow"">
                    <script>
                        loadChartsInDashboard('3', $(window).height())
    ");
            WriteLiteral(@"                </script>
                </div>
            </div>

            <div class=""col-xs-12"">
                <h6>CMS 1500</h6>
            </div>
            <div class=""col-xs-12"">
                <div id=""cmsVerificationRequiredContainer"" style=""cursor:pointer;"" class=""col-xs-12 col-sm-4 dashboardRow""");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1393, "\"", 1450, 3);
            WriteAttributeValue("", 1403, "location.href=\'", 1403, 15, true);
#line 33 "D:\Ravi Kiran_1\SVN\digitalmailroomportal\trunk\DigitalMailRoomDashboard\DigitalMailRoomMvc\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 1418, Url.Action("FullList", "Home"), 1418, 31, false);

#line default
#line hidden
            WriteAttributeValue("", 1449, "\'", 1449, 1, true);
            EndWriteAttribute();
            BeginContext(1451, 3420, true);
            WriteLiteral(@">
                    <script>
                        loadChartsInDashboard('4', $(window).height())
                    </script>
                </div>
                <div id=""cmsRollBackContainer"" class=""col-xs-12 col-sm-4 dashboardRow"">
                    <script>
                        loadChartsInDashboard('5', $(window).height())
                    </script>
                </div>
                <div id=""cmsOptionalVerificationContainer"" class=""col-xs-12 col-sm-4 dashboardRow"">
                    <script>
                        loadChartsInDashboard('6', $(window).height())
                    </script>
                </div>
            </div>
            <div class=""col-xs-12"">

                <h6>UB-04</h6>

            </div>
            <div class=""col-xs-12"">
                <div id=""ub04VerificationRequiredContainer"" class=""col-xs-12 col-sm-4 dashboardRow"">
                    <script>
                        loadChartsInDashboard('7', $(window).height())
      ");
            WriteLiteral(@"              </script>
                </div>
                <div id=""ub04RollBackContainer"" class=""col-xs-12 col-sm-4 dashboardRow"">
                    <script>
                        loadChartsInDashboard('8', $(window).height())
                    </script>
                </div>
                <div id=""ub04OptionalVerificationContainer"" class=""col-xs-12 col-sm-4 dashboardRow"">
                    <script>
                        loadChartsInDashboard('9', $(window).height())
                    </script>
                </div>
            </div>
            <div class=""col-xs-12"">

                <h6>DENTAL CLAIMS</h6>

            </div>
            <div class=""col-xs-12"">
                <div id=""dcVerificationRequiredContainer"" class=""col-xs-12 col-sm-4 dashboardRow"">
                    <script>
                        loadChartsInDashboard('10', $(window).height())
                    </script>
                </div>
                <div id=""dcRollBackContainer"" class=""");
            WriteLiteral(@"col-xs-12 col-sm-4 dashboardRow"">
                    <script>
                        loadChartsInDashboard('11', $(window).height())
                    </script>
                </div>
                <div id=""dcOptionalVerificationContainer"" class=""col-xs-12 col-sm-4 dashboardRow"">
                    <script>
                        loadChartsInDashboard('12', $(window).height())
                    </script>
                </div>
            </div>
        </div>
        <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-4"">
            <div class=""col-xs-12"">
                <h6 class=""centerAlignmentForText"">MY PERFORMANCE</h6>
            </div>

            <div id=""allocatedVsCompletedContainer"" class=""col-xs-12 metricChartRow"">
                <script>
                    loadChartsInDashboard('13', $(window).height())
                </script>
            </div>

            <div class=""col-xs-12"">
                <h4 class=""centerAlignmentForText"">Important Links</h4>
   ");
            WriteLiteral(@"         </div>
            <div class=""col-xs-12"">
                <div id=""importantLinksContainer"" class=""col-xs-12 metricLinkRow"" style=""border-radius:10px;background-color:#F0F0F0;height:100%;"">
                    <br />https://www.unitedstateszipcodes.org/
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
