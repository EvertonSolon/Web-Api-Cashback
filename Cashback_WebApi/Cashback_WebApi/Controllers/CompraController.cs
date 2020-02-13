using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public CompraController(ICompraService compraService, IRevendedoraService revendedoraService)
        {
            _compraService = compraService;
            _revendedoraService = revendedoraService;
        }

        // GET: api/Compra
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Compra/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("modelo")]
        public ActionResult Model()
        {
            return Ok(new CompraDto());
        }

        // POST: api/Compra
        [HttpPost]
        public ActionResult Post([FromBody] CompraDto compraDto)
        {
            //ModelState.Remove(nameof(compraDto.Id));

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
                Valor = compraDto.Valor
            };

            _compraService.Criar(compra);

            var created = Created($"/api/compra/{compra.Id}", compra);

            return created;
        }

        private static RevendedoraModel MapearRevendedora(RevendedoraModel revendedora)
        {
            return new RevendedoraModel
            {
                Id = revendedora.Id,
                AccessFailedCount = revendedora.AccessFailedCount,
                ConcurrencyStamp = revendedora.ConcurrencyStamp,
                Cpf = revendedora.Cpf,
                CriadoEm = revendedora.CriadoEm,
                Email = revendedora.Email,
                EmailConfirmed = revendedora.EmailConfirmed,
                Excluido = revendedora.Excluido,
                LockoutEnabled = revendedora.LockoutEnabled,
                LockoutEnd = revendedora.LockoutEnd,
                NomeCompleto = revendedora.NomeCompleto,
                NormalizedEmail = revendedora.NormalizedEmail,
                NormalizedUserName = revendedora.NormalizedUserName,
                PasswordHash = revendedora.PasswordHash,
                PhoneNumber = revendedora.PhoneNumber,
                PhoneNumberConfirmed = revendedora.PhoneNumberConfirmed,
                SecurityStamp = revendedora.SecurityStamp,
                TwoFactorEnabled = revendedora.TwoFactorEnabled,
                UserName = revendedora.UserName
            };
        }

        // PUT: api/Compra/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
