using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho_Laboratorio.Helpers;
using Trabalho_Laboratorio.Models;

namespace Trabalho_Laboratorio.ViewModel
{
	public class AgendarPratosIndexViewModel : AgendarPrato
	{
		public Int64 Contagem { get; set; }

		public AgendarPratosIndexViewModel(AgendarPrato _prato, int _contagem)
		{
			// This copies all the properties from fruit to this instance
			this.FillProperties(_prato);
			// Now we can take care of the new properties
			this.Contagem = _contagem;
		}
	}
}