using SimulaParcela.Dominio.Model;

namespace SimulaParcela.Dominio.Event
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
