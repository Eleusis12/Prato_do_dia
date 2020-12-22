using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Trabalho_Laboratorio.Data;
using Trabalho_Laboratorio.Models;

namespace Trabalho_Laboratorio.Controllers
{
	public class AgendarPratosController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IHostEnvironment _he;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IEmailSender _emailSender;

		public AgendarPratosController(ApplicationDbContext context, IHostEnvironment host,
			UserManager<IdentityUser> userManager, IEmailSender emailSender)
		{
			_context = context;
			_he = host;
			_userManager = userManager;
			_emailSender = emailSender;
		}

		// GET: AgendarPratos
		[Authorize(Roles = "Restaurant")]
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.AgendarPrato.Include(a => a.IdPratoNavigation).Include(a => a.IdRestauranteNavigation);
			return View(await applicationDbContext.ToListAsync());
		}

		// GET: AgendarPratos/Details/5
		public async Task<IActionResult> Detalhes(int? id)
		{
			Utilizador utilizador = await GetUtilizador();

			if (_context.GuardarClientePratoFavorito.FirstOrDefault(x => x.IdCliente == utilizador.IdUtilizador && x.IdPrato == id) != null)
			{
				ViewData["Notificacao"] = "true";
			}

			if (id == null)
			{
				return NotFound();
			}

			var agendarPrato = await _context.AgendarPrato
				.Include(a => a.IdPratoNavigation)
				.Include(a => a.IdRestauranteNavigation)
				.FirstOrDefaultAsync(m => m.IdAgendamento == id);
			if (agendarPrato == null)
			{
				return NotFound();
			}

			return View(agendarPrato);
		}

		private async Task<Utilizador> GetUtilizador()
		{
			IdentityUser applicationUser = await _userManager.GetUserAsync(User);
			string UserName = applicationUser?.UserName; // will give the user's Email

			// ID do Restaurante
			var utilizador = _context.Utilizador.FirstOrDefault(m => m.Username == UserName);
			return utilizador;
		}

		[Authorize(Roles = "Restaurant,Admin")]
		public async Task<IActionResult> AdicionarAsync()
		{
			// For ASP.NET Core <= 3.1
			IdentityUser applicationUser = await _userManager.GetUserAsync(User);
			string UserName = applicationUser?.UserName; // will give the user's Email

			// Obter o restaurante (utilizador)
			var utilizador = _context.Restaurante.Include(x => x.IdRestauranteNavigation).FirstOrDefault(m => m.IdRestauranteNavigation.Username == UserName);
			if (utilizador.StatusRestaurante == false)
			{
				// Se o restaurante ainda não está aprovado, retorna a a seguinte mensagem
				return View("Acesso Negado: Aguarde que o administrador aprove o seu pedido de registo");
			}

			ViewData["IdPrato"] = new SelectList(_context.Prato, "IdPrato", "Nome");
			ViewData["Tipo_Prato"] = new SelectList(new List<string> { "Carne", "Peixe", "Vegan" });
			return View();
		}

		// POST: AgendarPratos/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Adicionar(string Nome, string Tipo_Prato, IFormFile FotoExtra, [Bind("IdAgendamento,DataMarcacao,DataDoAgendamento,IdRestaurante,IdPrato,DescricaoExtra,FotoExtra,Preco,Destaque")] AgendarPrato agendarPrato)
		{
			string destination = Path.Combine(_he.ContentRootPath, "wwwroot/Fotos/", Path.GetFileName(FotoExtra.FileName));

			// Creates a filestream to store the file listing
			FileStream fs = new FileStream(destination, FileMode.Create);

			try
			{
				FotoExtra.CopyTo(fs);
				fs.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

			// For ASP.NET Core <= 3.1
			IdentityUser applicationUser = await _userManager.GetUserAsync(User);
			string UserName = applicationUser?.UserName; // will give the user's Email

			// ID do Restaurante
			var utilizador = _context.Utilizador.FirstOrDefault(m => m.Username == UserName);
			agendarPrato.IdRestaurante = utilizador.IdUtilizador;

			// path para depois guardar na base de dados
			agendarPrato.FotoExtra = "/Fotos/" + FotoExtra.FileName.ToString();

			// Não foi selecionado Prato da Lista
			if (agendarPrato.IdPrato == -1)
			{
				Prato prato = new Prato { Nome = Nome, TipoPrato = Tipo_Prato, FotoDefault = agendarPrato.FotoExtra, DescricaoDefault = agendarPrato.DescricaoExtra };
				_context.Prato.Add(prato);
				await _context.SaveChangesAsync();

				agendarPrato.IdPrato = prato.IdPrato;
			}

			agendarPrato.DataDoAgendamento = DateTime.Today;
			// Limpar os erros
			ModelState.Clear();

			if (TryValidateModel(agendarPrato))
			{
				_context.Add(agendarPrato);
				await _context.SaveChangesAsync();

				// O prato foi introduzido na base de dados, agora temos que notificar os utilizadores que pretendem ser notificados
				var utilizadoresANotificar = _context.GuardarClientePratoFavorito.Include(x => x.IdClienteNavigation).Include(x => x.IdClienteNavigation.IdClienteNavigation).Where(x => x.IdPrato == agendarPrato.IdPrato);

				// Há utilizadores para notificar
				if (utilizadoresANotificar != null)
				{
					foreach (var user in utilizadoresANotificar)
					{
						await _emailSender.SendEmailAsync(user.IdClienteNavigation.IdClienteNavigation.Email, $"RestaurantesDeluxe:'{agendarPrato.IdPratoNavigation.Nome} adicionado '",
						$"Venha provar o novo prato, confecionado pelo {agendarPrato.IdRestauranteNavigation.NomeRestaurante}");
					}
				}

				var utilizadoresANotificar2 = _context.PalavrasChave.Include(x => x.IdUtilizadorNavigation).Where(x => x.Palavra.Contains(agendarPrato.IdPratoNavigation.Nome));

				// Há utilizadores para notificar

				if (utilizadoresANotificar != null)
				{
					foreach (var user in utilizadoresANotificar)
					{
						await _emailSender.SendEmailAsync(user.IdClienteNavigation.IdClienteNavigation.Email, $"RestaurantesDeluxe:'{agendarPrato.IdPratoNavigation.Nome} adicionado '",
						$"Venha provar o novo prato, confecionado pelo {agendarPrato.IdRestauranteNavigation.NomeRestaurante}");
					}
				}
				return RedirectToAction(nameof(Index));
			}

			ViewData["IdPrato"] = new SelectList(_context.Prato, "IdPrato", "DescricaoDefault", agendarPrato.IdPrato);
			ViewData["IdRestaurante"] = new SelectList(_context.Restaurante, "IdRestaurante", "DiaDeDescanso", agendarPrato.IdRestaurante);
			return View(agendarPrato);
		}

		// GET: AgendarPratos/Edit/5
		[Authorize(Roles = "Restaurant,Admin")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var agendarPrato = await _context.AgendarPrato.FindAsync(id);
			if (agendarPrato == null)
			{
				return NotFound();
			}
			ViewData["IdPrato"] = new SelectList(_context.Prato, "IdPrato", "DescricaoDefault", agendarPrato.IdPrato);
			ViewData["IdRestaurante"] = new SelectList(_context.Restaurante, "IdRestaurante", "DiaDeDescanso", agendarPrato.IdRestaurante);
			return View(agendarPrato);
		}

		// POST: AgendarPratos/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("IdAgendamento,DataMarcacao,DataDoAgendamento,IdRestaurante,IdPrato,DescricaoExtra,FotoExtra,Preco,Destaque")] AgendarPrato agendarPrato)
		{
			if (id != agendarPrato.IdAgendamento)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(agendarPrato);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!AgendarPratoExists(agendarPrato.IdAgendamento))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["IdPrato"] = new SelectList(_context.Prato, "IdPrato", "DescricaoDefault", agendarPrato.IdPrato);
			ViewData["IdRestaurante"] = new SelectList(_context.Restaurante, "IdRestaurante", "DiaDeDescanso", agendarPrato.IdRestaurante);
			return View(agendarPrato);
		}

		// GET: AgendarPratos/Delete/5
		[Authorize(Roles = "Restaurant,Admin")]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var agendarPrato = await _context.AgendarPrato
				.Include(a => a.IdPratoNavigation)
				.Include(a => a.IdRestauranteNavigation)
				.FirstOrDefaultAsync(m => m.IdAgendamento == id);
			if (agendarPrato == null)
			{
				return NotFound();
			}

			return View(agendarPrato);
		}

		// POST: AgendarPratos/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var agendarPrato = await _context.AgendarPrato.FindAsync(id);
			_context.AgendarPrato.Remove(agendarPrato);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool AgendarPratoExists(int id)
		{
			return _context.AgendarPrato.Any(e => e.IdAgendamento == id);
		}
	}
}