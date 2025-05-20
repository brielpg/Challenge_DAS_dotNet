using ABDWNSprint1.Models;

namespace ABDWNSprint1.DTOs
{
    public class RelatorioEditDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Medico { get; set; }
        public DateTime DataConsulta { get; set; }
        public decimal ValorConsulta { get; set; }
        public string Imagem { get; set; }
        public int ClienteId { get; set; }
        public int ClinicaId { get; set; }
    }
}
