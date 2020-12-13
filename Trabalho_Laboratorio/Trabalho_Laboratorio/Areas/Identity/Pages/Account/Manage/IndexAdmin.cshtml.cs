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
	[Authorize(Roles = "Admin")]
	public partial class IndexAdminModel : PageModel
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ApplicationDbContext _context;
		private readonly IHostEnvironment _he;
		private readonly SignInManager<IdentityUser> _signInManager;

		public IndexAdminModel(
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

		public Administrador AdminBD { get; set; }

		public class InputModel : Administrador
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
			public IFormFile AdminFoto { get; set; }
		}

		private async Task LoadAsync(IdentityUser user)
		{
			var userName = await _userManager.GetUserNameAsync(user);
			//var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

			Username = userName;

			AdminBD = await _context.Administrador.Include(r => r.IdAdminNavigation).FirstOrDefaultAsync(x => x.IdAdminNavigation.Username == user.UserName);

			Input = new InputModel
			{
				//PhoneNumber = phoneNumber
				Nome = AdminBD.Nome,
				Apelido = AdminBD.Apelido,
				Foto = AdminBD.Foto,
				EnderecoCodigoPostal = AdminBD.IdAdminNavigation.EnderecoCodigoPostal,
				EnderecoMorada = AdminBD.IdAdminNavigation.EnderecoMorada,
				EnderecoLocalidade = AdminBD.IdAdminNavigation.EnderecoLocalidade,
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
			ViewData["Foto"] = AdminBD.Foto;

			return Page();
		}

		public async Task<IActionResult> OnPostAsync(Administrador admin)
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
			}

			//if (!ModelState.IsValid)
			//{
			//	await LoadAsync(user);
			//	return Page();
			//}

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

			AdminBD = await _context.Administrador.Include(r => r.IdAdminNavigation).FirstOrDefaultAsync(x => x.IdAdminNavigation.Username == Username);

			AdminBD.Nome = admin.Nome;
			AdminBD.Apelido = admin.Apelido;

			string destination = Path.Combine(_he.ContentRootPath, "wwwroot/Fotos/", Path.GetFileName(Input.AdminFoto.FileName));

			// Creates a filestream to store the file listing
			FileStream fs = new FileStream(destination, FileMode.Create);

			try
			{
				Input.AdminFoto.CopyTo(fs);
				fs.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}

			// path para depois guardar na base de dados
			Input.Foto = "/Fotos/" + Input.AdminFoto.FileName.ToString();
			AdminBD.Foto = Input.Foto;
			AdminBD.IdAdminNavigation.EnderecoLocalidade = Input.EnderecoLocalidade;
			AdminBD.IdAdminNavigation.EnderecoCodigoPostal = Input.EnderecoCodigoPostal;
			AdminBD.IdAdminNavigation.EnderecoMorada = Input.EnderecoMorada;

			ModelState.Clear();

			if (TryValidateModel(AdminBD))
			{
				_context.Administrador.Update(AdminBD);
				await _context.SaveChangesAsync();
			}

			await _signInManager.RefreshSignInAsync(user);
			StatusMessage = "Your profile has been updated";
			return RedirectToPage();
		}
	}
}