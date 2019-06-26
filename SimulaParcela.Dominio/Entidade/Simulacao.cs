using System;

namespace SimulaParcela.Dominio.Entidade
{
    public class Simulacao
    {
        public int Id { get; private set; }
        public decimal ValorTotalCompra { get; private set; }
        public decimal ValorJuros { get; private set; }
        public int QuantidadeDeParcela { get; private set; }
        public DateTime DataDaCompra { get; private set; }
        public decimal TotalJurosAPagar { get => Math.Round((ValorJuros * ValorTotalCompra)/100,4);}
        public decimal TotalCompasAPagar { get => Math.Round((TotalJurosAPagar + ValorTotalCompra),2);}

        protected Simulacao() { }

        public Simulacao(int id, decimal valorTotalCompra, decimal valorJuros,int quantidadeDeParcela,DateTime dataDaCompra)
        {
           Id = id;
           ValorJuros = valorJuros;
           ValorTotalCompra = valorTotalCompra;
           QuantidadeDeParcela = quantidadeDeParcela;
           DataDaCompra = dataDaCompra;
        }  


    }
}
