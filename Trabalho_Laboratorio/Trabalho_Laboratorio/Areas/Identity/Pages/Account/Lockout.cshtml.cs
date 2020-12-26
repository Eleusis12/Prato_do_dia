using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Trabalho_Laboratorio.Data;
using Trabalho_Laboratorio.Helpers.Encoding;

namespace Trabalho_Laboratorio.Areas.Identity.Pages.Account
{
	[AllowAnonymous]
	public class LockoutModel : PageModel
	{
		private readonly ILogger<LoginModel> _logger;
		private readonly ApplicationDbContext _context;

		public LockoutModel(ApplicationDbContext context,
			ILogger<LoginModel> logger)
		{
			_logger = logger;
			_context = context;
		}

		[BindProperty]
		public InputModel Input { get; set; }

		public class InputModel
		{
			[Required]
			[Display(Name = "User Name")]
			public string Username { get; set; }

			[Required]
			[Display(Name = "Motivo de Bloqueio")]
			public string MotivoBloqueio { get; set; }
		}

		public void OnGet(string value)
		{
			string usernameDecoded = System.Text.Encoding.UTF8.DecodeBase64(value);

			// Obter motivo da Ultima vez que foi bloqueado
			string motivoBloqueio = _context.Bloqueio
				.Include(x => x.IdUtilizadorNavigation)
				.Where(x => x.IdUtilizadorNavigation.Username == usernameDecoded)
				.OrderByDescending(x => x.IdBloqueio)
				.Take(1)
				.Select(x => x.Motivo)
				.ToList()
				.FirstOrDefault();

			Input = new InputModel
			{
				Username = usernameDecoded,
				MotivoBloqueio = motivoBloqueio
			};
		}
	}
}