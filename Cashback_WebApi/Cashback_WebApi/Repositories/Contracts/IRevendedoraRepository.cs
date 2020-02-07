using Cashback_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Repositories.Contracts
{
    public interface IRevendedoraRepository : ICrudBaseRepository<RevendedoraModel>
    {
        void Create(RevendedoraModel user, string password);
        RevendedoraModel GetEntity(string email, string password);
    }
}
