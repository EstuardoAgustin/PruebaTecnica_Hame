using System;
using System.Collections.Generic;

namespace pruebaHame.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string? CodigoUsuario { get; set; }
        public string CorreoUsuario { get; set; } = null!;
        public string PasswordUsuario { get; set; } = null!;
        public string? LoginStatusUsuario { get; set; }
        public DateTime? FechaRegistroUsuario { get; set; }
        public string? EstadoUsuario { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
