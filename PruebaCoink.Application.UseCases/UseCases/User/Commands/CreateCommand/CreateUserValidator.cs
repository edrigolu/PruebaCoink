using FluentValidation;

namespace PruebaCoink.Application.UseCases.UseCases.User.Commands.CreateCommand
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Nombres).NotNull()
                .WithMessage("El campo Nombres no puede ser nulo.")
                .NotEmpty()
                .WithMessage("El campo Nombre no puede ser vacío.");

            RuleFor(x => x.Direccion).NotNull()
               .WithMessage("El campo Dirección no puede ser nulo.")
               .NotEmpty()
               .WithMessage("El campo Apellido Paterno no puede ser vacío.");

            RuleFor(x => x.Telefono).NotNull()
             .WithMessage("El campo Telefono no puede ser nulo.")
             .NotEmpty()
             .WithMessage("El campo Telefono no puede ser vacío.")
             .Must(BeNumeric!).WithMessage("El campo Telefono debe contener ser solo numeros.");

            RuleFor(x => x.IdDepartamento).NotNull()
         .WithMessage("El campo Id Departamento no puede ser nulo.")
         .NotEmpty()
         .WithMessage("El campo Id Departamento no puede ser vacío.")
         .Must(BeNumeric!).WithMessage("El campo Id Departamento debe contener ser solo numeros.");

            RuleFor(x => x.IdMunicipio).NotNull()
        .WithMessage("El campo Id Municipio no puede ser nulo.")
        .NotEmpty()
        .WithMessage("El campo Id Municipio no puede ser vacío.")
        .Must(BeNumeric!).WithMessage("El campo Id Municipio debe contener ser solo numeros.");
        }


        private static bool BeNumeric(string input)
        {
            return int.TryParse(input, out _);
        }
    }
}

