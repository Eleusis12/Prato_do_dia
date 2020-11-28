using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Trabalho_Laboratorio.Data;
using Trabalho_Laboratorio.Models;

namespace Trabalho_Laboratorio.Controllers
{
	public class RestaurantesController : Controller
	{
		private readonly RestaurantesContext _context;
		private readonly IHostEnvironment _he;

		public RestaurantesController(RestaurantesContext context, IHostEnvironment host)
		{
			_context = context;
			_he = host;
		}

		// GET: Restaurantes
		public async Task<IActionResult> Index()
		{
			var restaurantesContext = _context.Restaurantes.Include(r => r.IdRestauranteNavigation);
			return View(await restaurantesContext.ToListAsync());
		}

		// GET: Restaurantes/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var restaurante = await _context.Restaurantes
				.Include(r => r.IdRestauranteNavigation)
				.FirstOrDefaultAsync(m => m.IdRestaurante == id);
			if (restaurante == null)
			{
				return NotFound();
			}

			return View(restaurante);
		}

		// GET: Restaurantes/Create
		public IActionResult Registar()
		{
			return View();
		}

		// POST: Restaurantes/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Registar(IFormFile Foto, [Bind("IdRestaurante,NomeRestaurante,Telefone,Foto,StatusRestaurante,TipoServico,DiaDeDescanso")] Restaurante restaurante)
		{
			// Assegura que o restaurante é inicializado como não aprovado
			restaurante.StatusRestaurante = false;

			string destination = Path.Combine(_he.ContentRootPath, "wwwroot/Fotos/", Path.GetFileName(Foto.FileName));

			// Creates a filestream to store the file listing
			FileStream fs = new FileStream(destination, FileMode.Create);

			try
			{
				Foto.CopyTo(fs);
				fs.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}

			// path para depois guardar na base de dados
			restaurante.Foto = "/Fotos/" + Foto.FileName.ToString();

			// Obter ID
			restaurante.IdRestaurante = (int)HttpContext.Session.GetInt32("id");

			ModelState.Clear();

			if (TryValidateModel(restaurante))
			{
				_context.Add(restaurante);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(restaurante);
		}

		// GET: Restaurantes/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var restaurante = await _context.Restaurantes.FindAsync(id);
			if (restaurante == null)
			{
				return NotFound();
			}
			ViewData["IdRestaurante"] = new SelectList(_context.Utilizadors, "IdUtilizador", "Email", restaurante.IdRestaurante);
			return View(restaurante);
		}

		// POST: Restaurantes/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("IdRestaurante,OwnerId,NomeRestaurante,Telefone,Foto,StatusRestaurante,TipoServico,DiaDeDescanso")] Restaurante restaurante)
		{
			if (id != restaurante.IdRestaurante)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(restaurante);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!RestauranteExists(restaurante.IdRestaurante))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["IdRestaurante"] = new SelectList(_context.Utilizadors, "IdUtilizador", "Email", restaurante.IdRestaurante);
			return View(restaurante);
		}

		// GET: Restaurantes/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var restaurante = await _context.Restaurantes
				.Include(r => r.IdRestauranteNavigation)
				.FirstOrDefaultAsync(m => m.IdRestaurante == id);
			if (restaurante == null)
			{
				return NotFound();
			}

			return View(restaurante);
		}

		// POST: Restaurantes/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var restaurante = await _context.Restaurantes.FindAsync(id);
			_context.Restaurantes.Remove(restaurante);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool RestauranteExists(int id)
		{
			return _context.Restaurantes.Any(e => e.IdRestaurante == id);
		}
	}
}