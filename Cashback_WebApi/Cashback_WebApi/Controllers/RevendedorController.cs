using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cashback_WebApi.Models;
using Cashback_WebApi.Repositories.Contracts;
using Cashback_WebApi.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cashback_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevendedorController : ControllerBase
    {
        private readonly IRevendedoraService _revendedoraService;

        public RevendedorController(IRevendedoraService revendedoraService)
        {
            _revendedoraService = revendedoraService;
        }

        
        // GET: api/Revendedor
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Revendedor/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Revendedor
        [HttpPost("")]
        public ActionResult Create([FromBody]RevendedoraDto revendedoraDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var user = new RevendedoraModel
            {
                NomeCompleto = revendedoraDto.NomeCompleto,
                Cpf = revendedoraDto.CPF,
                Email = revendedoraDto.Email,
                UserName = revendedoraDto.Email
            };

            var result = _revendedoraService.Criar(user, revendedoraDto.Senha);

            if (result.Succeeded)
                return Ok(user);

            var errors = new List<string>();

            foreach (var erro in result.Errors)
            {
                errors.Add(erro.Description);
            }

            return UnprocessableEntity(errors);
        }

        // PUT: api/Revendedor/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
