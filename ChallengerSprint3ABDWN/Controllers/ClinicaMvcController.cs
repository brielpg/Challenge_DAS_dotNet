using ABDWNSprint1.Models;
using ABDWNSprint1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ABDWNSprint1.Controllers
{
    public class ClinicaMvcController : Controller
    {
        private readonly IClinicaRepository _clinicaRepository;

        public ClinicaMvcController(IClinicaRepository clinicaRepository)
        {
            _clinicaRepository = clinicaRepository;
        }

        // GET: ClinicaMvc
        public IActionResult Index()
        {
            var clinicas = _clinicaRepository.ListarClinicas();
            return View(clinicas);
        }


        // GET: ClinicaMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClinicaMvc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Clinica clinica)
        {
            if (ModelState.IsValid)
            {
                _clinicaRepository.Inserir(clinica);
                return RedirectToAction(nameof(Index));
            }
            return View(clinica);
        }

        // GET: ClinicaMvc/Edit/5
        public IActionResult Edit(int id)
        {
            var clinica = _clinicaRepository.BuscarClinicaPorId(id);
            if (clinica == null)
            {
                return NotFound();
            }
            return View(clinica);
        }

        // POST: ClinicaMvc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Clinica clinica)
        {
            if (id != clinica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _clinicaRepository.Atualizar(clinica);
                return RedirectToAction(nameof(Index));
            }
            return View(clinica);
        }
    }
}
