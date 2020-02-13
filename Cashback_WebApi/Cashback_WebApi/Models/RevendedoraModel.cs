using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Models
{
    public class RevendedoraModel : IdentityUser
    {
        [Required]
        [ProtectedPersonalData]
        public string NomeCompleto { get; set; }
        
        private string cpf;

        [Required]
        [MaxLength(11)]
        public string Cpf
        {
            get { return cpf; }
            set
            {
                cpf = value.Replace(".", string.Empty).Replace("-", string.Empty);
            }
        }

        public DateTime CriadoEm { get; set; } = DateTime.Now;

        public bool Excluido { get; set; } = false;

        [ForeignKey("RevendedoraId")]
        public virtual ICollection<CompraModel> Compras { get; set; }
    }
}
