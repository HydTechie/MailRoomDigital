#pragma checksum "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\FullList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "126e9ba136397399ab114d56a3e2070feee2ec50"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_FullList), @"mvc.1.0.view", @"/Views/Home/FullList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/FullList.cshtml", typeof(AspNetCore.Views_Home_FullList))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"126e9ba136397399ab114d56a3e2070feee2ec50", @"/Views/Home/FullList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30a1188e53dcf6ee5406a2b293ac0d4101bed957", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_FullList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/RefreshIcon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:20px;width:20px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\FullList.cshtml"
  
    ViewData["Title"] = "About";

#line default
#line hidden
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\FullList.cshtml"
  
    var format = "dd-MM-yyyy"; // your datetime format
    var dateTimeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter { DateTimeFormat = format };
    var claimList = Newtonsoft.Json.JsonConvert
        .DeserializeObject<List<ClaimEntity>>("[{\"PatientId\":403264,\"ClaimId\":7918,\"ColumnsToVerify\":5,\"ConfidenceScore\":90,\"SubmissionDate\":\"25-11-2018\",\"ExtractedDate\":\"27-11-2018\"},{\"PatientId\":403265,\"ClaimId\":7919,\"ColumnsToVerify\":6,\"ConfidenceScore\":80,\"SubmissionDate\":\"24-11-2018\",\"ExtractedDate\":\"27-11-2018\"},{\"PatientId\":403266,\"ClaimId\":7920,\"ColumnsToVerify\":2,\"ConfidenceScore\":75,\"SubmissionDate\":\"23-11-2018\",\"ExtractedDate\":\"27-11-2018\"},{\"PatientId\":403267,\"ClaimId\":7921,\"ColumnsToVerify\":1,\"ConfidenceScore\":82,\"SubmissionDate\":\"22-11-2018\",\"ExtractedDate\":\"27-11-2018\"},{\"PatientId\":403268,\"ClaimId\":7922,\"ColumnsToVerify\":7,\"ConfidenceScore\":83,\"SubmissionDate\":\"21-11-2018\",\"ExtractedDate\":\"27-11-2018\"}]", dateTimeConverter);

#line default
#line hidden
            BeginContext(1099, 590, true);
            WriteLiteral(@"<div class=""container-fluid"">
    <div class=""col-xs-12"">
        <div class=""row"">
            <div class=""col-sm-12 col-md-3"">
                <h2>Verification Required</h2>
            </div>
            <div class=""col-sm-12 col-md-3"">
                <input type=""text"" id=""searchField"" placeholder="" Search Patient ID"" style=""margin-top:20px;height:30px;border-radius:8px;border-width:thin;"" />
            </div>
            <div class=""col-md-3"">
            </div>
            <div class=""col-sm-12 col-md-3"" style=""margin-top:20px;text-align:right"">
                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 1689, "\'", 1727, 1);
#line 24 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\FullList.cshtml"
WriteAttributeValue("", 1696, Url.Action("FullList", "Home"), 1696, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1728, 62, true);
            WriteLiteral(" style=\"cursor:pointer\" title=\"Refresh\">\r\n                    ");
            EndContext();
            BeginContext(1790, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "44dc7cdf52d646d8b13cb334d8e3bd7b", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1860, 601, true);
            WriteLiteral(@"
                </a>
            </div>
        </div>
        <div class=""row"">
            <table id=""example"" class=""table table-striped table-bordered"" style=""width:100%"">
                <thead>
                    <tr>
                        <th>Patient Id</th>
                        <th>Claim Id</th>
                        <th>Columns to verify</th>
                        <th>Confidence Score</th>
                        <th>Submitted Date</th>
                        <th>Extracted Date</th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 42 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\FullList.cshtml"
                     foreach (var claimItem in claimList)
                    {

#line default
#line hidden
            BeginContext(2543, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(2606, 19, false);
#line 45 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\FullList.cshtml"
                           Write(claimItem.PatientId);

#line default
#line hidden
            EndContext();
            BeginContext(2625, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(2665, 17, false);
#line 46 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\FullList.cshtml"
                           Write(claimItem.ClaimId);

#line default
#line hidden
            EndContext();
            BeginContext(2682, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(2722, 25, false);
#line 47 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\FullList.cshtml"
                           Write(claimItem.ColumnsToVerify);

#line default
#line hidden
            EndContext();
            BeginContext(2747, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(2787, 25, false);
#line 48 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\FullList.cshtml"
                           Write(claimItem.ConfidenceScore);

#line default
#line hidden
            EndContext();
            BeginContext(2812, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(2852, 24, false);
#line 49 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\FullList.cshtml"
                           Write(claimItem.SubmissionDate);

#line default
#line hidden
            EndContext();
            BeginContext(2876, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(2916, 23, false);
#line 50 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\FullList.cshtml"
                           Write(claimItem.ExtractedDate);

#line default
#line hidden
            EndContext();
            BeginContext(2939, 38, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n");
            EndContext();
#line 52 "D:\work\POCs\DigitalMailRoom\MailRoomDashboard\DigitalMailRoomMvc\Views\Home\FullList.cshtml"
                    }

#line default
#line hidden
            BeginContext(3000, 647, true);
            WriteLiteral(@"                </tbody>
            </table>
            <script>
                var table = $('#example').DataTable({ ""dom"": 'rt<""bottom""ip><""clear"">' });
                table.column(0).every(function () {
                    var that = this;
                    $('#searchField').on('keyup change', function () {
                        if (that.search() !== this.value) {
                            that
                                .search(this.value)
                                .draw();
                        }
                    });
                });
            </script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
