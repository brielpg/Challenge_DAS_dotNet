using ABDWNSprint1.Models;

namespace ABDWNSprint1.Repositories
{
    public interface IRelatorioRepository
    {
        IEnumerable<Relatorio> ListarRelatorios();
        Relatorio BuscarRelatorioPorId(int id);
        void Inserir(Relatorio relatorio);
        void Atualizar(Relatorio relatorio);
    }
}
