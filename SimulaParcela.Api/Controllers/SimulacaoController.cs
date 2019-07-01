using Rebus.Bus;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimulaParcela.Dominio.Command;
using SimulaParcela.Dominio.IRepositorio;

namespace SimulaParcela.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulacaoController : ControllerBase
    {
        private ISimulacaoRepositorio _simulacaoRepositorio;
        private readonly IBus _bus;

        public SimulacaoController(IBus bus, ISimulacaoRepositorio simulacaoRepositorio)
        {
            _bus = bus;
            _simulacaoRepositorio = simulacaoRepositorio;
        }           
       
        [HttpPost]
        public async Task<ActionResult> Post(RegistrarNovaSimulacaoCommand model)
        {
            await _bus.Send(model);          
            return Ok();
        }

        [HttpPut("{id}")]
        public void Put()
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var lista = await _simulacaoRepositorio.GetAsync();
            return Ok(lista);
        }
    }
}
