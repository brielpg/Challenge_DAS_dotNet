using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABDWNSprint1.Models
{
    [Table("TB_Enderecos")]
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(255)]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(10)]
        public string Cep{ get; set; }  

        [Required]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required]
        [MaxLength (255)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength (2)]
        public string Uf { get; set; }

    }
}
