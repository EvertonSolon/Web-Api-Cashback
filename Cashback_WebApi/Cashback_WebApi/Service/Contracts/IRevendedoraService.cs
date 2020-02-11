using Cashback_WebApi.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Service.Contracts
{
    public interface IRevendedoraService : ICrudBaseService<RevendedoraModel>
    {
        IdentityResult Criar(RevendedoraModel revendedora, string senha);
        RevendedoraModel Obter(string email, string password);
    }
}
