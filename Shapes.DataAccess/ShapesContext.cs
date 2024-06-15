using Microsoft.EntityFrameworkCore;

namespace Shapes.DataAccess
{
    public class ShapesContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<ShapeEntity> Shapes { get;  set; }
        public DbSet<ShapeTypeEntity> ShapeTypes { get;  set; }

        public ShapesContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShapeEntity>()
                .Property(e => e.ShapeTypeId)
                .HasColumnName("ShapeType");

            modelBuilder.Entity<ShapeEntity>()
                .HasOne(e => e.ShapeType)
                .WithMany(e => e.Shapes);
        }

    }
}
