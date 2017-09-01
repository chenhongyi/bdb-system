using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    /// <summary>
    /// 发布信息接口控制器
    /// </summary>
    public class IssueMsgController : Controller
    {
        
        /// <summary>
        /// 发布信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Issue(CarInfo model, string returnUrl = null)
        {
            return View();
        }
    }
}
