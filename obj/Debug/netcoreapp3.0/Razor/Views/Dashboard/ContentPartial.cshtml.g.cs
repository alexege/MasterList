#pragma checksum "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\ContentPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c3f818d6d7c355f06c1d48be51b7bbfb6402d0e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_ContentPartial), @"mvc.1.0.view", @"/Views/Dashboard/ContentPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c3f818d6d7c355f06c1d48be51b7bbfb6402d0e", @"/Views/Dashboard/ContentPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3d47b156277cad5d1fbf763eaa491055f42a9cf", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_ContentPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Note>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\ContentPartial.cshtml"
 if(@Model.isBullet == true){

#line default
#line hidden
#nullable disable
            WriteLiteral("<li");
            BeginWriteAttribute("class", " class=\"", 49, "\"", 90, 3);
            WriteAttributeValue("", 57, "content", 57, 7, true);
            WriteAttributeValue(" ", 64, "indent_", 65, 8, true);
#nullable restore
#line 4 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\ContentPartial.cshtml"
WriteAttributeValue("", 72, Model.indentLevel, 72, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" contenteditable=\"true\"");
            BeginWriteAttribute("id", " id=\"", 114, "\"", 132, 1);
#nullable restore
#line 4 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\ContentPartial.cshtml"
WriteAttributeValue("", 119, Model.NoteId, 119, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 4 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\ContentPartial.cshtml"
                                                                                   Write(Model.indentLevel);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 4 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\ContentPartial.cshtml"
                                                                                                      Write(Model.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 5 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\ContentPartial.cshtml"
} else {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div");
            BeginWriteAttribute("class", " class=\"", 188, "\"", 229, 3);
            WriteAttributeValue("", 196, "content", 196, 7, true);
            WriteAttributeValue(" ", 203, "indent_", 204, 8, true);
#nullable restore
#line 6 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\ContentPartial.cshtml"
WriteAttributeValue("", 211, Model.indentLevel, 211, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" contenteditable=\"true\"");
            BeginWriteAttribute("id", " id=\"", 253, "\"", 271, 1);
#nullable restore
#line 6 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\ContentPartial.cshtml"
WriteAttributeValue("", 258, Model.NoteId, 258, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 6 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\ContentPartial.cshtml"
                                                                                    Write(Model.indentLevel);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 6 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\ContentPartial.cshtml"
                                                                                                       Write(Model.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 7 "C:\Users\alexe\Documents\CodingDojo\Projects\masterList\Views\Dashboard\ContentPartial.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Note> Html { get; private set; }
    }
}
#pragma warning restore 1591
