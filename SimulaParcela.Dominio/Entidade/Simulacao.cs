using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulaParcela.Dominio.Entidade
{
    public class Simulacao
    {
        public int Id { get; set; }
        public decimal ValorJuros { get; private set; }
        public decimal ValorTotalCompra { get; private set; }
        public int QuantidadeDeParcela { get; private set; }
        public DateTime DataDaCompra { get; private set; }
        public IList<Parcela> Parcelas { get; }

        public decimal ValorTotalAPagar
        {
            get
            {
                return Math.Round((ValorTotalCompra * ValorJuros) / 100 + ValorTotalCompra,2);
            }
        }
        

        protected Simulacao() {
            CalcularParcelamento(this);
        }

        public Simulacao(int id, decimal valorTotalCompra, decimal valorJuros, int quantidadeDeParcela, DateTime dataDaCompra)
        {
           Id = id;
           ValorJuros = valorJuros;
           ValorTotalCompra = valorTotalCompra;
           QuantidadeDeParcela = quantidadeDeParcela;
           DataDaCompra = dataDaCompra;
           Parcelas = CalcularParcelamento(this);

        }
        
        public IList<Parcela> CalcularParcelamento(Simulacao simulacao)
        {
            DateTime dataReferencia = simulacao.DataDaCompra;

            var parcelas = new List<Parcela>();

            for (int i = 0; i < simulacao.QuantidadeDeParcela; i++)
            {   
                var parcela = new Parcela(simulacao,dataReferencia);
                dataReferencia = parcela.DataDoVencimento;
                parcelas.Add(parcela);
            }
            
            return parcelas;           
        }                   
    }
}
