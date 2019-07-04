
namespace SimulaParcela.Domain.Core.Interface
{
    public interface INotification
    {
        bool HasNotificacoes { get; }
        void AddNotificacao(string message);
        //Notificacao GetNotificacoes();
    }
}
