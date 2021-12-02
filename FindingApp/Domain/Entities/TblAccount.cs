using System;
using System.Collections.Generic;

#nullable disable

namespace FindingApp.Domain.Entities
{
    public partial class TblAccount
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Usuario { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
