using SimulaParcela.Domain.Core;
using System;
using System.Collections.Generic;

namespace SimulaParcela.Domain.Model
{
    public class Simulacao : Entity
    {
        public int ValorJuros { get; private set; }
        public decimal ValorTotalCompra { get; private set; }
        public int QuantidadeDeParcela { get; private set; }
        public DateTime DataDaCompra { get; private set; }
        public virtual IList<Parcela> Parcelas { get; private set; }

        public decimal ValorTotalAPagar
        {
            get
            {
                return Math.Round((ValorTotalCompra * ValorJuros) / 100 + ValorTotalCompra,2);
            }
        }        

        protected Simulacao() { }

        public Simulacao(int id, decimal valorTotalCompra, int valorJuros, int quantidadeDeParcela, DateTime dataDaCompra)
        {
           Id = id;
           ValorJuros = valorJuros;
           ValorTotalCompra = valorTotalCompra;
           QuantidadeDeParcela = quantidadeDeParcela;
           DataDaCompra = dataDaCompra;
        }    
    }
}
