using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Trabalho_Laboratorio.Data;
using Trabalho_Laboratorio.Helpers.Enums;
using Trabalho_Laboratorio.Models;
using Trabalho_Laboratorio.Pagination;
using Trabalho_Laboratorio.ViewModel;

namespace Trabalho_Laboratorio.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_logger = logger;
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		private async Task<Utilizador> GetUtilizador()
		{
			IdentityUser applicationUser = await _userManager.GetUserAsync(User);
			string UserName = applicationUser?.UserName; // will give the user's Email

			// ID do Restaurante
			var utilizador = _context.Utilizador.FirstOrDefault(m => m.Username == UserName);
			return utilizador;
		}

		public async Task<ActionResult> Index(int? page, int? dia)
		{
			// Para efeitos eduacionais definimos o dia de hoje como sendo dia 30/12/2020 (uma vez que não estamos sempre a atualizar a base de dados com novos pratos)
			DateTime hoje = new DateTime(2020, 12, 30, 0, 0, 0);
			DateTime amanha = new DateTime(2020, 12, 31, 0, 0, 0);

			// Filtering 0- Hoje, 1- Amanhã
			dia = (dia == null ? 0 : dia);
			TempData["dayFilter"] = dia;

			// Definimos que queremos apresentar 20 produtos por página (no máximo)
			int pageSize = 5;

			// Obtém todos os produtos disponíveis na base de dados
			var pratos = _context.AgendarPrato.Include(x => x.IdPratoNavigation).Include(x => x.IdRestauranteNavigation).Select(x => x);

			// Obter informação de destaque para apresentar na página principal
			var informação_destaque = _context.Hero.Select(x => x);

			HomePageViewModel viewModel = new HomePageViewModel();
			viewModel.ListaPratos = await PaginatedListProducts<AgendarPrato>.CreateAsync(
				pratos.Where(x => x.DataMarcacao.Date == (dia == 0 ? hoje.Date : amanha.Date)).AsNoTracking(), page ?? 1, pageSize);
			viewModel.Destaque = await PaginatedListProducts<AgendarPrato>.CreateAsync(pratos.Where(z => z.Destaque == true).AsNoTracking(), 1, 5);

			viewModel.Heroes = informação_destaque;

			// Retorna para a view
			return View(viewModel);
		}

		public async Task<ActionResult> Search(int? page, string query)
		{
			ViewData["Notificacao_Query"] = "false";

			if (_signInManager.IsSignedIn(User))
			{
				Utilizador utilizador = await GetUtilizador();

				if (_context.PalavrasChave.FirstOrDefault(x => x.IdUtilizador == utilizador.IdUtilizador && x.Palavra == query) != null)
				{
					ViewData["Notificacao_Query"] = "true";
				}
			}
			else
			{
				ViewData["Notificacao_Query"] = "true";
			}

			// Definimos que queremos apresentar 20 produtos por página (no máximo)
			int pageSize = 20;

			// Obtém todos os produtos disponíveis na base de dados
			var pratos = _context.AgendarPrato.Include(x => x.IdPratoNavigation).Include(x => x.IdRestauranteNavigation).Select(x => x);
			var restaurantes = _context.Restaurante.Include(x => x.IdRestauranteNavigation).Select(x => x);

			if (!String.IsNullOrEmpty(query))
			{
				pratos = pratos.Where(s => s.IdPratoNavigation.Nome.Contains(query));
			}

			if (!String.IsNullOrEmpty(query))
			{
				restaurantes = restaurantes.Where(s => s.NomeRestaurante.Contains(query));
			}

			// Popular o View Model para apresentar ao utilizador
			SearchViewModel viewModel = new SearchViewModel();
			viewModel.Query = query;
			viewModel.Pratos = await PaginatedListProducts<AgendarPrato>.CreateAsync(
				pratos.AsNoTracking(), page ?? 1, pageSize);
			viewModel.Restaurantes = await PaginatedListProducts<Restaurante>.CreateAsync(
				restaurantes.AsNoTracking(), page ?? 1, pageSize);

			// Retorna para a view
			return View(viewModel);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult AboutUs()
		{
			return View();
		}

		public IActionResult TermsOfService()
		{
			return View();
		}

		public IActionResult ContactUs()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ContactUs(ContactViewModel C)
		{
			string Name = C.FirstName;
			string Email = C.Email;
			string subject = C.Subject;
			string Message = C.Message;
			string Country = C.Country;

			if (ModelState.IsValid)
			{
				var body = "<p>Olá {0} ({1})</p><p>Enviou a seguinte mensagem:</p><p>{2}</p>";
				var message = new MailMessage();
				message.To.Add(new MailAddress(Email));  // replace with valid value
				message.From = new MailAddress("RestauranteDeluxe@hotmail.com");  // replace with valid value
				message.Subject = subject;
				message.Body = string.Format(body, Name, Email, Message);
				message.IsBodyHtml = true;
				using (var smtp = new SmtpClient())
				{
					var credential = new NetworkCredential
					{
						UserName = "RestauranteDeluxe@hotmail.com",  // replace with valid value
						Password = "bpLFiA3UcQcGZvr"  // replace with valid value
					};
					smtp.UseDefaultCredentials = false;
					smtp.Credentials = credential;
					smtp.Host = "smtp.office365.com";//address webmail
					smtp.Port = 587;
					smtp.EnableSsl = true;

					try
					{
						await smtp.SendMailAsync(message);
						// Apresentar toast com mensagem de sucesso
						//Notification("Mensagem enviada com sucesso", NotificationType.success);
					}
					catch (SmtpFailedRecipientsException recipientsException)
					{
						_logger.LogError($"Failed recipients: {string.Join(", ", recipientsException.InnerExceptions.Select(fr => fr.FailedRecipient))}");
						//Apresentar toast com mensagem de erro
						//Notification("Não foi possível enviar a mensagem", NotificationType.error);
					}
					catch (SmtpFailedRecipientException recipientException)
					{
						_logger.LogError($"Failed recipient: {recipientException.FailedRecipient}");
						//Notification("Não foi possível enviar a mensagem", NotificationType.error);
					}
					catch (SmtpException smtpException)
					{
						_logger.LogError(smtpException.Message);
						//Notification("Não foi possível enviar a mensagem", NotificationType.error);
					}

					return RedirectToAction(nameof(Index));
				}
			}
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}