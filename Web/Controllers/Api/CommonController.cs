using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class CommonController : Controller
    {
        [HttpGet]
        public int Captcha(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return -2;  //参数为空
            }
            if (!IsHandset(phoneNumber))
            {   
                return -1;  //不是有效手机号
            }
            if (!CheckSendTime())
            {
                return -3;  //短时间内发送验证码次数过多
            }

            return 0;
        }

        /// <summary>
        /// 检查短时间内发送验证码的次数
        /// </summary>
        /// <returns></returns>
        private bool CheckSendTime()
        {
            return true;
        }

        /// <summary>
        /// 正则验证是否是手机号
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public bool IsHandset(string phoneNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^[1]+[3,4,5,6,7,8]+\d{9}");
        }
    }
}
