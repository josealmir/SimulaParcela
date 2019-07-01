using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rebus.Persistence.InMem;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;
using Rebus.Transport.InMem;
using SimulaParcela.Api.Configuration;
using SimulaParcela.Dominio.Command;
using SimulaParcela.Dominio.Event;
using SimulaParcela.Dominio.IRepositorio;
using SimulaParcela.Dominio.Notification;
using SimulaParcela.Repositorio;

namespace SimulaParcela.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper();
            services.AutoRegisterHandlersFromAssemblyOf<SimulacaoCommandHandler>();
            
            var subscriberStore = new InMemorySubscriberStore();
            services.AddRebus(configure => configure
                    .Transport(t => t.UseInMemoryTransport(new InMemNetwork(), "Messages"))
                    .Subscriptions(s => s.StoreInMemory(subscriberStore))
                    .Routing(r => r.TypeBased().MapAssemblyOf<SimulacaoCommandHandler>("Messages")));                            
            
            services.AddScoped<ISimulacaoRepositorio,SimulacaoRepositorio>();
            services.AddScoped<IParcelaRepositorio,ParcelaRepositorio>();
            services.AddScoped<INotificacao,NotificacaoContext>();
            services.AddScoped<SimulacaoContext>();
            services.AddCors();     
            services.AddControllers()
                    .AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }     
            else
            {
                app.UseHsts();
            }

            app.ApplicationServices.UseRebus(async bus => await bus.Subscribe<SimularParcelamentoEvent>());

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
 
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
