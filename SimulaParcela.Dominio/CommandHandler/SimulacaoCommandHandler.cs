using AutoMapper;
using Rebus.Bus;
using Rebus.Handlers;
using SimulaParcela.Dominio.Entidade;
using SimulaParcela.Dominio.Envet;
using SimulaParcela.Dominio.IRepositorio;
using System;
using System.Threading.Tasks;

namespace SimulaParcela.Dominio.Command
{
    public class SimulacaoCommandHandler : IHandleMessages<RegistrarNovaSimulacaoCommand>, IHandleMessages<SimularParcelamentoEvento>
    {        
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly ISimulacaoRepositorio _simulacaoRepositorio;

        public SimulacaoCommandHandler(IBus bus, 
                                       IMapper mapper,
                                       ISimulacaoRepositorio simulacaoRepositorio)
        {
            _bus = bus;
            _mapper = mapper;
            _simulacaoRepositorio = simulacaoRepositorio;
            _bus.Subscribe<SimularParcelamentoEvento>();
        }
        

        public async Task Handle(RegistrarNovaSimulacaoCommand command)
        {
            try
            {
                var simulacao = _mapper.Map<Simulacao>(command);
                //await _simulacaoRepositorio.Salvar(simulacao);
                await _bus.Publish(new SimularParcelamentoEvento(simulacao));
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public async Task Handle(SimularParcelamentoEvento message)
        {
             var teste =  message;
        }
    }
}
