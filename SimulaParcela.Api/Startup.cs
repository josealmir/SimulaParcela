using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rebus.ServiceProvider;
using SimulaParcela.Api.Configuration;
using SimulaParcela.Domain.Core.Interface;
using SimulaParcela.Domain.Command;
using SimulaParcela.Domain.Event;
using SimulaParcela.Domain.Infra;
using SimulaParcela.Domain.IRepository;
using SimulaParcela.Repositorio;
using SimulaParcela.Repositorio.Context;

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
            services.AutoRegisterHandlersFromAssemblyOf<RegistrarNovaSimulacaoCommand>();
            services.AddAutoMapper();
            services.AddRebus();
            services.AddScoped<ISimulacaoRepository,SimulacaoRepository>();
            services.AddScoped<IParcelaRepository,ParcelaRepository>();
            services.AddScoped<INotification , NotificationContext>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<DataContext>();
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
