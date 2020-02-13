using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Models
{
    public class RevendedoraDto
    {
        [Required]
        public string NomeCompleto { get; set; }

        [Required]

        public string CPF { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        [Compare("Senha")]
        public string ConfirmacaoSenha { get; set; }
    }
}
