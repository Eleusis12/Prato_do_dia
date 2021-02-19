using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho_Laboratorio.Models;

namespace Trabalho_Laboratorio.ViewModel
{
	public class AdminIndexViewModel
	{
		public IQueryable<Restaurante> ListaRestaurantes { get; set; }
		public IQueryable<AgendarPrato> ListaAgendamentos { get; set; }
		public Administrador Administrador { get; set; }
	}
}