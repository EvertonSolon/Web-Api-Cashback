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
        private readonly SignInManager<RevendedoraModel> _signInManager;
        private readonly UserManager<RevendedoraModel> _userManager;

        public RevendedorController(IRevendedoraService revendedoraService, SignInManager<RevendedoraModel> signInManager,
            UserManager<RevendedoraModel> userManager)
        {
            _revendedoraService = revendedoraService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Authorize]
        // GET: api/Revendedor
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Revendedor/5
        [HttpGet("{id}", Name = "Get")]
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
                CPF = revendedoraDto.CPF,
                Email = revendedoraDto.Email,
                UserName = revendedoraDto.Email
            };

            var revendedora = _userManager.CreateAsync(user, revendedoraDto.Senha).Result;

            if (revendedora.Succeeded)
                return Ok(user);


            var errors = new List<string>();

            foreach (var erro in revendedora.Errors)
            {
                errors.Add(erro.Description);
            }

            return UnprocessableEntity(errors);

        }

        // PUT: api/Revendedor/5
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
