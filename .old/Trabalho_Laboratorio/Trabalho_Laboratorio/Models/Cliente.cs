using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Trabalho_Laboratorio.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            GuardarClientePratoFavoritos = new HashSet<GuardarClientePratoFavorito>();
            GuardarClienteRestauranteFavoritos = new HashSet<GuardarClienteRestauranteFavorito>();
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
        [InverseProperty(nameof(Utilizador.Cliente))]
        public virtual Utilizador IdClienteNavigation { get; set; }
        [InverseProperty(nameof(GuardarClientePratoFavorito.IdClienteNavigation))]
        public virtual ICollection<GuardarClientePratoFavorito> GuardarClientePratoFavoritos { get; set; }
        [InverseProperty(nameof(GuardarClienteRestauranteFavorito.IdClienteNavigation))]
        public virtual ICollection<GuardarClienteRestauranteFavorito> GuardarClienteRestauranteFavoritos { get; set; }
    }
}
