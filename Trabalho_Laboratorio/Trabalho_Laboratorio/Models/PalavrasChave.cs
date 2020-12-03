using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabalho_Laboratorio.Models
{
    [Table("Palavras_Chave")]
    public partial class PalavrasChave
    {
        [Key]
        [Column("ID_Palavras_Chave")]
        public int IdPalavrasChave { get; set; }
        [Key]
        [Column("ID_Utilizador")]
        public int IdUtilizador { get; set; }
        [Required]
        [StringLength(150)]
        public string Palavra { get; set; }

        [ForeignKey(nameof(IdUtilizador))]
        [InverseProperty(nameof(Utilizador.PalavrasChave))]
        public virtual Utilizador IdUtilizadorNavigation { get; set; }
    }
}
