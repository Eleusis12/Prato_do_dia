using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho_Laboratorio.Models;
using Trabalho_Laboratorio.Pagination;

namespace Trabalho_Laboratorio.ViewModel
{
	public class HomePageViewModel
	{
		public PaginatedListProducts<AgendarPrato> ListaPratos { get; set; }
		public PaginatedListProducts<AgendarPrato> Destaque { get; set; }

		public IQueryable<Hero> Heroes { get; set; }
	}
}