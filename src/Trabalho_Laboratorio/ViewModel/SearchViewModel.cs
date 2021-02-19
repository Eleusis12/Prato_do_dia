using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho_Laboratorio.Models;
using Trabalho_Laboratorio.Pagination;

namespace Trabalho_Laboratorio.ViewModel
{
	public class SearchViewModel
	{
		public string Query { get; set; }
		public PaginatedListProducts<AgendarPrato> Pratos { get; set; }
		public PaginatedListProducts<Restaurante> Restaurantes { get; set; }
	}
}