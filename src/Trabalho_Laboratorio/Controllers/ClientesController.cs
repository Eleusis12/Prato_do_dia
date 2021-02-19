using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabalho_Laboratorio.Data;
using Trabalho_Laboratorio.Models;

namespace Trabalho_Laboratorio.Controllers
{
	public class ClientesController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ClientesController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Clientes
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Clientes.Include(c => c.IdClienteNavigation);
			return View(await applicationDbContext.ToListAsync());
		}

		// GET: Clientes/Details/5
		public async Task<IActionResult> Detalhes(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var clientes = await _context.Clientes
				.Include(c => c.IdClienteNavigation)
				.FirstOrDefaultAsync(m => m.IdCliente == id);
			if (clientes == null)
			{
				return NotFound();
			}

			return View(clientes);
		}
	}
}