#pragma checksum "D:\TestCode\API\API-CRUD-MCC50\CORS\Views\Home\Person.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3841d56324cdc0193d68a70decfed7d4b7d11b8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Person), @"mvc.1.0.view", @"/Views/Home/Person.cshtml")]
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
#line 1 "D:\TestCode\API\API-CRUD-MCC50\CORS\Views\_ViewImports.cshtml"
using CORS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\TestCode\API\API-CRUD-MCC50\CORS\Views\_ViewImports.cshtml"
using CORS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3841d56324cdc0193d68a70decfed7d4b7d11b8a", @"/Views/Home/Person.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06bf70185e88e7cac10730ef064b15e7c0e8f839", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Person : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formPersonReg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("javascript:Insert()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formPersonUpd"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("javascript:Update()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/person.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\TestCode\API\API-CRUD-MCC50\CORS\Views\Home\Person.cshtml"
  
    Layout = "~/Views/Shared/AdminLTE/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container container-fluid"">
    <h1>PERSON</h1>
    <button type=""button"" class=""btn btn-primary mb-2 mt-2"" data-toggle=""modal"" data-target=""#modalRegister"">Register</button>
    <table id=""tablePerson"" class=""table table-responsive table-hover table-bordered"">
        <thead>
            <tr>
                <th>No.</th>
                <th>NIK</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Phone</th>
                <th>Degree</th>
                <th>GPA</th>
                <th>University ID</th>
                <th>Action</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody id=""bodyPerson"">
        </tbody>
    </table>
</div>



");
            WriteLiteral(@"<div class=""modal fade"" id=""modalRegister"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Register</h5>
                <button type=""button"" class=""btn-close"" data-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"" id=""bodyMRegister"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3841d56324cdc0193d68a70decfed7d4b7d11b8a6706", async() => {
                WriteLiteral(@"
                    <div class=""row"">
                        <div class=""col-6 my-1"">
                            <label for=""InputFirstName"" class=""col-form-label"">First Name</label>
                            <input type=""text"" class=""form-control"" id=""inputFirstName"" aria-describedby=""firstnameHelp"" required>
                            <div id=""firstnameHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""InputLastName"" class=""col-form-label"">Last Name</label>
                            <input type=""text"" class=""form-control"" id=""inputLastName"" aria-describedby=""lastnameHelp"" required>
                            <div id=""lastnameHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""InputPhone"" class=""col-form-label"">Phone</label>
                            <input type=""text"" class=""form-control");
                WriteLiteral(@""" id=""inputPhone"" aria-describedby=""phoneHelp"" required>
                            <div id=""phoneHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""InputBirthdate"" class=""col-form-label"">Birth Date</label>
                            <input type=""date"" class=""form-control"" id=""inputBirthdate"" aria-describedby=""BirthdateHelp"" required>
                            <div id=""BirthdateHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""InputSalary"" class=""col-form-label"">Salary</label>
                            <input type=""text"" class=""form-control"" id=""inputSalary"" aria-describedby=""salaryHelp"" required>
                            <div id=""salaryHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""Inpu");
                WriteLiteral(@"tEmail"" class=""col-form-label"">Email</label>
                            <input type=""email"" class=""form-control"" id=""inputEmail"" aria-describedby=""emailHelp"" required>
                            <div id=""emailHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""InputPassword"" class=""col-form-label"">Password</label>
                            <input type=""password"" class=""form-control"" id=""inputPassword"" aria-describedby=""passwordHelp"" minlength=""6"">
                            <div id=""passwordHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""InputDegree"" class=""col-form-label"">Degree</label>
                            <input type=""text"" class=""form-control"" id=""inputDegree"" aria-describedby=""degreeHelp"" required>
                            <div id=""degreeHelp"" class=""form-text""></div>
          ");
                WriteLiteral(@"              </div>
                        <div class=""col-6 my-1"">
                            <label for=""InputGpa"" class=""col-form-label"">IPK</label>
                            <input type=""number"" class=""form-control"" id=""inputGpa"" aria-describedby=""GpaHelp"" required>
                            <div id=""GpaHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""InputUniversityId"" class=""col-form-label"">University</label>
                            <input type=""text"" class=""form-control"" id=""inputUniversityId"" aria-describedby=""universityHelp"" required>
                            <div id=""universityHelp"" class=""form-text""></div>
                        </div>
                    </div>
                    <div class=""modal-footer"">
                        <button id=""registerBtn"" type=""submit"" class=""btn btn-primary"">Register</button>
                        <button type=""button"" class=""btn bt");
                WriteLiteral("n-secondary\" data-dismiss=\"modal\">Close</button>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            WriteLiteral(@"<div class=""modal fade"" id=""modalPerson"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Person Details</h5>
                <button type=""button"" class=""btn-close"" data-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"" id=""bodyMPerson"">
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <button type=""button"" class=""btn btn-primary"">Save changes</button>
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""modalUpdate"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
            ");
            WriteLiteral(@"    <h5 class=""modal-title"" id=""exampleModalLabel"">Update</h5>
                <button type=""button"" class=""btn-close"" data-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"" id=""bodyMUpdate"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3841d56324cdc0193d68a70decfed7d4b7d11b8a14129", async() => {
                WriteLiteral(@"
                    <div class=""row"">
                        <div class=""col-6 my-1"">
                            <label for=""Nik"" class=""col-form-label"">NIK</label>
                            <input type=""text"" class=""form-control"" id=""Nik"" aria-describedby=""nikHelp"" disabled>
                            <div id=""nikHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""FirstName"" class=""col-form-label"">First Name</label>
                            <input type=""text"" class=""form-control"" id=""FirstName"" aria-describedby=""firstnameHelp"">
                            <div id=""firstnameHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""LastName"" class=""col-form-label"">Last Name</label>
                            <input type=""text"" class=""form-control"" id=""LastName"" aria-describedby=""lastnameHelp"">
   ");
                WriteLiteral(@"                         <div id=""lastnameHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""Phone"" class=""col-form-label"">Phone</label>
                            <input type=""text"" class=""form-control"" id=""Phone"" aria-describedby=""phoneHelp"">
                            <div id=""phoneHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""Birthdate"" class=""col-form-label"">Birth Date</label>
                            <input type=""date"" class=""form-control"" id=""Birthdate"" value=""1997-06-15"" aria-describedby=""BirthdateHelp"">
                            <div id=""BirthdateHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""Salary"" class=""col-form-label"">Salary</label>
                            <input type");
                WriteLiteral(@"=""text"" class=""form-control"" id=""Salary"" aria-describedby=""salaryHelp"">
                            <div id=""salaryHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""Email"" class=""col-form-label"">Email</label>
                            <input type=""email"" class=""form-control"" id=""Email"" aria-describedby=""emailHelp"" disabled>
                            <div id=""emailHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""Password"" class=""col-form-label"">Password</label>
                            <input type=""password"" class=""form-control"" id=""Password"" aria-describedby=""passwordHelp"" minlength=""6"" disabled>
                            <div id=""passwordHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""");
                WriteLiteral(@"Degree"" class=""col-form-label"">Degree</label>
                            <input type=""text"" class=""form-control"" id=""Degree"" aria-describedby=""degreeHelp"">
                            <div id=""degreeHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""Gpa"" class=""col-form-label"">IPK</label>
                            <input type=""number"" class=""form-control"" id=""Gpa"" aria-describedby=""GpaHelp"">
                            <div id=""GpaHelp"" class=""form-text""></div>
                        </div>
                        <div class=""col-6 my-1"">
                            <label for=""UniversityId"" class=""col-form-label"">University</label>
                            <input type=""text"" class=""form-control"" id=""UniversityId"" aria-describedby=""universityHelp"">
                            <div id=""universityHelp"" class=""form-text""></div>
                        </div>
                    </div>
       ");
                WriteLiteral(@"             <div class=""modal-footer"">
                        <button id=""UpdateBtn"" type=""submit"" class=""btn btn-primary"">Update</button>
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3841d56324cdc0193d68a70decfed7d4b7d11b8a20440", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 196 "D:\TestCode\API\API-CRUD-MCC50\CORS\Views\Home\Person.cshtml"
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
                WriteLiteral("\r\n");
            }
            );
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
