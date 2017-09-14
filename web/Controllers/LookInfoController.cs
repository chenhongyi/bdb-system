using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.Data;
using web.Models.CarInfo;
using static web.Models.AllEnum;
using web.Models.CerealsViewModels;
using web.Models.Person;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web.Controllers
{
    public class LookInfoController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LookInfoController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpGet]
        public IActionResult BigTransportCarInfo(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = _db.Carinfo.Where(p => p.CarStatus == CarStatus.Free);
            if (model != null)
            {
                List<BigCarInfoViewModel> resModel = new List<BigCarInfoViewModel>();
                foreach (var m in model)
                {
                    resModel.Add((BigCarInfoViewModel)m);
                }
                return View(resModel);
            }
            return View();
        }

        [HttpGet]
        public IActionResult BigCarDetails(int id, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = _db.Carinfo.FirstOrDefault(p => p.Id == id);
            if (model != null)
            {
                return View((BigCarInfoViewModel)model);
            }
            return View();
        }

        [HttpGet]
        public IActionResult LookBuyCar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var model = _db.DealCarData.Where(p => p.BuyOrSell == BuyOrSell.买);
            if (model != null)
            {
                List<DealCarViewModel> resModel = new List<DealCarViewModel>();
                foreach (var m in model)
                {
                    resModel.Add((DealCarViewModel)m);
                }
                return View(resModel);
            }
            return View();
        }


        [HttpGet]
        public IActionResult LookSellCar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = _db.DealCarData.Where(p => p.BuyOrSell == BuyOrSell.卖);
            if (model != null)
            {
                List<DealCarViewModel> resModel = new List<DealCarViewModel>();
                foreach (var m in model)
                {
                    resModel.Add((DealCarViewModel)m);
                }
                return View(resModel);
            }
            return View();
        }

        [HttpGet]
        public IActionResult BuyCarDetails(int id, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = _db.DealCarData.FirstOrDefault(p => p.Id == id);
            if (model != null)
            {
                return View((DealCarViewModel)model);
            }
            return View();
        }

        [HttpGet]
        public IActionResult SellCarDetails(int id, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = _db.DealCarData.FirstOrDefault(p => p.Id == id);
            if (model != null)
            {
                return View((DealCarViewModel)model);
            }
            return View();
        }


        [HttpGet]
        public IActionResult LookBossInfo(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = _db.CerealsBossData.Where(p => true).OrderByDescending(p => p.JoinTime);
            if (model != null)
            {
                List<CerealsBossViewModel> resModel = new List<CerealsBossViewModel>();
                foreach (var m in model)
                {
                    resModel.Add((CerealsBossViewModel)m);
                }
                return View(resModel);
            }
            return View();
        }

        [HttpGet]
        public IActionResult BossInfoDetails(int id, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = _db.CerealsBossData.FirstOrDefault(p => p.Id == id);
            if (model != null)
            {
                return View((CerealsBossViewModel)model);
            }
            return View();
        }

        [HttpGet]
        public IActionResult LookHireInfo(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = _db.HireData.Where(p => true).OrderByDescending(p => p.JoinTime);
            if (model != null)
            {
                List<HireViewModel> resModel = new List<HireViewModel>();
                foreach (var m in model)
                {
                    resModel.Add((HireViewModel)m);
                }
                return View(resModel);
            }
            return View();
        }

        [HttpGet]
        public IActionResult HireInfoDetails(int id, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = _db.HireData.FirstOrDefault(p => p.Id == id);
            if (model != null)
            {
                return View((HireViewModel)model);
            }
            return View();
        }



        /// <summary>
        /// 查看个人简历
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult PeopleInfo(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = _db.ResumeData.Where(p => true).OrderByDescending(p => p.JoinTime);
            if (model != null)
            {
                List<ResumeViewModel> resModel = new List<ResumeViewModel>();
                foreach (var m in model)
                {
                    resModel.Add((ResumeViewModel)m);
                }
                return View(resModel);
            }
            return View();
        }


        [HttpGet]
        public IActionResult PeopleInfoDetails(int id, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = _db.ResumeData.FirstOrDefault(p => p.Id == id);
            if (model != null)
            {
                return View((ResumeViewModel)model);
            }
            return View();
        }

        [HttpGet]
        public IActionResult FindDriver(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = _db.DriverData.Where(p => p.DriverCarType == DriverCarType.车找司机).OrderByDescending(p => p.JoinTime);
            if (model != null)
            {
                List<DriverViewModel> resModel = new List<DriverViewModel>();
                foreach (var m in model)
                {
                    resModel.Add((DriverViewModel)m);
                }
                return View(resModel);
            }
            return View();
        }

        [HttpGet]
        public IActionResult FindDriverDetails(int id, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = _db.DriverData.FirstOrDefault(p => p.Id == id);
            if (model != null)
            {
                return View((DriverViewModel)model);
            }
            return View();
        }

        [HttpGet]
        public IActionResult FindCar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = _db.DriverData.Where(p => p.DriverCarType == DriverCarType.司机找车).OrderByDescending(p => p.JoinTime);
            if (model != null)
            {
                List<DriverViewModel> resModel = new List<DriverViewModel>();
                foreach (var m in model)
                {
                    resModel.Add((DriverViewModel)m);
                }
                return View(resModel);
            }
            return View();
        }

        [HttpGet]
        public IActionResult FindCarDetails(int id, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var model = _db.DriverData.FirstOrDefault(p => p.Id == id);
            if (model != null)
            {
                return View((DriverViewModel)model);
            }
            return View();
        }
    }
}
