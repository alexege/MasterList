#pragma checksum "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "045fc30264fba1b34eb541fc2edca2829d801db5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_WordPartial), @"mvc.1.0.view", @"/Views/Dashboard/WordPartial.cshtml")]
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
#line 1 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\_ViewImports.cshtml"
using masterList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\_ViewImports.cshtml"
using masterList.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"045fc30264fba1b34eb541fc2edca2829d801db5", @"/Views/Dashboard/WordPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3d47b156277cad5d1fbf763eaa491055f42a9cf", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_WordPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Word>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddNote", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("controller", new global::Microsoft.AspNetCore.Html.HtmlString("Dashboard"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div style=\"outline: 2px solid red\">\r\n");
            WriteLiteral("\r\n    <p>");
#nullable restore
#line 4 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
  Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n");
#nullable restore
#line 6 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
 foreach(var word in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"word\"");
            BeginWriteAttribute("id", " id=\"", 141, "\"", 158, 1);
#nullable restore
#line 8 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 146, word.WordId, 146, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" onmouseenter=""showInputField(this)"" onmouseleave=""hideInputField(this)"">
        <div class=""topLeft cornerPiece""></div>
        <div class=""topRight cornerPiece""></div>
        <div class=""bottomLeft cornerPiece""></div>
        <div class=""bottomRight cornerPiece""></div>

");
            WriteLiteral("        <button");
            BeginWriteAttribute("id", " id=\"", 597, "\"", 613, 1);
#nullable restore
#line 15 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 602, word.Title, 602, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"accordion accordStyle wordButton\">\r\n\r\n        <div class=\"contents title\" contenteditable=\"true\" onclick=\"event.stopPropagation();\">\r\n            ");
#nullable restore
#line 18 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
       Write(word.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"menu\">\r\n            <a onclick=\"editWordTitle(event, this); event.stopPropagation();\">\r\n                <i class=\"fas fa-edit\"></i>\r\n            </a>\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 984, "\"", 1016, 2);
            WriteAttributeValue("", 991, "/Word/Delete/", 991, 13, true);
#nullable restore
#line 25 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 1004, word.WordId, 1004, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fas fa-trash-alt\"></i>\r\n            </a>\r\n        </div>\r\n\r\n        </button>\r\n        <div class=\"panel\">\r\n\r\n");
#nullable restore
#line 33 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
             foreach(var note in @word.Notes)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""note"" onmouseenter=""showMenu(this)"" onmouseleave=""hideMenu(this)"">
                <div class=""contents"">
                    <div class=""menu"">
                        <i class=""fas fa-list-ul""></i>
                        <i class=""fas fa-outdent""></i>
                        <i class=""fas fa-indent""></i>
                        <i class=""fas fa-heading""></i>
");
#nullable restore
#line 42 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                         if(note.AlignPosition == 0){

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <i class=\"fas fa-align-left pressed\" onclick=\"updateAlignment(0, this)\"></i>\r\n");
#nullable restore
#line 44 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                        } else {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <i class=\"fas fa-align-left\" onclick=\"updateAlignment(0, this)\"></i>\r\n");
#nullable restore
#line 46 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                         if(note.AlignPosition == 1){

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <i class=\"fas fa-align-center pressed\" onclick=\"updateAlignment(1, this)\"></i>\r\n");
#nullable restore
#line 49 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                        } else {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <i class=\"fas fa-align-center\" onclick=\"updateAlignment(1, this)\"></i>\r\n");
#nullable restore
#line 51 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                         if(note.AlignPosition == 2){

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <i class=\"fas fa-align-right pressed\" onclick=\"updateAlignment(2, this)\"></i>\r\n");
#nullable restore
#line 54 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                        } else {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <i class=\"fas fa-align-right\" onclick=\"updateAlignment(2, this)\"></i>\r\n");
#nullable restore
#line 56 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i class=\"fas fa-trash\"></i>\r\n                    </div>\r\n\r\n                    <div class=\"replaceContent\">\r\n\r\n");
#nullable restore
#line 62 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                     if(note.Style == 1){

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h1");
            BeginWriteAttribute("class", " class=\"", 2789, "\"", 2855, 5);
            WriteAttributeValue("", 2797, "content", 2797, 7, true);
            WriteAttributeValue(" ", 2804, "align_", 2805, 7, true);
#nullable restore
#line 63 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 2811, note.AlignPosition, 2811, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 2830, "indent_", 2831, 8, true);
#nullable restore
#line 63 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 2838, note.indentLevel, 2838, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" contenteditable=\"true\"");
            BeginWriteAttribute("id", " id=\"", 2879, "\"", 2896, 1);
#nullable restore
#line 63 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 2884, note.NoteId, 2884, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 63 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                                                                                                                                   Write(note.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 64 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                    } else if(note.Style == 2){

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h2");
            BeginWriteAttribute("class", " class=\"", 2994, "\"", 3060, 5);
            WriteAttributeValue("", 3002, "content", 3002, 7, true);
            WriteAttributeValue(" ", 3009, "align_", 3010, 7, true);
#nullable restore
#line 65 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 3016, note.AlignPosition, 3016, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 3035, "indent_", 3036, 8, true);
#nullable restore
#line 65 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 3043, note.indentLevel, 3043, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" contenteditable=\"true\"");
            BeginWriteAttribute("id", " id=\"", 3084, "\"", 3101, 1);
#nullable restore
#line 65 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 3089, note.NoteId, 3089, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 65 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                                                                                                                                   Write(note.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 66 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                    } else if(note.Style == 3){

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h3");
            BeginWriteAttribute("class", " class=\"", 3199, "\"", 3265, 5);
            WriteAttributeValue("", 3207, "content", 3207, 7, true);
            WriteAttributeValue(" ", 3214, "align_", 3215, 7, true);
#nullable restore
#line 67 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 3221, note.AlignPosition, 3221, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 3240, "indent_", 3241, 8, true);
#nullable restore
#line 67 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 3248, note.indentLevel, 3248, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" contenteditable=\"true\"");
            BeginWriteAttribute("id", " id=\"", 3289, "\"", 3306, 1);
#nullable restore
#line 67 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 3294, note.NoteId, 3294, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 67 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                                                                                                                                   Write(note.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 68 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                    } else if(note.Style == 4){

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4");
            BeginWriteAttribute("class", " class=\"", 3404, "\"", 3470, 5);
            WriteAttributeValue("", 3412, "content", 3412, 7, true);
            WriteAttributeValue(" ", 3419, "align_", 3420, 7, true);
#nullable restore
#line 69 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 3426, note.AlignPosition, 3426, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 3445, "indent_", 3446, 8, true);
#nullable restore
#line 69 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 3453, note.indentLevel, 3453, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" contenteditable=\"true\"");
            BeginWriteAttribute("id", " id=\"", 3494, "\"", 3511, 1);
#nullable restore
#line 69 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 3499, note.NoteId, 3499, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 69 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                                                                                                                                   Write(note.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 70 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                    } else {

                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                         if(note.isBullet == true){

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li");
            BeginWriteAttribute("class", " class=\"", 3649, "\"", 3715, 5);
            WriteAttributeValue("", 3657, "content", 3657, 7, true);
            WriteAttributeValue(" ", 3664, "align_", 3665, 7, true);
#nullable restore
#line 73 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 3671, note.AlignPosition, 3671, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 3690, "indent_", 3691, 8, true);
#nullable restore
#line 73 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 3698, note.indentLevel, 3698, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" contenteditable=\"true\"");
            BeginWriteAttribute("id", " id=\"", 3739, "\"", 3756, 1);
#nullable restore
#line 73 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 3744, note.NoteId, 3744, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 73 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                                                                                                                                       Write(note.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 74 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                        } else {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div");
            BeginWriteAttribute("class", " class=\"", 3844, "\"", 3910, 5);
            WriteAttributeValue("", 3852, "content", 3852, 7, true);
            WriteAttributeValue(" ", 3859, "align_", 3860, 7, true);
#nullable restore
#line 75 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 3866, note.AlignPosition, 3866, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 3885, "indent_", 3886, 8, true);
#nullable restore
#line 75 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 3893, note.indentLevel, 3893, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" contenteditable=\"true\"");
            BeginWriteAttribute("id", " id=\"", 3934, "\"", 3951, 1);
#nullable restore
#line 75 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
WriteAttributeValue("", 3939, note.NoteId, 3939, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 75 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                                                                                                                                        Write(note.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 76 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                         

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                </div>\r\n");
#nullable restore
#line 83 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "045fc30264fba1b34eb541fc2edca2829d801db522946", async() => {
                WriteLiteral("\r\n                <input class=\"form-control addNoteInput\" type=\"text\" name=\"Content\" id=\"Content\" placeholder=\"Enter Note Content here\">\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-WordId", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 85 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
                                             WriteLiteral(word.WordId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["WordId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-WordId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["WordId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n        </div>\r\n\r\n        </div>\r\n");
#nullable restore
#line 92 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\WordPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Word>> Html { get; private set; }
    }
}
#pragma warning restore 1591
