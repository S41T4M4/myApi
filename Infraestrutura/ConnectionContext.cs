using AlunosBase.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AlunosBase.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<TurmaA> TurmaA { get; set; }
        public DbSet<TurmaB> TurmaB { get; set; }
        public DbSet<TurmaC> TurmaC { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(
                    "Server=localhost;" +
                    "Port=5432;Database=AlunosDB;" +
                    "User Id=postgres;" +
                    "Password=Staff4912;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TurmaA>().ToTable("turmaa");
            modelBuilder.Entity<TurmaB>().ToTable("turmab");
            modelBuilder.Entity<TurmaC>().ToTable("turmac");
        }
    }
}
