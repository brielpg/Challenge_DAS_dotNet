using ABDWNSprint1.Models;
using ABDWNSprint1.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ABDWNSprint1.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly FIAPDbContext _context;

        public ClinicaRepository(FIAPDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Clinica> ListarClinicas()
        {
            return _context.Clinicas.Include(c => c.Endereco).ToList();
        }

        public Clinica BuscarClinicaPorId(int id)
        {
            return _context.Clinicas.Include(c => c.Endereco).FirstOrDefault(c => c.Id == id);
        }

        public void Inserir(Clinica clinica)
        {
            _context.Clinicas.Add(clinica);
            _context.SaveChanges();
        }

        public void Atualizar(Clinica clinica)
        {
            _context.Clinicas.Update(clinica);
            _context.SaveChanges();
        }

        public Clinica Login(string email, string senha)
        {
            return _context.Clinicas.FirstOrDefault(c => c.Email == email && c.Senha == senha);
        }
    }
}
