﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cashback_WebApi.Models;
using Cashback_WebApi.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        public LoginController(IRevendedoraService revendedoraService, SignInManager<RevendedoraModel> signInManager,
            UserManager<RevendedoraModel> userManager)
        {
            _revendedoraService = revendedoraService;
            _signInManager = signInManager;
            _userManager = userManager;
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

            _signInManager.SignInAsync(revendedora, false);

            return Ok();
        }
    }
}