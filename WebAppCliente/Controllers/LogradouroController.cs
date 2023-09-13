using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppCliente.Models;
using WebAppCliente.Repositories.Interfaces;

namespace WebAppCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogradouroController : ControllerBase
    {
        private readonly ILogradouroRepositorio _logradouroRepositorio;

        public LogradouroController(ILogradouroRepositorio logradouroRepositorio)
        {
            _logradouroRepositorio = logradouroRepositorio;
                
        }

        [HttpGet]
        public async Task<ActionResult<List<LogradouroModel>>> ListarTodosLogradouros()
        {
            List<LogradouroModel> logradouros = await _logradouroRepositorio.ListarTodosLogradouros();
            return Ok(logradouros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LogradouroModel>> BuscarPorId(int id)
        {
            LogradouroModel logradouro = await _logradouroRepositorio.BuscarPorId(id);
            return Ok(logradouro);
        }

        [HttpPost]
        public async Task<ActionResult<LogradouroModel>> Cadastrar([FromBody] LogradouroModel logradouroModel)
        {
            LogradouroModel logradouro = await _logradouroRepositorio.Adicionar(logradouroModel);
            return Ok(logradouro);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LogradouroModel>> Atualizar([FromBody] LogradouroModel logradouroModel, int id)
        {
            logradouroModel.Id = id;
            LogradouroModel logradouro = await _logradouroRepositorio.Atualizar(logradouroModel, id);
            return Ok(logradouro);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LogradouroModel>> Apagar(int id)
        {
            bool apagado = await _logradouroRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
