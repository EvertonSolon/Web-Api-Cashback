using Cashback_WebApi.Models;
using Cashback_WebApi.Repositories.Contracts;
using Cashback_WebApi.Service.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Service
{
    public class RevendedoraService : IRevendedoraService
    {
        private readonly UserManager<RevendedoraModel> _userManager;
        private readonly IRevendedoraRepository _revendedoraRepository;

        public RevendedoraService(UserManager<RevendedoraModel> userManager, IRevendedoraRepository revendedoraRepository)
        {
            _userManager = userManager;
            _revendedoraRepository = revendedoraRepository;
        }

        public void Create(RevendedoraModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(RevendedoraModel entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<RevendedoraModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public RevendedoraModel GetEntity(string email, string password)
        {
            var revendedora = _revendedoraRepository.GetEntity(email, password);

            return revendedora;        }

        public RevendedoraModel GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(RevendedoraModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
