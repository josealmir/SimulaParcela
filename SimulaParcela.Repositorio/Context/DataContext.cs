using Microsoft.EntityFrameworkCore;
using SimulaParcela.Dominio.Model;
using SimulaParcela.Repositorio.Mapper;

namespace SimulaParcela.Repositorio
{
    public class DataContext : DbContext
    {

        public DbSet<Parcela> Parcela {get; set;}
        public DbSet<Simulacao> Simulacao {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SimulacaoMap());
            modelBuilder.ApplyConfiguration(new ParcelaMap());            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-QE2MS1N;Initial Catalog=DBSimulacao;User ID=sa;Password=almir;Persist Security Info=True;");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSimulacao;Integrated Security=SSPI");
            
        }   
    }
}
