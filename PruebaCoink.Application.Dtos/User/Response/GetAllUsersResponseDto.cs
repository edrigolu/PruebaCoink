namespace PruebaCoink.Application.Dtos.User.Response
{
    public class GetAllUsersResponseDto
    {
        public int IdUsuario { get; set; }
        public string? Nombres { get; set; }
        public int? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Departamento { get; set; }
        public string? Municipio { get; set; }
        public string? EsActivo { get; set; }
    }
}
