using System;
using System.Collections.Generic;

namespace pruebaHame.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClienteServicios = new HashSet<ClienteServicio>();
            Facturas = new HashSet<Factura>();
        }

        public int IdCliente { get; set; }
        public string NombreCliente { get; set; } = null!;
        public string? CodigoCliente { get; set; }
        public DateTime? FechaAltaCliente { get; set; }
        public string? DireccionCliente { get; set; }
        public string? CorreoCliente { get; set; }
        public string? TelefonoCliente { get; set; }
        public string? EstadoCliente { get; set; }

        public virtual ICollection<ClienteServicio> ClienteServicios { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
