using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.Models.CarInfo;

namespace web.Controllers
{
    public class CarInfoController : Controller
    {
        /// <summary>
        /// 车辆分类信息首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 大型车辆
        /// </summary>
        /// <returns></returns>
        public IActionResult BigTransportCar()
        {
            BigCarInfoViewModel bm = new BigCarInfoViewModel();
            return View(bm);
        }

        /// <summary>
        /// 收割车辆
        /// </summary>
        /// <returns></returns>
        public IActionResult ReapCar()
        {
            return View();
        }

        /// <summary>
        /// 雇佣收割车辆
        /// </summary>
        /// <returns></returns>
        public IActionResult HireReapCar()
        {
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
        public IActionResult TaxiReapCar()
        {
            return View();
        }

    }
}