using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace jwt.demo.model.Dto
{
    public class LoginRequestDTO
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [Required]
        [DisplayName("账户")]
        public string UserName { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        [Required]
        [DisplayName("密码")]
        public string Password { get; set; }
    }
}
