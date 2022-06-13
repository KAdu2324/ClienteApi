using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private static List<Cliente> Cliente = new List<Cliente> ;
           

        [HttpGet]//retorna lista toda de cliente
        public async Task<ActionResult<List<Cliente>>> Get()
        {

            return Ok(Cliente);
        }

        [HttpGet("{id}")]// retorna apenas Id
        public async Task<ActionResult<Cliente>> Get( int id)

        {
            var cliente = Cliente.Find(h => h.Id == id);
            if(cliente == null)
                return BadRequest("Cliente não encontrado.");
            return Ok(Cliente);
        }

        [HttpPost]// inserir minhas inoformações
        public async Task<ActionResult<List<Cliente>>> AddCliente(Cliente cliente)
        {
            Cliente.Add(cliente); 
            return Ok(Cliente);
        }
        [HttpPut]// Faz alteração
        public async Task<ActionResult<List<Cliente>>> UpdateCliente(Cliente request)
        {
            var cliente = Cliente.Find(h => h.Id == request.Id);
            if (cliente == null)
                return BadRequest("Cliente não encontrado.");
            
            cliente.Nome = request.Nome;
            cliente.CPF = request.CPF;
            cliente.Email = request.Email;
            cliente.Endereço = request.Endereço;
            cliente.Contato = request.Contato;
            cliente.Status = request.Status;


            return Ok(Cliente);
        }
        [HttpDelete("{id}")] //esse apaga
        public async Task<ActionResult<Cliente>> Delete(int id)

        {
            var cliente = Cliente.Find(h => h.Id == id);
            if (cliente == null)
                return BadRequest("Cliente não encontrado.");

            cliente.Remove(cliente);
            return Ok(Cliente);
        }

    }
}
    