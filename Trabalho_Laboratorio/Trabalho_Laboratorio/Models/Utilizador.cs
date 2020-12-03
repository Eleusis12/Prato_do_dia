using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabalho_Laboratorio.Models
{
	public partial class Utilizador
	{
		public Utilizador()
		{
			Bloqueio = new HashSet<Bloqueio>();
			PalavrasChave = new HashSet<PalavrasChave>();
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
		[RegularExpression(@"^\d{4}(-\d{3})$", ErrorMessage = "Must be a valid Postal Code")]
		public string EnderecoCodigoPostal { get; set; }

		[Required]
		[Column("Endereco_Localidade")]
		[StringLength(30)]
		[Display(Name = "Localidade")]
		public string EnderecoLocalidade { get; set; }

		[InverseProperty("IdAdminNavigation")]
		public virtual Administrador Administrador { get; set; }

		[InverseProperty("IdClienteNavigation")]
		public virtual Clientes Clientes { get; set; }

		[InverseProperty("IdRestauranteNavigation")]
		public virtual Restaurante Restaurante { get; set; }

		[InverseProperty("IdUtilizadorNavigation")]
		public virtual ICollection<Bloqueio> Bloqueio { get; set; }

		[InverseProperty("IdUtilizadorNavigation")]
		public virtual ICollection<PalavrasChave> PalavrasChave { get; set; }
	}
}