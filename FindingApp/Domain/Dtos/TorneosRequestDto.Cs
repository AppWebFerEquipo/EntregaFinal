using System;

namespace FindingApp.Domain.Dtos
{
    public record TorneosRequestDto(string Disciplina, string CantidadEquipo, string CostoIns, string Tipo);
}