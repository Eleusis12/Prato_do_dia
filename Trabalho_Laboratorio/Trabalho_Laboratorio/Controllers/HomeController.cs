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
	public class HomeController : Trabalho_Laboratorio.BaseController.BaseController
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
		{
			_logger = logger;
			_context = context;
			_userManager = userManager;
		}

		public async Task<ActionResult> Index(int? page)
		{
			// Definimos que queremos apresentar 20 produtos por página (no máximo)
			int pageSize = 20;

			// Obtém todos os produtos disponíveis na base de dados
			var pratos = _context.AgendarPrato.Include(x => x.IdPratoNavigation).Include(x => x.IdRestauranteNavigation).Select(x => x);

			// Obter informação de destaque para apresentar na página principal
			var informação_destaque = _context.Hero.Select(x => x);

			HomePageViewModel viewModel = new HomePageViewModel();
			viewModel.ListaPratos = await PaginatedListProducts<AgendarPrato>.CreateAsync(
				pratos.AsNoTracking(), page ?? 1, pageSize);
			viewModel.Destaque = await PaginatedListProducts<AgendarPrato>.CreateAsync(pratos.Where(z => z.Destaque == true).AsNoTracking(), 1, 5);

			viewModel.Heroes = informação_destaque;

			// Retorna para a view
			return View(viewModel);
		}

		[HttpPost]
		public async Task<string> AddQueryToFavoritesAsync(string query)
		{
			// For ASP.NET Core <= 3.1
			Utilizador utilizador = await GetUtilizador();
			PalavrasChave palavra = new PalavrasChave();

			// Se a palavra já foi adicionada anteriormente à base de dados
			if (_context.PalavrasChave.FirstOrDefault(x => x.IdUtilizador == utilizador.IdUtilizador && x.Palavra == query) != null)
			{
				return "";
			}
			// Adicionar à base de dados
			else
			{
				palavra.IdUtilizador = utilizador.IdUtilizador;
				palavra.Palavra = query;
				_context.PalavrasChave.Add(palavra);
				_context.SaveChanges();
			}
			return "Sucess";
		}

		[HttpPost]
		public async Task<string> AddDishToFavoritesAsync(int? id)
		{
			if (id == null)
			{
				return "";
			}

			// For ASP.NET Core <= 3.1
			Utilizador utilizador = await GetUtilizador();
			Prato prato = new Prato();

			//obter o prato de acordo com o id enviado
			prato = _context.Prato.FirstOrDefault(x => x.IdPrato == id);

			// Se o prato já foi adicionada anteriormente à base de dados como prato favorito do cliente em causa
			if (_context.GuardarClientePratoFavorito.FirstOrDefault(x => x.IdCliente == utilizador.IdUtilizador && x.IdPrato == id) != null)
			{
				return "";
			}
			// Adicionar à base de dados
			else
			{
				GuardarClientePratoFavorito prato_favorito = new GuardarClientePratoFavorito();

				prato_favorito.IdCliente = utilizador.IdUtilizador;
				prato_favorito.IdPrato = (int)id;
				_context.GuardarClientePratoFavorito.Add(prato_favorito);
				_context.SaveChanges();
			}
			return "Sucess";
		}

		[HttpPost]
		public async Task<string> AddRestauranteToFavoritesAsync(int? id)
		{
			if (id == null)
			{
				return "";
			}

			// For ASP.NET Core <= 3.1
			Utilizador utilizador = await GetUtilizador();
			Restaurante restaurante = new Restaurante();

			//obter o prato de acordo com o id enviado
			restaurante = _context.Restaurante.FirstOrDefault(x => x.IdRestaurante == id);

			// Se o prato já foi adicionada anteriormente à base de dados como prato favorito do cliente em causa
			if (_context.GuardarClienteRestauranteFavorito.FirstOrDefault(x => x.IdCliente == utilizador.IdUtilizador && x.IdRestaurante == id) != null)
			{
				return "";
			}
			// Adicionar à base de dados
			else
			{
				GuardarClienteRestauranteFavorito restaurante_favorito = new GuardarClienteRestauranteFavorito();

				restaurante_favorito.IdCliente = utilizador.IdUtilizador;
				restaurante_favorito.IdRestaurante = (int)id;
				_context.GuardarClienteRestauranteFavorito.Add(restaurante_favorito);
				_context.SaveChanges();
			}
			return "Sucess";
		}

		[HttpPost]
		public IActionResult RemoverPratoFavorito(int? id)
		{
			if (id == null)
			{
				return PartialView("~/Areas/Identity/Pages/Account/Manage/_PartialFavoritesDishes", _context.GuardarClientePratoFavorito.Include(m => m.IdPratoNavigation).Include(m => m.IdClienteNavigation).Select(x => x));
			}

			var PratoFavorito = _context.GuardarClientePratoFavorito.FirstOrDefault(x => x.IdClientePratoFavorito == id);

			// Vamos verificar se o id introduzido é válido
			if (PratoFavorito == null)
			{
				// Erro
				return PartialView("~/Areas/Identity/Pages/Account/Manage/_PartialFavoritesDishes", _context.GuardarClientePratoFavorito.Include(m => m.IdPratoNavigation).Include(m => m.IdClienteNavigation).Select(x => x));
			}
			// Remover Da Base de dados
			else
			{
				_context.GuardarClientePratoFavorito.Attach(PratoFavorito);
				_context.GuardarClientePratoFavorito.Remove(PratoFavorito);
				_context.SaveChanges();
			}

			// Retorna Sucesso
			return PartialView("~/Areas/Identity/Pages/Account/Manage/_PartialFavoritesDishes", _context.GuardarClientePratoFavorito.Include(m => m.IdPratoNavigation).Include(m => m.IdClienteNavigation).Select(x => x));
		}

		[HttpPost]
		public IActionResult RemoverRestauranteFavorito(int? id)
		{
			if (id == null)
			{
				return PartialView("~/Areas/Identity/Pages/Account/Manage/_PartialFavoritesRestaurants", _context.GuardarClienteRestauranteFavorito.Include(m => m.IdClienteNavigation).Include(m => m.IdRestauranteNavigation).Select(x => x));
			}

			var RestauranteFavorito = _context.GuardarClienteRestauranteFavorito.FirstOrDefault(x => x.IdClienteRestauranteFavorito == id);

			// Vamos verificar se o id introduzido é válido
			if (RestauranteFavorito == null)
			{
				// Erro
				return PartialView("~/Areas/Identity/Pages/Account/Manage/_PartialFavoritesRestaurants", _context.GuardarClienteRestauranteFavorito.Include(m => m.IdClienteNavigation).Include(m => m.IdRestauranteNavigation).Select(x => x));
			}
			// Remover Da Base de dados
			else
			{
				_context.GuardarClienteRestauranteFavorito.Attach(RestauranteFavorito);
				_context.GuardarClienteRestauranteFavorito.Remove(RestauranteFavorito);
				_context.SaveChanges();
			}

			// Retorna Sucesso
			return PartialView("~/Areas/Identity/Pages/Account/Manage/_PartialFavoritesRestaurants", _context.GuardarClienteRestauranteFavorito.Include(m => m.IdClienteNavigation).Include(m => m.IdRestauranteNavigation).Select(x => x));
		}

		private async Task<Utilizador> GetUtilizador()
		{
			IdentityUser applicationUser = await _userManager.GetUserAsync(User);
			string UserName = applicationUser?.UserName; // will give the user's Email

			// ID do Restaurante
			var utilizador = _context.Utilizador.FirstOrDefault(m => m.Username == UserName);
			return utilizador;
		}

		public async Task<ActionResult> Search(int? page, string query)
		{
			Utilizador utilizador = await GetUtilizador();

			if (_context.PalavrasChave.FirstOrDefault(x => x.IdUtilizador == utilizador.IdUtilizador && x.Palavra == query) != null)
			{
				ViewData["Notificacao"] = "true";
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