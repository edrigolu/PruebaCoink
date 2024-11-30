using MediatR;
using PruebaCoink.Application.UseCases.Common.Bases;

namespace PruebaCoink.Application.UseCases.UseCases.User.Commands.CreateCommand
{
    public class CreateUserCommand : IRequest<BaseResponse<bool>>
    {
        public string? Nombres { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? IdDepartamento { get; set; }
        public string? IdMunicipio { get; set; }        
    }
}
