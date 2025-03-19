using ABDWNSprint1.DTOs;
using ABDWNSprint1.Models;
using ABDWNSprint1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABDWNSprint1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        /// <summary>
        /// Retorna todos os clientes cadastrados
        /// </summary>
        /// <returns>Lista de Clientes</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ClienteDTO>> ListarClientes()
        {
            var clientes = _clienteRepository.ListarClientes();
            var clienteDTOs = clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Telefone = c.Telefone,
                NumeroCarteiraOdonto = c.NmrCarteiraOdonto,
                QuantidadeConsultas = c.QuantidadeConsultas,
                FotoCliente = c.FotoCliente,
                EnderecoId = c.EnderecoId,
                Endereco = c.Endereco
            });

            return Ok(clienteDTOs);
        }

        /// <summary>
        /// Busca os dados de um Cliente pelo id
        /// </summary>
        /// <param name="id">Id do Cliente</param>
        /// <returns>Dados do Cliente</returns>
        [HttpGet("{id}")]
        public ActionResult<ClienteDTO> BuscarClientePorId(int id)
        {
            var cliente = _clienteRepository.BuscarClientePorId(id);
            if (cliente == null)
                return NotFound();

            var clienteDTO = new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                NumeroCarteiraOdonto = cliente.NmrCarteiraOdonto,
                QuantidadeConsultas = cliente.QuantidadeConsultas,
                FotoCliente = cliente.FotoCliente,
                EnderecoId = cliente.EnderecoId,
                Endereco = cliente.Endereco
            };

            return Ok(clienteDTO);
        }

        /// <summary>
        /// Inseri um novo cliente no banco de dados.
        /// </summary>
        /// <param name="cliente">Dados do cliente</param>
        /// <returns>Dados do cliente inserido.</returns>
        [HttpPost]
        public IActionResult InserirCliente([FromBody] Cliente cliente)
        {
            _clienteRepository.Inserir(cliente);
            return CreatedAtAction(nameof(BuscarClientePorId), new { id = cliente.Id }, cliente);
        }


        /// <summary>
        /// Atualiza os dados de um cliente
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <param name="clienteDTO">Dados do cliente a serem atualizados</param>
        /// <returns>Confirmação da atualização</returns>
        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(int id, [FromBody] ClienteDTO clienteDTO)
        {
            var cliente = _clienteRepository.BuscarClientePorId(id);
            if (cliente == null)
                return NotFound();

            cliente.Nome = clienteDTO.Nome;
            cliente.Telefone = clienteDTO.Telefone;
            cliente.NmrCarteiraOdonto = clienteDTO.NumeroCarteiraOdonto;
            cliente.QuantidadeConsultas = clienteDTO.QuantidadeConsultas;
            cliente.FotoCliente = clienteDTO.FotoCliente;
            cliente.EnderecoId = clienteDTO.EnderecoId;
            cliente.Endereco = clienteDTO.Endereco;

            _clienteRepository.Atualizar(cliente);
            return NoContent();
        }

        /// <summary>
        /// Remover um cliente do banco de dados
        /// </summary>
        /// <param name="id">Id do cliente a ser deletado</param>
        /// <returns>Confirmação da exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletarCliente(int id)
        {
            var cliente = _clienteRepository.BuscarClientePorId(id);
            if (cliente == null)
                return NotFound();

            _clienteRepository.Deletar(id);
            return NoContent();
        }
    }
}
