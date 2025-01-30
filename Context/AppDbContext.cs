using Microsoft.EntityFrameworkCore;
using Transacoes.Modelo;
using Transacoes.Models;

namespace Transacoes.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiKey>()
                .ToTable("apikeys", "public");

            modelBuilder.Entity<Transacao>()
                .ToTable("transacoes", "public");

        }
    }
}
