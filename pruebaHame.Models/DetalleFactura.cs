using System;
using System.Collections.Generic;

namespace pruebaHame.Models
{
    public partial class DetalleFactura
    {
        public int IdDetalleFact { get; set; }
        public int IdFacturaFk { get; set; }
        public int IdServicioFk { get; set; }
        public string? PeriodoServicioDetalleFact { get; set; }
        public decimal? CostoMensualDetalleFact { get; set; }
        public decimal? SubtotalDetalleFact { get; set; }
        public string? EstadoDetalleFact { get; set; }
        public int IdDescuetnoFk { get; set; }

        public virtual Factura IdFacturaFkNavigation { get; set; } = null!;
        public virtual Servicio IdServicioFkNavigation { get; set; } = null!;
    }
}
