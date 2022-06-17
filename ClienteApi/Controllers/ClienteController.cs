using ClienteApi.Models;
using ClienteApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteApi.Controllers
{
    [Route("api/[controller]")] //o cria o cliente
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly ClienteServices _clienteServices;
        public ClienteController(ClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpGet]//retorna lista toda de cliente
        public async Task<List<Cliente>> GetClientes() =>
             await _clienteServices.GetAsync();


        [HttpGet("{id}")]// retorna apenas Id
        public async Task<ActionResult<Cliente>> Get(string id)
        {
            var cliente = await _clienteServices.GetAsync(id);

            if (cliente is null)
            {
                return NotFound();
            }

            return cliente;
        }
        [HttpPost]// inserir minhas inoformações
        public async Task<IActionResult> Post(Cliente novoCliente)
        {
            await _clienteServices.CreateAsync(novoCliente);

            return CreatedAtAction(nameof(Get), new { id = novoCliente.Id }, novoCliente);

        }
        [HttpPut]// Faz alteração
        public async Task<IActionResult> Update(string id, Cliente atualizarCliente)
        {
            var cliente = await _clienteServices.GetAsync(id);

            if (cliente is null)
            {
                return NotFound();
            }

            atualizarCliente.Id = cliente.Id;

            await _clienteServices.UpdateAsync(id, atualizarCliente);

            return NoContent();
        }

        [HttpDelete("{id}")] //esse apaga
        public async Task<IActionResult> Delete(string id)
        {
            var cliente = await _clienteServices.GetAsync(id);

            if (cliente is null)
            {
                return NotFound();
            }

            await _clienteServices.RemoveAsync(id);

            return NoContent();
        }
    }
}




    