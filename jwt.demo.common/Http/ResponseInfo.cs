using System;
using System.Collections.Generic;
using System.Text;

namespace jwt.demo.common.Http
{
    /// <summary>
    /// 统一HTTP响应对象
    /// </summary>
    public class ResponseInfo
    {

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 响应码（0为成功）
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 响应业务（错误）消息
        /// </summary>
        public string Msg { get; set; } = "";

        /// <summary>
        /// （异常）详细描述
        /// </summary>
        public string Desc { get; set; } = "";

        /// <summary>
        /// 数据结果
        /// </summary>
        public object Data { get; set; }
    }

    /// <summary>
    /// 统一HTTP响应对象
    /// </summary>
    public class ResponseInfo<T>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 响应码（0为成功）
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 响应业务（错误）消息
        /// </summary>
        public string Msg { get; set; } = "";

        /// <summary>
        /// （异常）详细描述
        /// </summary>
        public string Desc { get; set; } = "";

        /// <summary>
        /// 数据结果
        /// </summary>
        public T Data { get; set; } = default(T);
    }
}
