using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Trabalho_Laboratorio.Models
{
    [Table("Prato")]
    public partial class Prato
    {
        public Prato()
        {
            AgendarPratos = new HashSet<AgendarPrato>();
            GuardarClientePratoFavoritos = new HashSet<GuardarClientePratoFavorito>();
        }

        [Key]
        [Column("ID_Prato")]
        public int IdPrato { get; set; }
        [Required]
        [Column("Tipo_Prato")]
        [StringLength(40)]
        public string TipoPrato { get; set; }
        [Required]
        [Column("Descricao_Default")]
        [StringLength(300)]
        public string DescricaoDefault { get; set; }
        [Required]
        [Column("Foto_Default")]
        [StringLength(500)]
        public string FotoDefault { get; set; }

        [InverseProperty(nameof(AgendarPrato.IdPratoNavigation))]
        public virtual ICollection<AgendarPrato> AgendarPratos { get; set; }
        [InverseProperty(nameof(GuardarClientePratoFavorito.IdPratoNavigation))]
        public virtual ICollection<GuardarClientePratoFavorito> GuardarClientePratoFavoritos { get; set; }
    }
}
