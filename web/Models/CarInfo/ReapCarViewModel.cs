using Senparc.Weixin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static web.Models.AllEnum;

namespace web.Models.CarInfo
{
    public class ReapCarViewModel : ViewModelBase
    {
        /// <summary>
        /// 车辆型号
        /// </summary>
        [Display(Name = "车型")]
        public ReapCarType ReapCarType { get; set; }

        /// <summary>
        /// 车辆型号
        /// </summary>
        [Display(Name = "车型")]
        public string ReapCarTypeViewModel { get; set; }

        [Display(Name = "收割机品牌")]
        public Brand Brand { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        [Display(Name = "品牌")]
        public string BrandViewModel { get; set; }

        [Display(Name = "所在地区")]
        public int InZoneInt { get; set; }

        [Display(Name = "所在地区")]
        public string InZone { get; set; }

        /// <summary>
        /// 多少亩地等待收割
        /// </summary>
        [Display(Name = "多少亩地")]
        public double Land { get; set; }

        /// <summary>
        /// 需求车辆数
        /// </summary>
        [Display(Name = "车辆数量")]
        public int CarCount { get; set; }

        public static explicit operator ReapCarViewModel(Data.ReapCarData data)
        {
            var time = DateTimeHelper.GetDateTimeFromXml(data.JoinTime);
            string brand = string.Empty;
            string reapCarType = string.Empty;
            string inZone = string.Empty;

            switch (data.Brand)
            {
                case AllEnum.Brand.久保田:
                    brand = "久保田";
                    break;
            }

            switch (data.ReapCarType)
            {
                case AllEnum.ReapCarType.大型收割机:
                    reapCarType = "大型收割机";
                    break;
                case AllEnum.ReapCarType.小型收割机:
                    reapCarType = "小型收割机";
                    break;
            }

            switch ((InZone)data.InZone)
            {
                case AllEnum.InZone.八五零:
                    inZone = "八五零农场";
                    break;
                case AllEnum.InZone.八五四:
                    inZone = "八五四农场";
                    break;
                case AllEnum.InZone.八五五:
                    inZone = "八五五农场";
                    break;
                case AllEnum.InZone.八五六:
                    inZone = "八五六农场";
                    break;
                case AllEnum.InZone.八五七:
                    inZone = "八五七农场";
                    break;
                case AllEnum.InZone.八五八:
                    inZone = "八五八农场";
                    break;
                case AllEnum.InZone.八五一一:
                    inZone = "八五一一农场";
                    break;
                case AllEnum.InZone.兴凯湖:
                    inZone = "兴凯湖农场";
                    break;
                case AllEnum.InZone.虎林:
                    inZone = "虎林市";
                    break;
                case AllEnum.InZone.密山:
                    inZone = "密山市";
                    break;
                case AllEnum.InZone.管局:
                    inZone = "牡丹江管局";
                    break;
                case AllEnum.InZone.鸡西:
                    inZone = "鸡西市";
                    break;
                default:
                    inZone = "黑龙江省";
                    break;
            }

            return new ReapCarViewModel()
            {
                BrandViewModel = brand,
                ReapCarTypeViewModel = reapCarType,
                CarCount = data.CarCount,
                Id = data.Id,
                Desc = data.Desc,
                InZone = inZone,
                JoinTime = time,
                Land = data.Land,
                Name = data.Name,
                Phone = data.Phone,
                Price = data.Price,
                Title = data.Title,
            };
        }

    }
}
