namespace SimulaParcela.Domain.Core
{
    public class Notification
    {
        public bool Erro { get; private set ; }
        public string MensagemErro { get; set; }

        public Notification(string mensagemErro)
        {
            if (!Erro)
                 Erro = true;

            MensagemErro = mensagemErro;
        }
    }
}
