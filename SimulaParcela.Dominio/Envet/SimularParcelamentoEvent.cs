using SimulaParcela.Dominio.Entidade;

namespace SimulaParcela.Dominio.Envet
{
    public class SimularParcelamentoEvent
    {
        public Simulacao Simulacao { get; private set; }
        public SimularParcelamentoEvent(Simulacao simulacao)
        {
            Simulacao =  simulacao;
        }
    }     
}
