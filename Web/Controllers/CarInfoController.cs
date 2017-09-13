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
    /// ������Ϣ�ӿڿ�����
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
        /// ����������Ϣ��ҳ
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// ���ͳ���
        /// </summary>
        /// <returns></returns>
        public IActionResult BigTransportCar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            BigCarInfoViewModel bm = new BigCarInfoViewModel();
            return View(bm);
        }

        /// <summary>
        /// �ո��
        /// </summary>
        /// <returns></returns>
        public IActionResult ReapCar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// ��Ӷ�ո��
        /// </summary>
        /// <returns></returns>
        public IActionResult HireReapCar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
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
        [HttpGet]
        public IActionResult TaxiReapCar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }



        /// <summary>
        /// �������ֳ�������������
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SendBuyCar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// �������ֳ�������������
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]  //��ֹ��վ���󹥻�
        public IActionResult BuyCar(DealCarViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                //д�����ݿ�  �����
                //1.����ת��
                model.BuyOrSell = Models.AllEnum.BuyOrSell.��;
                var dbModel = (DealCarData)model;

                //2.д�����ݿ�
                _db.DealCarData.Add(dbModel);
                _db.SaveChanges();
                return RedirectToLocal(returnUrl);
            }
            return View(model);
        }

        /// <summary>
        /// �������ֳ�����������
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SendSellCar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// �������ֳ�����������
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]  //��ֹ��վ���󹥻�
        public IActionResult SellCar(DealCarViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                //д�����ݿ�  �����
                //1.����ת��
                model.BuyOrSell = Models.AllEnum.BuyOrSell.��;
                var dbModel = (DealCarData)model;

                //2.д�����ݿ�
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