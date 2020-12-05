﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabalho_Laboratorio.Data;
using Trabalho_Laboratorio.Models;

namespace Trabalho_Laboratorio.Controllers
{
	public class RestaurantesController : Controller
	{
		private readonly ApplicationDbContext _context;

		public RestaurantesController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Restaurantes

		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Restaurante.Include(r => r.IdRestauranteNavigation);
			return View(await applicationDbContext.ToListAsync());
		}

		// GET: Restaurantes/Details/5
		public async Task<IActionResult> Detalhes(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var restaurante = await _context.Restaurante
				.Include(r => r.IdRestauranteNavigation)
				.FirstOrDefaultAsync(m => m.IdRestaurante == id);
			if (restaurante == null)
			{
				return NotFound();
			}

			return View(restaurante);
		}

		// GET: Restaurantes/Create
		public IActionResult Create()
		{
			ViewData["IdRestaurante"] = new SelectList(_context.Utilizador, "IdUtilizador", "Email");
			return View();
		}

		// POST: Restaurantes/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("IdRestaurante,NomeRestaurante,Telefone,Foto,StatusRestaurante,TipoServico,DiaDeDescanso")] Restaurante restaurante)
		{
			if (ModelState.IsValid)
			{
				_context.Add(restaurante);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["IdRestaurante"] = new SelectList(_context.Utilizador, "IdUtilizador", "Email", restaurante.IdRestaurante);
			return View(restaurante);
		}

		// GET: Restaurantes/Edit/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var restaurante = await _context.Restaurante.FindAsync(id);
			if (restaurante == null)
			{
				return NotFound();
			}
			ViewData["IdRestaurante"] = new SelectList(_context.Utilizador, "IdUtilizador", "Email", restaurante.IdRestaurante);
			return View(restaurante);
		}

		// POST: Restaurantes/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("IdRestaurante,NomeRestaurante,Telefone,Foto,StatusRestaurante,TipoServico,DiaDeDescanso")] Restaurante restaurante)
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
			ViewData["IdRestaurante"] = new SelectList(_context.Utilizador, "IdUtilizador", "Email", restaurante.IdRestaurante);
			return View(restaurante);
		}

		// GET: Restaurantes/Delete/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var restaurante = await _context.Restaurante
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
			var restaurante = await _context.Restaurante.FindAsync(id);
			_context.Restaurante.Remove(restaurante);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool RestauranteExists(int id)
		{
			return _context.Restaurante.Any(e => e.IdRestaurante == id);
		}
	}
}