using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Trabalho_Laboratorio.Data;
using Trabalho_Laboratorio.Models;
using Trabalho_Laboratorio.Pagination;

namespace Trabalho_Laboratorio.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<ActionResult> Index(int? page)
		{
			// Definimos que queremos apresentar 20 produtos por página (no máximo)
			int pageSize = 20;

			// Obtém todos os produtos disponíveis na base de dados
			var pratos = _context.AgendarPrato.Include(x => x.IdPratoNavigation).Include(x => x.IdRestauranteNavigation).Select(x => x);

			List<AgendarPrato> pratos_destaque = pratos.Where(x => x.Destaque == true).ToList();

			// Retorna para o utilizador
			return View(await PaginatedListProducts<AgendarPrato>.CreateAsync(
				pratos.AsNoTracking(), page ?? 1, pageSize, pratos_destaque));
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}