using SimulaParcela.Dominio.Entidade;
using System.Collections.Generic;
using System.Linq;

namespace SimulaParcela.Dominio.Notification
{
    public class NotificacaoContext : INotificacao
    {
        private IList<string> message;

        public bool HasNotificacoes { get { return message.Any(); } }

        public NotificacaoContext()
            => message = new List<string>();


        public void AddNotificacao(string message)
        {
            this.message.Add(message);
        }

        public Notificacao GetNotificacoes()
            => new Notificacao(string.Join(',', message));
    }
}
