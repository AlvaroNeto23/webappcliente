using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppCliente.Models;
using WebAppCliente.Repositories.Interfaces;

namespace WebAppCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
                
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> ListarTodosClientes()
        {
            List<ClienteModel> clientes = await _clienteRepositorio.ListarTodosClientes();
            return Ok(clientes);
        }

        //***Busca no banco de dados utilizando STORE PROCEDURE
        [HttpGet("SP")]
        public async Task<ActionResult<List<ClienteModel>>> ListarTodosClientes_SP()
        {
            List<ClienteModel> clientes = await _clienteRepositorio.ListarTodosClientes_SP();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> BuscarPorId(int id)
        {
            ClienteModel cliente = await _clienteRepositorio.BuscarPorId(id);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteModel>> Cadastrar([FromBody] ClienteModel clienteModel)
        {
            ClienteModel cliente = await _clienteRepositorio.Adicionar(clienteModel);
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteModel>> Atualizar([FromBody] ClienteModel clienteModel, int id)
        {
            clienteModel.Id = id;
            ClienteModel cliente = await _clienteRepositorio.Atualizar(clienteModel, id);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteModel>> Apagar(int id)
        {
            bool apagado = await _clienteRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
