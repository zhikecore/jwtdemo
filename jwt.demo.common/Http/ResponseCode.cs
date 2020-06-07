using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace jwt.demo.common.Http
{
    /// <summary>
    /// HTTP调用响应码枚举
    /// </summary>
    public enum ResponseCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        OK = 0,

        #region 异常代码系统段（3位：1000到9999）

        /// <summary>
        /// 认证_默认失败
        /// </summary>
        [Description("认证失败")]
        Authentication_DefaultFailed = 1000,

        /// <summary>
        /// 授权_默认失败
        /// </summary>
        [Description("授权失败")]
        Authorization_DefaultFailed = 1001,

        /// <summary>
        /// 请求参数验证_默认异常
        /// </summary>
        [Description("参数验证失败")]
        Validation_DefaultError = 1002,

        /// <summary>
        /// 业务逻辑_默认异常
        /// </summary>
        [Description("业务验证失败")]
        Business_DefaultError = 1003,

        //.............
        //.............
        //.............

        /// <summary>
        /// 系统_默认未知异常
        /// </summary>
        [Description("发生异常")]
        System_DefaultException = 9999,

        #endregion


        #region 异常代码用户段（5位及以上：10000开始）

        /// <summary>
        /// 登录_账号不存在
        /// </summary>
        [Description("账号不存在")]
        Login_AccountNotFound = 10000,

        /// <summary>
        /// 登录_账号已禁用
        /// </summary>
        [Description("账号已禁用")]
        Login_AccountInactive = 10001,

        /// <summary>
        /// 登录_密码不正确
        /// </summary>
        [Description("密码不正确")]
        Login_WrongPassword = 10002,

        /// <summary>
        /// 登录_第三方平台账号未绑定
        /// </summary>
        [Description("第三方平台账号未绑定")]
        Login_ThirdPartyNotBind = 10003,

        #endregion
    }
}
