using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulaParcela.Dominio.Entidade;

namespace SimulaParcela.Repositorio.Mapper
{
    public class ParcelaMap : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
            builder.HasKey(p=> p.Id);
            
            builder.Property(p=> p.DataDoVencimento)
                   .IsRequired();

            builder.Property(p=> p.ValorDaParcela)
                   .IsRequired();

            builder.Property(p=> p.ValorDoJurosAplicado)
                   .IsRequired();

            builder.HasOne(p=> p.Simulacao)
                   .WithMany(s=> s.Parcelas)
                   .HasForeignKey(x => x.SimulacaoId); 
        }
    }
}
