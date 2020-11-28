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
		private readonly RestaurantesContext _context;

		public HomeController(ILogger<HomeController> logger, RestaurantesContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<IActionResult> Index(int? page)
		{
			// Obtém todos os pratos do dia disponíveis na base de dados
			var produtos = _context.Pratos.Include(x => x.AgendarPratos).Include(x => x.AgendarPratos).Select(x => x);

			// Definimos que queremos apresentar 20 produtos por página (no máximo)
			int pageSize = 20;

			// Retorna todos os produtos
			return View(await PaginatedListProducts<Prato>.CreateAsync(
			produtos.AsNoTracking(), page ?? 1, pageSize));
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