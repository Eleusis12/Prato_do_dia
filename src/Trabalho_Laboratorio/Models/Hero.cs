using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Trabalho_Laboratorio.Helpers;

namespace Trabalho_Laboratorio.Models
{
	public class Hero
	{
		[Key]
		[Column("ID_Hero")]
		public int IDHero { get; set; }

		[Column("Titulo")]
		[StringLength(150)]
		[Required]
		public string Titulo { get; set; }

		[Required]
		[Column("Descricao")]
		[StringLength(400)]
		public string Descricao { get; set; }

		[Required]
		[Display(Name = "Imagem")]
		[StringLength(500)]
		public string HeroPhoto { get; set; }

		[Required]
		[Display(Name = "Url de referência")]
		[StringLength(500)]
		[Url]
		public string WebsiteURL { get; set; }
	}
}