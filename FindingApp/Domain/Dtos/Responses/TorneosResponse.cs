using System;

namespace FindingApp.Domain.Dtos.Responses
{
    public class TorneosResponse
    {
        public int Id { get; set; }
        public string Disciplina { get; set; }
        public string CantidadEquipo { get; set; }
        public string CostoIns { get; set; }
    }
}