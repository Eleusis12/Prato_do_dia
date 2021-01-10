using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Trabalho_Laboratorio.Data;
using Trabalho_Laboratorio.Models;

namespace Trabalho_Laboratorio.Areas.Identity.Pages.Account.Manage
{
	public partial class IndexClientModel : PageModel
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ApplicationDbContext _context;
		private readonly IHostEnvironment _he;
		private readonly SignInManager<IdentityUser> _signInManager;

		public IndexClientModel(
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

		public Clientes ClientBD { get; set; }

		public class InputModel : Clientes
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
		}

		private async Task LoadAsync(IdentityUser user)
		{
			var userName = await _userManager.GetUserNameAsync(user);
			//var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

			Username = userName;

			ClientBD = await _context.Clientes.Include(r => r.IdClienteNavigation).FirstOrDefaultAsync(x => x.IdClienteNavigation.Username == Username);

			Input = new InputModel
			{
				Nome = ClientBD.Nome,
				Apelido = ClientBD.Apelido,
				EnderecoCodigoPostal = ClientBD.IdClienteNavigation.EnderecoCodigoPostal,
				EnderecoMorada = ClientBD.IdClienteNavigation.EnderecoMorada,
				EnderecoLocalidade = ClientBD.IdClienteNavigation.EnderecoLocalidade,
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
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
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

			ClientBD = await _context.Clientes.Include(r => r.IdClienteNavigation).FirstOrDefaultAsync(x => x.IdClienteNavigation.Username == user.UserName);

			ClientBD.Nome = Input.Nome;
			ClientBD.Apelido = Input.Apelido;
			ClientBD.IdClienteNavigation.EnderecoLocalidade = Input.EnderecoLocalidade;
			ClientBD.IdClienteNavigation.EnderecoCodigoPostal = Input.EnderecoCodigoPostal;
			ClientBD.IdClienteNavigation.EnderecoMorada = Input.EnderecoMorada;

			ModelState.Clear();

			if (TryValidateModel(ClientBD))
			{
				_context.Update(ClientBD);
				await _context.SaveChangesAsync();
			}

			await _signInManager.RefreshSignInAsync(user);
			StatusMessage = "Your profile has been updated";
			return RedirectToPage();
		}
	}
}