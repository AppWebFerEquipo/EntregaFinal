using System;
using System.Collections.Generic;

#nullable disable

namespace FindingApp.Domain.Entities
{
    public partial class TblClub
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Logotipo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Geoubicacion { get; set; }
        public DateTime? Horario { get; set; }
    }
}
