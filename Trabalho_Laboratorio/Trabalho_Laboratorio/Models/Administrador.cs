using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Trabalho_Laboratorio.Models
{
    [Table("Administrador")]
    public partial class Administrador
    {
        [Key]
        [Column("ID_Admin")]
        public int IdAdmin { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [StringLength(20)]
        public string Apelido { get; set; }

        [ForeignKey(nameof(IdAdmin))]
        [InverseProperty(nameof(Utilizador.Administrador))]
        public virtual Utilizador IdAdminNavigation { get; set; }
    }
}
