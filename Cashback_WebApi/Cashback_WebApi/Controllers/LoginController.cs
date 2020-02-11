using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cashback_WebApi.Models;
using Cashback_WebApi.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Cashback_WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRevendedoraService _revendedoraService;
        private readonly SignInManager<RevendedoraModel> _signInManager;
        private readonly UserManager<RevendedoraModel> _userManager;
        private readonly IConfiguration Configuration;

        public LoginController(IRevendedoraService revendedoraService, SignInManager<RevendedoraModel> signInManager,
            UserManager<RevendedoraModel> userManager, IConfiguration configuration)
        {
            _revendedoraService = revendedoraService;
            _signInManager = signInManager;
            _userManager = userManager;
            Configuration = configuration;
        }

        [HttpPost("")]
        public ActionResult Login([FromBody]RevendedoraDto revendedoraDto)
        {
            ModelState.Remove(nameof(revendedoraDto.NomeCompleto));
            ModelState.Remove(nameof(revendedoraDto.CPF));
            ModelState.Remove(nameof(revendedoraDto.ConfirmacaoSenha));

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var revendedora = _revendedoraService.Obter(revendedoraDto.Email, revendedoraDto.Senha);

            if (revendedora == null)
                return NotFound("Usuário(a) não localizado(a)!");

            //_signInManager.SignInAsync(revendedora, false);

            return Ok(BuildToken(revendedora));
        }

        public object BuildToken(RevendedoraModel user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Aud, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["API_Access:ApiKey"]));
            var sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expMin = DateTime.Now.AddMinutes(1);
            //var expHour = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expMin,
                signingCredentials: sign
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new { token = tokenString, expiration = expMin };
        }
    }
}