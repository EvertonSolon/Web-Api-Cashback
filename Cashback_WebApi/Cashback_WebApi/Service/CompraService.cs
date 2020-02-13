using Cashback_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cashback_WebApi.Service.Contracts;
using Cashback_WebApi.Repositories.Contracts;
using Cashback_WebApi.Biblioteca.Constantes;
using Microsoft.Extensions.Configuration;

namespace Cashback_WebApi.Service
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository _compraRepository;

        public CompraService(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        public void Criar(CompraModel compra)
        {
            _compraRepository.Criar(compra);
        }

        public void Excluir(CompraModel compra)
        {
            _compraRepository.Excluir(compra);
        }

        public ICollection<CompraModel> ObterTodos()
        {
            var compras = _compraRepository.ObterTodos();

            return compras;
        }

        public CompraModel Obter(int id)
        {
            var compra = _compraRepository.Obter(id);

            return compra;
        }

        public CompraModel Obter(string codigoCompra)
        {
            var compra = _compraRepository.Obter(codigoCompra);

            return compra;
        }
        
        public void Atualizar(CompraModel compra)
        {
            _compraRepository.Atualizar(compra);
                //return "Somente é possível atualizar vendas com status \"Em Validação\"";
        }
    }
}
