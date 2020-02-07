using Cashback_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Repositories.Contracts
{
    public interface IRevendedoraRepository : ICrudBaseRepository<RevendedoraModel>
    {
        void Create(RevendedoraModel revendedora, string senha);
        RevendedoraModel GetEntity(string email, string senha);
    }
}
