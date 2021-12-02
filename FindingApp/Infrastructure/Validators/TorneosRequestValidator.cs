using System;
using FluentValidation;
using FindingApp.Domain.Dtos.Requests;
using FindingApp.Domain.Interfaces;

namespace FindingApp.Infrastructure.Validators
{
    public class TorneosCreateRequestValidator : AbstractValidator<TorneosCreateRequest>
    {
        private readonly ITorneosRepository _repository;

        public TorneosCreateRequestValidator(ITorneosRepository repository)
        {
            this._repository = repository;

            RuleFor(x => x.Disciplina).NotNull().NotEmpty().Length(2, 25);

            RuleFor(x => x.CantidadEquipo)
            .NotNull()
            .NotEmpty()
            .Matches("^[0-9]+$")
            .WithMessage("Ingresa una cantidad de equipo");

            RuleFor(x => x.Lugares).NotNull().NotEmpty();

            RuleFor(x => x.CostoIns)
            .NotNull()
            .NotEmpty()
            .Matches("^[0-9]+$")
            .Length(2, 10)
            .WithMessage("Ingrese un precio $");

            RuleFor(x => x.NumRondas)
            .NotNull()
            .NotEmpty()
            .Matches("^[0-9]+$")
            .WithMessage("Ingrese un numero de rondas");

            RuleFor(x => x.Tipo).NotNull().NotEmpty();
        }
    }
}