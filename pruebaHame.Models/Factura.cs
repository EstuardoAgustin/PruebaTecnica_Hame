using System;
using System.Collections.Generic;

namespace pruebaHame.Models
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
            Pagos = new HashSet<Pago>();
        }

        public int IdFactura { get; set; }
        public string? NumeroFactura { get; set; }
        public string? SerieFactura { get; set; }
        public decimal? TotalGlobalFactura { get; set; }
        public decimal? DescuentoGlobalFactura { get; set; }
        public DateTime? FechaCreacionFactura { get; set; }
        public DateTime? FechaFacturacionFactura { get; set; }
        public DateTime? FechaPagoFactura { get; set; }
        public string? EstadoPagoFactura { get; set; }
        public string? EstadoFactura { get; set; }
        public int IdClienteFk { get; set; }
        public int IdEmpleadoFk { get; set; }

        public virtual Cliente IdClienteFkNavigation { get; set; } = null!;
        public virtual Empleado IdEmpleadoFkNavigation { get; set; } = null!;
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
