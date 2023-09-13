using Microsoft.EntityFrameworkCore;
using WebAppCliente.Data;
using WebAppCliente.Models;
using WebAppCliente.Repositories.Interfaces;

namespace WebAppCliente.Repositories
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly WebAppClienteDbContext _dbContext;
        public ClienteRepositorio(WebAppClienteDbContext webAppClienteDbContext)
        {
            _dbContext = webAppClienteDbContext;
        }

        public async Task<List<ClienteModel>> ListarTodosClientes()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        //***Busca no banco de dados utilizando STORE PROCEDURE
        public async Task<List<ClienteModel>> ListarTodosClientes_SP()
        {
            return await _dbContext.Clientes.FromSqlRaw("SP_GetAllClients").ToListAsync();
        }

        public async Task<ClienteModel> BuscarPorId(int id)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        //***Verificar E-mail Duplicado
        public async Task<ClienteModel> VerificarEmailDuplicado(string email)
        {
            int count = _dbContext.Clientes.Count(x => x.Email == email);

            if (count > 1)
                return null;
            else
                return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<ClienteModel> Adicionar(ClienteModel cliente)
        {
            ClienteModel clienteAtualizar = await VerificarEmailDuplicado(cliente.Email);

            if (clienteAtualizar == null)
            {
                throw new Exception($"Este e-mail já existe: {cliente.Email}");
            }

            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }        

        public async Task<ClienteModel> Atualizar(ClienteModel cliente, int id)
        {
            ClienteModel clienteAtualizar = await BuscarPorId(id);
            
            if (clienteAtualizar == null)
            {
                throw new Exception($"Não foi encontrado um Cliente com este Id: {id}");
            }

            clienteAtualizar = await VerificarEmailDuplicado(cliente.Email);

            if (clienteAtualizar == null)
            {
                throw new Exception($"Este e-mail já existe: {cliente.Email}");
            }

            clienteAtualizar.Nome = cliente.Nome;
            clienteAtualizar.Email = cliente.Email;
            clienteAtualizar.Logotipo = cliente.Logotipo;
            clienteAtualizar.IsActive = cliente.IsActive;

            _dbContext.Clientes.Update(clienteAtualizar);
            await _dbContext.SaveChangesAsync();

            return clienteAtualizar;
        }

        public async Task<bool> Apagar(int id)
        {
            ClienteModel clientePorId = await BuscarPorId(id);

            if (clientePorId == null)
            {
                throw new Exception($"Não foi encontrado um Cliente com este Id: {id}");
            }

            _dbContext.Clientes.Remove(clientePorId);
            await _dbContext.SaveChangesAsync();
            
            return true;
        }
    }
}
