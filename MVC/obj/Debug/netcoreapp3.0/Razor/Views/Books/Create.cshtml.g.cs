#pragma checksum "C:\Users\Виктория\Source\Repos\KPZ_labs\MVC\Views\Books\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e0e13cb604e265feff705b62a76eac00938659a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Books_Create), @"mvc.1.0.view", @"/Views/Books/Create.cshtml")]
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
#line 1 "C:\Users\Виктория\Source\Repos\KPZ_labs\MVC\Views\_ViewImports.cshtml"
using MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Виктория\Source\Repos\KPZ_labs\MVC\Views\_ViewImports.cshtml"
using MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e0e13cb604e265feff705b62a76eac00938659a", @"/Views/Books/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d7a8f56340c239c091cff637a00cc2fdf252300", @"/Views/_ViewImports.cshtml")]
    public class Views_Books_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MVC.Models.BookModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("Create"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Виктория\Source\Repos\KPZ_labs\MVC\Views\Books\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Виктория\Source\Repos\KPZ_labs\MVC\Views\Books\Create.cshtml"
   
    List<TagModel> tags = new List<TagModel>();


#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8e0e13cb604e265feff705b62a76eac00938659a4271", async() => {
                WriteLiteral(@"
        <table>
            <tr>
                <td>
                    Name:
                </td>
                <td>
                    <input type=""text"" name=""Name"" />
                </td>
            </tr>
            <tr>
                <td>
                    Year:
                </td>
                <td>
                    <input type=""number"" name=""Year"" />
                </td>
            </tr>
            <tr>
                <td>
                    Amount:
                </td>
                <td>
                    <input type=""number"" name=""Amount"" />
                </td>
            </tr>
            <tr>
                <td>
                    Tags:
                </td>
                <td>
");
#nullable restore
#line 43 "C:\Users\Виктория\Source\Repos\KPZ_labs\MVC\Views\Books\Create.cshtml"
                     for (int i = 0; i < Model.Tags.Count; i++)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\Виктория\Source\Repos\KPZ_labs\MVC\Views\Books\Create.cshtml"
                   Write(Html.HiddenFor(m => Model.Tags[i].Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\Виктория\Source\Repos\KPZ_labs\MVC\Views\Books\Create.cshtml"
                   Write(Html.HiddenFor(m => Model.Tags[i].Name));

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\Виктория\Source\Repos\KPZ_labs\MVC\Views\Books\Create.cshtml"
                   Write(Html.CheckBoxFor(x => Model.Tags[i].Checked));

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <span>");
#nullable restore
#line 48 "C:\Users\Виктория\Source\Repos\KPZ_labs\MVC\Views\Books\Create.cshtml"
                         Write(Model.Tags[i].Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span><br />\r\n");
#nullable restore
#line 49 "C:\Users\Виктория\Source\Repos\KPZ_labs\MVC\Views\Books\Create.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </td>\r\n            </tr>\r\n            <tr>\r\n                <td rowspan=\"2\">\r\n                    <button type=\"submit\">Create</button>\r\n                </td>\r\n            </tr>\r\n        </table>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MVC.Models.BookModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
