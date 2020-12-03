using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Trabalho_Laboratorio.Models
{
    [Table("Guardar_Cliente_Restaurante_Favorito")]
    public partial class GuardarClienteRestauranteFavorito
    {
        [Key]
        [Column("ID_Cliente_Restaurante_Favorito")]
        public int IdClienteRestauranteFavorito { get; set; }
        [Key]
        [Column("ID_Cliente")]
        public int IdCliente { get; set; }
        [Key]
        [Column("ID_Restaurante")]
        public int IdRestaurante { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Cliente.GuardarClienteRestauranteFavoritos))]
        public virtual Cliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdRestaurante))]
        [InverseProperty(nameof(Restaurante.GuardarClienteRestauranteFavoritos))]
        public virtual Restaurante IdRestauranteNavigation { get; set; }
    }
}
