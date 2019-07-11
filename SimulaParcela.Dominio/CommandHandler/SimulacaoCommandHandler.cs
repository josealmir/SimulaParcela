using System;
using Rebus.Bus;
using AutoMapper;
using Rebus.Handlers;
using System.Threading.Tasks;
using SimulaParcela.Dominio.Event;
using SimulaParcela.Dominio.IRepository;
using SimulaParcela.Domain.Core.Interface;
using SimulaParcela.Dominio.Model;
using System.Collections.Generic;

namespace SimulaParcela.Dominio.Command
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
                                       ISimulacaoRepository simulacaoRepositorio,
                                       IParcelaRepository parcelaRepositorio,
                                       INotification notificacao)
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
                await _bus.Publish(new SimularParcelamentoEvent(simulacao));
            }
            catch (AggregateException ex)
            {
                _notification.AddNotificacao(ex.Message);
                throw;
            }
            await _unitOfWork.CommitAsync();
        }

        public async Task Handle(SimularParcelamentoEvent message)
        {
            try
            {
                var parcela = new Parcela(message.Simulacao);
                var lista = new List<Parcela>();
                lista.Add(parcela);
                var dataReferencia = parcela.DataDoVencimento;
                
                for (int i = 1; i < message.Simulacao.QuantidadeDeParcela; i++)
                {
                    parcela.CalcularDataVencimento(dataReferencia);
                    dataReferencia = parcela.DataDoVencimento;
                    lista.Add(parcela);
                }
                //foreach (var item in parcelas)
                //{
                //    item.Id = id;
                //    await _parcelaRepositorio.SaveAsync(item);    
                //} 
            }
            catch (AggregateException ex)
            {
                throw; 
            }
            await _unitOfWork.CommitAsync();
        }
    }
}
