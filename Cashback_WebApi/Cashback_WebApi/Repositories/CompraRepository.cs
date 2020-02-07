using Cashback_WebApi.Database;
using Cashback_WebApi.Models;
using Cashback_WebApi.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly CashbackContext _contexto;

        public CompraRepository(CashbackContext contexto)
        {
            _contexto = contexto;
        }

        public void Criar(CompraModel compra)
        {
            throw new NotImplementedException();
        }

        public void Excluir(CompraModel compra)
        {
            throw new NotImplementedException();
        }

        public ICollection<CompraModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public CompraModel Obter(int id)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(CompraModel compra)
        {
            throw new NotImplementedException();
        }
    }
}
