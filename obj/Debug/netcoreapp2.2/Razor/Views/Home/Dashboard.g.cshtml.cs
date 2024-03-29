#pragma checksum "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f163c0c3b06526d6acd5709ab9a694ad6e2903dc"
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
#line 1 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/_ViewImports.cshtml"
using CSharpBelt;

#line default
#line hidden
#line 2 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/_ViewImports.cshtml"
using CSharpBelt.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f163c0c3b06526d6acd5709ab9a694ad6e2903dc", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d8fc45ca57f482f0e439930ed604d9b20ad5fb5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DojoActivity>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 46, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f163c0c3b06526d6acd5709ab9a694ad6e2903dc3791", async() => {
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
            BeginContext(46, 129, true);
            WriteLiteral("\n<div class=\"dashHeader\">\n    <h2 class=\"display-4\">Dojo Activity Center</h2>\n    <div class=\"rightheader\">\n        <h5>Welcome, ");
            EndContext();
            BeginContext(176, 17, false);
#line 5 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                Write(ViewBag.user_name);

#line default
#line hidden
            EndContext();
            BeginContext(193, 78, true);
            WriteLiteral("!</h5>\n        <h5><a href=\"/logout\">Log Out</a></h5>\n    </div>\n</div>\n<div>\n");
            EndContext();
            BeginContext(301, 429, true);
            WriteLiteral(@"    <div class=""activities"">
        <table class=""table table-striped"">
            <thead>
                <tr>
                    <th>Activity</th>
                    <th>Date and Time</th>
                    <th>Duration</th>
                    <th>Event Coordinator</th>
                    <th>No. of Participants</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 24 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                  
                    var sortedActivities = Model.OrderBy(a => a.date).ToList();
                

#line default
#line hidden
            BeginContext(848, 16, true);
            WriteLiteral("                ");
            EndContext();
#line 27 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                 foreach(var activity in sortedActivities)
                {

#line default
#line hidden
            BeginContext(925, 55, true);
            WriteLiteral("                    <tr>\n                        <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 980, "\"", 1018, 2);
            WriteAttributeValue("", 987, "/activity/", 987, 10, true);
#line 30 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 997, activity.activity_id, 997, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1019, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1021, 13, false);
#line 30 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                                                                 Write(activity.name);

#line default
#line hidden
            EndContext();
            BeginContext(1034, 38, true);
            WriteLiteral("</a></td>\n                        <td>");
            EndContext();
            BeginContext(1073, 44, false);
#line 31 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                       Write(activity.fullTime.ToString("M/dd @ h:mm tt"));

#line default
#line hidden
            EndContext();
            BeginContext(1117, 6, true);
            WriteLiteral("</td>\n");
            EndContext();
#line 32 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                          
                            if(activity.duration == 1){

#line default
#line hidden
            BeginContext(1206, 36, true);
            WriteLiteral("                                <td>");
            EndContext();
            BeginContext(1243, 17, false);
#line 34 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                               Write(activity.duration);

#line default
#line hidden
            EndContext();
            BeginContext(1260, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1262, 68, false);
#line 34 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                                                  Write(activity.durationType.Substring(0,(@activity.durationType.Length-1)));

#line default
#line hidden
            EndContext();
            BeginContext(1330, 6, true);
            WriteLiteral("</td>\n");
            EndContext();
#line 35 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(1429, 36, true);
            WriteLiteral("                                <td>");
            EndContext();
            BeginContext(1466, 17, false);
#line 38 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                               Write(activity.duration);

#line default
#line hidden
            EndContext();
            BeginContext(1483, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1485, 21, false);
#line 38 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                                                  Write(activity.durationType);

#line default
#line hidden
            EndContext();
            BeginContext(1506, 6, true);
            WriteLiteral("</td>\n");
            EndContext();
#line 39 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"

                            }
                        

#line default
#line hidden
            BeginContext(1569, 28, true);
            WriteLiteral("                        <td>");
            EndContext();
            BeginContext(1598, 25, false);
#line 42 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                       Write(activity.Coordinator.name);

#line default
#line hidden
            EndContext();
            BeginContext(1623, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(1658, 20, false);
#line 43 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                       Write(activity.Plans.Count);

#line default
#line hidden
            EndContext();
            BeginContext(1678, 35, true);
            WriteLiteral("</td>\n                        <td>\n");
            EndContext();
#line 45 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                          
                            if(activity.coordinator_id == ViewBag.user_id)
                            {

#line default
#line hidden
            BeginContext(1845, 57, true);
            WriteLiteral("                                <a class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("href", "href=\"", 1902, "\"", 1946, 3);
            WriteAttributeValue("", 1908, "/activity/", 1908, 10, true);
#line 48 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1918, activity.activity_id, 1918, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 1939, "/delete", 1939, 7, true);
            EndWriteAttribute();
            BeginContext(1947, 12, true);
            WriteLiteral(">Delete</a>\n");
            EndContext();
#line 49 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                            }else if(activity.Plans.FirstOrDefault(p => p.user_id == ViewBag.user_id)!=null)
                            {

#line default
#line hidden
            BeginContext(2098, 58, true);
            WriteLiteral("                                <a class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("href", "href=\"", 2156, "\"", 2199, 3);
            WriteAttributeValue("", 2162, "/activity/", 2162, 10, true);
#line 51 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 2172, activity.activity_id, 2172, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 2193, "/leave", 2193, 6, true);
            EndWriteAttribute();
            BeginContext(2200, 11, true);
            WriteLiteral(">Leave</a>\n");
            EndContext();
#line 52 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                            }else
                            {

#line default
#line hidden
            BeginContext(2275, 58, true);
            WriteLiteral("                                <a class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("href", "href=\"", 2333, "\"", 2375, 3);
            WriteAttributeValue("", 2339, "/activity/", 2339, 10, true);
#line 54 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 2349, activity.activity_id, 2349, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 2370, "/join", 2370, 5, true);
            EndWriteAttribute();
            BeginContext(2376, 10, true);
            WriteLiteral(">Join</a>\n");
            EndContext();
#line 55 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                            }
                        

#line default
#line hidden
            BeginContext(2442, 56, true);
            WriteLiteral("                        </td>\n                    </tr>\n");
            EndContext();
#line 59 "/Users/quentin/Desktop/Coding_Dojo/BeltExams/C#/CSharpBelt/Views/Home/Dashboard.cshtml"
                }

#line default
#line hidden
            BeginContext(2516, 133, true);
            WriteLiteral("\n            </tbody>\n        </table>\n    </div>\n    <a href=\"/new\" class=\"addActBtn btn btn-primary\">Add a New Activity</a>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DojoActivity>> Html { get; private set; }
    }
}
#pragma warning restore 1591
