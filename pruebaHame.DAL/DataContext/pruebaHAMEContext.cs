using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using pruebaHame.Models; //hacemos referencia a nuestra capa de modelos

namespace pruebaHame.DAL.DataContext
{
    public partial class pruebaHAMEContext : DbContext
    {
        public pruebaHAMEContext()
        {
        }

        public pruebaHAMEContext(DbContextOptions<pruebaHAMEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<ClienteServicio> ClienteServicios { get; set; } = null!;
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=ESTUARDOAGUSTIN\\SQLEXPRESS; Database=pruebaHAME; Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("codigoCliente");

                entity.Property(e => e.CorreoCliente)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("correoCliente");

                entity.Property(e => e.DireccionCliente)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("direccionCliente");

                entity.Property(e => e.EstadoCliente)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("estadoCliente");

                entity.Property(e => e.FechaAltaCliente)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaAltaCliente");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("nombreCliente");

                entity.Property(e => e.TelefonoCliente)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("telefonoCliente");
            });

            modelBuilder.Entity<ClienteServicio>(entity =>
            {
                entity.HasKey(e => e.IdClienteServicio);

                entity.ToTable("cliente_Servicio");

                entity.Property(e => e.IdClienteServicio).HasColumnName("idClienteServicio");

                entity.Property(e => e.DetallesClienteServicio)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("detallesClienteServicio");

                entity.Property(e => e.DireccionClienteServicio)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("direccionClienteServicio");

                entity.Property(e => e.EstadoClienteServicio)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("estadoClienteServicio");

                entity.Property(e => e.IdClienteFk).HasColumnName("idCliente_FK");

                entity.Property(e => e.IdServicioFk).HasColumnName("idServicio_FK");

                entity.Property(e => e.PaqueteClienteServicio)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("paqueteClienteServicio");

                entity.Property(e => e.TipoClienteServicio)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UbicacionClienteServicio)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ubicacionClienteServicio");

                entity.Property(e => e.VelocidadClienteServicio)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("velocidadClienteServicio");

                entity.HasOne(d => d.IdClienteFkNavigation)
                    .WithMany(p => p.ClienteServicios)
                    .HasForeignKey(d => d.IdClienteFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cliente_Servicio_cliente");

                entity.HasOne(d => d.IdServicioFkNavigation)
                    .WithMany(p => p.ClienteServicios)
                    .HasForeignKey(d => d.IdServicioFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cliente_Servicio_servicio");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalleFact);

                entity.ToTable("detalle_factura");

                entity.Property(e => e.IdDetalleFact).HasColumnName("idDetalleFact");

                entity.Property(e => e.CostoMensualDetalleFact)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("costoMensualDetalleFact");

                entity.Property(e => e.EstadoDetalleFact)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("estadoDetalleFact");

                entity.Property(e => e.IdDescuetnoFk).HasColumnName("idDescuetno_FK");

                entity.Property(e => e.IdFacturaFk).HasColumnName("idFactura_FK");

                entity.Property(e => e.IdServicioFk).HasColumnName("idServicio_FK");

                entity.Property(e => e.PeriodoServicioDetalleFact)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("periodoServicioDetalleFact");

                entity.Property(e => e.SubtotalDetalleFact)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("subtotalDetalleFact");

                entity.HasOne(d => d.IdFacturaFkNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.IdFacturaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_factura_factura");

                entity.HasOne(d => d.IdServicioFkNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.IdServicioFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_factura_servicio");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.ToTable("empleado");

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.CuotaIggsEmpleado)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("cuotaIggsEmpleado");

                entity.Property(e => e.EstadoEmpleado)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("estadoEmpleado");

                entity.Property(e => e.IdUsuarioFk).HasColumnName("idUsuario_FK");

                entity.Property(e => e.NombreEmpleado)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("nombreEmpleado");

                entity.Property(e => e.PuestoEmpleado)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("puestoEmpleado");

                entity.Property(e => e.RetencionIsrempleado)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("retencionISREmpleado");

                entity.Property(e => e.SalarioEmpleado)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("salarioEmpleado");

                entity.HasOne(d => d.IdUsuarioFkNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdUsuarioFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_empleado_usuario");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.ToTable("factura");

                entity.Property(e => e.IdFactura).HasColumnName("idFactura");

                entity.Property(e => e.DescuentoGlobalFactura)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("descuentoGlobalFactura");

                entity.Property(e => e.EstadoFactura)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("estadoFactura");

                entity.Property(e => e.EstadoPagoFactura)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("estadoPagoFactura");

                entity.Property(e => e.FechaCreacionFactura)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacionFactura");

                entity.Property(e => e.FechaFacturacionFactura)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaFacturacionFactura");

                entity.Property(e => e.FechaPagoFactura)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaPagoFactura");

                entity.Property(e => e.IdClienteFk).HasColumnName("idCliente_FK");

                entity.Property(e => e.IdEmpleadoFk).HasColumnName("idEmpleado_FK");

                entity.Property(e => e.NumeroFactura)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("numeroFactura");

                entity.Property(e => e.SerieFactura)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("serieFactura");

                entity.Property(e => e.TotalGlobalFactura)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("totalGlobalFactura");

                entity.HasOne(d => d.IdClienteFkNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdClienteFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_factura_cliente");

                entity.HasOne(d => d.IdEmpleadoFkNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdEmpleadoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_factura_empleado");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago);

                entity.ToTable("pago");

                entity.Property(e => e.IdPago).HasColumnName("idPago");

                entity.Property(e => e.EstadoPago)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("estadoPago");

                entity.Property(e => e.FechaPago)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaPago");

                entity.Property(e => e.IdFacturaFk).HasColumnName("idFactura_FK");

                entity.Property(e => e.MontoPago)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("montoPago");

                entity.Property(e => e.NotaPago)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("notaPago");

                entity.Property(e => e.TipoPago)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("tipoPago");

                entity.HasOne(d => d.IdFacturaFkNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdFacturaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pago_factura");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio);

                entity.ToTable("servicio");

                entity.Property(e => e.IdServicio).HasColumnName("idServicio");

                entity.Property(e => e.CostoServicio)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("costoServicio");

                entity.Property(e => e.DetalleServicio)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("detalleServicio");

                entity.Property(e => e.EstadoServicio)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("estadoServicio");

                entity.Property(e => e.NombreServicio)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("nombreServicio");

                entity.Property(e => e.PeriodoServicio)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("periodoServicio");

                entity.Property(e => e.TipoServicio)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("tipoServicio");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.CodigoUsuario)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("codigoUsuario");

                entity.Property(e => e.CorreoUsuario)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("correoUsuario");

                entity.Property(e => e.EstadoUsuario)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("estadoUsuario");

                entity.Property(e => e.FechaRegistroUsuario)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistroUsuario");

                entity.Property(e => e.LoginStatusUsuario)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("loginStatusUsuario");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("nombreUsuario");

                entity.Property(e => e.PasswordUsuario)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("passwordUsuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
