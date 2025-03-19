using ABDWNSprint1.Models;

namespace ABDWNSprint1.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string NumeroCarteiraOdonto { get; set; }
        public int QuantidadeConsultas { get; set; }
        public string FotoCliente   { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

    }
}
