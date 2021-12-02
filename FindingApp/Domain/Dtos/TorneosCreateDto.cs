using System;

namespace FindingApp.Domain.Dtos
{
    public record TorneosCreateDto(string Disciplina, string CantidadEquipo, string Lugares, string CostoIns, string Bases, string NumRondas, string Tipo);
}