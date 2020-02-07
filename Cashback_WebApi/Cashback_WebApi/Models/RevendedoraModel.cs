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

        [Required]
        public string CPF { get; set; }

        public DateTime CriadoEm { get; set; }

        public bool Excluido { get; set; }

        [ForeignKey("CpfRevendedor")]
        public virtual ICollection<CompraModel> Compras { get; set; }
    }
}
