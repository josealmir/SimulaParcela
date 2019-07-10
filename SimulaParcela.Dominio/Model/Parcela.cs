using SimulaParcela.Domain.Core;
using System;

namespace SimulaParcela.Dominio.Model
{
    public class Parcela : Entity
    {
        public decimal ValorDaParcela { get; private set; }
        public decimal ValorDoJurosAplicado { get; private set; }
        public DateTime DataDoVencimento { get; private set; }
        public int SimulacaoId { get; set;}
        public virtual Simulacao Simulacao { get; private set; }

        protected Parcela() { }
        public Parcela(Simulacao simulacao)
        {
            if (simulacao == null)
                throw new ArgumentNullException(nameof(simulacao));

            this.SimulacaoId = simulacao.Id;
            CalcularParcela(simulacao.QuantidadeDeParcela,simulacao.ValorJuros,simulacao.ValorTotalCompra,simulacao.DataDaCompra);
        }

        public Parcela(Simulacao simulacao,DateTime dataReferencia)
        {
            if (simulacao == null)
                throw new ArgumentNullException(nameof(simulacao));

            if (dataReferencia == null)
                throw new ArgumentNullException(nameof(dataReferencia));

            this.SimulacaoId = simulacao.Id;
            this.DataDoVencimento = CalcularDataVencimento(dataReferencia);
        }

        public DateTime CalcularDataVencimento(DateTime dataReferencia)
                        => dataReferencia.AddMonths(1);

        public Parcela CalcularParcela(Simulacao simulacao)
        {
            return CalcularParcela(simulacao.QuantidadeDeParcela,simulacao.ValorJuros,simulacao.ValorTotalCompra,simulacao.DataDaCompra);
        }                        
        public Parcela CalcularParcela(int quantidadeDeParcela,int valorJuros,decimal valorTotalDaCompra,DateTime dataReferencia)
        {
            var valorParcelaSemJuros = valorTotalDaCompra / quantidadeDeParcela;
            this.ValorDaParcela = Math.Round((valorParcelaSemJuros* valorJuros / 100) + valorParcelaSemJuros, 2);
            this.ValorDoJurosAplicado = Math.Round(this.ValorDaParcela - valorParcelaSemJuros, 4);
            this.DataDoVencimento = CalcularDataVencimento(Simulacao.DataDaCompra);
            return this;
        }
    }
}
