using ABDWNSprint1.Models;

namespace ABDWNSprint1.Repositories
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> ListarClientes();
        Cliente BuscarClientePorId(int id);
        void Inserir(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Deletar(int id);
    }
}
