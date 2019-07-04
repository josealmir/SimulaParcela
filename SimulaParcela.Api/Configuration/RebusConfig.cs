using Microsoft.Extensions.DependencyInjection;
using Rebus.Persistence.InMem;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;
using Rebus.Transport.InMem;
using SimulaParcela.Dominio.Command;

namespace SimulaParcela.Api.Configuration
{
    public static class RebusConfig
    {
        public static IServiceCollection AddRebus(this IServiceCollection services)
        {
            var subscriberStore = new InMemorySubscriberStore();
            services.AddRebus(configure => configure
                    .Transport(t => t.UseInMemoryTransport(new InMemNetwork(), "Messages"))
                    .Subscriptions(s => s.StoreInMemory(subscriberStore))
                    .Routing(r => r.TypeBased().MapAssemblyOf<SimulacaoCommandHandler>("Messages")));
            return services;
        }
    }
}


