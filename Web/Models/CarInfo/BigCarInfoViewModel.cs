using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class BigCarInfoViewModel:CarBase
    {


        [Display(Name = "运输范围")]
        public string AreaRange { get; set; }

        [Display(Name = "照片")]
        public string Image { get; set; }

        [Display(Name = "小视频")]
        public string Video { get; set; }

        [Display(Name = "所在地区")]
        public string InZone { get; set; }

        [Display(Name = "所在地区")]
        public int InZoneInt { get; set; }

        /// <summary>
        /// 车辆类型
        /// </summary>
        [Display(Name = "车型")]
        public int CarTypeIn { get; set; }

        /// <summary>
        /// 吨位
        /// </summary>
        [Display(Name = "吨位")]
        public string LoadWeightOut { get; set; }

        [Display(Name = "吨位")]
        public LoadWeight LoadWeightIn { get; set; }
        /// <summary>
        /// 车辆型号  侧翻 挂车 仓兰
        /// </summary>
        public string CarTypeOut { get; set; }



        public static explicit operator BigCarInfoViewModel(Data.CarInfo data)
        {
            var time = DateTimeHelper.GetDateTimeFromXml(data.JoinTime);
            string areaRange = string.Empty;
            string inZone = string.Empty;
            string carType = string.Empty;
            string weight = string.Empty;
            switch ((LoadWeight)data.Weight)
            {
                case AllEnum.LoadWeight.W40:
                    weight = "40吨以下";
                    break;
                case AllEnum.LoadWeight.W40T50:
                    weight = "40到50吨";
                    break;
                case AllEnum.LoadWeight.W50T60:
                    weight = "50到70吨";
                    break;
                case AllEnum.LoadWeight.W60T70:
                    weight = "60到70吨";
                    break;
                case AllEnum.LoadWeight.W70:
                    weight = "70吨往上";
                    break;
            }
            switch (data.AreaRange)
            {
                case "0":
                    areaRange = "牡丹江管局内";
                    break;
                case "1":
                    areaRange = "黑龙江省内";
                    break;
                case "2":
                    areaRange = "东三省";
                    break;
                case "3":
                    areaRange = "全国";
                    break;
                case "4":
                    areaRange = "八五六农场";
                    break;
            }
            switch ((InZone)data.InZone)
            {
                case AllEnum.InZone.F850:
                    inZone = "八五零农场";
                    break;
                case AllEnum.InZone.F854:
                    inZone = "八五四农场";
                    break;
                case AllEnum.InZone.F855:
                    inZone = "八五五农场";
                    break;
                case AllEnum.InZone.F856:
                    inZone = "八五六农场";
                    break;
                case AllEnum.InZone.F857:
                    inZone = "八五七农场";
                    break;
                case AllEnum.InZone.F858:
                    inZone = "八五八农场";
                    break;
                case AllEnum.InZone.F8511:
                    inZone = "八五一一农场";
                    break;
                case AllEnum.InZone.XingKaiHu:
                    inZone = "兴凯湖农场";
                    break;
                case AllEnum.InZone.HuLin:
                    inZone = "虎林市";
                    break;
                case AllEnum.InZone.MiShan:
                    inZone = "密山市";
                    break;
                case AllEnum.InZone.GuanJu:
                    inZone = "牡丹江管局";
                    break;
                case AllEnum.InZone.JiXi:
                    inZone = "鸡西市";
                    break;
                default:
                    inZone = "黑龙江省";
                    break;
            }
            switch (data.CarType)
            {
                case AllEnum.CarType.侧翻:
                    carType = "侧翻斗车";
                    break;
                case AllEnum.CarType.挂车:
                    carType = "挂车";
                    break;
                case AllEnum.CarType.仓兰:
                    carType = "仓兰";
                    break;
                case AllEnum.CarType.大型拉粮卡车:
                    carType = "大型拉粮卡车";
                    break;
                case AllEnum.CarType.收割机:
                    carType = "收割机";
                    break;
                case AllEnum.CarType.农用拖拉机:
                    carType = "农用拖拉机";
                    break;
                case AllEnum.CarType.物流配货车:
                    carType = "物流配货车";
                    break;
                case AllEnum.CarType.工程车辆:
                    carType = "工程车辆";
                    break;
            }
            return new BigCarInfoViewModel()
            {
                Id = data.Id,
                AreaRange = areaRange,
                Desc = data.Desc,
                Image = data.ImagePath ?? "",
                InZone = inZone,
                Name = data.Name,
                Phone = data.Phone,
                Price = data.Price,
                Title = data.Title,
                Video = data.VideoPath ?? "",
                JoinTime = time,
                LoadWeightOut = weight,
                CarTypeOut = carType
            };
        }
    }






}
