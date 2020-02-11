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

        public void Criar(RevendedoraModel revendedora)
        {
            _userManager.CreateAsync(revendedora);
        }

        public IdentityResult Criar(RevendedoraModel revendedora, string senha)
        {
            var result = _userManager.CreateAsync(revendedora, senha).Result;

            return result;
        }

        public void Excluir(RevendedoraModel revendedora)
        {
            _userManager.DeleteAsync(revendedora);
        }

        public ICollection<RevendedoraModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public RevendedoraModel Obter(int id)
        {
            throw new NotImplementedException();
        }

        public RevendedoraModel Obter(string email, string senha)
        {
            var revendedora = _userManager.FindByEmailAsync(email).Result;

            if (_userManager.CheckPasswordAsync(revendedora, senha).Result)
                return revendedora;

            return null;
        }

        public void Atualizar(RevendedoraModel revendedora)
        {
            throw new NotImplementedException();
        }
    }
}
