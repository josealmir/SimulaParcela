using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SimulaParcela.Api.Configuration
{
  public static class AutoMapperConfig
  {
     public static IServiceCollection AddAutoMapper(this IServiceCollection services)
     {
         var mapperConfiguration = new MapperConfiguration(mc =>
         {
             mc.AddProfile(new DomainToDtoProfile());
             mc.AddProfile(new DtoToDomainProfile());
         });
         IMapper mapper = mapperConfiguration.CreateMapper();
         services.AddSingleton(mapper);

         return services;
     }
  }
}

