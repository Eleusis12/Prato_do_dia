using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Trabalho_Laboratorio.Data;
using Trabalho_Laboratorio.Models;

namespace Trabalho_Laboratorio.Areas.Identity.Pages.Account
{
	[AllowAnonymous]
	public class RegisterModel : PageModel
	{
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ILogger<RegisterModel> _logger;
		private readonly IEmailSender _emailSender;
		private readonly ApplicationDbContext _dbContext;
		private readonly RoleManager<IdentityRole> _roleManager;

		public RegisterModel(
			UserManager<IdentityUser> userManager,
			SignInManager<IdentityUser> signInManager,
			ILogger<RegisterModel> logger,
			IEmailSender emailSender,
			ApplicationDbContext dbContext,
			RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_logger = logger;
			_emailSender = emailSender;
			_dbContext = dbContext;
			_roleManager = roleManager;
		}

		[BindProperty]
		public InputModel Input { get; set; }

		public string ReturnUrl { get; set; }

		public IList<AuthenticationScheme> ExternalLogins { get; set; }

		public class InputModel : Utilizador
		{
			[Required]
			public string Role { get; set; }

			[DataType(DataType.Password)]
			[Display(Name = "Confirm password")]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }
		}

		public async Task OnGetAsync(string returnUrl = null)
		{
			ViewData["roles"] = _roleManager.Roles.ToList();

			ReturnUrl = returnUrl;
			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
		}

		public async Task<IActionResult> OnPostAsync(string returnUrl = null)
		{
			returnUrl = returnUrl ?? Url.Content("~/");
			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
			if (ModelState.IsValid)
			{
				var user = new IdentityUser { UserName = Input.Username, Email = Input.Email };
				var result = await _userManager.CreateAsync(user, Input.Password);
				if (result.Succeeded)
				{
					_logger.LogInformation("User created a new account with password.");

					await _userManager.AddToRoleAsync(user, Input.Role);

					// Criar Utilizador
					Utilizador u = new Utilizador { Username = user.UserName, Password = user.PasswordHash, Email = Input.Email, EmailConfirmado = false, EnderecoCodigoPostal = Input.EnderecoCodigoPostal, EnderecoLocalidade = Input.EnderecoLocalidade, EnderecoMorada = Input.EnderecoMorada };
					_dbContext.Utilizador.Add(u);
					await _dbContext.SaveChangesAsync();

					// Vamos Criar tabelas Cliente, Restaurante e Admin vazias simplesmente para efetuar a conexão das tabelas pela o id
					switch (Input.Role)
					{
						case "Client":
							Clientes cl = new Clientes { IdCliente = u.IdUtilizador, Nome = "Null", Apelido = "Null" };
							_dbContext.Clientes.Add(cl);
							break;

						case "Restaurant":
							Restaurante restaurante = new Restaurante { IdRestaurante = u.IdUtilizador, NomeRestaurante = "Null", Telefone = "Null", Foto = "Null", StatusRestaurante = false, TipoServico = "Null", DiaDeDescanso = "Null" };
							_dbContext.Restaurante.Add(restaurante);
							break;

						case "Admin":
							Administrador admin = new Administrador { IdAdmin = u.IdUtilizador, Nome = "Null", Apelido = "Null" };
							_dbContext.Administrador.Add(admin);
							break;

						default:
							throw new ArgumentException();
					}

					await _dbContext.SaveChangesAsync();

					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
					var callbackUrl = Url.Page(
						"/Account/ConfirmEmail",
						pageHandler: null,
						values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
						protocol: Request.Scheme);

					await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
						$"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

					if (_userManager.Options.SignIn.RequireConfirmedAccount)
					{
						return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
					}
					else
					{
						await _signInManager.SignInAsync(user, isPersistent: false);
						return LocalRedirect(returnUrl);
					}
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			// If we got this far, something failed, redisplay form
			return Page();
		}
	}
}