using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Models
{
    public class Base
    {
        public int Id { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;

        public bool Excluido { get; set; } = false;
    }
}
