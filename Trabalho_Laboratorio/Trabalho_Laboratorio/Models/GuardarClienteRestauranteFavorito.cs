using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [InverseProperty(nameof(Clientes.GuardarClienteRestauranteFavorito))]
        public virtual Clientes IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdRestaurante))]
        [InverseProperty(nameof(Restaurante.GuardarClienteRestauranteFavorito))]
        public virtual Restaurante IdRestauranteNavigation { get; set; }
    }
}
