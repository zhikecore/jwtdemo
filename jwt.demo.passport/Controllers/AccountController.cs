using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using jwt.demo.common.Http;
using jwt.demo.model.Dto;
using jwt.demo.passport.ViewModel.Response;
using jwt.demo.service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace jwt.demo.passport.Controllers
{
    [Produces("application/json")]
    [Route("v1/account")]
    public class AccountController : BaseApiController
    {
        private readonly IAuthenticateService _authService;

        public AccountController(
            IAuthenticateService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(ResponseInfo<LoginVM>), 200)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginRequestDTO req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }
            string sToken;
            if (_authService.IsAuthenticated(req, out sToken))
            {
                return Ok(sToken);
            }
            return BadRequest("Invalid Request");

        }
    }
}