using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabalho_Laboratorio.Models
{
    public partial class Restaurante
    {
        public Restaurante()
        {
            AgendarPrato = new HashSet<AgendarPrato>();
            GuardarClienteRestauranteFavorito = new HashSet<GuardarClienteRestauranteFavorito>();
            Horario = new HashSet<Horario>();
        }

        [Key]
        [Column("ID_Restaurante")]
        public int IdRestaurante { get; set; }
        [Required]
        [Column("Nome_Restaurante")]
        [StringLength(100)]
        public string NomeRestaurante { get; set; }
        [Required]
        [StringLength(20)]
        public string Telefone { get; set; }
        [Required]
        [StringLength(500)]
        public string Foto { get; set; }
        [Column("Status_Restaurante")]
        public bool StatusRestaurante { get; set; }
        [Required]
        [Column("Tipo_Servico")]
        [StringLength(40)]
        public string TipoServico { get; set; }
        [Required]
        [Column("Dia_De_Descanso")]
        [StringLength(20)]
        public string DiaDeDescanso { get; set; }

        [ForeignKey(nameof(IdRestaurante))]
        [InverseProperty(nameof(Utilizador.Restaurante))]
        public virtual Utilizador IdRestauranteNavigation { get; set; }
        [InverseProperty("IdRestauranteNavigation")]
        public virtual ICollection<AgendarPrato> AgendarPrato { get; set; }
        [InverseProperty("IdRestauranteNavigation")]
        public virtual ICollection<GuardarClienteRestauranteFavorito> GuardarClienteRestauranteFavorito { get; set; }
        [InverseProperty("IdRestauranteNavigation")]
        public virtual ICollection<Horario> Horario { get; set; }
    }
}
