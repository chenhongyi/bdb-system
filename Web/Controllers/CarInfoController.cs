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
        /// 中型车辆
        /// </summary>
        /// <returns></returns>
        public IActionResult MiddleTransportCar()
        {
            return View();
        }

        /// <summary>
        /// 小型车辆
        /// </summary>
        /// <returns></returns>
        public IActionResult SmallTransportCar()
        {
            return View();
        }


        /// <summary>
        /// 拖拉机，牵引车辆
        /// </summary>
        /// <returns></returns>
        public IActionResult TractorsCar()
        {
            return View();
        }

        /// <summary>
        /// 物流车辆
        /// </summary>
        /// <returns></returns>
        public IActionResult LogisticsCar()
        {
            return View();
        }


        /// <summary>
        /// 工程车辆
        /// </summary>
        /// <returns></returns>
        public IActionResult EngineeringCar()
        {
            return View();
        }
        

    }
}