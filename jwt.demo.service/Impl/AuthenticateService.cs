using jwt.demo.model;
using jwt.demo.model.Dto;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jwt.demo.service.Impl
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly TokenManagement _tokenManagement;

        public AuthenticateService(IOptions<TokenManagement> tokenManagement)
        {
            this._tokenManagement = tokenManagement.Value;
        }
        public bool IsAuthenticated(LoginRequestDTO request, out string token)
        {
            //TODO:验证账户密码逻辑 自行补全
            token = string.Empty;
            var claims = new[]
            {
            new Claim(ClaimTypes.Name,request.UserName),
            new Claim(ClaimTypes.Name,request.Password)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claims, expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration), signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return true;
        }
    }
}
