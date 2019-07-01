using AutoMapper;
using Rebus.Bus;
using Rebus.Handlers;
using SimulaParcela.Dominio.Entidade;
using SimulaParcela.Dominio.Event;
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
        private readonly IParcelaRepositorio _parcelaRepositorio;
        private readonly ISimulacaoRepositorio _simulacaoRepositorio;

        public SimulacaoCommandHandler(IBus bus, 
                                       IMapper mapper,
                                       ISimulacaoRepositorio simulacaoRepositorio,
                                       IParcelaRepositorio parcelaRepositorio,
                                       INotificacao notificacao)
        {
            _bus = bus;
            _mapper = mapper;
            _parcelaRepositorio = parcelaRepositorio;
            _simulacaoRepositorio = simulacaoRepositorio;
        }
        

        public async Task Handle(RegistrarNovaSimulacaoCommand command)
        {
            try
            {
                var simulacao = _mapper.Map<Simulacao>(command);
                _simulacaoRepositorio.SalvarAsync(simulacao).Wait();
                await _bus.Publish(new SimularParcelamentoEvent(simulacao));
            }
            catch (AggregateException)
            {
                throw;
            }           
        }

        public async Task Handle(SimularParcelamentoEvent message)
        {
            try
            {
                var id = message.Simulacao.Id;
                var parcelas = message.Simulacao.CalcularParcelamento(message.Simulacao);                
                //await _parcelaRepositorio.SalvarAsync(parcelas);    
            }
            catch (AggregateException ex)
            {
                 throw; 
            }
        }
    }
}
