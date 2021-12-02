using System;

namespace FindingApp.Domain.Dtos.Requests
{
    public class TorneosCreateRequest
    {
        public int Id { get; set; }
        public string Disciplina { get; set; }
        public string CantidadEquipo { get; set; }
        public string Lugares { get; set; }
        public string CostoIns { get; set; }
        public string Bases { get; set; }
        public string NumRondas { get; set; }
        public string Tipo { get; set; }
    }
}