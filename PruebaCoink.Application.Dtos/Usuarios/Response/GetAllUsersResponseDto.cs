namespace PruebaCoink.Application.Dtos.Usuarios.Response
{
    public class GetAllUsersResponseDto
    {
        public int? IdUsuario { get; set; }
        public string? Nombres { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Pais { get; set; }
        public string? Departamento { get; set; }
        public string? Municipio { get; set; }
    }
}
