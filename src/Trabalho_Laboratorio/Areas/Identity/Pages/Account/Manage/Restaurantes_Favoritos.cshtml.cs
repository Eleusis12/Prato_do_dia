using System;
using System.Collections.Generic;
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
	[Authorize(Roles = "Client")]
	public class Restaurantes_FavoritosModel : PageModel
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ApplicationDbContext _context;
		private readonly IHostEnvironment _he;
		private readonly SignInManager<IdentityUser> _signInManager;

		public Restaurantes_FavoritosModel(
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
		public Clientes ClientBD { get; set; }

		public IQueryable<GuardarClienteRestauranteFavorito> ListaRestaurantesFavoritos { get; set; }

		private async Task LoadAsync(IdentityUser user)
		{
			var userName = await _userManager.GetUserNameAsync(user);
			//var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

			Username = userName;

			ClientBD = await _context.Clientes.Include(r => r.IdClienteNavigation).FirstOrDefaultAsync(x => x.IdClienteNavigation.Username == Username);
			ListaRestaurantesFavoritos = _context.GuardarClienteRestauranteFavorito.Include(x => x.IdClienteNavigation).Include(x => x.IdRestauranteNavigation).Include(x => x.IdClienteNavigation.IdClienteNavigation).Where(x => x.IdClienteNavigation.IdClienteNavigation.Username == Username);
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

		//public async Task<IActionResult> OnPostAsync(Clientes cliente)
		//{
		//	var user = await _userManager.GetUserAsync(User);
		//	if (user == null)
		//	{
		//		return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
		//	}

		//	//if (!ModelState.IsValid)
		//	//{
		//	//	await LoadAsync(user);
		//	//	return Page();
		//	//}

		//	//var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
		//	//if (Input.PhoneNumber != phoneNumber)
		//	//{
		//	//	var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
		//	//	if (!setPhoneResult.Succeeded)
		//	//	{
		//	//		StatusMessage = "Unexpected error when trying to set phone number.";
		//	//		return RedirectToPage();
		//	//	}
		//	//}

		//	ClientBD = await _context.Clientes.Include(r => r.IdClienteNavigation).FirstOrDefaultAsync(x => x.IdClienteNavigation.Username == user.UserName);

		//	ClientBD.Nome = cliente.Nome;
		//	ClientBD.Apelido = cliente.Apelido;

		//	ModelState.Clear();

		//	if (TryValidateModel(ClientBD))
		//	{
		//		_context.Update(ClientBD);
		//		await _context.SaveChangesAsync();
		//	}

		//	await _signInManager.RefreshSignInAsync(user);
		//	StatusMessage = "Your profile has been updated";
		//	return RedirectToPage();
		//}
	}
}