using Microsoft.EntityFrameworkCore;
using SimulaParcela.Dominio.Entidade;
using SimulaParcela.Repositorio.Mapper;

namespace SimulaParcela.Repositorio
{
    public class SimulacaoContext : DbContext
    {
        public DbSet<Simulacao> Simulacaos { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SimulacaoMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-QE2MS1N;Initial Catalog=DBSimulacao;User ID=sa;Password=almir;Persist Security Info=True;");
        }
    }
}
