#pragma checksum "C:\Users\Ali\Desktop\almost final\AspNetCore Demo App\EVS373.PakClassified.WebUI\Views\Home\Nav.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1329e3305dd37a3249dbe04e78570f8d57f8272"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Nav), @"mvc.1.0.view", @"/Views/Home/Nav.cshtml")]
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
#line 1 "C:\Users\Ali\Desktop\almost final\AspNetCore Demo App\EVS373.PakClassified.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Ali\Desktop\almost final\AspNetCore Demo App\EVS373.PakClassified.WebUI\Views\_ViewImports.cshtml"
using EVS373.UsersMgt;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Ali\Desktop\almost final\AspNetCore Demo App\EVS373.PakClassified.WebUI\Views\_ViewImports.cshtml"
using EVS373.PakClassified.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Ali\Desktop\almost final\AspNetCore Demo App\EVS373.PakClassified.WebUI\Views\_ViewImports.cshtml"
using EVS373.PakClassified.WebUI.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1329e3305dd37a3249dbe04e78570f8d57f8272", @"/Views/Home/Nav.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59d762d9455dbe727c1167fe9153586d28b1bac1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Nav : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EVS373.PakClassified.WebUI.Models.AdvertizementModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "advertizements", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("lnk-advdetails"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Ali\Desktop\almost final\AspNetCore Demo App\EVS373.PakClassified.WebUI\Views\Home\Nav.cshtml"
   
    Layout = "~/Views/Shared/_OthersLayout.cshtml";


    string parent = (string)ViewData["Parent"];
    string child = (string)ViewData["Child"];
    List <EVS373.PakClassified.WebUI.Models.AdvertizementModel>  ads = (List<EVS373.PakClassified.WebUI.Models.AdvertizementModel>)ViewData["list"];





#line default
#line hidden
#nullable disable
            WriteLiteral("<style>\r\n    #myrow{\r\n        margin-left:25px;\r\n        margin-top:25px;\r\n        margin-bottom:50px;\r\n    }\r\n</style>\r\n    <div id=\"myrow\" class=\"row\">\r\n        <h4>Home --> ");
#nullable restore
#line 22 "C:\Users\Ali\Desktop\almost final\AspNetCore Demo App\EVS373.PakClassified.WebUI\Views\Home\Nav.cshtml"
                Write(parent);

#line default
#line hidden
#nullable disable
            WriteLiteral(" --> ");
#nullable restore
#line 22 "C:\Users\Ali\Desktop\almost final\AspNetCore Demo App\EVS373.PakClassified.WebUI\Views\Home\Nav.cshtml"
                            Write(child);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n        </div>\r\n\r\n        <div class=\"row mt-3 ml-2 mr-2\">\r\n            <div class=\"card-deck\" style=\"width: -webkit-fill-available; min-height:350px\">\r\n");
#nullable restore
#line 27 "C:\Users\Ali\Desktop\almost final\AspNetCore Demo App\EVS373.PakClassified.WebUI\Views\Home\Nav.cshtml"
                 foreach (var adv in ads)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"advsum col-xl-4 col-lg-4 col-md-6 col-sm-6 col-12 mb-3\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c1329e3305dd37a3249dbe04e78570f8d57f82726392", async() => {
                WriteLiteral(@"


                            <div id=""adcard"" class=""card"" style=""min-height:100%; box-shadow:10px 10px black"">
                                <img class=""card-img-top h-100"" style=""max-height: 20rem; object-fit:contain; border:1px groove; border-color:black""");
                BeginWriteAttribute("src", " src=\"", 1299, "\"", 1346, 2);
                WriteAttributeValue("", 1305, "data:image/jpg;base64,", 1305, 22, true);
#nullable restore
#line 35 "C:\Users\Ali\Desktop\almost final\AspNetCore Demo App\EVS373.PakClassified.WebUI\Views\Home\Nav.cshtml"
WriteAttributeValue("", 1327, adv.Images.First(), 1327, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" alt=\"~/images/others/adv_none.jpg\">\r\n                                <div class=\"card-body text-dark\">\r\n                                    <h4 class=\"card-title fas fa-comment-dollar\">");
#nullable restore
#line 37 "C:\Users\Ali\Desktop\almost final\AspNetCore Demo App\EVS373.PakClassified.WebUI\Views\Home\Nav.cshtml"
                                                                            Write(adv.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n                                    <p class=\"card-text text-truncate\">");
#nullable restore
#line 38 "C:\Users\Ali\Desktop\almost final\AspNetCore Demo App\EVS373.PakClassified.WebUI\Views\Home\Nav.cshtml"
                                                                  Write(adv.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                </div>\r\n                            </div>\r\n\r\n\r\n\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "C:\Users\Ali\Desktop\almost final\AspNetCore Demo App\EVS373.PakClassified.WebUI\Views\Home\Nav.cshtml"
                                                                                  WriteLiteral(adv.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "title", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 31 "C:\Users\Ali\Desktop\almost final\AspNetCore Demo App\EVS373.PakClassified.WebUI\Views\Home\Nav.cshtml"
AddHtmlAttributeValue("", 1022, adv.Name, 1022, 9, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 46 "C:\Users\Ali\Desktop\almost final\AspNetCore Demo App\EVS373.PakClassified.WebUI\Views\Home\Nav.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n\r\n    ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EVS373.PakClassified.WebUI.Models.AdvertizementModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
