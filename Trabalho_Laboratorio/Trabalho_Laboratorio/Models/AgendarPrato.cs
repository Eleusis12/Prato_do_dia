using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabalho_Laboratorio.Models
{
	[Table("Agendar_Prato")]
	public partial class AgendarPrato
	{
		[Key]
		[Column("ID_Agendamento")]
		public int IdAgendamento { get; set; }

		[Key]
		[Column("Data_Marcacao", TypeName = "datetime")]
		[Display(Name = "Marcar para o dia")]
		public DateTime DataMarcacao { get; set; }

		[Key]
		[Column("Data_Do_Agendamento", TypeName = "datetime")]
		public DateTime DataDoAgendamento { get; set; }

		[Key]
		[Column("ID_Restaurante")]
		public int IdRestaurante { get; set; }

		[Key]
		[Column("ID_Prato")]
		public int IdPrato { get; set; }

		[Required]
		[Column("Descricao_Extra")]
		[Display(Name = "Descrição")]
		[StringLength(300)]
		public string DescricaoExtra { get; set; }

		[Required]
		[Column("Foto_Extra")]
		[Display(Name = "Foto")]
		[StringLength(500)]
		public string FotoExtra { get; set; }

		public decimal Preco { get; set; }
		public bool Destaque { get; set; }

		[ForeignKey(nameof(IdPrato))]
		[InverseProperty(nameof(Prato.AgendarPrato))]
		public virtual Prato IdPratoNavigation { get; set; }

		[ForeignKey(nameof(IdRestaurante))]
		[InverseProperty(nameof(Restaurante.AgendarPrato))]
		public virtual Restaurante IdRestauranteNavigation { get; set; }
	}
}