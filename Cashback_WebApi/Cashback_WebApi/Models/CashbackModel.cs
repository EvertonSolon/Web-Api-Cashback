using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Models
{
    public class CashbackModel : CrudBase
    {
        
        public double Valor { get; set; }
        public int CompraId { get; set; }
    }
}
