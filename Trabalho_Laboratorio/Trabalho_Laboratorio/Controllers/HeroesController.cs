using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Trabalho_Laboratorio.Data;
using Trabalho_Laboratorio.Models;

namespace Trabalho_Laboratorio.Controllers
{
	public class HeroesController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IHostEnvironment _he;

		public HeroesController(ApplicationDbContext context, IHostEnvironment host)
		{
			_context = context;
			_he = host;
		}

		// GET: Heroes
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Index()
		{
			return View(await _context.Hero.ToListAsync());
		}

		[Authorize(Roles = "Admin")]

		// GET: Heroes/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var hero = await _context.Hero
				.FirstOrDefaultAsync(m => m.IDHero == id);
			if (hero == null)
			{
				return NotFound();
			}

			return View(hero);
		}

		// GET: Heroes/Create
		[Authorize(Roles = "Admin")]
		public IActionResult Create()
		{
			return View();
		}

		// POST: Heroes/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(IFormFile HeroPhoto, [Bind("IDHero,Titulo,Descricao,HeroPhoto,WebsiteURL")] Hero hero)
		{
			string destination = Path.Combine(_he.ContentRootPath, "wwwroot/Fotos/", Path.GetFileName(HeroPhoto.FileName));

			// Creates a filestream to store the file listing
			FileStream fs = new FileStream(destination, FileMode.Create);

			try
			{
				HeroPhoto.CopyTo(fs);
				fs.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}

			// path para depois guardar na base de dados
			hero.HeroPhoto = "/Fotos/" + HeroPhoto.FileName.ToString();

			ModelState.Clear();

			if (TryValidateModel(hero))
			{
				_context.Add(hero);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(hero);
		}

		// GET: Heroes/Edit/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var hero = await _context.Hero.FindAsync(id);
			if (hero == null)
			{
				return NotFound();
			}
			return View(hero);
		}

		// POST: Heroes/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("IDHero,Titulo,Descricao,HeroPhoto,WebsiteURL")] Hero hero)
		{
			if (id != hero.IDHero)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(hero);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!HeroExists(hero.IDHero))
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
			return View(hero);
		}

		// GET: Heroes/Delete/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var hero = await _context.Hero
				.FirstOrDefaultAsync(m => m.IDHero == id);
			if (hero == null)
			{
				return NotFound();
			}

			return View(hero);
		}

		// POST: Heroes/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var hero = await _context.Hero.FindAsync(id);
			_context.Hero.Remove(hero);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool HeroExists(int id)
		{
			return _context.Hero.Any(e => e.IDHero == id);
		}
	}
}