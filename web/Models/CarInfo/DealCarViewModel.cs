using Senparc.Weixin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using web.Data;
using static web.Models.AllEnum;

namespace web.Models.CarInfo
{
    /// <summary>
    /// 车辆交易数据
    /// </summary>
    public class DealCarViewModel : ViewModelBase
    {
        [Display(Name = "品牌")]
        public CarBrand CarBrand { get; set; } = CarBrand.手动填写;

        [Display(Name = "品牌")]
        [StringLength(16, ErrorMessage = "{0}长度应该介于{2}与{1}之间", MinimumLength = 1)]
        public string BrandViewModel { get; set; }

        /// <summary>
        /// 请选择几年内的车
        /// </summary>
        [Display(Name = "年限")] public double Years { get; set; } = 0;

        /// <summary>
        /// 排量
        /// </summary>
        [Display(Name = "排量")] public double Displacement { get; set; } = 0;

        /// <summary>
        /// 上牌时间
        /// </summary>
        [Display(Name = "上牌时间")] public DateTime RegTime { get; set; }

        /// <summary>
        /// 行驶里程
        /// </summary>
        [Display(Name = "公里数")] public double RunRoadCount { get; set; } = 0;

        /// <summary>
        /// 手续是否齐全
        /// </summary>
        [Display(Name = "手续")] public Procedure Procedure { get; set; } = Procedure.有;

        /// <summary>
        /// 手动自动
        /// </summary>
        [Display(Name = "自动手动")]
        public Auto Auto { get; set; } = Auto.自动;
        /// <summary>
        /// 买还是卖
        /// </summary>
        public BuyOrSell BuyOrSell { get; set; } = BuyOrSell.买;

        /// <summary>
        /// 所在区域
        /// </summary>
        [Display(Name = "所在地区")] public InZone InZone { get; set; } = InZone.八五零;



        /// <summary>
        /// 下次验车时间
        /// </summary>
        //public DateTime NextCheckTime { get; set; }

        ///// <summary>
        ///// 交强险到期时间
        ///// </summary>
        //public DateTime JqxEndTime { get; set; }

        ///// <summary>
        ///// 商业险到期时间
        ///// </summary>
        //public DateTime SyxEndTime { get; set; }

        public static explicit operator DealCarViewModel(DealCarData data)
        {
            DateTime joinTime = DateTimeHelper.GetDateTimeFromXml(data.JoinTime);
            DateTime regTime = DateTimeHelper.GetDateTimeFromXml(data.RegTime);
            return new DealCarViewModel()
            {
                Auto = data.Auto,
                BrandViewModel = data.Brand,
                BuyOrSell = data.BuyOrSell,
                CarBrand = data.CarBrand,
                Desc = data.Desc,
                Displacement = data.Displacement,
                Id = data.Id,
                JoinTime = joinTime,
                Name = data.Name,
                Phone = data.Phone,
                Price = data.Price,
                Procedure = data.Procedure,
                RegTime = regTime,
                RunRoadCount = data.RunRoadCount,
                Title = data.Title,
                Years = data.Years,
                InZone = data.InZone
            };
        }

    }
}
