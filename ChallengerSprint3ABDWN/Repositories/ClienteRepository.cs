using ABDWNSprint1.Persistence;
using ABDWNSprint1.Models;
using Microsoft.EntityFrameworkCore;


namespace ABDWNSprint1.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly FIAPDbContext _context;

        public ClienteRepository(FIAPDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> ListarClientes()
        {
            return _context.Clientes.Include(c => c.Endereco).ToList();
        }

        public Cliente BuscarClientePorId(int id)
        {
            return _context.Clientes.Include(c => c.Endereco).FirstOrDefault(c => c.Id == id);
        }

        public void Inserir(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Atualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
