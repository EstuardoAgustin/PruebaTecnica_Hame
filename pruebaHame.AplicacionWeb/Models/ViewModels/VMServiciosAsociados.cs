namespace pruebaHame.AplicacionWeb.Models.ViewModels
{
    public class VMServiciosAsociados
    {
        public int IdClienteServicio { get; set; }
        public int IdClienteFk { get; set; }
        public int IdServicioFk { get; set; }
        public string? TipoClienteServicio { get; set; }
        public string? EstadoClienteServicio { get; set; }
        public string? DireccionClienteServicio { get; set; }
        public string? UbicacionClienteServicio { get; set; }
        public string? VelocidadClienteServicio { get; set; }
        public string? PaqueteClienteServicio { get; set; }
        public string? DetallesClienteServicio { get; set; }
        public VMCliente ClienteAsociado { get; set; } = null!;
        public VMServicio ServicioAsociado { get; set; } = null!;
    }
}
