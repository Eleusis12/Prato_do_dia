using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

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
        [InverseProperty(nameof(Cliente.GuardarClientePratoFavoritos))]
        public virtual Cliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdPrato))]
        [InverseProperty(nameof(Prato.GuardarClientePratoFavoritos))]
        public virtual Prato IdPratoNavigation { get; set; }
    }
}
