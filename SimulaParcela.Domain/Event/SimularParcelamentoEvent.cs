using SimulaParcela.Domain.Model;

namespace SimulaParcela.Domain.Event
{
    public class SimularParcelamentoEvent
    {
        public Simulacao Simulacao { get; private set; }
        public SimularParcelamentoEvent(Simulacao simulacao)
        {
            Simulacao = simulacao;
        }
    }     
}
