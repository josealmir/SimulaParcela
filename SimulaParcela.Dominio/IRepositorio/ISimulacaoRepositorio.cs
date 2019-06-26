using SimulaParcela.Dominio.Entidade;
using System.Threading.Tasks;

namespace SimulaParcela.Dominio.IRepositorio
{
    public interface ISimulacaoRepositorio
    {
        Task Salvar(Simulacao entidade);
        Task Deletar(Simulacao entidade);
        Task Editar(Simulacao entidade);
    }
}
