#pragma checksum "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Shared/_CommentCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1330fa6d7701ba7bce42148d7feb4955074ce70"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CommentCard), @"mvc.1.0.view", @"/Views/Shared/_CommentCard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1330fa6d7701ba7bce42148d7feb4955074ce70", @"/Views/Shared/_CommentCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5179110afca779530499299f559d2ff1aee6cc83", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CommentCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Comment>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n    <div>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f1330fa6d7701ba7bce42148d7feb4955074ce705025", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 4 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Shared/_CommentCard.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CommentId);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        <hr style=\"height:3px;border:none;color:#333;background-color:#333;\" />\n        <div class=\"row ml-3\">\n            <div class=\"col-2\">\n                <div class=\"row\" style=\"margin-bottom:10px\">\n                    <div");
            BeginWriteAttribute("style", " style=\"", 305, "\"", 367, 4);
            WriteAttributeValue("", 313, "background-image:", 313, 17, true);
            WriteAttributeValue(" ", 330, "url(\'/img/", 331, 11, true);
#nullable restore
#line 9 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Shared/_CommentCard.cshtml"
WriteAttributeValue("", 341, Model.AuthorProfilePic, 341, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 364, "\');", 364, 3, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"blog-author-image\"></div>\n                </div>\n                <div class=\"row\">\n                    <h6><a");
            BeginWriteAttribute("href", " href=\"", 485, "\"", 522, 2);
            WriteAttributeValue("", 492, "/social/profile2/", 492, 17, true);
#nullable restore
#line 12 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Shared/_CommentCard.cshtml"
WriteAttributeValue("", 509, Model.Author, 509, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 12 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Shared/_CommentCard.cshtml"
                                                            Write(Model.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h6>\n                    <div class=\"meta\">");
#nullable restore
#line 13 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Shared/_CommentCard.cshtml"
                                 Write(Model.DateOfCreation.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                    <div class=\"meta\">");
#nullable restore
#line 14 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Shared/_CommentCard.cshtml"
                                 Write(Model.DateOfCreation.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                </div>\n\n            </div>\n            <div class=\"col-10\">\n                <h4 class=\"card-subtitle mb-2 mt-3 text-muted\">");
#nullable restore
#line 19 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Shared/_CommentCard.cshtml"
                                                          Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n                <p>");
#nullable restore
#line 20 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Shared/_CommentCard.cshtml"
              Write(Model.Body);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 21 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Shared/_CommentCard.cshtml"
                 if (User.Identity.Name == Model.Author || User.IsInRole("Admin"))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div style=\"float: right;\">\n                        <button type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1105, "\"", 1176, 8);
            WriteAttributeValue("", 1115, "findCommentId(", 1115, 14, true);
#nullable restore
#line 24 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Shared/_CommentCard.cshtml"
WriteAttributeValue("", 1129, Model.CommentId, 1129, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1145, ",", 1145, 1, true);
            WriteAttributeValue(" ", 1146, "\'", 1147, 2, true);
#nullable restore
#line 24 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Shared/_CommentCard.cshtml"
WriteAttributeValue("", 1148, Model.Title, 1148, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1160, "\',\'", 1160, 3, true);
#nullable restore
#line 24 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Shared/_CommentCard.cshtml"
WriteAttributeValue("", 1163, Model.Body, 1163, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1174, "\')", 1174, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm\" data-toggle=\"modal\" data-target=\"#editCommentModal\">\n                            Edit\n                        </button>\n\n                        <a type=\"button\"");
            BeginWriteAttribute("href", " href=\"", 1370, "\"", 1415, 2);
            WriteAttributeValue("", 1377, "/social/commentdelete/", 1377, 22, true);
#nullable restore
#line 28 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Shared/_CommentCard.cshtml"
WriteAttributeValue("", 1399, Model.CommentId, 1399, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-sm\">\n                            Delete\n                        </a>\n                    </div>\n");
#nullable restore
#line 32 "/Users/fatihyildiz/Desktop/final/BeenThere Fatih Yildiz Summer Internship 2020/BeenThere Solution/BeenThere1.WebUI/Views/Shared/_CommentCard.cshtml"
                 }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\n        </div>\n    </div>\n        \n            \n\n\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Comment> Html { get; private set; }
    }
}
#pragma warning restore 1591
