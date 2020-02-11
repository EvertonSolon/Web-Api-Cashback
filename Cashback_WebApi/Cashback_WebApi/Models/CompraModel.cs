using Cashback_WebApi.Biblioteca.Constantes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Models
{
    public class CompraModel : CrudBase
    {
        [Required]
        public string CodigoCompra { get; set; }

        [Required]
        public double Valor { get; set; }
        
        [Required]
        public DateTime DataCompra { get; set; }

        [Required]
        public StatusCompra Status { get; }

        [ForeignKey("Revendedora")]
        public string CpfRevendedor { get; set; }
        public RevendedoraModel Revendedora { get; set; }

        public double Cashback { get; set; }

        //[ForeignKey("Cashback")]
        //public int CashbackId { get; set; }
        //public virtual CashbackModel Cashback { get; set; }


    }
}
