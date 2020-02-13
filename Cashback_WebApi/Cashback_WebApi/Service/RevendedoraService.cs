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
        private readonly IRevendedoraRepository _revendedoraRepository;

        public RevendedoraService(IRevendedoraRepository revendedoraRepository)
        {
            _revendedoraRepository = revendedoraRepository;
        }

        public void Criar(RevendedoraModel revendedora)
        {
            _revendedoraRepository.Criar(revendedora);
        }

        public IdentityResult Criar(RevendedoraModel revendedora, string senha)
        {
            var result = _revendedoraRepository.Criar(revendedora, senha);

            return result;
        }

        public void Excluir(RevendedoraModel revendedora)
        {
            _revendedoraRepository.Excluir(revendedora);
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
            var revendedora = _revendedoraRepository.Obter(id);

            return revendedora;
        }

        public RevendedoraModel Obter(string cpf)
        {
            cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);
            var revendedora = _revendedoraRepository.Obter(cpf);

            return revendedora;
        }

        public void Atualizar(RevendedoraModel revendedora)
        {
            _revendedoraRepository.Atualizar(revendedora);
        }
    }
}
