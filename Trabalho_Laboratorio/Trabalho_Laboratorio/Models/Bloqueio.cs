using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Trabalho_Laboratorio.Models
{
    [Table("Bloqueio")]
    public partial class Bloqueio
    {
        [Key]
        [Column("ID_Bloqueio")]
        public int IdBloqueio { get; set; }
        [Key]
        [Column("ID_Utilizador")]
        public int IdUtilizador { get; set; }
        [Required]
        [StringLength(500)]
        public string Motivo { get; set; }

        [ForeignKey(nameof(IdUtilizador))]
        [InverseProperty(nameof(Utilizador.Bloqueios))]
        public virtual Utilizador IdUtilizadorNavigation { get; set; }
    }
}
