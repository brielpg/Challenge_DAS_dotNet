﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ABDWNSprint1.Models
{
    [Table("TB_Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }  
        
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }  

        [Required]
        [MaxLength(15)]
        public string Telefone { get; set; }

        [Required]
        public string NmrCarteiraOdonto { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
        
        public int QuantidadeConsultas { get; set; }

        [Required]
        public string FotoCliente { get; set; }


        [Required]
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

    }
}
