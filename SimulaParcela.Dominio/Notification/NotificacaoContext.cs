using SimulaParcela.Domain.Core;
using SimulaParcela.Domain.Core.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimulaParcela.Dominio.Notification
{
    public class NotificacaoContext : INotification
    {
        private IList<string> message;

        public bool HasNotificacoes { get { return message.Any(); } }

        public NotificacaoContext()
            => message = new List<string>();


        public void AddNotificacao(string message)
        {
            this.message.Add(message);
        }

        public Notification GetNotificacoes()
            => new Domain.Core.Notification(string.Join(',', message));
    }
}
