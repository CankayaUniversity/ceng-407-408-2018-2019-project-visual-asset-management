#pragma checksum "C:\Users\MTR\Desktop\Final Version\Final_Version\ASPCoreSample\Views\Brand\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "29fb5ed6b0e3136bb2daa0c71cd6c1dd1b9d677f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Brand_Index), @"mvc.1.0.view", @"/Views/Brand/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Brand/Index.cshtml", typeof(AspNetCore.Views_Brand_Index))]
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
#line 1 "C:\Users\MTR\Desktop\Final Version\Final_Version\ASPCoreSample\Views\_ViewImports.cshtml"
using ASPCoreSample;

#line default
#line hidden
#line 2 "C:\Users\MTR\Desktop\Final Version\Final_Version\ASPCoreSample\Views\_ViewImports.cshtml"
using ASPCoreSample.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29fb5ed6b0e3136bb2daa0c71cd6c1dd1b9d677f", @"/Views/Brand/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f845085478c17c21ccf585a30cbb75e9ac1be715", @"/Views/_ViewImports.cshtml")]
    public class Views_Brand_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ASPCoreSample.Models.BrandModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'Silmek istediğinizden emin misiniz?\');"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\MTR\Desktop\Final Version\Final_Version\ASPCoreSample\Views\Brand\Index.cshtml"
  
    ViewData["Title"] = "Marka Listesi";

#line default
#line hidden
            BeginContext(104, 28, true);
            WriteLiteral("\r\n<h2>Marka Listesi</h2>\r\n\r\n");
            EndContext();
#line 9 "C:\Users\MTR\Desktop\Final Version\Final_Version\ASPCoreSample\Views\Brand\Index.cshtml"
 if (@ViewData["department"] != null && @ViewData["department"].Equals("Admin"))
{

#line default
#line hidden
            BeginContext(217, 17, true);
            WriteLiteral("    <p>\r\n        ");
            EndContext();
            BeginContext(234, 45, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f053498fb3d46278662ca96202943af", async() => {
                BeginContext(257, 18, true);
                WriteLiteral("Yeni Marka Oluştur");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(279, 12, true);
            WriteLiteral("\r\n    </p>\r\n");
            EndContext();
#line 14 "C:\Users\MTR\Desktop\Final Version\Final_Version\ASPCoreSample\Views\Brand\Index.cshtml"
}

#line default
#line hidden
            BeginContext(294, 104, true);
            WriteLiteral("<table class=\"table\">\r\n    <tr>\r\n        <th>\r\n            Marka Adı\r\n        </th>\r\n        <th></th>\r\n");
            EndContext();
#line 21 "C:\Users\MTR\Desktop\Final Version\Final_Version\ASPCoreSample\Views\Brand\Index.cshtml"
         if (@ViewData["department"] != null && @ViewData["department"].Equals("Admin"))
        {

#line default
#line hidden
            BeginContext(499, 23, true);
            WriteLiteral("            <th></th>\r\n");
            EndContext();
#line 24 "C:\Users\MTR\Desktop\Final Version\Final_Version\ASPCoreSample\Views\Brand\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(533, 13, true);
            WriteLiteral("    </tr>\r\n\r\n");
            EndContext();
#line 27 "C:\Users\MTR\Desktop\Final Version\Final_Version\ASPCoreSample\Views\Brand\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(587, 36, true);
            WriteLiteral("    <tr>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(624, 39, false);
#line 31 "C:\Users\MTR\Desktop\Final Version\Final_Version\ASPCoreSample\Views\Brand\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.name));

#line default
#line hidden
            EndContext();
            BeginContext(663, 17, true);
            WriteLiteral("\r\n        </td>\r\n");
            EndContext();
#line 33 "C:\Users\MTR\Desktop\Final Version\Final_Version\ASPCoreSample\Views\Brand\Index.cshtml"
         if (@ViewData["department"] != null && @ViewData["department"].Equals("Admin"))
        {

#line default
#line hidden
            BeginContext(781, 34, true);
            WriteLiteral("            <td>\r\n                ");
            EndContext();
            BeginContext(815, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "de3bcefe7e3f4c6fb8c285d3397f33c6", async() => {
                BeginContext(860, 7, true);
                WriteLiteral("Düzenle");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 36 "C:\Users\MTR\Desktop\Final Version\Final_Version\ASPCoreSample\Views\Brand\Index.cshtml"
                                       WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(871, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(891, 119, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c81e7e0677a4809afb823ca6cec6b7f", async() => {
                BeginContext(1003, 3, true);
                WriteLiteral("Sil");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 37 "C:\Users\MTR\Desktop\Final Version\Final_Version\ASPCoreSample\Views\Brand\Index.cshtml"
                                         WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1010, 21, true);
            WriteLiteral("\r\n            </td>\r\n");
            EndContext();
#line 39 "C:\Users\MTR\Desktop\Final Version\Final_Version\ASPCoreSample\Views\Brand\Index.cshtml"

        }

#line default
#line hidden
            BeginContext(1044, 11, true);
            WriteLiteral("    </tr>\r\n");
            EndContext();
#line 42 "C:\Users\MTR\Desktop\Final Version\Final_Version\ASPCoreSample\Views\Brand\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1062, 10, true);
            WriteLiteral("</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ASPCoreSample.Models.BrandModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591