using Microsoft.EntityFrameworkCore;
using SimulaParcela.Domain.Core.Interface;
using SimulaParcela.Dominio.Entidade;
using SimulaParcela.Dominio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulaParcela.Repositorio
{
    public class ParcelaRepositorio : IParcelaRepositorio
    {
           
        private readonly SimulacaoContext _ParcelaContext; 

        public ParcelaRepositorio(DataContext ParcelaContext)
                => _ParcelaContext = ParcelaContext;

        public async Task SalvarAsync(Parcela entidade)
        {
            await _ParcelaContext.Parcela.AddAsync(entidade);
        }

        public async Task SalvarAsync(IList<Parcela> lista)
        {

            foreach(var item in lista)
            {
                await _ParcelaContext.Parcela.AddAsync(item);    
                await _ParcelaContext.SaveChangesAsync();         
            }
        }   

        public async Task EditarAsync(Parcela entidade)
        {
            _ParcelaContext.Update(entidade);
            await _ParcelaContext.SaveChangesAsync();
        }
        public async Task DeletarAsync(Parcela entidade)
        {
            _ParcelaContext.Parcela.Remove(entidade);
            await _ParcelaContext.SaveChangesAsync();
        }

        public async Task<IList<Parcela>> GetAsync()
                => await _ParcelaContext.Parcela.ToListAsync();                
    }
}
