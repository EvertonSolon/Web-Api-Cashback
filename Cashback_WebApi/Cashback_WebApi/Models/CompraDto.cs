using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Models
{
    public class CompraDto
    {
        [Required]
        public string CodigoCompra { get; set; }

        [Required]
        public double Valor { get; set; }

        [Required]
        public DateTime DataCompra { get; set; }

        [MinLength(11), MaxLength(14)]
        public string CpfRevendedor { get; set; }
    }
}
