namespace PruebaCoinl.Application.Dtos.User.Response
{
    public class GetUserByIdResponseDto
    {
        public int IdUsuario { get; set; }
        public string? Nombres { get; set; }
        public int? Telefono { get; set; }
        public string? Direccion { get; set; }
        public int IdDepartamento { get; set; }
        public int IdMunicipio { get; set; }
    }
}
