using FinanceManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContaPagar> ContasPagar { get; set; } = null!;
        public DbSet<ContaReceber> ContasReceber { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContaPagar>(entity =>
            {
                entity.ToTable("contas_pagar");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Descricao).IsRequired();
                entity.Property(e => e.Valor)
                      .HasColumnType("decimal(10,2)")
                      .IsRequired();
                entity.Property(e => e.DataVencimento).IsRequired();
                entity.Property(e => e.Status)
                      .HasMaxLength(20)
                      .IsRequired();
                entity.Property(e => e.Categoria).IsRequired();

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<ContaReceber>(e =>
            {
                e.ToTable("contas_receber");
                e.HasKey(c => c.Id);

                e.Property(c => c.UserId)
                 .IsRequired();

                e.Property(c => c.Descricao)
                 .HasMaxLength(200)
                 .IsRequired();

                e.Property(c => c.Valor)
                 .HasColumnType("decimal(18,2)")
                 .IsRequired();

                e.Property(c => c.DataRecebimento)
                 .IsRequired();

                e.Property(c => c.Categoria)
                 .HasMaxLength(100)
                 .IsRequired();

                e.Property(c => c.Status)
                 .HasMaxLength(50)
                 .IsRequired();

                e.Property(c => c.CreatedAt)
                 .IsRequired()
                 .HasDefaultValueSql("CURRENT_TIMESTAMP"); ;
            });
        }
    }
}
