﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabalho_Laboratorio.Models
{
    public partial class Horario
    {
        [Key]
        [Column("ID_Horario")]
        public int IdHorario { get; set; }
        [Key]
        [Column("ID_Restaurante")]
        public int IdRestaurante { get; set; }
        [Column("Dia_Semana")]
        public int DiaSemana { get; set; }
        [Column("Hora_De_Entrada")]
        public TimeSpan HoraDeEntrada { get; set; }
        [Column("Hora_De_Saida")]
        public TimeSpan HoraDeSaida { get; set; }

        [ForeignKey(nameof(IdRestaurante))]
        [InverseProperty(nameof(Restaurante.Horario))]
        public virtual Restaurante IdRestauranteNavigation { get; set; }
    }
}
