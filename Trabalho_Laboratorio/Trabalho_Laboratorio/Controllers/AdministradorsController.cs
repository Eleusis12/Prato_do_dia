using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Trabalho_Laboratorio.Areas.Identity.Pages.Account;
using Trabalho_Laboratorio.Data;
using Trabalho_Laboratorio.Models;
using Trabalho_Laboratorio.ViewModel;

namespace Trabalho_Laboratorio.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdministradorsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ILogger<RegisterModel> _logger;

		public AdministradorsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<RegisterModel> logger)
		{
			_context = context;
			_userManager = userManager;
			_logger = logger;
		}

		// GET: Administradors
		public async Task<IActionResult> IndexAsync()
		{
			// For ASP.NET Core <= 3.1
			IdentityUser applicationUser = await _userManager.GetUserAsync(User);
			string UserName = applicationUser?.UserName; // will give the user's Email

			// ID do Restaurante
			var administrador = _context.Administrador.Include(m => m.IdAdminNavigation).FirstOrDefault(m => m.IdAdminNavigation.Username == UserName);

			AdminIndexViewModel adminIndexViewModel = new AdminIndexViewModel
			{
				// Pede apenas os restaurantes que ainda não foram confirmados
				ListaRestaurantes = _context.Restaurante.Include(m => m.IdRestauranteNavigation).Where(x => x.StatusRestaurante == false),

				// Ordena pelos últimos pratos a serem agendados
				ListaAgendamentos = _context.AgendarPrato.Include(m => m.IdPratoNavigation).Include(m => m.IdRestauranteNavigation).Select(x => x).OrderBy(x => x.DataDoAgendamento).Take(5),
				Administrador = administrador,
			};

			return View(adminIndexViewModel);
		}

		public async Task<IActionResult> Profile()
		{
			Administrador administrador = await GetLoggedAdmin();
			AdminProfileViewModel viewModel = new AdminProfileViewModel();
			viewModel.Administrador = administrador;

			return View(viewModel);
		}

		public async Task<IActionResult> ManageUsers()
		{
			Administrador administrador = await GetLoggedAdmin();
			AdminManageUsersViewModel viewModel = new AdminManageUsersViewModel();
			viewModel.Utilizadores = _context.Utilizador;
			viewModel.Administrador = administrador;

			return View(viewModel);
		}

		public async Task<IActionResult> ManageAdmins()
		{
			Administrador administrador = await GetLoggedAdmin();
			AdminManageAdminsViewModel viewModel = new AdminManageAdminsViewModel();
			viewModel.Administradores = _context.Administrador.Where(x => x.IdAdmin != administrador.IdAdmin);
			viewModel.Administrador = administrador;

			return View(viewModel);
		}

		public async Task<IActionResult> CheckNotifications()
		{
			Administrador administrador = await GetLoggedAdmin();
			AdminCheckNotificationsViewModel viewModel = new AdminCheckNotificationsViewModel();
			viewModel.Administrador = administrador;

			return View(viewModel);
		}

		public async Task<IActionResult> CheckLogs()
		{
			Administrador administrador = await GetLoggedAdmin();
			AdminCheckLogsViewModel viewModel = new AdminCheckLogsViewModel();
			viewModel.Administrador = administrador;

			return View(viewModel);
		}

		private async Task<Administrador> GetLoggedAdmin()
		{
			IdentityUser applicationUser = await _userManager.GetUserAsync(User);
			string UserName = applicationUser?.UserName; // will give the user's Email

			// ID do Restaurante
			var administrador = _context.Administrador.Include(m => m.IdAdminNavigation).FirstOrDefault(m => m.IdAdminNavigation.Username == UserName);
			return administrador;
		}

		[HttpPost]
		public async Task<IActionResult> RegistarAdministrador()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> BloquearUtilizador(int? id, string motivo)
		{
			var utilizador = _context.Utilizador.FirstOrDefault(x => x.IdUtilizador == id);
			IdentityUser user = await _userManager.FindByNameAsync(utilizador.Username);

			// Bloquear Indefenidamente Um Utilizador
			var lockoutEndDate = new DateTime(2999, 01, 01);
			await _userManager.SetLockoutEnabledAsync(user, true);
			await _userManager.SetLockoutEndDateAsync(user, lockoutEndDate);

			// Guardar na base de dados o motivo para o bloqueio do utilizador
			Bloqueio bloqueio = new Bloqueio();
			bloqueio.IdUtilizador = utilizador.IdUtilizador;
			bloqueio.Motivo = motivo;

			_context.Bloqueio.Add(bloqueio);
			_context.SaveChanges();

			return PartialView("_PartialUsersListing", _context.Utilizador.Include(m => m.Bloqueio).Where(x => x.Bloqueio == null));
		}

		[HttpPost]
		public async Task<IActionResult> AceitarRestaurante(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var restaurante = await _context.Restaurante
				.Include(a => a.IdRestauranteNavigation)
				.FirstOrDefaultAsync(m => m.IdRestaurante == id);

			if (restaurante == null)
			{
				return NotFound();
			}

			restaurante.StatusRestaurante = true;
			_context.SaveChanges();

			return PartialView("_PartialRestauranteListing", _context.Restaurante.Include(m => m.IdRestauranteNavigation).Where(x => x.StatusRestaurante == false));
		}

		[HttpPost]
		public async Task<IActionResult> RecusarRestauranteAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var restaurante = await _context.Restaurante
				.Include(a => a.IdRestauranteNavigation)
				.FirstOrDefaultAsync(m => m.IdRestaurante == id);

			if (restaurante == null)
			{
				return NotFound();
			}

			// Guardar temporariamente o valor do username para que possamos apagar os respetivos dados tb nas outras tableas não apenas na tabela restaurante
			string username = restaurante.IdRestauranteNavigation.Username;

			// Apaga na tabela restaurante
			_context.Restaurante.Remove(restaurante);

			// Apaga na tabela utilizador
			_context.Utilizador.Remove(_context.Utilizador.First(x => x.Username == username));

			IdentityUser user = await _userManager.GetUserAsync(User);
			if (user != null)
			{
				using (ApplicationDbContext dbcontext = new ApplicationDbContext())
				{
					dbcontext.UserLogins.RemoveRange(dbcontext.UserLogins.Where(ul => ul.UserId == user.Id));

					dbcontext.UserRoles.RemoveRange(dbcontext.UserRoles.Where(ur => ur.UserId == user.Id));

					dbcontext.Users.Remove(dbcontext.Users.Where(usr => usr.Id == user.Id).Single());

					dbcontext.SaveChanges();
				}
				return PartialView("_PartialRestauranteListing", _context.Restaurante.Include(m => m.IdRestauranteNavigation).Where(x => x.StatusRestaurante == false));
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> CreateNewAdminAsync()
		{
			Administrador administrador = await GetLoggedAdmin();
			AdminCreateNewAdminViewModel viewModel = new AdminCreateNewAdminViewModel();
			viewModel.Administrador = administrador;

			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> CreateNewAdminAsync(AdminCreateNewAdminViewModel admin)
		{
			Administrador adminLogado = await GetLoggedAdmin();
			admin.Administrador = adminLogado;
			admin.Utilizador.Password = "Error";

			ModelState.Clear();
			if (TryValidateModel(admin))
			{
				var user = new IdentityUser { UserName = admin.Utilizador.Username, Email = admin.Utilizador.Email };
				var result = await _userManager.CreateAsync(user, admin.Password);
				if (result.Succeeded)
				{
					_logger.LogInformation("User created a new account with password.");

					await _userManager.AddToRoleAsync(user, "Admin");

					// Criar Utilizador
					admin.Password = user.PasswordHash;
					_context.Utilizador.Add(admin.Utilizador);
					await _context.SaveChangesAsync();

					admin.AdministradorACriar.IdAdmin = admin.Utilizador.IdUtilizador;
					_context.Administrador.Add(admin.AdministradorACriar);

					await _context.SaveChangesAsync();

					// Sucesso
					return RedirectToAction(nameof(ManageAdmins));
				}
			}

			// Erro
			return View(admin);
		}
	}
}