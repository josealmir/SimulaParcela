using Microsoft.EntityFrameworkCore;
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

        public async Task SalvarAsync(Simulacao entidade)
        {
            await _simulacaoContext.Simulacaos.AddAsync(entidade);
            await _simulacaoContext.SaveChangesAsync();         
        }
        public async Task EditarAsync(Simulacao entidade)
        {
            _simulacaoContext.Update(entidade);
            await _simulacaoContext.SaveChangesAsync();
        }
        public async Task DeletarAsync(Simulacao entidade)
        {
            _simulacaoContext.Simulacaos.Remove(entidade);
            await _simulacaoContext.SaveChangesAsync();
        }

        public async Task<IList<Simulacao>> GetAsync()
        {   
            var list = await _simulacaoContext.Simulacaos.ToListAsync();    
            if (list.Any())
                return list;
            return null;
        }                   
    }
}
