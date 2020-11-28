using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabalho_Laboratorio.Data;
using Trabalho_Laboratorio.Helpers;
using Trabalho_Laboratorio.Models;

namespace Trabalho_Laboratorio.Controllers
{
	public class UtilizadoresController : Controller
	{
		private readonly RestaurantesContext _context;

		public UtilizadoresController(RestaurantesContext context)
		{
			_context = context;
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(string username, string password)
		{
			if (ModelState.IsValid)
			{
				string passwordHash = Sha256Hash.ComputeSha256Hash(password);
				Utilizador u = _context.Utilizadors.SingleOrDefault(u => u.Username == username && u.Password == passwordHash);
				if (u == null)
				{
					ModelState.AddModelError("username", "username or password are wrong");
				}
				else
				{
					// the user is authenticated
					// the session variable "user" is created to recover the user identity at each request

					HttpContext.Session.SetString("user", username);

					return RedirectToAction("Index", "Home");
				}
			}
			return View();
		}

		public IActionResult Logout()
		{
			HttpContext.Response.Cookies.Delete(".Class08b.Session");

			return RedirectToAction("Index", "Home");
		}

		//// GET: Utilizadores
		//public async Task<IActionResult> Index()
		//{
		//    return View(await _context.Utilizadors.ToListAsync());
		//}

		//// GET: Utilizadores/Details/5
		//public async Task<IActionResult> Details(int? id)
		//{
		//    if (id == null)
		//    {
		//        return NotFound();
		//    }

		//    var utilizador = await _context.Utilizadors
		//        .FirstOrDefaultAsync(m => m.IdUtilizador == id);
		//    if (utilizador == null)
		//    {
		//        return NotFound();
		//    }

		//    return View(utilizador);
		//}

		// GET: Utilizadores/Create
		public IActionResult Registar()
		{
			return View();
		}

		// POST: Utilizadores/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Registar([Bind("IdUtilizador,Email,EmailConfirmado,Username,Password,EnderecoMorada,EnderecoCodigoPostal,EnderecoLocalidade")] Utilizador utilizador, int Tipo)
		{
			// Assegurar que o email confirmado é falso
			utilizador.EmailConfirmado = false;

			// Para o caso de o utilizador tentar fazer o POST com outros valores
			if (Tipo != 1 && Tipo != 2)
			{
				ViewData["Tipo_Cliente"] = "Tipo de Cliente não existe";
				return RedirectToAction(nameof(Index));
			}
			else
			{
				ViewData["Tipo_Cliente"] = null;
			}

			if (ModelState.IsValid)
			{
				utilizador.Password = Sha256Hash.ComputeSha256Hash(utilizador.Password);
				_context.Add(utilizador);
				await _context.SaveChangesAsync();

				HttpContext.Session.SetInt32("id", utilizador.IdUtilizador);

				// Tenta Registar a parte do Cliente ou do Restaurante
				return Tipo == 1 ? RedirectToAction("Registar", "Clientes") : RedirectToAction("Registar", "Restaurantes");
			}
			return View(utilizador);
		}

		//// GET: Utilizadores/Edit/5
		//public async Task<IActionResult> Edit(int? id)
		//{
		//    if (id == null)
		//    {
		//        return NotFound();
		//    }

		//    var utilizador = await _context.Utilizadors.FindAsync(id);
		//    if (utilizador == null)
		//    {
		//        return NotFound();
		//    }
		//    return View(utilizador);
		//}

		//// POST: Utilizadores/Edit/5
		//// To protect from overposting attacks, enable the specific properties you want to bind to, for
		//// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Edit(int id, [Bind("IdUtilizador,Email,EmailConfirmado,Username,Password,EnderecoMorada,EnderecoCodigoPostal,EnderecoLocalidade")] Utilizador utilizador)
		//{
		//    if (id != utilizador.IdUtilizador)
		//    {
		//        return NotFound();
		//    }

		//    if (ModelState.IsValid)
		//    {
		//        try
		//        {
		//            _context.Update(utilizador);
		//            await _context.SaveChangesAsync();
		//        }
		//        catch (DbUpdateConcurrencyException)
		//        {
		//            if (!UtilizadorExists(utilizador.IdUtilizador))
		//            {
		//                return NotFound();
		//            }
		//            else
		//            {
		//                throw;
		//            }
		//        }
		//        return RedirectToAction(nameof(Index));
		//    }
		//    return View(utilizador);
		//}

		//// GET: Utilizadores/Delete/5
		//public async Task<IActionResult> Delete(int? id)
		//{
		//    if (id == null)
		//    {
		//        return NotFound();
		//    }

		//    var utilizador = await _context.Utilizadors
		//        .FirstOrDefaultAsync(m => m.IdUtilizador == id);
		//    if (utilizador == null)
		//    {
		//        return NotFound();
		//    }

		//    return View(utilizador);
		//}

		//// POST: Utilizadores/Delete/5
		//[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> DeleteConfirmed(int id)
		//{
		//    var utilizador = await _context.Utilizadors.FindAsync(id);
		//    _context.Utilizadors.Remove(utilizador);
		//    await _context.SaveChangesAsync();
		//    return RedirectToAction(nameof(Index));
		//}

		//private bool UtilizadorExists(int id)
		//{
		//    return _context.Utilizadors.Any(e => e.IdUtilizador == id);
		//}
	}
}