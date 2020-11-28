using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Trabalho_Laboratorio.Models
{
	[Table("Restaurante")]
	public partial class Restaurante
	{
		public Restaurante()
		{
			AgendarPratos = new HashSet<AgendarPrato>();
			GuardarClienteRestauranteFavoritos = new HashSet<GuardarClienteRestauranteFavorito>();
			Horarios = new HashSet<Horario>();
		}

		[Key]
		[Column("ID_Restaurante")]
		public int IdRestaurante { get; set; }

		[Required]
		[Column("Nome_Restaurante")]
		[Display(Name = "Nome do Restaurante")]
		[StringLength(100)]
		public string NomeRestaurante { get; set; }

		[Required]
		[StringLength(20)]
		public string Telefone { get; set; }

		[Required]
		[StringLength(500)]
		public string Foto { get; set; }

		[Column("Status_Restaurante")]
		[Display(Name = "Status")]
		public bool StatusRestaurante { get; set; }

		[Required]
		[Column("Tipo_Servico")]
		[Display(Name = "Tipo de Serviço")]
		[StringLength(40)]
		public string TipoServico { get; set; }

		[Required]
		[Column("Dia_De_Descanso")]
		[Display(Name = "Dia de Descanso")]
		[StringLength(20)]
		public string DiaDeDescanso { get; set; }

		[ForeignKey(nameof(IdRestaurante))]
		[InverseProperty(nameof(Utilizador.Restaurante))]
		public virtual Utilizador IdRestauranteNavigation { get; set; }

		[InverseProperty(nameof(AgendarPrato.IdRestauranteNavigation))]
		public virtual ICollection<AgendarPrato> AgendarPratos { get; set; }

		[InverseProperty(nameof(GuardarClienteRestauranteFavorito.IdRestauranteNavigation))]
		public virtual ICollection<GuardarClienteRestauranteFavorito> GuardarClienteRestauranteFavoritos { get; set; }

		[InverseProperty(nameof(Horario.IdRestauranteNavigation))]
		public virtual ICollection<Horario> Horarios { get; set; }
	}
}