using Microsoft.AspNetCore.Mvc;
using Projekat.Core.Contract;
using Projekat.Core.Domain.Entities;
using Projekat.Core.Services.Abstraction;

namespace Projekat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(Guid id)
        {
            var result = _clientService.GetClient(id);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllClients()
        {
            var result = _clientService.GetAllClients();

            return Ok(result);

        }

        [HttpPost]
        public IActionResult InsertClient([FromBody] ClientDtoInsert client)
        {
            Client createdClient = _clientService.InsertClient(client);
            return CreatedAtAction(nameof(GetClient), new { id = client }, client);
        }

        [HttpPut]
        public IActionResult UpdateClient(Client client)
        {
            _clientService.UpdateClient(client);
            return Ok("Updated done");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(Guid Id)
        {
            _clientService.DeleteClient(Id);
            return Ok("Data Deleted");
        }
    }
}