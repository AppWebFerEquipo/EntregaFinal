using System;
using System.Collections.Generic;

#nullable disable

namespace FindingApp.Domain.Entities
{
    public partial class TblService
    {
        public int Id { get; set; }
        public string Disciplina { get; set; }
        public DateTime? Horario { get; set; }
        public string CantidadPersonas { get; set; }
        public string EquipoEspecial { get; set; }
        public string PracticaDiscapacidad { get; set; }
    }
}
