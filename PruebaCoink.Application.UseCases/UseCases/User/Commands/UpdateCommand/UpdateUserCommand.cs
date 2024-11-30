using MediatR;
using PruebaCoink.Application.UseCases.Common.Bases;

namespace PruebaCoink.Application.UseCases.UseCases.User.Commands.UpdateCommand
{
    public class UpdateUserCommand : IRequest<BaseResponse<bool>>
    {
        public int? IdUsuario { get; set; }
        public string? Nombres { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? IdDepartamento { get; set; }
        public string? IdMunicipio { get; set; }
    }
}
