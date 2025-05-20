using ABDWNSprint1.Models;
using ABDWNSprint1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ABDWNSprint1.Controllers
{
    public class ClienteMvcController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteMvcController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET: ClienteMvc
        public IActionResult Index()
        {
            var clientes = _clienteRepository.ListarClientes();
            return View(clientes);
        }

        // GET: ClienteMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClienteMvc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.Inserir(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: ClienteMvc/Edit/5
        public IActionResult Edit(int id)
        {
            var cliente = _clienteRepository.BuscarClientePorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: ClienteMvc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _clienteRepository.Atualizar(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }
    }
}
