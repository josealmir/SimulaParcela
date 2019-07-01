using SimulaParcela.Dominio.Entidade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulaParcela.Dominio.IRepositorio
{
    public interface IParcelaRepositorio
    {
        Task SalvarAsync(Parcela entidade);
        Task SalvarAsync(IList<Parcela> lista);
        Task DeletarAsync(Parcela entidade);
        Task EditarAsync(Parcela entidade);
    }
}
