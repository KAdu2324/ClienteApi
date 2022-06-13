using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
      
            private static List<Cliente> Cliente = new List<Cliente>
            {
                new Cliente {
                    Id = 1,
                    Nome = "Carlos",
                    CPF= "12345678912",
                    Contato= "1194856-5689",
                    Email = "hgsdgs@gmail.com",
                    Endereço = "rua junior",
                    Status = "ativo",
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        { 

            return Ok(Cliente);
        }
    }
}
