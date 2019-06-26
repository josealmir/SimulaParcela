using SimulaParcela.Dominio.Entidade;

namespace SimulaParcela.Dominio.Notification
{
    public interface INotificacao
    {
        bool HasNotificacoes { get; }
        void AddNotificacao(string message);
        Notificacao GetNotificacoes();
    }
}
