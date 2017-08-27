using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.MP;
using Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    public class VerifyController : Controller
    {


        // GET: /<controller>/
        [HttpGet]
        [ActionName("Index")]
        public IActionResult Get(string signature, string timestamp, string nonce, string echostr)
        {
            if (CheckSignature.Check(signature, timestamp, nonce, DefineModel.Token))
            {
                return Content(echostr);
            }
            else
            {
                return Content("failed:" + signature + "," + Senparc.Weixin.MP.CheckSignature.GetSignature(timestamp, nonce, DefineModel.Token) + "。如果您在浏览器中看到这条信息，表明此Url可以填入微信后台。");
            }
        }
    }
}
