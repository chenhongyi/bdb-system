using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.Models.CarInfo;
using static web.Models.AllEnum;

namespace web.Data
{
    /// <summary>
    /// 车辆信息表
    /// </summary>
    [Serializable()]
    public class CarInfo : CarBaseData
    {
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// 视频路径
        /// </summary>
        public string VideoPath { get; set; }



        /// <summary>
        /// 载重量
        /// </summary>
        public LoadWeight Weight { get; set; } = 0;

        /// <summary>
        /// 高度
        /// </summary>
        public double Height { get; set; } = 0;

        /// <summary>
        /// 车长
        /// </summary>
        public double LongSize { get; set; } = 0;

        /// <summary>
        /// 运输范围  1，2，3，4，5
        /// </summary>
        public string AreaRange { get; set; }


        /// <summary>
        /// 车宽
        /// </summary>
        public double Width { get; set; } = 0;



        /// <summary>
        /// 省级车辆运输目的地
        /// </summary>
        public Province DestinationProvince { get; set; }
        /// <summary>
        /// 市级车辆运输目的地
        /// </summary>
        public City DestinationCity { get; set; }
        /// <summary>
        /// 县级车辆运输目的地
        /// </summary>
        public County DestinationCounty { get; set; }
        /// <summary>
        /// 镇级车辆运输目的地
        /// </summary>
        public Town DestinationTown { get; set; }
        /// <summary>
        /// 村级车辆运输目的地
        /// </summary>
        public Village DestinationVillage { get; set; }
        /// <summary>
        /// 作业站级车辆运输目的地
        /// </summary>
        public WorkStation DestinationLevel6 { get; set; }

        /// <summary>
        /// X坐标
        /// </summary>
        [Display(Name = "X坐标")]
        public double PosX { get; set; }

        /// <summary>
        /// Y坐标
        /// </summary>
        [Display(Name = "Y坐标")]
        public double PosY { get; set; }

        /// <summary>
        /// 雇主id
        /// </summary>
        [MaxLength(128)]
        [Display(Name = "雇主ID")]
        public string BossId { get; set; }



        /// <summary>
        /// 微信号
        /// </summary>
        //[MaxLength(32)] public string WeChatId { get; set; }



        public static explicit operator CarInfo(BigCarInfoViewModel model)
        {
            return new CarInfo()
            {
                Title = model.Title,
                Price = model.Price,
                Desc = model.Desc,
                AreaRange = model.AreaRange,
                ImagePath = model.Image,
                VideoPath = model.Video,
                InZone = model.InZoneInt,
                //WeChatId = model.WeChatId,
                Name = model.Name,
                Phone = model.Phone,
                CarType = (CarType)model.CarTypeIn,
                Weight = model.LoadWeightIn
            };
        }
    }

}