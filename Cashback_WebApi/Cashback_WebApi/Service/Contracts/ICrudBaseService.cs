using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Service.Contracts
{
    public interface ICrudBaseService<TEntity> where TEntity : class
    {
        TEntity GetEntity(int id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        ICollection<TEntity> GetAll();
    }
}
