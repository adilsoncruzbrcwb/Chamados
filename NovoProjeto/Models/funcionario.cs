using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NovoProjeto.Models
{
    public class Funcionario
    {

        [Key]
        public int FuncionarioId { get; set; }

        [Display(Name = "Nome do funcionário")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        public int CPF { get; set; }

        [Display(Name = "RG")]
        public int RG { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Setor")]
        public string Setor { get; set; }

        [Display(Name = "Status")]
        public Boolean Status { get; set; }

    }
}