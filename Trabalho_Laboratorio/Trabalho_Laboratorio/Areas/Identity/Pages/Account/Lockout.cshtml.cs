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
using Microsoft.Extensions.Logging;
using Trabalho_Laboratorio.Data;

namespace Trabalho_Laboratorio.Areas.Identity.Pages.Account
{
	[AllowAnonymous]
	public class LockoutModel : PageModel
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly ILogger<LoginModel> _logger;
		private readonly ApplicationDbContext _context;

		public LockoutModel(ApplicationDbContext context, SignInManager<IdentityUser> signInManager,
			ILogger<LoginModel> logger,
			UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
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

		public async Task OnGetAsync()
		{
			IdentityUser applicationUser = await _userManager.GetUserAsync(User);
			string UserName = applicationUser?.UserName; // will give the user's Email

			Input.Username = UserName;
			Input.MotivoBloqueio = _context.Bloqueio.FirstOrDefault(x => x.IdUtilizadorNavigation.Username == Input.Username).Motivo;
		}
	}
}