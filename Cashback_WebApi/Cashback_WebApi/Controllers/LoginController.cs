using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cashback_WebApi.Models;
using Cashback_WebApi.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cashback_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRevendedoraService _revendedoraService;
        private readonly SignInManager<RevendedoraModel> _signInManager;
        private readonly UserManager<RevendedoraModel> _userManager;

        public LoginController(IRevendedoraService revendedoraService, SignInManager<RevendedoraModel> signInManager,
            UserManager<RevendedoraModel> userManager)
        {
            _revendedoraService = revendedoraService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Login([FromBody]LoginDto login)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var revendedora = _revendedoraService.Obter(login.Email, login.Senha);

            if (revendedora == null)
                return NotFound("Usuário(a) não localizado(a)!");

            _signInManager.SignInAsync(revendedora, false);

            return Ok();

        }
    }
}