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

        public void Criar(RevendedoraModel revendedora)
        {
            throw new NotImplementedException();
        }

        public void Excluir(RevendedoraModel revendedora)
        {
            throw new NotImplementedException();
        }

        public ICollection<RevendedoraModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public RevendedoraModel Obter(string email, string password)
        {
            var revendedora = _revendedoraRepository.Obter(email, password);

            return revendedora;        }

        public RevendedoraModel Obter(int id)
        {
            throw new NotImplementedException();
        }



        public void Atualizar(RevendedoraModel revendedora)
        {
            throw new NotImplementedException();
        }
    }
}
