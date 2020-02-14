using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Cashback_WebApi.ApiClients;
using Cashback_WebApi.Biblioteca.Constantes;
using Cashback_WebApi.Models;
using Cashback_WebApi.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cashback_WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _compraService;
        private readonly IRevendedoraService _revendedoraService;
        private readonly ApiClient _apiClient;

        public CompraController(ICompraService compraService, IRevendedoraService revendedoraService, ApiClient apiClient)
        {
            _compraService = compraService;
            _revendedoraService = revendedoraService;
            _apiClient = apiClient;
        }

        [HttpGet("acumuladocashback")]
        public ActionResult AcumuladoCashback()
        {
            //_apiClient.Autenticar();

            //if (!_apiClient.AutenticadoComToken)
            //    return Unauthorized();

            var resultado = _apiClient.Obter_AcumuladoCashback();

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpGet("modelo")]
        public ActionResult Modelo()
        {
            return Ok(new CompraDto());
        }

        // POST: api/Compra
        [HttpPost]
        public ActionResult Post([FromBody] CompraDto compraDto)
        {
            if (compraDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var revendedora = _revendedoraService.Obter(compraDto.CpfRevendedor);

            if (revendedora == null)
                return NotFound("Revendedor(a) não encontrado(a)!");

            var compra = new CompraModel
            {
                CodigoCompra = compraDto.CodigoCompra,
                CpfRevendedor = compraDto.CpfRevendedor,
                DataCompra = compraDto.DataCompra,
                Valor = compraDto.Valor,
                RevendedoraId = revendedora.Id
            };

            _compraService.Criar(compra);

            var created = Created($"/api/compra/{compra.Id}", compra);

            return created;
        }

        // PUT: api/Compra/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CompraDto compraDto)
        {
            if (compraDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var compra = _compraService.Obter(id);

            if (compra == null)
                return NotFound("Venda não encontrada!");

            if (compra.Status == StatusCompraConstante.Aprovado)
                return StatusCode(405, "Venda já aprovada!");

            var revendedora = _revendedoraService.Obter(compraDto.CpfRevendedor);

            if (revendedora == null)
                return NotFound("Revendedor(a) não encontrado(a)!");

            compra.CodigoCompra = compraDto.CodigoCompra;
            compra.Valor = compraDto.Valor;
            compra.DataCompra = compraDto.DataCompra;
            compra.CpfRevendedor = compraDto.CpfRevendedor;

            _compraService.Atualizar(compra);

            return Ok(compra);
        }

        [HttpGet("todas")]
        public ActionResult Todas()
        {
            var compras = _compraService.ObterTodos();

            var jsonObjs = new List<object>();

            foreach (var compra in compras.OrderByDescending(x => x.DataCompra))
            {
                var porcentagemCashback = (compra.Cashback / compra.Valor) * 100;

                jsonObjs.Add(
                    new
                    {
                        compra.CodigoCompra,
                        compra.Valor,
                        compra.DataCompra,
                        PorcentagemCashback = string.Concat(porcentagemCashback, "%"),
                        ValorCashback = compra.Cashback,
                        compra.Status
                    }
                    );
            }

            return Ok(jsonObjs);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var compra = _compraService.Obter(id);

            if (compra == null)
                return NotFound("Venda não encontrada!");

            if (compra.Status == StatusCompraConstante.Aprovado)
                return StatusCode(405, "Venda já aprovada!");

            compra.Excluido = true;

            _compraService.Atualizar(compra);

            return NoContent();
        }
    }
}
