namespace SimulaParcela.Dominio.Entidade
{
    public sealed class Notificacao
    {
        public bool Erro { get; private set ; }
        public string MensagemErro { get; set; }

        public Notificacao(string mensagemErro)
        {
            if (!Erro)
                 Erro = true;

            MensagemErro = mensagemErro;
        }
    }
}
