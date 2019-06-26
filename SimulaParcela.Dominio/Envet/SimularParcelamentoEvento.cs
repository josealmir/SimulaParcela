using SimulaParcela.Dominio.Entidade;

namespace SimulaParcela.Dominio.Envet
{
    public class SimularParcelamentoEvento
    {
        public Simulacao Simulacao { get; private set; }
        public SimularParcelamentoEvento(Simulacao simulacao)
        {
            Simulacao =  simulacao;
        }
    }     
}
