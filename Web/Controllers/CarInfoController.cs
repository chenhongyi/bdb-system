using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.Models.CarInfo;
using Microsoft.AspNetCore.Authorization;
using web.Data;
using Senparc.Weixin.Helpers;

namespace web.Controllers
{
    /// <summary>
    /// 发布信息接口控制器
    /// </summary>
    [AllowAnonymous]
    public class CarInfoController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CarInfoController(ApplicationDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// 车辆分类信息首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// 大型车辆
        /// </summary>
        /// <returns></returns>
        public IActionResult BigTransportCar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            BigCarInfoViewModel bm = new BigCarInfoViewModel();
            return View(bm);
        }

        /// <summary>
        /// 收割车辆
        /// </summary>
        /// <returns></returns>
        public IActionResult ReapCar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// 雇佣收割车辆
        /// </summary>
        /// <returns></returns>
        public IActionResult HireReapCar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        /// <summary>
        /// 雇佣收割车辆
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult HireReapCar(ReapCarViewModel model)
        {
            return View();
        }

        /// <summary>
        /// 出租收割车辆
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult TaxiReapCar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }



        /// <summary>
        /// 发布二手车交易卖车需求
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SendBuyCar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// 发布二手车交易卖车需求
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]  //防止跨站请求攻击
        public IActionResult BuyCar(DealCarViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                //写入数据库  待审核
                //1.数据转换
                model.BuyOrSell = Models.AllEnum.BuyOrSell.买;
                var dbModel = (DealCarData)model;

                //2.写入数据库
                _db.DealCarData.Add(dbModel);
                _db.SaveChanges();
                return RedirectToLocal(returnUrl);
            }
            return View(model);
        }

        /// <summary>
        /// 发布二手车交易买车需求
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SendSellCar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// 发布二手车交易买车需求
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]  //防止跨站请求攻击
        public IActionResult SellCar(DealCarViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                //写入数据库  待审核
                //1.数据转换
                model.BuyOrSell = Models.AllEnum.BuyOrSell.卖;
                var dbModel = (DealCarData)model;

                //2.写入数据库
                _db.DealCarData.Add(dbModel);
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
                return RedirectToAction(nameof(CarInfoController.Index), "CarInfo");
            }
        }
    }
}