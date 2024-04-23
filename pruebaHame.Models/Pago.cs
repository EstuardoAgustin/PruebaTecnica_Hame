using System;
using System.Collections.Generic;

namespace pruebaHame.Models
{
    public partial class Pago
    {
        public int IdPago { get; set; }
        public int IdFacturaFk { get; set; }
        public DateTime? FechaPago { get; set; }
        public decimal? MontoPago { get; set; }
        public string? TipoPago { get; set; }
        public string? NotaPago { get; set; }
        public string? EstadoPago { get; set; }

        public virtual Factura IdFacturaFkNavigation { get; set; } = null!;
    }
}
