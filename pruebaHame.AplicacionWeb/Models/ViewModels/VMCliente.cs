namespace pruebaHame.AplicacionWeb.Models.ViewModels
{
    public class VMCliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; } = null!;
        public string? CodigoCliente { get; set; }
        public DateTime? FechaAltaCliente { get; set; }
        public string? DireccionCliente { get; set; }
        public string? CorreoCliente { get; set; }
        public string? TelefonoCliente { get; set; }
        public string? EstadoCliente { get; set; }
    }
}
