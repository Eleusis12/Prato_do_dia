using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabalho_Laboratorio.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            GuardarClientePratoFavorito = new HashSet<GuardarClientePratoFavorito>();
            GuardarClienteRestauranteFavorito = new HashSet<GuardarClienteRestauranteFavorito>();
        }

        [Key]
        [Column("ID_Cliente")]
        public int IdCliente { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [StringLength(20)]
        public string Apelido { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Utilizador.Clientes))]
        public virtual Utilizador IdClienteNavigation { get; set; }
        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<GuardarClientePratoFavorito> GuardarClientePratoFavorito { get; set; }
        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<GuardarClienteRestauranteFavorito> GuardarClienteRestauranteFavorito { get; set; }
    }
}
