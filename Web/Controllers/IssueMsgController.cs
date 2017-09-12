using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Senparc.Weixin.Helpers;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using web.Models.CarInfo;
using web.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web.Controllers
{
    /// <summary>
    /// 发布信息接口控制器
    /// </summary>
    [AllowAnonymous]
    public class IssueMsgController : Controller
    {
        private readonly ApplicationDbContext _db;
        public IssueMsgController(ApplicationDbContext db)
        {
            _db = db;
        }

        /*
         原理：

            1、<%:Html.AntiForgeryToken()%>这个方法会生成一个隐藏域：
            <inputname="__RequestVerificationToken" type="hidden" value="7FTM...sdLr1" />
            并且会将一个以"__RequestVerificationToken“为KEY的COOKIE给控制层。

            2、[ValidateAntiForgeryToken]，根据传过来的令牌进行对比，如果相同，则允许访问，如果不同则拒绝访问。

            关键：ValidateAntiForgeryToken只针对POST请求。

            换句话说，[ValidateAntiForgeryToken]必须和[HttpPost]同时加在一个ACTION上才可以正常使用。
             */

        /// <summary>
        /// 发布信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]  //防止跨站请求攻击
        public IActionResult Issue(BigCarInfoViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                //写入数据库  待审核
                //1.数据转换
                var dbModel = (CarInfo)model;
                dbModel.JoinTime = DateTimeHelper.GetWeixinDateTime(DateTime.Now);
         
                //2.写入数据库
                _db.Carinfo.Add(dbModel);
                _db.SaveChanges();
                return RedirectToLocal(returnUrl);
            }
            return View(model);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
