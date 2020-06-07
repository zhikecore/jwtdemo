using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace jwt.demo.passport.ViewModel.Response
{
    public class LoginVM
    {
        /// <summary>
        /// access token
        /// </summary>
        [DataMember]
        public string Token { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [DataMember]
        public long UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }
    }
}
