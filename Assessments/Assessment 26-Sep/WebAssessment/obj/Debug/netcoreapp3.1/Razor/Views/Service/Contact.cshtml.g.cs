#pragma checksum "C:\training\daily-training\Assessments\Assessment 26-Sep\WebAssessment\Views\Service\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0cd6b22e90ed34ce50ae57774ea03d6807693b8d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Service_Contact), @"mvc.1.0.view", @"/Views/Service/Contact.cshtml")]
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
#line 1 "C:\training\daily-training\Assessments\Assessment 26-Sep\WebAssessment\Views\_ViewImports.cshtml"
using WebAssessment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\training\daily-training\Assessments\Assessment 26-Sep\WebAssessment\Views\_ViewImports.cshtml"
using WebAssessment.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0cd6b22e90ed34ce50ae57774ea03d6807693b8d", @"/Views/Service/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"349c9c0466045e3779de83c9b0f8dfc990b6fc61", @"/Views/_ViewImports.cshtml")]
    public class Views_Service_Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
            WriteLiteral("<h3 class=\"mt-5 mb-3\">Contact Us</h3>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0cd6b22e90ed34ce50ae57774ea03d6807693b8d3336", async() => {
                WriteLiteral(@"
    <div class=""form-group row"">
        <label for=""inputEmail"" class=""col-sm-2 col-form-label"">Email</label>
        <div class=""col-sm-10"">
            <input type=""email"" class=""form-control inp-fields"" id=""inputEmail"" placeholder=""Email"">
        </div>
    </div>
    <div class=""form-group row"">
        <label for=""inputName"" class=""col-sm-2 col-form-label"">Name</label>
        <div class=""col-sm-10"">
            <input type=""text"" class=""form-control inp-fields"" id=""inputName"" placeholder=""Name"">
        </div>
    </div>
    <div class=""form-group row"">
        <label for=""inputMobile"" class=""col-sm-2 col-form-label"">Mobile</label>
        <div class=""col-sm-10"">
            <input type=""tel"" class=""form-control inp-fields"" id=""inputMobile"" placeholder=""Mobile"">
        </div>
    </div>
    <div class=""form-group row"">
        <label for=""inputFeedback"" class=""col-sm-2 col-form-label"">Feedback</label>
        <div class=""col-sm-10"">
            <textarea class=""form-control inp");
                WriteLiteral(@"-fields"" id=""inputFeedback"" rows=""3"" placeholder=""Your Feedback...""></textarea>
        </div>
    </div>
    <div class=""form-group row"">
        <div class=""col-sm-10"">
            <button type=""submit"" class=""btn btn-info contact-btn"">Submit</button>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
