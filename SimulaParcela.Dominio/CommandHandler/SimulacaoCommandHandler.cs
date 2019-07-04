using System;
using Rebus.Bus;
using AutoMapper;
using Rebus.Handlers;
using System.Threading.Tasks;
using SimulaParcela.Dominio.Event;
using SimulaParcela.Dominio.IRepositorio;
using SimulaParcela.Domain.Core.Interface;
using SimulaParcela.Dominio.Entidade;

namespace SimulaParcela.Dominio.Command
{
    public class SimulacaoCommandHandler : IHandleMessages<RegistrarNovaSimulacaoCommand>, IHandleMessages<SimularParcelamentoEvent>
    {        
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IParcelaRepositorio _parcelaRepositorio;
        private readonly ISimulacaoRepositorio _simulacaoRepositorio;

        public SimulacaoCommandHandler(IBus bus, 
                                       IMapper mapper,
                                       IUnitOfWork unitOfWork,
                                       ISimulacaoRepositorio simulacaoRepositorio,
                                       IParcelaRepositorio parcelaRepositorio,
                                       INotification notificacao)
        {
            _bus = bus;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _parcelaRepositorio = parcelaRepositorio;
            _simulacaoRepositorio = simulacaoRepositorio;
        }
        

        public async Task Handle(RegistrarNovaSimulacaoCommand command)
        {
            try
            {
                var simulacao = _mapper.Map<Simulacao>(command);
                await _simulacaoRepositorio.SalvarAsync(simulacao);
                await _bus.Publish(new SimularParcelamentoEvent(simulacao));

            }
            catch (AggregateException)
            {
                throw;
            }

            await _unitOfWork.CommitAsync();
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
