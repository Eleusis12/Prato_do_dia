using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Trabalho_Laboratorio.Data;
using Trabalho_Laboratorio.Interfaces;
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
		private readonly IHostEnvironment _he;

		public RegisterModel(
			UserManager<IdentityUser> userManager,
			SignInManager<IdentityUser> signInManager,
			ILogger<RegisterModel> logger,
			IEmailSender emailSender,
			ApplicationDbContext dbContext,
			RoleManager<IdentityRole> roleManager, IHostEnvironment host)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_logger = logger;
			_emailSender = emailSender;
			_dbContext = dbContext;
			_roleManager = roleManager;
			_he = host;
		}

		[BindProperty]
		public InputModel Input { get; set; }

		public string ReturnUrl { get; set; }

		public IList<AuthenticationScheme> ExternalLogins { get; set; }

		public class InputModel : IUtilizador, ICliente, IRestaurante

		{
			public InputModel()
			{
				Utilizador = new Utilizador();
				Restaurante = new Restaurante();
				Cliente = new Clientes();
			}

			[Required]
			public string Role { get; set; }

			[DataType(DataType.Password)]
			[Display(Name = "Confirm password")]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }

			[Display(Name = "Imagem")]
			public IFormFile RestaurantFoto { get; set; }

			public string Password { get; set; }

			public Utilizador Utilizador
			{
				get; set;
			}

			public Restaurante Restaurante
			{
				get; set;
			}

			public Clientes Cliente
			{
				get; set;
			}
		}

		public async Task OnGetAsync(string returnUrl = null)
		{
			ViewData["roles"] = _roleManager.Roles.Where(x => x.Name.ToLower() != "Admin".ToLower()).ToList();

			ReturnUrl = returnUrl;
			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
		}

		public async Task<IActionResult> OnPostAsync(string returnUrl = null)
		{
			returnUrl = returnUrl ?? Url.Content("~/");
			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

			Input.Utilizador.Password = "Error";

			// Corrigir os erros com o Model
			ModelState.Clear();
			TryValidateModel(Input);

			// Obtém as propriedades que estejam decoradas com a tag Required para o respetivo objeto
			var propriedadesRestaurante = Input.Restaurante.GetType().GetProperties().Where(p => p.GetCustomAttributes().OfType<RequiredAttribute>().Any()).Select(p => p.Name).ToList();
			var propriedadesCliente = Input.Cliente.GetType().GetProperties().Where(p => p.GetCustomAttributes().OfType<RequiredAttribute>().Any()).Select(p => p.Name).ToList();

			if (Input.Role == "Client")
			{
				// Se vamos inscrever uma conta de cliente, não vale a pena considerar erros de propriedades relacionadas para o restaurante
				foreach (var prop in propriedadesRestaurante)  // of type ImportParameter

				{
					ModelState["Restaurante." + prop].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
				}
			}
			else if (Input.Role == "Restaurant")
			{
				foreach (var prop in propriedadesCliente)
				{
					ModelState["Cliente." + prop].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
				}
				Input.Restaurante.Foto = "Vazio";
				ModelState["Restaurante.Foto"].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
			}

			if (ModelState.IsValid)
			{
				var user = new IdentityUser { UserName = Input.Utilizador.Username, Email = Input.Utilizador.Email };
				var result = await _userManager.CreateAsync(user, Input.Password);
				if (result.Succeeded)
				{
					_logger.LogInformation("User created a new account with password.");

					await _userManager.AddToRoleAsync(user, Input.Role);

					// Criar Utilizador
					//Utilizador u = new Utilizador { Username = user.UserName, Password = user.PasswordHash, Email = Input.Email, EmailConfirmado = false, EnderecoCodigoPostal = Input.EnderecoCodigoPostal, EnderecoLocalidade = Input.EnderecoLocalidade, EnderecoMorada = Input.EnderecoMorada };
					Input.Utilizador.Password = user.PasswordHash;
					_dbContext.Utilizador.Add(Input.Utilizador);
					await _dbContext.SaveChangesAsync();

					// Vamos Criar tabelas Cliente, Restaurante e Admin vazias simplesmente para efetuar a conexão das tabelas pela o id
					switch (Input.Role)
					{
						case "Client":
							Input.Cliente.IdCliente = Input.Utilizador.IdUtilizador;
							_dbContext.Clientes.Add(Input.Cliente);
							break;

						case "Restaurant":
							//Restaurante restaurante = new Restaurante { IdRestaurante = u.IdUtilizador, NomeRestaurante = "Null", Telefone = "Null", Foto = "Null", StatusRestaurante = false, TipoServico = "Null", DiaDeDescanso = "Null" };
							Input.Restaurante.IdRestaurante = Input.Utilizador.IdUtilizador;
							Input.Restaurante.StatusRestaurante = false;

							if (Input.RestaurantFoto != null)
							{
								string destination = Path.Combine(_he.ContentRootPath, "wwwroot/Fotos/", Path.GetFileName(Input.RestaurantFoto.FileName));

								// Creates a filestream to store the file listing
								FileStream fs = new FileStream(destination, FileMode.Create);

								try
								{
									Input.RestaurantFoto.CopyTo(fs);
									fs.Close();
								}
								catch (Exception ex)
								{
									throw ex;
								}

								// path para depois guardar na base de dados
								Input.Restaurante.Foto = "/Fotos/" + Input.RestaurantFoto.FileName.ToString();
							}

							_dbContext.Restaurante.Add(Input.Restaurante);
							break;

						// Não pretendemos que se possa criar contas admin através da página de registo princiapal
						case "Admin":
							throw new ArgumentException();

						default:
							throw new ArgumentOutOfRangeException();
					}

					await _dbContext.SaveChangesAsync();

					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
					var callbackUrl = Url.Page(
						"/Account/ConfirmEmail",
						pageHandler: null,
						values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
						protocol: Request.Scheme);

					await _emailSender.SendEmailAsync(Input.Utilizador.Email, "Confirm your email",
						$"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

					if (_userManager.Options.SignIn.RequireConfirmedAccount)
					{
						return RedirectToPage("RegisterConfirmation", new { email = Input.Utilizador.Email, returnUrl = returnUrl });
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