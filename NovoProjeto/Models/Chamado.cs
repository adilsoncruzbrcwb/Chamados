using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NovoProjeto.Models
{
    public class Chamado
    {

        [Key]
        public int ChamadoId { get; set; }

        [Display(Name = "Observações do chamado: ")]
        public string NomeChamado { get; set; }

        [Display(Name = "Data do chamado: ")]
        public DateTime DataChamado { get; set; }

        [Display(Name = "Status do chamado: ")]
        public string StatusChamado { get; set; }

    }
}