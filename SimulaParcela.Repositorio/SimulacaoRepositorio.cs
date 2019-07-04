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
           
        private readonly DataContext _simulacaoContext; 
        public SimulacaoRepositorio(DataContext simulacaoContext)
                => _simulacaoContext = simulacaoContext;

        public async Task SalvarAsync(Simulacao entidade)
        {
            await _simulacaoContext.Simulacao.AddAsync(entidade);
            await _simulacaoContext.SaveChangesAsync();         
        }
        public async Task EditarAsync(Simulacao entidade)
        {
            _simulacaoContext.Update(entidade);
            await _simulacaoContext.SaveChangesAsync();
        }
        public async Task DeletarAsync(Simulacao entidade)
        {
            _simulacaoContext.Simulacao.Remove(entidade);
            await _simulacaoContext.SaveChangesAsync();
        }

        public async Task<IList<Simulacao>> GetAsync()
        {   
            var list = await _simulacaoContext.Simulacao.ToListAsync();    
            if (list.Any())
                return list;
            return null;
        }                   
    }
}
