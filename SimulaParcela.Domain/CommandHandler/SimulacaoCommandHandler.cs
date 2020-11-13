using System;
using Rebus.Bus;
using AutoMapper;
using Rebus.Handlers;
using System.Threading.Tasks;
using SimulaParcela.Domain.Event;
using SimulaParcela.Domain.IRepository;
using SimulaParcela.Domain.Core.Interface;
using SimulaParcela.Domain.Model;
using System.Collections.Generic;

namespace SimulaParcela.Domain.Command
{
    public class SimulacaoCommandHandler : IHandleMessages<RegistrarNovaSimulacaoCommand>, IHandleMessages<SimularParcelamentoEvent>
    {        
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotification _notification;
        private readonly IParcelaRepository _parcelaRepositorio;
        private readonly ISimulacaoRepository _simulacaoRepositorio;

        public SimulacaoCommandHandler(IBus bus, 
                                       IMapper mapper,
                                       IUnitOfWork unitOfWork,
                                       INotification notificacao,
                                       IParcelaRepository parcelaRepositorio,
                                       ISimulacaoRepository simulacaoRepositorio)
        {
            _bus = bus;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _notification = notificacao;
            _parcelaRepositorio = parcelaRepositorio;
            _simulacaoRepositorio = simulacaoRepositorio;
        }
        

        public async Task Handle(RegistrarNovaSimulacaoCommand command)
        {
            try
            {
                var simulacao = _mapper.Map<Simulacao>(command);
                await _simulacaoRepositorio.SaveAsync(simulacao);
                await _unitOfWork.CommitAsync();
                await _bus.Publish(new SimularParcelamentoEvent(simulacao));
            }
            catch (AggregateException ex)
            {
                _notification.AddNotificacao(ex.Message);
                throw;
            }            
        }

        public async Task Handle(SimularParcelamentoEvent message)
        {
            try
            {
                var parcela = new Parcela(message.Simulacao);
                var dataReferencia = parcela.DataDoVencimento;
                var lista = new List<Parcela>();
                for (int i = 1; i <= message.Simulacao.QuantidadeDeParcela; i++)
                {                
                    dataReferencia = parcela.CalcularDataVencimento(dataReferencia);
                    lista.Add(parcela);
                }
                await _parcelaRepositorio.SaveAsync(lista);         
                await _unitOfWork.CommitAsync();
            }
            catch (AggregateException ex)
            {
                throw; 
            }

        }
    }
}
