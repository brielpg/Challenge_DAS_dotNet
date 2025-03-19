using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ABDWNSprint1.Models
{
    [Table("TB_Relatorios")]
    public class Relatorio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(255)]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(255)]
        public string Medico { get; set; }

        [Required]
        public DateTime DataConsulta { get; set; }

        public DateTime DataEnvioRelatorio { get; set; }

        [Required]
        public decimal ValorConsulta { get; set; }

        public string Status { get; set; }

        [Required]
        public string Imagem { get; set; }



        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int ClinicaId { get; set; }
    }
}
