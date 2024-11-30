namespace PruebaCoink.Domain.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Nombres { get; set; }
        public int? Telefono { get;set; }
        public string? Direccion {  get; set; }
        public int IdDepartamento { get; set; }
        public int IdMunicipio {  get; set; }

    }
}
