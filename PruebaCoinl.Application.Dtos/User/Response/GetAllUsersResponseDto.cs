namespace PruebaCoinl.Application.Dtos.User.Response
{
    public class GetAllUsersResponseDto
    {
        public int IdUsuario { get; set; }
        public string? Nombres { get; set; }
        public int Telefono { get; set; }
        public string? Direccion { get; set; }
        public int Departamento { get; set; }
        public int Municipio { get; set; }
        public string? EstaActivo {  get; set; }
    }
}
