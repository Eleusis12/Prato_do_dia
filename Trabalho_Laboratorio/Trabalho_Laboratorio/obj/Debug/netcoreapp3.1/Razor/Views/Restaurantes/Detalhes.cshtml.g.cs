#pragma checksum "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\Restaurantes\Detalhes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51ecd585d172a624365bc096870a5905c39f3bcd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Restaurantes_Detalhes), @"mvc.1.0.view", @"/Views/Restaurantes/Detalhes.cshtml")]
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
#line 1 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\_ViewImports.cshtml"
using Trabalho_Laboratorio;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\_ViewImports.cshtml"
using Trabalho_Laboratorio.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51ecd585d172a624365bc096870a5905c39f3bcd", @"/Views/Restaurantes/Detalhes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a9f5449fe23e2242fb51575cb1bfe96f5b5be27", @"/Views/_ViewImports.cshtml")]
    public class Views_Restaurantes_Detalhes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Trabalho_Laboratorio.Models.Restaurante>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ClientSettings", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddRestauranteToFavorites", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-success", new global::Microsoft.AspNetCore.Html.HtmlString("sucesso"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-failure", new global::Microsoft.AspNetCore.Html.HtmlString("AjaxError"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\Restaurantes\Detalhes.cshtml"
  
	ViewData["Title"] = "Detalhes";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container container-product-detail mt-4\">\r\n\r\n\t<div class=\"row\">\r\n\t\t<!-- Left Column / Headphones Image -->\r\n\t\t<div class=\"col-md-6 offset-2\">\r\n\t\t\t<img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 273, "\"", 316, 1);
#nullable restore
#line 12 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\Restaurantes\Detalhes.cshtml"
WriteAttributeValue("", 279, Html.DisplayFor(model => model.Foto), 279, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Image not Loaded\" />\r\n\t\t</div>\r\n\r\n\t\t<!-- Right Column -->\r\n\t\t<div class=\"col-md-4 \">\r\n\r\n\t\t\t<!-- Product Description -->\r\n\t\t\t<div class=\"product-description\">\r\n\t\t\t\t<span>Restaurante</span>\r\n\t\t\t\t<h1>");
#nullable restore
#line 21 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\Restaurantes\Detalhes.cshtml"
               Write(Html.DisplayFor(model => model.NomeRestaurante));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\t\t\t\t<p>");
#nullable restore
#line 22 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\Restaurantes\Detalhes.cshtml"
              Write(Html.DisplayFor(model => model.TipoServico));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t<p>Dia de descanso: ");
#nullable restore
#line 23 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\Restaurantes\Detalhes.cshtml"
                               Write(Html.DisplayFor(model => model.DiaDeDescanso));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t</div>\r\n\r\n\t\t\t<!-- Product Configuration -->\r\n\t\t\t<div class=\"product-configuration\">\r\n\r\n\t\t\t\t<!-- Cable Configuration -->\r\n\t\t\t\t<div class=\"cable-config\">\r\n\t\t\t\t\t<span>Telefone</span>\r\n\r\n\t\t\t\t\t<div class=\"cable-choose\">\r\n\t\t\t\t\t\t<button>");
#nullable restore
#line 34 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\Restaurantes\Detalhes.cshtml"
                           Write(Html.DisplayFor(model => model.Telefone));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t<a href=\"#\">Quer contactar restaurante?</a>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n\r\n<div class=\"row\" id=\"row-notification\">\r\n\t<div class=\"col-md-6 col-sm-12 offset-md-4\">\r\n\r\n");
#nullable restore
#line 47 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\Restaurantes\Detalhes.cshtml"
         if (User.IsInRole("Client"))
		{
			

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\Restaurantes\Detalhes.cshtml"
             if ((string)ViewData["Notificacao_Restaurante"] != "true")
			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51ecd585d172a624365bc096870a5905c39f3bcd10368", async() => {
                WriteLiteral("\r\n\t\t\t\t\t<input hidden type=\"text\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 1530, "\"", 1558, 1);
#nullable restore
#line 52 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\Restaurantes\Detalhes.cshtml"
WriteAttributeValue("", 1538, Model.IdRestaurante, 1538, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\t\t\t\t\t<button type=\"submit\" class=\"add-favorite-list\">Adicione o restaurante ");
#nullable restore
#line 53 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\Restaurantes\Detalhes.cshtml"
                                                                                      Write(Model.NomeRestaurante);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ao seus favoritos.</button>\r\n\t\t\t\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 55 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\Restaurantes\Detalhes.cshtml"
			}

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\Francisco\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Views\Restaurantes\Detalhes.cshtml"
             
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\t<script>\r\n\t\tfunction sucesso() {\r\n\t\t\tAjaxSucess();\r\n\r\n\t\t\t// Esconder o Botao\r\n\t\t\tconst btnNoti = document.querySelector(\"#row-notification\");\r\n\t\t\tbtnNoti.style.display = \"none\";\r\n\r\n\t\t}\r\n\t</script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Trabalho_Laboratorio.Models.Restaurante> Html { get; private set; }
    }
}
#pragma warning restore 1591
