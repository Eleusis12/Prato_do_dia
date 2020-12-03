using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabalho_Laboratorio.Models
{
    [Table("Guardar_Cliente_Prato_Favorito")]
    public partial class GuardarClientePratoFavorito
    {
        [Key]
        [Column("ID_Cliente_Prato_Favorito")]
        public int IdClientePratoFavorito { get; set; }
        [Key]
        [Column("ID_Cliente")]
        public int IdCliente { get; set; }
        [Key]
        [Column("ID_Prato")]
        public int IdPrato { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Clientes.GuardarClientePratoFavorito))]
        public virtual Clientes IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdPrato))]
        [InverseProperty(nameof(Prato.GuardarClientePratoFavorito))]
        public virtual Prato IdPratoNavigation { get; set; }
    }
}
