using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Trabalho_Laboratorio.Models
{
	[Table("Utilizador")]
	public partial class Utilizador
	{
		public Utilizador()
		{
			Bloqueios = new HashSet<Bloqueio>();
			PalavrasChaves = new HashSet<PalavrasChave>();
		}

		[Key]
		[Column("ID_Utilizador")]
		public int IdUtilizador { get; set; }

		[Required]
		[StringLength(100)]
		public string Email { get; set; }

		public bool EmailConfirmado { get; set; }

		[Required]
		[StringLength(100)]
		public string Username { get; set; }

		[Required]
		[Column("_Password")]
		[StringLength(100)]
		public string Password { get; set; }

		[Required]
		[Column("Endereco_Morada")]
		[StringLength(50)]
		[Display(Name = "Morada")]
		public string EnderecoMorada { get; set; }

		[Required]
		[Column("Endereco_CodigoPostal")]
		[StringLength(8)]
		[Display(Name = "Código Postal")]
		public string EnderecoCodigoPostal { get; set; }

		[Required]
		[Column("Endereco_Localidade")]
		[StringLength(30)]
		[Display(Name = "Localidade")]
		public string EnderecoLocalidade { get; set; }

		[InverseProperty("IdAdminNavigation")]
		public virtual Administrador Administrador { get; set; }

		[InverseProperty("IdClienteNavigation")]
		public virtual Cliente Cliente { get; set; }

		[InverseProperty("IdRestauranteNavigation")]
		public virtual Restaurante Restaurante { get; set; }

		[InverseProperty(nameof(Bloqueio.IdUtilizadorNavigation))]
		public virtual ICollection<Bloqueio> Bloqueios { get; set; }

		[InverseProperty(nameof(PalavrasChave.IdUtilizadorNavigation))]
		public virtual ICollection<PalavrasChave> PalavrasChaves { get; set; }
	}
}