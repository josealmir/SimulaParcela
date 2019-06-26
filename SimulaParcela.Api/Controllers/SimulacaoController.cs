using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;
using SimulaParcela.Dominio.Command;
using SimulaParcela.Dominio.IRepositorio;
using SimulaParcela.Repositorio;
using System.Threading.Tasks;

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
       
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            //var lista = _simulacaoRepositorio.Get();
            return Ok();
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
    }
}
