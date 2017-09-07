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
        /// ����������Ϣ��ҳ
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// ���ͳ���
        /// </summary>
        /// <returns></returns>
        public IActionResult BigTransportCar()
        {
            BigCarInfoViewModel bm = new BigCarInfoViewModel();
            return View(bm);
        }

        /// <summary>
        /// ���ͳ���
        /// </summary>
        /// <returns></returns>
        public IActionResult MiddleTransportCar()
        {
            return View();
        }

        /// <summary>
        /// С�ͳ���
        /// </summary>
        /// <returns></returns>
        public IActionResult SmallTransportCar()
        {
            return View();
        }


        /// <summary>
        /// ��������ǣ������
        /// </summary>
        /// <returns></returns>
        public IActionResult TractorsCar()
        {
            return View();
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public IActionResult LogisticsCar()
        {
            return View();
        }


        /// <summary>
        /// ���̳���
        /// </summary>
        /// <returns></returns>
        public IActionResult EngineeringCar()
        {
            return View();
        }
        

    }
}