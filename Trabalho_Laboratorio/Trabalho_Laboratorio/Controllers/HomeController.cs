using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
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
	public class HomeController : Trabalho_Laboratorio.BaseController.BaseController
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
						Notification("Mensagem enviada com sucesso", NotificationType.success);
					}
					catch (SmtpFailedRecipientsException recipientsException)
					{
						_logger.LogError($"Failed recipients: {string.Join(", ", recipientsException.InnerExceptions.Select(fr => fr.FailedRecipient))}");
						Notification("Não foi possível enviar a mensagem", NotificationType.error);
					}
					catch (SmtpFailedRecipientException recipientException)
					{
						_logger.LogError($"Failed recipient: {recipientException.FailedRecipient}");
						Notification("Não foi possível enviar a mensagem", NotificationType.error);
					}
					catch (SmtpException smtpException)
					{
						_logger.LogError(smtpException.Message);
						Notification("Não foi possível enviar a mensagem", NotificationType.error);
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