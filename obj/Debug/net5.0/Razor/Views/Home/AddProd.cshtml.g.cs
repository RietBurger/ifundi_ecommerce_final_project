#pragma checksum "C:\Users\Riette\Documents\mvc_ecommerce_final_project_ifundi\Views\Home\AddProd.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "555c4b365f3662a5f484b6f687073f57915b0764"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AddProd), @"mvc.1.0.view", @"/Views/Home/AddProd.cshtml")]
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
#line 1 "C:\Users\Riette\Documents\mvc_ecommerce_final_project_ifundi\Views\_ViewImports.cshtml"
using mvc_ecommerce_tutorial;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Riette\Documents\mvc_ecommerce_final_project_ifundi\Views\_ViewImports.cshtml"
using mvc_ecommerce_tutorial.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"555c4b365f3662a5f484b6f687073f57915b0764", @"/Views/Home/AddProd.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f563f30c9a0f1c87a0c5ea4a3da871c9bf15c0b6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_AddProd : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("AddProd"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "C:\Users\Riette\Documents\mvc_ecommerce_final_project_ifundi\Views\Home\AddProd.cshtml"
  
    ViewData["Title"] = "Add Products";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<div class=\"jumbotron\">  \r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "555c4b365f3662a5f484b6f687073f57915b07644237", async() => {
                WriteLiteral("\r\n    <table>\r\n        <tr>\r\n            <td>Product Name: </td>\r\n            <td><input type=\"text\"");
                BeginWriteAttribute("required", " required=\"", 279, "\"", 290, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"Name\" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td>Product Description: </td>\r\n            <td><input type=\"text\" name=\"Desc\" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td>Price: </td>\r\n            <td><input type=\"text\"");
                BeginWriteAttribute("required", " required=\"", 535, "\"", 546, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"Price\" /></td>\r\n            <td>");
#nullable restore
#line (22,18)-(22,29) 6 "C:\Users\Riette\Documents\mvc_ecommerce_final_project_ifundi\Views\Home\AddProd.cshtml"
Write(ViewBag.err);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>Quantity Available: </td>\r\n            <td><input type=\"text\"");
                BeginWriteAttribute("required", " required=\"", 711, "\"", 722, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"Qty\" /></td>\r\n            <td>");
#nullable restore
#line (27,18)-(27,29) 6 "C:\Users\Riette\Documents\mvc_ecommerce_final_project_ifundi\Views\Home\AddProd.cshtml"
Write(ViewBag.err);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <label for=\"Product Image\">Product Image</label>\r\n            <input type=\"file\" class=\"form-control-file\" name=\"ImgSource\" id=\"file\">\r\n        </tr>\r\n");
                WriteLiteral("        <tr>\r\n            <td>Category ID: </td>\r\n            <td><input type=\"text\"");
                BeginWriteAttribute("required", " required=\"", 1105, "\"", 1116, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"CatID\" /></td>\r\n            <td>");
#nullable restore
#line (37,18)-(37,29) 6 "C:\Users\Riette\Documents\mvc_ecommerce_final_project_ifundi\Views\Home\AddProd.cshtml"
Write(ViewBag.err);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td colspan=\"2\"><input type=\"submit\" value=\"Submit Form\"/></td>\r\n        </tr>\r\n    </table>\r\n    \r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>  \r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
