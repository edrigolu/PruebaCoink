using MediatR;
using PruebaCoink.Application.UseCases.Common.Bases;

namespace PruebaCoink.Application.UseCases.UseCases.Usuarios.Commands.UpdateCommand
{
    public class UpdateUserCommand : IRequest<BaseResponse<bool>>
    {
        public int IdUsuario {  get; set; }
        public string? Nombres { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public int? IdPais {  get; set; }
        public int? IdDepartamento { get; set; }
        public int? IdMunicipio { get; set; }
    }
}
