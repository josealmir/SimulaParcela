using AutoMapper;
using SimulaParcela.Dominio.Command;
using SimulaParcela.Dominio.Entidade;

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
