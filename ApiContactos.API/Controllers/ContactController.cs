using ApiContactos.Application.Features.Interface.Client;
using Microsoft.AspNetCore.Mvc;

namespace ApiContactos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IClientQuery _clientQuery;

        public ContactController(IClientQuery clientQuery) {
            _clientQuery = clientQuery;
         }
        
        [HttpGet("Healt")]
        public async Task<ActionResult<string>> HealthCheck()
        {
            try
            {
                return Ok("I'm alive");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllContacs")]
        public async Task<bool> GetAllContacs ()
        {
            var clients = await _clientQuery.GetAllClients();
            return true;
        }

    }

}
