using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabalho_Laboratorio.Models
{
	public partial class Prato
	{
		public Prato()
		{
			AgendarPrato = new HashSet<AgendarPrato>();
			GuardarClientePratoFavorito = new HashSet<GuardarClientePratoFavorito>();
		}

		[Key]
		[Column("ID_Prato")]
		public int IdPrato { get; set; }

		[Required]
		[StringLength(100)]
		public string Nome { get; set; }

		[Required]
		[Column("Tipo_Prato")]
		[StringLength(40)]
		public string TipoPrato { get; set; }

		[Required]
		[Column("Descricao_Default")]
		[StringLength(300)]
		public string DescricaoDefault { get; set; }

		[Required]
		[Column("Foto_Default")]
		[StringLength(500)]
		public string FotoDefault { get; set; }

		[InverseProperty("IdPratoNavigation")]
		public virtual ICollection<AgendarPrato> AgendarPrato { get; set; }

		[InverseProperty("IdPratoNavigation")]
		public virtual ICollection<GuardarClientePratoFavorito> GuardarClientePratoFavorito { get; set; }
	}
}