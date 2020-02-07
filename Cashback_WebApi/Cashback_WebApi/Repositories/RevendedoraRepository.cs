using Cashback_WebApi.Models;
using Cashback_WebApi.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashback_WebApi.Repositories
{
    public class RevendedoraRepository : IRevendedoraRepository
    {
        private readonly UserManager<RevendedoraModel> _userManager;

        public RevendedoraRepository(UserManager<RevendedoraModel> userManager)
        {
            _userManager = userManager;
        }

        public void Create(RevendedoraModel entity)
        {
            throw new NotImplementedException();
        }

        public void Create(RevendedoraModel user, string password)
        {
            var result = _userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
                return;

            var stringBuilder = new StringBuilder();

            foreach (var erro in result.Errors)
            {
                stringBuilder.Append(erro.Description);
            }

            throw new Exception($"Revendedora(a) não cadastrado(a)! {stringBuilder.ToString()}");

        }

        public void Delete(RevendedoraModel entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<RevendedoraModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public RevendedoraModel GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public RevendedoraModel GetEntity(string email, string password)
        {
            var revendedora = _userManager.FindByEmailAsync(email).Result;

            if (_userManager.CheckPasswordAsync(revendedora, password).Result)
                return revendedora;

            throw new Exception("Revendedora(a) não localizado(a)!");
        }

        public void Update(RevendedoraModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
