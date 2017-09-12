using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.Data;
using web.Models.CarInfo;
using static web.Models.AllEnum;

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
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BigTransportCarInfo()
        {
            var model = _db.Carinfo.Where(p => p.CarStatus == CarStatus.Free);
            List<BigCarInfoViewModel> resModel = new List<BigCarInfoViewModel>();
            foreach (var m in model)
            {
                resModel.Add((BigCarInfoViewModel)m);
            }
            return View(resModel);
        }

        [HttpGet]
        public IActionResult BigCarDetails(int id)
        {
            var model = _db.Carinfo.FirstOrDefault(p => p.Id == id);
            if (model != null)
            {
                return View((BigCarInfoViewModel)model);
            }
            return null;
        }
    }
}
