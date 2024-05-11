using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RestaurantHelper.Models
{
    public partial class RestaurantContext : DbContext
    {
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<PedidoComanda> PedidosComanda { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Filename=restaurantHelper.db",
                sqliteOptionsAction: op => { op.MigrationsAssembly(
                        Assembly.GetExecutingAssembly().FullName
                    ); }
                ) ;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comanda>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Observaciones)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Mesa).WithMany(p => p.Comandas)
                    .HasForeignKey(d => d.MesaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comanda_Mesa");

                entity.HasOne(d => d.Usuario).WithMany(p => p.Comandas)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comanda_Usuario");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Detalle)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mesa>(entity =>
            {
                entity.ToTable("Mesa");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.ComandaActual).WithMany(p => p.Mesas)
                    .HasForeignKey(d => d.ComandaActualId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mesa_Comanda");
            });

            modelBuilder.Entity<PedidoComanda>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Comanda).WithMany()
                    .HasForeignKey(d => d.ComandaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PedidoComanda_Comanda");

                entity.HasOne(d => d.Menu).WithMany()
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PedidoComanda_Menu");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07C1CD3BFD");

                entity.ToTable("Usuario");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Rut)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}