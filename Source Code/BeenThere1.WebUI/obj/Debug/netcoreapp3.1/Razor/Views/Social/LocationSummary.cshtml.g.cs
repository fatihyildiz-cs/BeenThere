#pragma checksum "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f67bdee571904e6c5fa0eef1ff121006ab7a9da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Social_LocationSummary), @"mvc.1.0.view", @"/Views/Social/LocationSummary.cshtml")]
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
#line 1 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/_ViewImports.cshtml"
using BeenThere1.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/_ViewImports.cshtml"
using BeenThere1.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/_ViewImports.cshtml"
using BeenThere1.WebUI.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/_ViewImports.cshtml"
using BeenThere1.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/_ViewImports.cshtml"
using Bia.Countries.Iso3166;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/_ViewImports.cshtml"
using BeenThere1.WebUI.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f67bdee571904e6c5fa0eef1ff121006ab7a9da", @"/Views/Social/LocationSummary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5179110afca779530499299f559d2ff1aee6cc83", @"/Views/_ViewImports.cshtml")]
    public class Views_Social_LocationSummary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LocationSummaryModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/locationSummary.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("image-popup"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("position: absolute; top: 50px; right:50px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f67bdee571904e6c5fa0eef1ff121006ab7a9da6036", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 5 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    <script type=\"text/javascript\">\n        var currentPlace = { lat: ");
#nullable restore
#line 7 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
                             Write(Model.Location.Latitude);

#line default
#line hidden
#nullable disable
                WriteLiteral(", lng: ");
#nullable restore
#line 7 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
                                                            Write(Model.Location.Longitude);

#line default
#line hidden
#nullable disable
                WriteLiteral(" };\n    </script>\n    <script defer src=\"https://maps.googleapis.com/maps/api/js?key=AIzaSyCE1Y1CP375rP8PlxlKBoumKtsGkzk1KWE&callback=initMap&libraries=places\"></script>\n");
            }
            );
            WriteLiteral(@"<style type=""text/css"">
    #map {
        height: 800px;
        width: 100%;
    }

    body {
        background-color: #232931;
    }
</style>

<section class=""ftco-section ftco-no-pb testimony-section"" style="" margin-bottom:10%"">
    <div class=""overlay""></div>
    <div class=""container"">
        <div class=""row justify-content-center pb-3"">
            <div class=""col-md-7 text-center heading-section heading-section-white ftco-animate"" style=""width:50%""> 
                <h2>What Do Travelers Say About ");
#nullable restore
#line 27 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
                                           Write(Model.Location.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("?</h2>\n            </div>\n        </div>\n        <div class=\"row mb-3 pb-3\">\n            <div class=\"col-md-7 col-lg-12\">\n                <h4 class=\"mr-3\" style=\"color:white; display:inline\">Categories:</h4>\n");
#nullable restore
#line 33 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
                 foreach (var category in Model.CategoriesOfThisLocation)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a class=\"btn btn-sm btn-light\" style=\" display:inline;\"");
            BeginWriteAttribute("href", " href=\"", 1334, "\"", 1378, 2);
            WriteAttributeValue("", 1341, "/social/categorysummary/", 1341, 24, true);
#nullable restore
#line 35 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
WriteAttributeValue("", 1365, category.Url, 1365, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 35 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
                                                                                                                     Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n");
#nullable restore
#line 36 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n        <div class=\"row ftco-animate\">\n            <div class=\"col-md-12 testimonial\">\n                <div class=\"carousel-testimony owl-carousel ftco-owl\">\n\n");
#nullable restore
#line 44 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
                     foreach (var experience in Model.ExperiencesOfThisLocation)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"item\">\n                            <div class=\"testimony-wrap\"");
            BeginWriteAttribute("style", " style=\"", 1812, "\"", 1869, 4);
            WriteAttributeValue("", 1820, "background-image:", 1820, 17, true);
            WriteAttributeValue(" ", 1837, "url(/img/", 1838, 10, true);
#nullable restore
#line 47 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
WriteAttributeValue("", 1847, experience.ImageUrl, 1847, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1867, ");", 1867, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\n                                <div class=\"overlay\"></div>\n                                <div class=\"text p-3\" style=\"border-radius:5px;background-color: white;\">\n                                    <h1 class=\"mb-4\">");
#nullable restore
#line 50 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
                                                Write(experience.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n                                    <h3>Author: ");
#nullable restore
#line 51 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
                                           Write(experience.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n                                    <span class=\"position\">\n");
#nullable restore
#line 53 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
                                         foreach (var category in experience.ExperienceCategoryJunctions.Select(e => e.Category))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <a class=\"btn btn-sm btn-dark\" style=\"display:inline\"");
            BeginWriteAttribute("href", " href=\"", 2514, "\"", 2558, 2);
            WriteAttributeValue("", 2521, "/social/categorysummary/", 2521, 24, true);
#nullable restore
#line 55 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
WriteAttributeValue("", 2545, category.Url, 2545, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 55 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
                                                                                                                                          Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n");
#nullable restore
#line 56 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </span>\n                                </div>\n                                <a");
            BeginWriteAttribute("href", " href=\"", 2738, "\"", 2795, 2);
            WriteAttributeValue("", 2745, "/social/experiencedetails/", 2745, 26, true);
#nullable restore
#line 59 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
WriteAttributeValue("", 2771, experience.ExperienceId, 2771, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-dark btn-lg\" style=\"position: absolute; bottom: 50px; width:200px; \">Read More</a>\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f67bdee571904e6c5fa0eef1ff121006ab7a9da16583", async() => {
                WriteLiteral("\n                                    <span class=\"icon-expand\"></span>\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2936, "~/img/", 2936, 6, true);
#nullable restore
#line 60 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
AddHtmlAttributeValue("", 2942, experience.ImageUrl, 2942, 20, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                            </div>\n\n                        </div>\n");
#nullable restore
#line 66 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/LocationSummary.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n            </div>\n        </div>\n    </div>\n</section>\n\n");
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LocationSummaryModel> Html { get; private set; }
    }
}
#pragma warning restore 1591