#pragma checksum "C:\Users\Waver\source\repos\HomeSquareApp\HomeSquareApp\Views\Shared\_ModalLoginSignUpPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aea595ce9c6ca4f56a88399371a166e286a78f4c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ModalLoginSignUpPartial), @"mvc.1.0.view", @"/Views/Shared/_ModalLoginSignUpPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_ModalLoginSignUpPartial.cshtml", typeof(AspNetCore.Views_Shared__ModalLoginSignUpPartial))]
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
#line 1 "C:\Users\Waver\source\repos\HomeSquareApp\HomeSquareApp\Views\_ViewImports.cshtml"
using HomeSquareApp;

#line default
#line hidden
#line 2 "C:\Users\Waver\source\repos\HomeSquareApp\HomeSquareApp\Views\_ViewImports.cshtml"
using HomeSquareApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aea595ce9c6ca4f56a88399371a166e286a78f4c", @"/Views/Shared/_ModalLoginSignUpPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a5520fbc05a94fac60d7e61edcbd77a4127b62e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ModalLoginSignUpPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 785, true);
            WriteLiteral(@"<div class=""modal fade"" id=""loginModal"" tabindex=""-1"" aria-labelledby=""loginModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""login-wrap"">
                <div class=""login-html"">
                    <input id=""tab-1"" type=""radio"" name=""tab"" class=""sign-in"" checked><label for=""tab-1"" class=""tab"">Sign In</label>
                    <input id=""tab-2"" type=""radio"" name=""tab"" class=""sign-up""><label for=""tab-2"" class=""tab"">Sign Up</label>
                    <div class=""login-form"">
                        <div class=""sign-in-htm"">
");
            EndContext();
            BeginContext(914, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(942, 1137, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca57c2f2daa14262a8ed881bfd128426", async() => {
                BeginContext(948, 1124, true);
                WriteLiteral(@"
                                <div class=""group"">
                                    <label for=""emailLogIn"" class=""label"">Email</label>
                                    <input id=""emailLogIn"" type=""email"" class=""input"" required>
                                </div>
                                <div class=""group"">
                                    <label for=""pass"" class=""label"">Password</label>
                                    <input id=""passLogIn"" type=""password"" class=""input"" data-type=""password"" required>
                                </div>
                                <div class=""group"">
                                    <input id=""check"" type=""checkbox"" class=""check"" checked>
                                    <label for=""check""><span class=""icon""></span> Keep me Signed in</label>
                                </div>
                                <div class=""group"">
                                    <button type=""submit"" class=""btn btn-primary form-control r");
                WriteLiteral("ounded-pill\"> Sign In</button>\r\n                                </div>\r\n                            ");
                EndContext();
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
            EndContext();
            BeginContext(2079, 194, true);
            WriteLiteral("\r\n                            <div class=\"foot-lnk\">\r\n                                <a href=\"#forgot\">Forgot Password?</a>\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
            BeginContext(2405, 6784, true);
            WriteLiteral(@"                        <div class=""sign-up-htm"">
                            <span id=""progressBarPrompt"">1/2</span>
                            <div class=""progress mb-3"" style=""height: 1px;"">
                                <div id=""progressBarLogin"" class=""progress-bar"" role=""progressbar"" style=""width: 50%;"" aria-valuenow=""50"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                            </div>
                            <div>
                                <div id=""signUpGroup1"">
                                    <div class=""group"">
                                        <label for=""emailSignup"" class=""label"">Email Address</label>
                                        <input onchange=""validateEmail(this.value)"" id=""emailSignup"" type=""email"" class=""input"" required>
                                        <span id=""emailSignupValidPrompt"" class=""form-text""></span>
                                    </div>
                                    <div class=""group"">
              ");
            WriteLiteral(@"                          <label for=""passwordSignup"" class=""label"">Password</label>
                                        <input onchange=""validatePassword(this.value)"" id=""passwordSignup"" type=""password"" class=""input"" data-type=""password"" required>
                                        <div id=""passwordSignupValidPrompt"" class=""form-text"">Password should be atleast 8 characters and contain atleast 1 numeric character</div>
                                    </div>
                                    <div class=""group"">
                                        <label for=""confirmPassSignup"" class=""label"">Repeat Password</label>
                                        <input onchange=""validateRepeatPassword()"" id=""confirmPasswordSignup"" type=""password"" class=""input"" data-type=""password"" required>
                                        <span id=""confirmPasswordSignupValidPrompt"" class=""text-danger form-text""></span>
                                    </div>
                                    <d");
            WriteLiteral(@"iv class=""group"">
                                        <button onclick=""nextSignup()"" class=""btn btn-primary form-control rounded-pill"">Next</button>
                                    </div>
                                </div>
                                <div id=""signUpGroup2"" class=""d-none"">
                                    <div class=""group"">
                                        <label for=""firstNameSignup"" class=""label"">First Name</label>
                                        <input id=""firstNameSignup"" type=""text"" class=""input"" required>
                                        <span class=""text-danger form-text""></span>
                                    </div>
                                    <div class=""group"">
                                        <label for=""lastNameSignup"" class=""label"">Last Name</label>
                                        <input id=""lastNameSignup"" type=""text"" class=""input"" required>
                                        <span class=""text");
            WriteLiteral(@"-danger form-text""></span>
                                    </div>
                                    <div class=""group"">
                                        <label for=""addressSignup"" class=""label"">Address</label>
                                        <input id=""addressSignup"" type=""text"" class=""input"">
                                        <span class=""text-danger form-text""></span>
                                    </div>
                                    <div class=""group"">
                                        <label for=""phoneSignup"" class=""label"">Phone Number</label>
                                        <input id=""phoneSignup"" type=""text"" class=""input"" required>
                                        <span class=""form-text""></span>
                                    </div>
                                    <div class=""form-check"">
                                        <input class=""form-check-input"" type=""checkbox"" value="""" id=""flexCheckChecked"" required>
      ");
            WriteLiteral(@"                                  <label class=""form-check-label form-text"" for=""flexCheckChecked"">
                                            I am ready to receive email to activate my account
                                        </label>
                                    </div>
                                    <div class=""group mt-2"">
                                        <button onclick=""backSignup()"" class=""btn btn-light border border-dark form-control rounded-pill"">Back</button>
                                    </div>
                                    <div class=""group"">
                                        <input onclick=""submitForm()"" class=""btn btn-primary form-control rounded-pill"" value=""Sign Up"" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


<script>
   ");
            WriteLiteral(@" function nextSignup() {
        var emailElement = document.getElementById('emailSignup');
        var passwordElement = document.getElementById('passwordSignup')
        var confirmPasswordElement = document.getElementById('confirmPasswordSignup');

        if (checkEmptyValue(emailElement) && checkEmptyValue(passwordElement) && checkEmptyValue(confirmPasswordElement)) {

            if (validateEmail(emailElement.value) && validatePassword(passwordElement.value) && validateRepeatPassword()) {
                document.getElementById('progressBarPrompt').innerHTML = ""2/2"";
                document.getElementById('progressBarLogin').style.width = ""100%"";
                document.getElementById('signUpGroup1').classList.add('d-none');
                document.getElementById('signUpGroup2').classList.remove('d-none');
            }
            return;
        }
        return;
    }

    function checkEmptyValue(element) {
        if (!element.value) {
            element.classList.add('bord");
            WriteLiteral(@"er');
            element.classList.add('border-danger');
            return false;
        } 
        element.classList.remove('border');
        element.classList.remove('border-danger');
        return true;
    }

    function backSignup() {
        document.getElementById('progressBarPrompt').innerHTML = ""1/2"";
        document.getElementById('progressBarLogin').style.width = ""50%"";
        document.getElementById('signUpGroup1').classList.remove('d-none');
        document.getElementById('signUpGroup2').classList.add('d-none');
    }

    function validateEmail(email) {
        const re = /^(([^<>()[\]\\.,;:\s");
            EndContext();
            BeginContext(9190, 24, true);
            WriteLiteral("@\"]+(\\.[^<>()[\\]\\\\.,;:\\s");
            EndContext();
            BeginContext(9215, 15, true);
            WriteLiteral("@\"]+)*)|(\".+\"))");
            EndContext();
            BeginContext(9231, 1524, true);
            WriteLiteral(@"@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        var result = re.test(String(email).toLowerCase());
        var el = document.getElementById('emailSignupValidPrompt');

        if (!result) {
            el.classList.add('text-danger');
            el.innerHTML = ""Invalid email address"";
            return false;
        } else {
            el.innerHTML = """";
            return true;
        }
    }

    function validatePassword(password) {
        const re = /^(?=.*[0-9])(?=.{8,})/;
        var result = re.test(String(password));
        var el = document.getElementById('passwordSignupValidPrompt');
        if (!result) {
            el.classList.remove('text-success');
            el.classList.add('text-danger');
            return false;
        }
        el.classList.remove('text-danger');
        el.classList.add('text-success');
        return true;
    }

    function validateRepeatPassword() {
        var passwordEl = d");
            WriteLiteral(@"ocument.getElementById('passwordSignup');
        var confirmPasswordEl = document.getElementById('confirmPasswordSignup');

        console.log(passwordEl.value + "" "" + confirmPasswordEl.value)

        if (passwordEl.value != confirmPasswordEl.value) {
            confirmPasswordSignupValidPrompt.innerHTML = ""Password and the confirmation did not match"";
            return false;
        }
        confirmPasswordSignupValidPrompt.innerHTML = """";
        return true;
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
