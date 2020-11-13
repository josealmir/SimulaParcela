using System;

namespace SimulaParcela.Domain.Command
{
    public class RegistrarNovaSimulacaoCommand
    {
        public decimal ValorTotalCompra { get; private set; }
        public int ValorJuros { get; private set; }
        public int QuantidadeDeParcela { get; private set; }
        public DateTime DataDaCompra { get; private set; }

        public RegistrarNovaSimulacaoCommand(decimal valorTotalCompra, int valorJuros, int quantidadeDeParcela, DateTime dataDaCompra)
        {
            ValorJuros = valorJuros;
            ValorTotalCompra = valorTotalCompra;
            QuantidadeDeParcela = quantidadeDeParcela;
            DataDaCompra = dataDaCompra;
        }
    }
}
