using WebAppCliente.Models;

namespace WebAppCliente.Repositories.Interfaces
{
    public interface ILogradouroRepositorio
    {
        Task<List<LogradouroModel>> ListarTodosLogradouros();
        Task<LogradouroModel> BuscarPorId(int id);
        Task<LogradouroModel> Adicionar(LogradouroModel logradouro);
        Task<LogradouroModel> Atualizar(LogradouroModel logradouro, int id);
        Task<bool> Apagar(int id);
    }
}
