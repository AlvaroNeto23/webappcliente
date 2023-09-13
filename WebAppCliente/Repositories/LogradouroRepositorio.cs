using Microsoft.EntityFrameworkCore;
using WebAppCliente.Data;
using WebAppCliente.Models;
using WebAppCliente.Repositories.Interfaces;

namespace WebAppCliente.Repositories
{
    public class LogradouroRepositorio : ILogradouroRepositorio
    {
        private readonly WebAppClienteDbContext _dbContext;
        public LogradouroRepositorio(WebAppClienteDbContext webAppClienteDbContext)
        {
            _dbContext = webAppClienteDbContext;
        }

        public async Task<List<LogradouroModel>> ListarTodosLogradouros()
        {
            return await _dbContext.Logradouros
                .Include(x => x.Cliente)
                .ToListAsync();
        }

        public async Task<LogradouroModel> BuscarPorId(int id)
        {
            return await _dbContext.Logradouros
                .Include(x => x.Cliente)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<LogradouroModel> Adicionar(LogradouroModel logradouro)
        {
            await _dbContext.Logradouros.AddAsync(logradouro);
            await _dbContext.SaveChangesAsync();

            return logradouro;
        }        

        public async Task<LogradouroModel> Atualizar(LogradouroModel logradouro, int id)
        {
            LogradouroModel logradouroAtualizar = await BuscarPorId(id);
            
            if (logradouroAtualizar == null)
            {
                throw new Exception($"Não foi encontrado um Logradouro com este Id: {id}");
            }

            logradouroAtualizar.Logradouro = logradouro.Logradouro;
            logradouroAtualizar.IsActive = logradouro.IsActive;
            logradouroAtualizar.ClienteId = logradouro.ClienteId;

            _dbContext.Logradouros.Update(logradouroAtualizar);
            await _dbContext.SaveChangesAsync();

            return logradouroAtualizar;
        }

        public async Task<bool> Apagar(int id)
        {
            LogradouroModel logradouroPorId = await BuscarPorId(id);

            if (logradouroPorId == null)
            {
                throw new Exception($"Não foi encontrado um Logradouro com este Id: {id}");
            }

            _dbContext.Logradouros.Remove(logradouroPorId);
            await _dbContext.SaveChangesAsync();
            
            return true;
        }
    }
}
