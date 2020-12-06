using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Trabalho_Laboratorio.Data;
using Trabalho_Laboratorio.Helpers;
using Trabalho_Laboratorio.Models;

namespace Trabalho_Laboratorio.Areas.Identity.Pages.Account.Manage
{
	[Authorize(Roles = "Restaurant")]
	public partial class IndexRestaurantModel : PageModel
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ApplicationDbContext _context;
		private readonly IHostEnvironment _he;
		private readonly SignInManager<IdentityUser> _signInManager;

		public IndexRestaurantModel(
			UserManager<IdentityUser> userManager,
			SignInManager<IdentityUser> signInManager,
			ApplicationDbContext context, IHostEnvironment host)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
			_he = host;
		}

		public string Username { get; set; }

		[TempData]
		public string StatusMessage { get; set; }

		[BindProperty]
		public InputModel Input { get; set; }

		public Restaurante RestauranteBD { get; set; }

		public class InputModel : Restaurante
		{
			[Required]
			[StringLength(50)]
			[Display(Name = "Morada")]
			public string EnderecoMorada { get; set; }

			[Required]
			[StringLength(8)]
			[Display(Name = "Código Postal")]
			[RegularExpression(@"^\d{4}(-\d{3})$", ErrorMessage = "Must be a valid Postal Code")]
			public string EnderecoCodigoPostal { get; set; }

			[Required]
			[StringLength(30)]
			[Display(Name = "Localidade")]
			public string EnderecoLocalidade { get; set; }

			[Display(Name = "Imagem")]
			[Required(ErrorMessage = "Faz Upload a uma imagem do teu restaurante")]
			[AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
			public IFormFile RestaurantFoto { get; set; }
		}

		private async Task LoadAsync(IdentityUser user)
		{
			var userName = await _userManager.GetUserNameAsync(user);
			Username = userName;

			RestauranteBD = await _context.Restaurante.Include(r => r.IdRestauranteNavigation).FirstOrDefaultAsync(x => x.IdRestauranteNavigation.Username == Username);

			Input = new InputModel
			{
				NomeRestaurante = RestauranteBD.NomeRestaurante,
				Telefone = RestauranteBD.Telefone,
				DiaDeDescanso = RestauranteBD.DiaDeDescanso,
				Foto = RestauranteBD.Foto,
				TipoServico = RestauranteBD.TipoServico,
				EnderecoCodigoPostal = RestauranteBD.IdRestauranteNavigation.EnderecoCodigoPostal,
				EnderecoMorada = RestauranteBD.IdRestauranteNavigation.EnderecoMorada,
				EnderecoLocalidade = RestauranteBD.IdRestauranteNavigation.EnderecoLocalidade,
			};
		}

		public async Task<IActionResult> OnGetAsync()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
			}
			await LoadAsync(user);
			ViewData["Foto"] = RestauranteBD.Foto;

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
			}

			//var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
			//if (Input.PhoneNumber != phoneNumber)
			//{
			//	var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
			//	if (!setPhoneResult.Succeeded)
			//	{
			//		StatusMessage = "Unexpected error when trying to set phone number.";
			//		return RedirectToPage();
			//	}
			//}

			RestauranteBD = await _context.Restaurante.Include(r => r.IdRestauranteNavigation).FirstOrDefaultAsync(x => x.IdRestauranteNavigation.Username == user.UserName);

			// Assegura que o restaurante é inicializado como não aprovado

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
			Input.Foto = "/Fotos/" + Input.RestaurantFoto.FileName.ToString();

			// Fazer update aos dados na base de dados
			RestauranteBD.NomeRestaurante = Input.NomeRestaurante;
			RestauranteBD.Telefone = Input.Telefone;
			RestauranteBD.TipoServico = Input.TipoServico;
			RestauranteBD.DiaDeDescanso = Input.DiaDeDescanso;
			RestauranteBD.Foto = Input.Foto;
			RestauranteBD.IdRestauranteNavigation.EnderecoLocalidade = Input.EnderecoLocalidade;
			RestauranteBD.IdRestauranteNavigation.EnderecoCodigoPostal = Input.EnderecoCodigoPostal;
			RestauranteBD.IdRestauranteNavigation.EnderecoMorada = Input.EnderecoMorada;

			ModelState.Clear();

			if (TryValidateModel(RestauranteBD))
			{
				_context.Restaurante.Update(RestauranteBD);
				await _context.SaveChangesAsync();
			}

			await _signInManager.RefreshSignInAsync(user);
			StatusMessage = "Your profile has been updated";
			return RedirectToPage();
		}
	}
}