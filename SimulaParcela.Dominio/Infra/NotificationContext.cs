using SimulaParcela.Domain.Core;
using SimulaParcela.Domain.Core.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimulaParcela.Dominio.Infra
{
    public class NotificationContext : INotification
    {
        private IList<string> message;

        public bool HasNotificacoes { get { return message.Any(); } }

        public NotificationContext()
            => message = new List<string>();

        public void AddNotificacao(string message)
        {
            this.message.Add(message);
        }

        public Notification GetNotification()
               => new Notification(string.Join(',', message));
    }
}
