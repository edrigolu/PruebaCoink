using FluentValidation;

namespace PruebaCoink.Application.UseCases.UseCases.Usuarios.Commands.UpdateCommand
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Nombres).NotNull()
                                   .WithMessage("El campo Nombres no puede ser nulo.")
                                   .NotEmpty()
                                   .WithMessage("El campo Nombres no puede ser vacío.");

            RuleFor(x => x.Direccion).NotNull()
                                     .WithMessage("El campo Dirección no puede ser nulo.")
                                     .NotEmpty()
                                     .WithMessage("El campo Nombre no puede ser vacío.");

            RuleFor(x => x.Telefono).NotNull()
                                    .WithMessage("El campo Telefono no puede ser nulo.")
                                    .NotEmpty()
                                    .WithMessage("El campo Teléfono no puede ser vacío.")
                                    .Must(BeNumeric!)
                                    .WithMessage("El campo Teléfono debe contener ser solo números.")
                                    .Length(10)
                                    .WithMessage("El campo Teléfono debe contener diez (10) números.");
        }

        private bool BeNumeric(string input)
        {
            return int.TryParse(input, out _);
        }
    }
}
