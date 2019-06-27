using AutoMapper;
using Rebus.Bus;
using Rebus.Handlers;
using SimulaParcela.Dominio.Entidade;
using SimulaParcela.Dominio.Envet;
using SimulaParcela.Dominio.IRepositorio;
using SimulaParcela.Dominio.Notification;
using System;
using System.Threading.Tasks;

namespace SimulaParcela.Dominio.Command
{
    public class SimulacaoCommandHandler : IHandleMessages<RegistrarNovaSimulacaoCommand>, IHandleMessages<SimularParcelamentoEvent>
    {        
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly ISimulacaoRepositorio _simulacaoRepositorio;

        public SimulacaoCommandHandler(IBus bus, 
                                       IMapper mapper,
                                       ISimulacaoRepositorio simulacaoRepositorio,
                                       INotificacao notificacao)
        {
            _bus = bus;
            _mapper = mapper;
            _simulacaoRepositorio = simulacaoRepositorio;
        }
        

        public async Task Handle(RegistrarNovaSimulacaoCommand command)
        {
            try
            {
                var simulacao = _mapper.Map<Simulacao>(command);
                //_simulacaoRepositorio.Salvar(simulacao).Wait();
                simulacao.Id = 22;
                await _bus.Publish(new SimularParcelamentoEvent(simulacao));
            }
            catch (Exception ex)
            {
                throw;
            }           
        }

        public async Task Handle(SimularParcelamentoEvent message)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
