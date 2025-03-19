using ABDWNSprint1.DTOs;
using ABDWNSprint1.Models;
using ABDWNSprint1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABDWNSprint1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        private readonly IClinicaRepository _clinicaRepository;

        public ClinicaController(IClinicaRepository clinicaRepository)
        {
            _clinicaRepository = clinicaRepository;
        }

        /// <summary>
        /// Retorna todos as clinicas cadastrados
        /// </summary>
        /// <returns>Lista de Clinicas</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ClinicaDTO>> ListarClinicas()
        {
            var clinicas = _clinicaRepository.ListarClinicas();
            var clinicaDTOs = clinicas.Select(c => new ClinicaDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Telefone = c.Telefone,
                Email = c.Email,
                RazaoSocial = c.RazaoSocial,
                FotoClinica = c.FotoClinica,
                EnderecoId = c.EnderecoId,
                Endereco = c.Endereco
            });

            return Ok(clinicaDTOs);
        }


        /// <summary>
        /// Busca uma clinica pelo ID
        /// </summary>
        /// <param name="id">Id da clinica</param>
        /// <returns>Retorna os dados da clinica</returns>
        [HttpGet("{id}")]
        public ActionResult<ClinicaDTO> BuscarClinicaPorId(int id)
        {
            var clinica = _clinicaRepository.BuscarClinicaPorId(id);
            if (clinica == null)
                return NotFound();

            var clinicaDTO = new ClinicaDTO
            {
                Id = clinica.Id,
                Nome = clinica.Nome,
                Telefone = clinica.Telefone,
                Email = clinica.Email,
                RazaoSocial = clinica.RazaoSocial,
                FotoClinica = clinica.FotoClinica,
                EnderecoId = clinica.EnderecoId,
                Endereco = clinica.Endereco
            };

            return Ok(clinicaDTO);
        }


        /// <summary>
        /// Adiciona uma nova clinica ao banco de dados 
        /// </summary>
        /// <param name="clinica">Dados da clinica</param>
        /// <returns>Dados da clinica inserido</returns>
        [HttpPost]
        public IActionResult InserirClinica([FromBody] Clinica clinica)
        {
            _clinicaRepository.Inserir(clinica);
            return CreatedAtAction(nameof(BuscarClinicaPorId), new { id = clinica.Id }, clinica);
        }


        /// <summary>
        /// Atualiza os dados da clinica
        /// </summary>
        /// <param name="id">Id da clinica a ser atualizada</param>
        /// <param name="clinicaDTO">Dados da clinica a serem atualizados</param>
        /// <returns>Confirmação da atualização</returns>
        [HttpPut("{id}")]
        public IActionResult AtualizarClinica(int id, [FromBody] ClinicaDTO clinicaDTO)
        {
            var clinica = _clinicaRepository.BuscarClinicaPorId(id);
            if (clinica == null)
                return NotFound();

            clinica.Nome = clinicaDTO.Nome;
            clinica.Telefone = clinicaDTO.Telefone;
            clinica.Email = clinicaDTO.Email;
            clinica.RazaoSocial = clinicaDTO.RazaoSocial;
            clinica.FotoClinica = clinicaDTO.FotoClinica;
            clinica.EnderecoId = clinicaDTO.EnderecoId;
            clinica.Endereco = clinicaDTO.Endereco;

            _clinicaRepository.Atualizar(clinica);
            return NoContent();
        }


        /// <summary>
        /// Realiza o login da clinica com base no email e senha
        /// </summary>
        /// <param name="loginDTO">Email e senha da clinica</param>
        /// <returns>Retorna se o login for bem sucedido</returns>
        [HttpPost("login")]
        public ActionResult<ClinicaDTO> Login([FromBody] LoginClinicaDTO loginDTO)
        {
            var clinica = _clinicaRepository.Login(loginDTO.Email, loginDTO.Senha);
            if (clinica == null)
                return Unauthorized();

            var clinicaDTO = new ClinicaDTO
            {
                Id = clinica.Id,
                Nome = clinica.Nome,
                Telefone = clinica.Telefone,
                Email = clinica.Email,
                RazaoSocial = clinica.RazaoSocial,
                FotoClinica = clinica.FotoClinica,
                EnderecoId = clinica.EnderecoId,
                Endereco = clinica.Endereco
            };

            return Ok(clinicaDTO);
        }
    }
}
