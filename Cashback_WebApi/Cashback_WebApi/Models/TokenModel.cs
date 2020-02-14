using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Models
{
    public class TokenModel
    {
        public bool Autenticado { get; set; }
        public string Criado { get; set; }
        public string Expiracao { get; set; }
        public string Token { get; set; }
    }
}
