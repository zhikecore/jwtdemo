using jwt.demo.model.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace jwt.demo.service
{
    public interface IAuthenticateService:IService
    {
        bool IsAuthenticated(LoginRequestDTO request, out string token);
    }
}
