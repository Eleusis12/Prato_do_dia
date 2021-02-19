using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho_Laboratorio.Models;

namespace Trabalho_Laboratorio.ViewModel
{
	public class AdminCreateNewAdminViewModel
	{
		public Utilizador Utilizador { get; set; }
		public Administrador Administrador { get; set; }
		public Administrador AdministradorACriar { get; set; }

		public string Password { get; set; }
	}
}