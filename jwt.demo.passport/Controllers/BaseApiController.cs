using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwt.demo.common.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwt.demo.passport.Controllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        //private AppBasicInfo _appBasicInfo = null;
        //private IAppContext _appContext = null;

        ///// <summary>
        ///// app请求上下文（包含用户信息）
        ///// </summary>
        //public IAppContext AppContext
        //{
        //    get
        //    {
        //        if (_appContext != null) return _appContext;

        //        return _appContext = HttpContext.RequestServices.GetService(typeof(IAppContext)) as IAppContext;
        //    }
        //}

        ///// <summary>
        ///// APP请求基础信息
        ///// </summary>
        //public AppBasicInfo AppBasicInfo
        //{
        //    get
        //    {
        //        if (_appBasicInfo != null) return _appBasicInfo;

        //        return _appBasicInfo = HttpContext.Items[AppBasicInfo.ContextItemKey] as AppBasicInfo;
        //    }
        //}

        /// <summary>
        /// 返回接口调用成功的响应
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected ResponseInfo ResponseOk(object data = null)
        {
            return new ResponseInfo
            {
                Success = true,
                Code = (int)ResponseCode.OK,
                Data = data,
            };
        }

        /// <summary>
        /// 返回接口调用成功的响应
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected ResponseInfo ResponseOk<T>(T data)
        {
            return new ResponseInfo
            {
                Success = true,
                Code = (int)ResponseCode.OK,
                Data = data,
            };
        }

        /// <summary>
        /// 获取用户编号
        /// </summary>
        /// <returns></returns>
        //protected Guid GetUserId()
        //{
        //    //验证网关token 
        //    if (AppContext.User != null && AppContext.User.Id != Guid.Empty)
        //        return AppContext.User.Id;

        //    //兼容验证运管老token
        //    StringValues token;
        //    StringValues mebdeviceid;
        //    if ((HttpContext.Request.Headers.TryGetValue("usercachekey", out token) || HttpContext.Request.Headers.TryGetValue("token", out token))
        //       && HttpContext.Request.Headers.TryGetValue("mebdeviceid", out mebdeviceid))
        //        return UserTokenUtil.GetUserId(token, mebdeviceid);

        //    throw new ValidationException("未登录");
        //}
    }
}