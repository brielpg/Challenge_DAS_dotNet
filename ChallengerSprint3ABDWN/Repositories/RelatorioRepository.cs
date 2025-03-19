using ABDWNSprint1.Models;
using ABDWNSprint1.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ABDWNSprint1.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly FIAPDbContext _context;

        public RelatorioRepository(FIAPDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Relatorio> ListarRelatorios()
        {
            return _context.Relatorios
                .ToList();
        }

        public Relatorio BuscarRelatorioPorId(int id)
        {
            return _context.Relatorios
                .FirstOrDefault(r => r.Id == id);
        }

        public void Inserir(Relatorio relatorio)
        {
            _context.Relatorios.Add(relatorio);
            _context.SaveChanges();
        }

        public void Atualizar(Relatorio relatorio)
        {
            _context.Relatorios.Update(relatorio);
            _context.SaveChanges();
        }
    }
}
