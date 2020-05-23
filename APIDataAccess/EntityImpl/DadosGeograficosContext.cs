using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIDataAccess.EntityImpl
{
    public class DadosGeograficosContext : DbContext
    {
       public DbSet<Regiao> Regioes { get; set; }
       public DbSet<Estado> Estados { get; set; }

        public DadosGeograficosContext(
            DbContextOptions<DadosGeograficosContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Regiao>().HasKey(r => r.IdRegiao);
            modelBuilder.Entity<Estado>().HasKey(e => e.SiglaEstado);
            
            modelBuilder.Entity<Regiao>()
                .HasMany(r => r.Estados)
                .WithOne(e => e.Regiao);
        }
    }
}