using System;
using System.Collections.Generic;

namespace pruebaHame.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Facturas = new HashSet<Factura>();
        }

        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; } = null!;
        public string? PuestoEmpleado { get; set; }
        public decimal? SalarioEmpleado { get; set; }
        public decimal? CuotaIggsEmpleado { get; set; }
        public decimal? RetencionIsrempleado { get; set; }
        public string? EstadoEmpleado { get; set; }
        public int IdUsuarioFk { get; set; }

        public virtual Usuario IdUsuarioFkNavigation { get; set; } = null!;
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
