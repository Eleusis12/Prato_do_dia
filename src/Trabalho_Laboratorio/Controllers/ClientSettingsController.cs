using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Trabalho_Laboratorio.Data;
using Trabalho_Laboratorio.Models;

namespace Trabalho_Laboratorio.Controllers
{
	public class ClientSettingsController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;

		public ClientSettingsController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
		{
			_logger = logger;
			_context = context;
			_userManager = userManager;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddQueryToFavoritesAsync(string query)
		{
			// For ASP.NET Core <= 3.1
			Utilizador utilizador = await GetUtilizador();
			PalavrasChave palavra = new PalavrasChave();

			// Se a palavra já foi adicionada anteriormente à base de dados
			if (_context.PalavrasChave.FirstOrDefault(x => x.IdUtilizador == utilizador.IdUtilizador && x.Palavra == query) != null)
			{
				// Erro porque em primeiro lugar, o utilizador não deveria ter acesso a este botão
				_logger.LogWarning("Utilizador tentou adicionador palavra já existente na sua base de dados");
				return StatusCode(500);
			}
			// Adicionar à base de dados
			else
			{
				palavra.IdUtilizador = utilizador.IdUtilizador;
				palavra.Palavra = query;
				_context.PalavrasChave.Add(palavra);
				_context.SaveChanges();
			}
			ViewData["Notificacao_Query"] = "true";
			return Ok();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddDishToFavoritesAsync(int? id)
		{
			if (id == null)
			{
				return BadRequest();
			}

			// For ASP.NET Core <= 3.1
			Utilizador utilizador = await GetUtilizador();
			Prato prato = new Prato();

			//obter o prato de acordo com o id enviado
			prato = _context.Prato.FirstOrDefault(x => x.IdPrato == id);

			// Se o prato já foi adicionada anteriormente à base de dados como prato favorito do cliente em causa
			if (_context.GuardarClientePratoFavorito.FirstOrDefault(x => x.IdCliente == utilizador.IdUtilizador && x.IdPrato == id) != null)
			{
				_logger.LogWarning("Utilizador tentou adicionador prato favorito já existente na sua base de dados");
				return StatusCode(500);
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
			ViewData["Notificacao_Prato"] = "true";
			return Ok();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddRestauranteToFavoritesAsync(int? id)
		{
			if (id == null)
			{
				return BadRequest();
			}

			// For ASP.NET Core <= 3.1
			Utilizador utilizador = await GetUtilizador();
			Restaurante restaurante = new Restaurante();

			//obter o prato de acordo com o id enviado
			restaurante = _context.Restaurante.FirstOrDefault(x => x.IdRestaurante == id);

			// Se o prato já foi adicionada anteriormente à base de dados como prato favorito do cliente em causa
			if (_context.GuardarClienteRestauranteFavorito.FirstOrDefault(x => x.IdCliente == utilizador.IdUtilizador && x.IdRestaurante == id) != null)
			{
				_logger.LogWarning("Utilizador tentou adicionador restaurante favorito já existente na sua base de dados");
				return StatusCode(500);
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
			ViewData["Notificacao_Restaurante"] = "true";
			return Ok();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult RemoverPratoFavorito(int? id)
		{
			if (id == null)
			{
				return BadRequest();
			}

			var PratoFavorito = _context.GuardarClientePratoFavorito.FirstOrDefault(x => x.IdClientePratoFavorito == id);

			// Vamos verificar se o id introduzido é válido
			if (PratoFavorito == null)
			{
				// Erro
				return StatusCode(500);
			}
			// Remover Da Base de dados
			else
			{
				_context.GuardarClientePratoFavorito.Attach(PratoFavorito);
				_context.GuardarClientePratoFavorito.Remove(PratoFavorito);
				_context.SaveChanges();
			}
			// Retorna Sucesso
			var ListaPratosFavoritos = _context.GuardarClientePratoFavorito.Include(x => x.IdClienteNavigation).Include(x => x.IdPratoNavigation).Include(x => x.IdClienteNavigation.IdClienteNavigation).Where(x => x.IdCliente == PratoFavorito.IdCliente);
			return PartialView("~/Areas/Identity/Pages/Account/Manage/_PartialFavoritesDishes.cshtml", ListaPratosFavoritos);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult RemoverRestauranteFavorito(int? id)
		{
			if (id == null)
			{
				return BadRequest();
			}

			var RestauranteFavorito = _context.GuardarClienteRestauranteFavorito.FirstOrDefault(x => x.IdClienteRestauranteFavorito == id);

			// Vamos verificar se o id introduzido é válido
			if (RestauranteFavorito == null)
			{
				// Erro
				return StatusCode(500);
			}
			// Remover Da Base de dados
			else
			{
				_context.GuardarClienteRestauranteFavorito.Attach(RestauranteFavorito);
				_context.GuardarClienteRestauranteFavorito.Remove(RestauranteFavorito);
				_context.SaveChanges();
			}

			// Retorna Sucesso
			var ListaRestaurantesFavoritos = _context.GuardarClienteRestauranteFavorito.Include(x => x.IdClienteNavigation).Include(x => x.IdRestauranteNavigation).Include(x => x.IdClienteNavigation.IdClienteNavigation).Where(x => x.IdClienteRestauranteFavorito == RestauranteFavorito.IdClienteRestauranteFavorito);
			return PartialView("~/Areas/Identity/Pages/Account/Manage/_PartialFavoritesRestaurants.cshtml", ListaRestaurantesFavoritos);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult RemoverAlerta(int? id)
		{
			if (id == null)
			{
				// Erro
				return BadRequest();
			}

			var palavraChave = _context.PalavrasChave.FirstOrDefault(x => x.IdPalavrasChave == id);

			// Vamos verificar se o id introduzido é válido
			if (palavraChave == null)
			{
				// Erro
				return StatusCode(500);
			}
			// Remover Da Base de dados
			else
			{
				_context.PalavrasChave.Attach(palavraChave);
				_context.PalavrasChave.Remove(palavraChave);
				_context.SaveChanges();
			}

			// Retorna Sucesso
			var ListaPalavrasChave = _context.PalavrasChave.Include(x => x.IdUtilizadorNavigation).Where(x => x.IdUtilizador == palavraChave.IdUtilizador);
			return PartialView("~/Areas/Identity/Pages/Account/Manage/_PartialAlerts.cshtml", ListaPalavrasChave);
		}

		// GET
		public IActionResult EditarAlerta(int? id)
		{
			PalavrasChave alerta = _context.PalavrasChave.SingleOrDefault(x => x.IdPalavrasChave == id);
			return PartialView("EditarAlerta", alerta);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public string EditarAlerta(int id, PalavrasChave palavrasChave)
		{
			PalavrasChave alerta = null;
			try
			{
				alerta = _context.PalavrasChave.SingleOrDefault(x => x.IdPalavrasChave == id);
				alerta.Palavra = palavrasChave.Palavra;
				_context.SaveChanges();
				return palavrasChave.Palavra;
			}
			catch
			{
				_logger.LogError("Erro ao editar alerta");
				return alerta.Palavra ?? "Error";
			}
		}

		private async Task<Utilizador> GetUtilizador()
		{
			IdentityUser applicationUser = await _userManager.GetUserAsync(User);
			string UserName = applicationUser?.UserName; // will give the user's Email

			// ID do Restaurante
			var utilizador = _context.Utilizador.FirstOrDefault(m => m.Username == UserName);
			return utilizador;
		}
	}
}