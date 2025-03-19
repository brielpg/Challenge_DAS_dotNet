using ABDWNSprint1.Models;
using ABDWNSprint1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABDWNSprint1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioController(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        /// <summary>
        /// Listagem dos relatorios do banco de dados.
        /// </summary>
        /// <returns>Lista de relatorios.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Relatorio>> ListarRelatorios()
        {
            return Ok(_relatorioRepository.ListarRelatorios());
        }

        /// <summary>
        /// Busca um relatorio pelo ID.
        /// </summary>
        /// <param name="id">ID do relatório a ser procurado.</param>
        /// <returns>Retorna com o relatorio do id.</returns>
        [HttpGet("{id}")]
        public ActionResult<Relatorio> BuscarRelatorioPorId(int id)
        {
            var relatorio = _relatorioRepository.BuscarRelatorioPorId(id);
            if (relatorio == null)
                return NotFound();

            return Ok(relatorio);
        }

        /// <summary>
        /// Adiciona um novo relatório ao sistema.
        /// </summary>
        /// <param name="relatorio">Dados do relatório a ser criado.</param>
        /// <returns>Retorna o relatorio inserido.</returns>
        [HttpPost]
        public IActionResult InserirRelatorio([FromBody] Relatorio relatorio)
        {
            _relatorioRepository.Inserir(relatorio);
            return CreatedAtAction(nameof(BuscarRelatorioPorId), new { id = relatorio.Id }, relatorio);
        }

        /// <summary>
        /// Atualiza um relatório existente no sistema.
        /// </summary>
        /// <param name="id">ID do relatório a ser atualizado.</param>
        /// <param name="relatorioAtualizado">Dados atualizados do relatório.</param>
        /// <returns>Adiciona ao banco o relatorio atualizado.</returns>
        [HttpPut("{id}")]
        public IActionResult AtualizarRelatorio(int id, [FromBody] Relatorio relatorioAtualizado)
        {
            var relatorio = _relatorioRepository.BuscarRelatorioPorId(id);
            if (relatorio == null)
                return NotFound();

            relatorio.Titulo = relatorioAtualizado.Titulo;
            relatorio.Descricao = relatorioAtualizado.Descricao;
            relatorio.Medico = relatorioAtualizado.Medico;
            relatorio.DataConsulta = relatorioAtualizado.DataConsulta;
            relatorio.DataEnvioRelatorio = relatorioAtualizado.DataEnvioRelatorio;
            relatorio.ValorConsulta = relatorioAtualizado.ValorConsulta;
            relatorio.Status = relatorioAtualizado.Status;
            relatorio.Imagem = relatorioAtualizado.Imagem;
            relatorio.ClienteId = relatorioAtualizado.ClienteId;
            relatorio.ClinicaId = relatorioAtualizado.ClinicaId;

            _relatorioRepository.Atualizar(relatorio);
            return NoContent();
        }
    }
}
