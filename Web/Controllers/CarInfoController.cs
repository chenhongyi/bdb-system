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
        /// �ո��
        /// </summary>
        /// <returns></returns>
        public IActionResult ReapCar()
        {
            return View();
        }

        /// <summary>
        /// ��Ӷ�ո��
        /// </summary>
        /// <returns></returns>
        public IActionResult HireReapCar()
        {
            return View();
        }


        /// <summary>
        /// ��Ӷ�ո��
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult HireReapCar(ReapCarViewModel model)
        {
            return View();
        }

        /// <summary>
        /// �����ո��
        /// </summary>
        /// <returns></returns>
        public IActionResult TaxiReapCar()
        {
            return View();
        }

    }
}