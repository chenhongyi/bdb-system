using Senparc.Weixin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using web.Models.CarInfo;
using static web.Models.AllEnum;

namespace web.Data
{
    /// <summary>
    /// 二手车辆买卖信息
    /// </summary>
    [Serializable()]
    public class DealCarData : BaseData
    {
        /// <summary>
        /// 品牌
        /// </summary>
        public CarBrand CarBrand { get; set; } = CarBrand.手动填写;

        /// <summary>
        /// 品牌
        /// </summary>
        [MaxLength(16)] public string Brand { get; set; } = string.Empty;

        /// <summary>
        /// 年限
        /// </summary>
        public double Years { get; set; } = 0;

        /// <summary>
        /// 排量
        /// </summary>
        public double Displacement { get; set; } = 0;

        /// <summary>
        /// 上牌时间
        /// </summary>
        public long RegTime { get; set; } = 0;
        /// <summary>
        /// 行驶里程
        /// </summary>
        public double RunRoadCount { get; set; } = 0;

        /// <summary>
        /// 手续是否齐全
        /// </summary>
        public Procedure Procedure { get; set; } = Procedure.有;

        /// <summary>
        /// 手动自动
        /// </summary>
        public Auto Auto { get; set; } = Auto.自动;

        /// <summary>
        /// 卖车还是买车
        /// </summary>
        public BuyOrSell BuyOrSell { get; set; } = BuyOrSell.卖;


        public static explicit operator DealCarData(DealCarViewModel data)
        {
            long regTime = DateTimeHelper.GetWeixinDateTime(data.RegTime);
            if (regTime <= 0)
            {
                regTime = 0;
            }
            long time = DateTimeHelper.GetWeixinDateTime(DateTime.Now);
            return new DealCarData()
            {
                Auto = data.Auto,
                Brand = data.BrandViewModel,
                CarBrand = data.CarBrand,
                BuyOrSell = data.BuyOrSell,
                Desc = data.Desc,
                Displacement = data.Displacement,
                Id = data.Id,
                InZone = data.InZone,
                Price = data.Price,
                Name = data.Name,
                Phone = data.Phone,
                Procedure = data.Procedure,
                RegTime = regTime,
                JoinTime = time,
                RunRoadCount = data.RunRoadCount,
                Title = data.Title,
                Years = data.Years
            };
        }
    }
}
