#pragma checksum "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f9ce839f088add3462cfb9073c826633d9edb32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Social_ExperienceList), @"mvc.1.0.view", @"/Views/Social/ExperienceList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f9ce839f088add3462cfb9073c826633d9edb32", @"/Views/Social/ExperienceList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5179110afca779530499299f559d2ff1aee6cc83", @"/Views/_ViewImports.cshtml")]
    public class Views_Social_ExperienceList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ExperienceListModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "searchKeyword", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Places, names, authors..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString("selected"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("ExperienceList"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("experienceFilter"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("form", new global::Microsoft.AspNetCore.Html.HtmlString("experienceFilter"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            DefineSection("Css", async() => {
                WriteLiteral("\n    \n    <style>\n        .mul-select {\n            width: 100%;\n        }\n    </style>\n");
            }
            );
            WriteLiteral("\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
   

    <script>
        $(document).ready(function () {
            $("".mul-select"").select2({
                placeholder: "" Select categories"",
                tags: true,
                tokenSeparators: ['/', ',', ';', "" ""]
            });
        })
    </script>

    <script>
        jQuery(document).ready(function($){
            $('select').find('option[value=");
#nullable restore
#line 27 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
                                      Write(Model.ChosenCountryCode);

#line default
#line hidden
#nullable disable
                WriteLiteral("]\').attr(\'selected\',\'selected\');\n        });\n\n    </script>\n");
            }
            );
            WriteLiteral(@"

<section class=""hero-wrap hero-wrap-2 js-fullheight"" style=""background-image: url('/img/images/bg_3.jpg');"" data-stellar-background-ratio=""0.5"">
    <div class=""overlay""></div>
    <div class=""container"">
        <div class=""row no-gutters slider-text js-fullheight align-items-end justify-content-center"">
            <div class=""col-md-9 ftco-animate pb-5 mb-5 text-center"">
                <h1 class=""mb-3 bread"">Places to Travel</h1>
                <p class=""breadcrumbs""><span class=""mr-2""><a href=""index.html"">Home <i class=""ion-ios-arrow-forward""></i></a></span> <span>Read <i class=""ion-ios-arrow-forward""></i></span></p>
            </div>
        </div>
    </div>
</section>

<section class=""ftco-section ftco-no-pb ftco-no-pt"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""search-wrap-1 ftco-animate p-4"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6f9ce839f088add3462cfb9073c826633d9edb3211103", async() => {
                WriteLiteral(@"
                        <div class=""row"">
                            <div class=""col-lg align-items-end"">
                                <div class=""form-group"">
                                    <div class=""form-field"">
                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6f9ce839f088add3462cfb9073c826633d9edb3211631", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 56 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.SearchKeyword);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    </div>
                                </div>
                            </div>
                            <div class=""col-lg align-items-end"">
                                <div class=""form-group"">
                                    <div class=""form-field"">
                                        <div class=""select-wrap"">
                                            <select name=""countryCode"" id=""countryCode"" class=""form-control"">
                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6f9ce839f088add3462cfb9073c826633d9edb3214301", async() => {
                    WriteLiteral("\n                                                    Country Choice\n                                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                                                ");
#nullable restore
#line 68 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
                                           Write(await Html.PartialAsync("_CountrySelectList"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
                                            </select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-lg align-items-end"">
                                <div class=""form-group"">
                                    <div class=""form-field"">

                                        <div class=""form-group"">
                                            <select name=""filterCategoryIds"" class=""mul-select"" multiple=""true"">
");
#nullable restore
#line 80 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
                                                 foreach (var category in Model.AllCategories)
                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    <");
                WriteLiteral("option name=\"filterCategoryIds[]\"");
                BeginWriteAttribute("value", " value=\"", 3575, "\"", 3603, 1);
#nullable restore
#line 82 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
WriteAttributeValue("", 3583, category.CategoryId, 3583, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" ");
#nullable restore
#line 82 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
                                                                                                                 Write(Model.FilterCategoryIds.Any(i => i == category.CategoryId) ? "selected" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(">");
#nullable restore
#line 82 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
                                                                                                                                                                                                Write(category.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</");
                WriteLiteral("option>\n");
#nullable restore
#line 83 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                            </select>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class=""col-lg align-self-end"">
                                <div class=""form-group"">
                                    <div class=""form-field"">
                                        <input type=""submit"" value=""Search"" class=""form-control btn btn-primary"">
                                    </div>
                                </div>
                            </div>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
        </div>
    </div>
</section>

<section class=""ftco-section mb-5"" style=""padding:2em;"">
    <div class=""container"">
        <div class=""row mb-3"">
            <div class=""col text-center"">
                <div class=""block-27"">
                    <ul>
");
#nullable restore
#line 111 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
                         for (int i = 0; i < Model.PageInfo.TotalPages(); i++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li");
            BeginWriteAttribute("class", " class=\"", 4889, "\"", 4958, 2);
            WriteAttributeValue("", 4897, "page-item", 4897, 9, true);
#nullable restore
#line 113 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
WriteAttributeValue(" ", 4906, Model.PageInfo.CurrentPage== i+1? "active" : "" , 4907, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6f9ce839f088add3462cfb9073c826633d9edb3222367", async() => {
                WriteLiteral("\n                                    ");
#nullable restore
#line 115 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
                                Write(i+1);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 114 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
                                                                                                     WriteLiteral(i+1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                            </li>\n");
#nullable restore
#line 118 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </ul>\n                </div>\n            </div>\n        </div>\n\n        <div class=\"row mb-5\">\n");
#nullable restore
#line 126 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
             foreach (var experience in Model.Experiences)
            {

                

#line default
#line hidden
#nullable disable
#nullable restore
#line 129 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
           Write(await Html.PartialAsync("_ExperienceCard3", experience));

#line default
#line hidden
#nullable disable
#nullable restore
#line 129 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Social/ExperienceList.cshtml"
                                                                        ;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n\n    </div>\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ExperienceListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
