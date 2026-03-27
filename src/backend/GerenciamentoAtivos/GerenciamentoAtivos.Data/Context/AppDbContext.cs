using Microsoft.EntityFrameworkCore;
using GerenciamentoAtivos.Domain.Models;

namespace GerenciamentoAtivos.Data.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Ativo> Ativos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Esta linha procura todas as classes que herdam de IEntityTypeConfiguration 
            // neste projeto (Assembly) e as aplica automaticamente.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Procura por todas as entidades que estão sendo alteradas ou inseridas
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.Created = DateTime.Now;
                }
                else
                {
                    entity.Updated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
