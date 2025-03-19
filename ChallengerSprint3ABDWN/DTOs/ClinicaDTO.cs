using ABDWNSprint1.Models;

namespace ABDWNSprint1.DTOs
{
    public class ClinicaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string RazaoSocial { get; set; }
        public string FotoClinica { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
