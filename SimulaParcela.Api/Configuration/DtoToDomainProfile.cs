using AutoMapper;
using SimulaParcela.Domain.Command;
using SimulaParcela.Domain.Model;

namespace SimulaParcela.Api.Configuration
{
    public sealed class DtoToDomainProfile : Profile
  {
      public DtoToDomainProfile()
      {
          CreateMap<RegistrarNovaSimulacaoCommand,Simulacao>();
      }
  }
}
