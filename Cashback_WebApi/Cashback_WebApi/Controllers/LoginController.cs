using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cashback_WebApi.Models;
using Cashback_WebApi.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Cashback_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRevendedoraService _revendedoraService;
        private readonly IConfiguration Configuration;

        public LoginController(IRevendedoraService revendedoraService, IConfiguration configuration)
        {
            _revendedoraService = revendedoraService;
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

            return Ok(BuildToken(revendedora));
        }

        private object BuildToken(RevendedoraModel user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Aud, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["API_Access:ApiKey"]));
            var sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var exp = DateTime.Now.AddMinutes(1);
            //var exp = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: exp,
                signingCredentials: sign
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new { token = tokenString, expiracao = exp };
        }
    }
}