#pragma checksum "C:\Users\franc\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Areas\Identity\Pages\Account\Manage\_PartialFavoritesDishes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "979caaf4921cd6ba617d5422cd6894e2186fdad2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_Manage__PartialFavoritesDishes), @"mvc.1.0.view", @"/Areas/Identity/Pages/Account/Manage/_PartialFavoritesDishes.cshtml")]
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
#line 1 "C:\Users\franc\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\franc\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Areas\Identity\Pages\_ViewImports.cshtml"
using Trabalho_Laboratorio.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\franc\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Areas\Identity\Pages\_ViewImports.cshtml"
using Trabalho_Laboratorio.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\franc\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using Trabalho_Laboratorio.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\franc\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using Trabalho_Laboratorio.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"979caaf4921cd6ba617d5422cd6894e2186fdad2", @"/Areas/Identity/Pages/Account/Manage/_PartialFavoritesDishes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e108cca96aad573107f61e0b2f3b6ff197bcbe4", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"811ac65b27e00b582142470aedef2472fa10befa", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1345de54d10cc7eebe44abeb1858365a711fd79", @"/Areas/Identity/Pages/Account/Manage/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Manage__PartialFavoritesDishes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IQueryable<Trabalho_Laboratorio.Models.GuardarClientePratoFavorito>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ClientSettings", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoverPratoFavorito", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-mode", new global::Microsoft.AspNetCore.Html.HtmlString("replace"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-update", new global::Microsoft.AspNetCore.Html.HtmlString("#table"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-confirm", new global::Microsoft.AspNetCore.Html.HtmlString("Tem a certeza?"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-success", new global::Microsoft.AspNetCore.Html.HtmlString("AjaxSucess"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-failure", new global::Microsoft.AspNetCore.Html.HtmlString("AjaxError"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<table id=""table"" class=""table table-bordered table-hover"">
	<thead class=""thead-dark"">
		<tr>
			<th scope=""col"">#</th>
			<th scope=""col"">Nome do Prato</th>
			<th scope=""col"">Tipo de Prato</th>
			<th scope=""col"">Remover</th>
		</tr>
	</thead>
	<tbody>
");
#nullable restore
#line 18 "C:\Users\franc\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Areas\Identity\Pages\Account\Manage\_PartialFavoritesDishes.cshtml"
          int i = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 20 "C:\Users\franc\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Areas\Identity\Pages\Account\Manage\_PartialFavoritesDishes.cshtml"
         foreach (var prato in Model)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<tr>\r\n\r\n\t\t\t\t<th scope=\"row\">\r\n\t\t\t\t\t");
#nullable restore
#line 25 "C:\Users\franc\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Areas\Identity\Pages\Account\Manage\_PartialFavoritesDishes.cshtml"
               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</th>\r\n\t\t\t\t<td>");
#nullable restore
#line 27 "C:\Users\franc\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Areas\Identity\Pages\Account\Manage\_PartialFavoritesDishes.cshtml"
               Write(prato.IdPratoNavigation.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t<td>");
#nullable restore
#line 28 "C:\Users\franc\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Areas\Identity\Pages\Account\Manage\_PartialFavoritesDishes.cshtml"
               Write(prato.IdPratoNavigation.TipoPrato);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "979caaf4921cd6ba617d5422cd6894e2186fdad210635", async() => {
                WriteLiteral("\r\n\t\t\t\t\t\t<img src=\"/assets/images/rejected.png\" alt=\"Recusar\"\r\n\t\t\t\t\t\t\t class=\"rounded-circle btn RejectImage\" style=\"width: 64px;\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1132, "\"", 1210, 3);
                WriteAttributeValue("", 1142, "document.querySelector(\'#col_", 1142, 29, true);
#nullable restore
#line 33 "C:\Users\franc\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Areas\Identity\Pages\Account\Manage\_PartialFavoritesDishes.cshtml"
WriteAttributeValue("", 1171, prato.IdClientePratoFavorito, 1171, 29, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1200, "\').click()", 1200, 10, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n\t\t\t\t\t\t<button");
                BeginWriteAttribute("id", " id=\"", 1229, "\"", 1267, 2);
                WriteAttributeValue("", 1234, "col_", 1234, 4, true);
#nullable restore
#line 34 "C:\Users\franc\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Areas\Identity\Pages\Account\Manage\_PartialFavoritesDishes.cshtml"
WriteAttributeValue("", 1238, prato.IdClientePratoFavorito, 1238, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"submit\" class=\"reject\" hidden />\r\n\t\t\t\t\t");
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
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "C:\Users\franc\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Areas\Identity\Pages\Account\Manage\_PartialFavoritesDishes.cshtml"
                                                                                              WriteLiteral(prato.IdClientePratoFavorito);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\t\t\t</tr>\r\n");
#nullable restore
#line 38 "C:\Users\franc\OneDrive\Utad\3ºano\1ºsemestre\Laboratório de Aplicações Web e Bases de Dados\Prato_do_Dia\Trabalho_Laboratorio\Trabalho_Laboratorio\Areas\Identity\Pages\Account\Manage\_PartialFavoritesDishes.cshtml"
			i++;

		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IQueryable<Trabalho_Laboratorio.Models.GuardarClientePratoFavorito>> Html { get; private set; }
    }
}
#pragma warning restore 1591
