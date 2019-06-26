using SimulaParcela.Dominio.Entidade;
using SimulaParcela.Dominio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulaParcela.Repositorio
{
    public class SimulacaoRepositorio : ISimulacaoRepositorio
    {
           
        private readonly SimulacaoContext _simulacaoContext; 
        public SimulacaoRepositorio(SimulacaoContext simulacaoContext)
                => _simulacaoContext = simulacaoContext;

        public async Task Salvar(Simulacao entidade)
        {
            await _simulacaoContext.Simulacaos.AddAsync(entidade);
            await _simulacaoContext.SaveChangesAsync();         
        }
        public async Task Editar(Simulacao entidade)
        {
            _simulacaoContext.Update(entidade);
            await _simulacaoContext.SaveChangesAsync();
        }
        public async Task Deletar(Simulacao entidade)
        {
            _simulacaoContext.Simulacaos.Remove(entidade);
            await _simulacaoContext.SaveChangesAsync();
        }

        public IList<Simulacao> Get()
                => _simulacaoContext.Simulacaos.ToList();                
    }
}
