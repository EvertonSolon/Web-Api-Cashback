using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Models
{
    public class AcumuladoCashback
    {
        public string StatusCode { get; set; }
        public Body Body { get; set; }
    }

    public class Body
    {
        public string Credit { get; set; }
    }
}
