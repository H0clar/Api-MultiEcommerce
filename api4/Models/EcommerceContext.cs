using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace api4.Models;

public partial class EcommerceContext : DbContext
{
    public EcommerceContext()
    {
    }

    public EcommerceContext(DbContextOptions<EcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriasProducto> CategoriasProductos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ConfiguracionesTiendum> ConfiguracionesTienda { get; set; }

    public virtual DbSet<DetallesPedido> DetallesPedidos { get; set; }

    public virtual DbSet<HistorialCliente> HistorialClientes { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProyectosEcommerce> ProyectosEcommerces { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Obtén la cadena de conexión desde la configuración
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionSQLserver"].ConnectionString;
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriasProducto>(entity =>
        {
            entity.HasKey(e => e.Idcategoria).HasName("PK__Categori__70E82E287A234CA7");

            entity.Property(e => e.Idcategoria)
                .ValueGeneratedNever()
                .HasColumnName("IDCategoria");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK__Clientes__9B8553FC9562D4F1");

            entity.Property(e => e.Idcliente)
                .ValueGeneratedNever()
                .HasColumnName("IDCliente");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Idproyecto).HasColumnName("IDProyecto");
            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.HasOne(d => d.IdproyectoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Idproyecto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Clientes_ProyectosEcommerce");
        });

        modelBuilder.Entity<ConfiguracionesTiendum>(entity =>
        {
            entity.HasKey(e => e.Idconfiguracion).HasName("PK__Configur__34AFFB0DE0D5B725");

            entity.Property(e => e.Idconfiguracion)
                .ValueGeneratedNever()
                .HasColumnName("IDConfiguracion");
            entity.Property(e => e.Idproyecto).HasColumnName("IDProyecto");
            entity.Property(e => e.NombreConfiguracion).HasMaxLength(255);
            entity.Property(e => e.ValorConfiguracion).HasMaxLength(255);

            entity.HasOne(d => d.IdproyectoNavigation).WithMany(p => p.ConfiguracionesTienda)
                .HasForeignKey(d => d.Idproyecto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ConfiguracionesTienda_ProyectosEcommerce");
        });

        modelBuilder.Entity<DetallesPedido>(entity =>
        {
            entity.HasKey(e => e.IddetallePedido).HasName("PK__Detalles__8F055244D25F9F50");

            entity.ToTable("DetallesPedido");

            entity.Property(e => e.IddetallePedido)
                .ValueGeneratedNever()
                .HasColumnName("IDDetallePedido");
            entity.Property(e => e.Idpedido).HasColumnName("IDPedido");
            entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

            entity.HasOne(d => d.IdpedidoNavigation).WithMany(p => p.DetallesPedidos)
                .HasForeignKey(d => d.Idpedido)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DetallesPedido_Pedidos");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.DetallesPedidos)
                .HasForeignKey(d => d.Idproducto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DetallesPedido_Productos");
        });

        modelBuilder.Entity<HistorialCliente>(entity =>
        {
            entity.HasKey(e => e.Idhistorial).HasName("PK__Historia__C4BEFB6919D0B645");

            entity.Property(e => e.Idhistorial)
                .ValueGeneratedNever()
                .HasColumnName("IDHistorial");
            entity.Property(e => e.Accion).HasMaxLength(255);
            entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.HistorialClientes)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_HistorialClientes_Clientes");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Idpedido).HasName("PK__Pedidos__00C11F99D5C8DB8F");

            entity.Property(e => e.Idpedido)
                .ValueGeneratedNever()
                .HasColumnName("IDPedido");
            entity.Property(e => e.Idcliente).HasColumnName("IDCliente");
            entity.Property(e => e.Idproyecto).HasColumnName("IDProyecto");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idcliente)
                .HasConstraintName("FK_Pedidos_Clientes");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__Producto__ABDAF2B443A23056");

            entity.Property(e => e.Idproducto)
                .ValueGeneratedNever()
                .HasColumnName("IDProducto");
            entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");
            entity.Property(e => e.Idproyecto).HasColumnName("IDProyecto");
            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Idcategoria)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Productos_CategoriasProductos");

            entity.HasOne(d => d.IdproyectoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Idproyecto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Productos_ProyectosEcommerce");
        });

        modelBuilder.Entity<ProyectosEcommerce>(entity =>
        {
            entity.HasKey(e => e.Idproyecto).HasName("PK__Proyecto__CBAEF2A9791E88D7");

            entity.ToTable("ProyectosEcommerce");

            entity.Property(e => e.Idproyecto)
                .ValueGeneratedNever()
                .HasColumnName("IDProyecto");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("URL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
