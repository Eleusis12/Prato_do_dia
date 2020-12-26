using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trabalho_Laboratorio.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trabalho_Laboratorio.Controllers
{
	[Route("api/Application")]
	[ApiController]
	public class ApplicationRestController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public ApplicationRestController(ApplicationDbContext context)
		{
			_context = context;
		}

		[Produces("application/json")]
		[HttpGet("Search")]
		public IActionResult Search()
		{
			try
			{
				string term = HttpContext.Request.Query["term"].ToString();
				var nomesPratos = (from N in _context.Prato
								   where N.Nome.Contains(term)
								   select new { value = N.Nome });

				var nomesRestaurantes = (from N in _context.Restaurante
										 where N.NomeRestaurante.Contains(term)
										 select new { value = N.NomeRestaurante });
				return Ok(nomesPratos.Concat(nomesRestaurantes));
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}