namespace PruebaCoink.Domain.Entities
{
    public class Usuarios
    {
        public int? IdUsuario { get; set; }
        public string? Nombres { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get;set; }       
        public int? IdPais { get; set; }
        public int? IdDepartamento { get; set; }
        public int? IdMunicipio { get; set; }
    }
}
