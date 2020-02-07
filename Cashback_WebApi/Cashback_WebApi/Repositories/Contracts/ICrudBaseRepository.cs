using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Repositories.Contracts
{
    public interface ICrudBaseRepository<TEntity> where TEntity : class
    {
        TEntity Obter(int id);

        void Criar(TEntity entity);

        void Atualizar(TEntity entity);

        void Excluir(TEntity entity);

        ICollection<TEntity> ObterTodos();
    }
}
