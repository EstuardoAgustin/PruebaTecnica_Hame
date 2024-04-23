namespace pruebaHame.AplicacionWeb.Models.ViewModels
{
    public class VMServicio
    {
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; } = null!;
        public string? PeriodoServicio { get; set; }
        public decimal? CostoServicio { get; set; }
        public string? TipoServicio { get; set; }
        public string? DetalleServicio { get; set; }
        public string? EstadoServicio { get; set; }
    }
}
