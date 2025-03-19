using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ABDWNSprint1.Models
{
    [Table("TB_Clinicas")]
    public class Clinica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(14)]
        public string Cnpj{ get; set; }  


        [Required]
        [MaxLength(15)]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string RazaoSocial { get; set; }

        [Required]
        [MaxLength(255)]
        public string Senha { get; set; }

        public string FotoClinica { get; set; }


        [Required]
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
