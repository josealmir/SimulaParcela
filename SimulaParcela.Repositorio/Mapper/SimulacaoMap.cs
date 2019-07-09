using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulaParcela.Dominio.Model;

namespace SimulaParcela.Repositorio.Mapper
{
    public class SimulacaoMap : IEntityTypeConfiguration<Simulacao>
    {
        public void Configure(EntityTypeBuilder<Simulacao> builder)
        {
            builder.HasKey(s=>s.Id);
            builder.Property(s => s.QuantidadeDeParcela)
                   .IsRequired();

            builder.Property(s => s.ValorJuros)
                   .IsRequired();

            builder.Property(s => s.ValorTotalCompra)
                   .IsRequired();

            builder.Property(s => s.DataDaCompra)
                   .IsRequired();

            builder.HasMany(s => s.Parcelas)
                   .WithOne(p => p.Simulacao)
                   .HasForeignKey(x=>x.SimulacaoId);
        }
    }
}
