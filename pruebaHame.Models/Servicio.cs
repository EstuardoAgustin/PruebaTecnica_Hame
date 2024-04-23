using System;
using System.Collections.Generic;

namespace pruebaHame.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            ClienteServicios = new HashSet<ClienteServicio>();
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int IdServicio { get; set; }
        public string NombreServicio { get; set; } = null!;
        public string? PeriodoServicio { get; set; }
        public decimal? CostoServicio { get; set; }
        public string? TipoServicio { get; set; }
        public string? DetalleServicio { get; set; }
        public string? EstadoServicio { get; set; }

        public virtual ICollection<ClienteServicio> ClienteServicios { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
