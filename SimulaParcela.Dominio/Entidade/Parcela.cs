using System;

namespace SimulaParcela.Dominio.Entidade
{
    public class Parcela
    {
        public int Id{ get; set;}
        public decimal ValorDaParcela { get; private set; }
        public decimal ValorDoJurosAplicado { get; private set; }
        public DateTime DataDoVencimento { get; private set; }
        public Simulacao Simulacao { get; private set; }

        protected Parcela() { }
        public Parcela(Simulacao simulacao)
        {
            if (simulacao == null)
                throw new ArgumentNullException(nameof(simulacao));

            this.Simulacao = simulacao;

            this.CalcularParcela();
        }

        public Parcela(Simulacao simulacao,DateTime dataReferencia)
        {
            if (simulacao == null)
                throw new ArgumentNullException(nameof(simulacao));

            if (dataReferencia == null)
                throw new ArgumentNullException(nameof(dataReferencia));

            this.Simulacao = simulacao;

            this.CalcularParcela();

            this.DataDoVencimento = this.CalcularDataVencimento(dataReferencia);
        }

        public void CalcularParcela()
        {
            var valorParcelaSemJuros = Simulacao.ValorTotalCompra / Simulacao.QuantidadeDeParcela;

            this.ValorDaParcela =       Math.Round((valorParcelaSemJuros* Simulacao.ValorJuros / 100)+ valorParcelaSemJuros, 2);
            this.ValorDoJurosAplicado = Math.Round(this.ValorDaParcela - valorParcelaSemJuros, 4);
            this.DataDoVencimento =     CalcularDataVencimento(Simulacao.DataDaCompra);
        }

        public DateTime CalcularDataVencimento(DateTime dataReferencia)
                        => dataReferencia.AddMonths(1);
    }
}
