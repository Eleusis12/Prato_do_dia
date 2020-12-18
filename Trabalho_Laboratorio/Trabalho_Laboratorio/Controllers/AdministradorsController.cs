using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

		public AdministradorsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
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
			// For ASP.NET Core <= 3.1
			IdentityUser applicationUser = await _userManager.GetUserAsync(User);
			string UserName = applicationUser?.UserName; // will give the user's Email

			// ID do Restaurante
			var administrador = _context.Administrador.Include(m => m.IdAdminNavigation).FirstOrDefault(m => m.IdAdminNavigation.Username == UserName);

			return View(administrador);
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

		// GET: Administradors/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var administrador = await _context.Administrador
				.Include(a => a.IdAdminNavigation)
				.FirstOrDefaultAsync(m => m.IdAdmin == id);
			if (administrador == null)
			{
				return NotFound();
			}

			return View(administrador);
		}

		// GET: Administradors/Create
		public IActionResult Create()
		{
			ViewData["IdAdmin"] = new SelectList(_context.Utilizador, "IdUtilizador", "Email");
			return View();
		}

		// POST: Administradors/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("IdAdmin,Nome,Apelido")] Administrador administrador)
		{
			if (ModelState.IsValid)
			{
				_context.Add(administrador);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(IndexAsync));
			}
			ViewData["IdAdmin"] = new SelectList(_context.Utilizador, "IdUtilizador", "Email", administrador.IdAdmin);
			return View(administrador);
		}

		// GET: Administradors/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var administrador = await _context.Administrador.FindAsync(id);
			if (administrador == null)
			{
				return NotFound();
			}
			ViewData["IdAdmin"] = new SelectList(_context.Utilizador, "IdUtilizador", "Email", administrador.IdAdmin);
			return View(administrador);
		}

		// POST: Administradors/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("IdAdmin,Nome,Apelido")] Administrador administrador)
		{
			if (id != administrador.IdAdmin)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(administrador);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!AdministradorExists(administrador.IdAdmin))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(IndexAsync));
			}
			ViewData["IdAdmin"] = new SelectList(_context.Utilizador, "IdUtilizador", "Email", administrador.IdAdmin);
			return View(administrador);
		}

		// GET: Administradors/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var administrador = await _context.Administrador
				.Include(a => a.IdAdminNavigation)
				.FirstOrDefaultAsync(m => m.IdAdmin == id);
			if (administrador == null)
			{
				return NotFound();
			}

			return View(administrador);
		}

		// POST: Administradors/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var administrador = await _context.Administrador.FindAsync(id);
			_context.Administrador.Remove(administrador);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(IndexAsync));
		}

		private bool AdministradorExists(int id)
		{
			return _context.Administrador.Any(e => e.IdAdmin == id);
		}
	}
}