using CadastroSimples.Domain.Entities;
using CadastroSimples.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadastroSimples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public IEnumerable<Client> GetAll()
        {
            return _clientService.GetAll();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public Client Get(int id)
        {
            return _clientService.Get(id);
        }

        // POST api/<ClientController>
        [HttpPost]
        public Client Post([FromBody] Client client)
        {
            return _clientService.Insert(client);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public Client Put(int id, [FromBody] Client client)
        {
            return _clientService.Update(client);
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public Client Delete(int id)
        {
           return _clientService.Delete(id);
        }
    }
}
