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
            _contexto.Compras.Add(compra);
            _contexto.SaveChanges();
        }

        public void Excluir(CompraModel compra)
        {
            _contexto.Compras.Remove(compra);
            _contexto.SaveChanges();
        }

        public ICollection<CompraModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public CompraModel Obter(int id)
        {
            var compra = _contexto.Compras.Find(id);

            return compra;
        }

        public void Atualizar(CompraModel compra)
        {
            _contexto.Compras.Update(compra);
            _contexto.SaveChanges();
        }
    }
}
