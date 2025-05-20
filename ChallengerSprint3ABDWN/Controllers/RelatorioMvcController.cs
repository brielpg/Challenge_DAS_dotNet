using ABDWNSprint1.Models;
using ABDWNSprint1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ABDWNSprint1.Controllers
{
    public class RelatorioMvcController : Controller
    {
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioMvcController(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        // GET: RelatorioMvc
        public IActionResult Index()
        {
            var relatorios = _relatorioRepository.ListarRelatorios();
            return View(relatorios);
        }

        // GET: RelatorioMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RelatorioMvc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Relatorio relatorio)
        {
            if (ModelState.IsValid)
            {
                _relatorioRepository.Inserir(relatorio);
                return RedirectToAction(nameof(Index));
            }
            return View(relatorio);
        }

        // GET: RelatorioMvc/Edit/5
        public IActionResult Edit(int id)
        {
            var relatorio = _relatorioRepository.BuscarRelatorioPorId(id);
            if (relatorio == null)
            {
                return NotFound();
            }
            return View(relatorio);
        }

        // POST: RelatorioMvc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Relatorio relatorio)
        {
            if (id != relatorio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _relatorioRepository.Atualizar(relatorio);
                return RedirectToAction(nameof(Index));
            }
            return View(relatorio);
        }
    }
}
