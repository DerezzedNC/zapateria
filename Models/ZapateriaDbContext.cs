using Microsoft.EntityFrameworkCore;

namespace ZapateriaAPI.Models
{
    public class ZapateriaDbContext : DbContext
    {
        public ZapateriaDbContext(DbContextOptions<ZapateriaDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Zapato> Zapatos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<CobroZapato> CobrosZapato { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<PedidoMaterial> PedidoMaterial { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Sucursal>().ToTable("Sucursal");
            modelBuilder.Entity<MetodoPago>().ToTable("MetodoPago"); // corregido aquí
            modelBuilder.Entity<Zapato>().ToTable("Zapato");
            modelBuilder.Entity<Pedido>().ToTable("Pedido");
            modelBuilder.Entity<Material>().ToTable("Material");
            modelBuilder.Entity<CobroZapato>().ToTable("CobroZapato");
            modelBuilder.Entity<Horario>().ToTable("Horario");
            modelBuilder.Entity<PedidoMaterial>().ToTable("Pedido_Material");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Telefono).IsRequired().HasMaxLength(15);
                entity.Property(e => e.TipoServicio).IsRequired().HasMaxLength(30);
                entity.Property(e => e.TipoZapato).IsRequired().HasMaxLength(20);

                entity.ToTable(t =>
                {
                    t.HasCheckConstraint("CK_Cliente_TipoServicio", "TipoServicio IN ('Cambio de Color', 'Cambio de Suela', 'Reparación Total')");
                    t.HasCheckConstraint("CK_Cliente_TipoZapato", "TipoZapato IN ('Tacones', 'Botas', 'Tenis', 'Chancletas')");
                });
            });
        }
    }
}
