using WebAppCliente.Models;

namespace WebAppCliente.Repositories.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<List<ClienteModel>> ListarTodosClientes();

        //***Busca no banco de dados utilizando STORE PROCEDURE
        Task<List<ClienteModel>> ListarTodosClientes_SP();
        Task<ClienteModel> BuscarPorId(int id);

        //***Verificar E-mail Duplicado
        Task<ClienteModel> VerificarEmailDuplicado(string email);        
        Task<ClienteModel> Adicionar(ClienteModel cliente);
        Task<ClienteModel> Atualizar(ClienteModel cliente, int id);
        Task<bool> Apagar(int id);
    }
}
