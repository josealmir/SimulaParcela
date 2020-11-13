using Rebus.Bus;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimulaParcela.Domain.Command;
using SimulaParcela.Domain.IRepository;
using SimulaParcela.Domain.Core.Interface;

namespace SimulaParcela.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulacaoController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly INotification _notification;
        private readonly ISimulacaoRepository _simulacaoRepositorio;
        
        public SimulacaoController(IBus bus,
                                   INotification notification, 
                                   ISimulacaoRepository simulacaoRepositorio)
        {
            _bus = bus;
            _notification = notification;
            _simulacaoRepositorio = simulacaoRepositorio;
        }           
       
        [HttpPost]
        public async Task<ActionResult> Post(RegistrarNovaSimulacaoCommand model)
        {
            await _bus.Send(model);

            if (_notification.HasNotificacoes)
                return BadRequest(_notification.GetNotification());

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _simulacaoRepositorio.GetAsync();
            return Ok(lista);
        }
    }
}
