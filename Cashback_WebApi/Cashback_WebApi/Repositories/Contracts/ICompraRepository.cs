using Cashback_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Repositories.Contracts
{
    public interface ICompraRepository : ICrudBaseRepository<CompraModel>
    {
        CompraModel Obter(string codigoCompra);
    }
}
