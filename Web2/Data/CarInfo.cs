using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web2.Models.CarInfo;

namespace Web2.Data
{
    /// <summary>
    /// 车辆信息表
    /// </summary>
    [Serializable()]
    public class CarInfo
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(128)]
        public string UserId { get; set; }

        /// <summary>
        /// 信息标题
        /// </summary>
        [MaxLength(64)] public string Title { get; set; }

        /// <summary>
        /// 价格 收费
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// 文字描述介绍
        /// </summary>
        [MaxLength(256)]
        public string Desc { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// 视频路径
        /// </summary>
        public string VideoPath { get; set; }

        /// <summary>
        /// 车辆类型
        /// </summary>
        public CarType CarType { get; set; } = CarType.大型拉粮卡车;

        /// <summary>
        /// 载重量
        /// </summary>
        public double Weight { get; set; } = 0;

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
        /// 所在区域
        /// </summary>
        public int InZone { get; set; }
        /// <summary>
        /// 车宽
        /// </summary>
        public double Width { get; set; } = 0;

        /// <summary>
        /// 车辆状态
        /// </summary>
        public CarStatus CarStatus { get; set; } = CarStatus.Free;

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
        /// 收录时间
        /// </summary>
        public long JoinTime { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public long CheckTime { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        [MaxLength(32)] public string WeChatId { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        [MaxLength(8)] public string Name { get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        [MaxLength(11)] public string Phone { get; set; }

        public static explicit operator CarInfo(BigCarInfoViewModel model)
        {
            string areaRange = string.Empty;
            StringBuilder sbAr = new StringBuilder();
            if (model.AreaRange != null)
            {
                foreach (var ar in model.AreaRange)
                {
                    sbAr.Append(ar.ToString() + ",");
                }
            }
            return new CarInfo()
            {
                Title = model.Title,
                Price = model.Price,
                Desc = model.Desc,
                AreaRange = sbAr.ToString(),
                ImagePath = model.Image,
                VideoPath = model.Video,
                InZone = (int)model.InZone,
                WeChatId = model.WeChatId,
                Name = model.Name,
                Phone = model.Phone
            };
        }
    }

    public enum CarType
    {
        /// <summary>
        /// 载重量多少吨以上
        /// </summary>
        大型拉粮卡车,

        中型拉粮卡车,

        /// <summary>
        /// 载重量多少吨-多少吨
        /// </summary>
        小型拉辆卡车,

        农用田间拉粮车,

        物流配货车,

        工程车辆,

    }


    /// <summary>
    /// 车辆状态
    /// </summary>
    public enum CarStatus
    {
        /// <summary>
        /// 空闲车辆
        /// </summary>
        [Display(Name = "空闲")]
        Free,

        /// <summary>
        /// 已预约
        /// </summary>
        [Display(Name = "已预约")]
        Ordered,

        /// <summary>
        /// 已接单
        /// </summary>
        [Display(Name = "已接单")]
        GetOrder,

        /// <summary>
        /// 运输中
        /// </summary>
        [Display(Name = "运输中")]
        Transiting,

        /// <summary>
        /// 卸货中
        /// </summary>
        [Display(Name = "卸货中")]
        UnLoading,

        /// <summary>
        /// 返程中
        /// </summary>
        [Display(Name = "返程中")]
        BackHome,

        /// <summary>
        /// 休息中
        /// </summary>
        [Display(Name = "休息中")]
        Resting,
    }

    /// <summary>
    /// 省
    /// </summary>
    public enum Province
    {
        /// <summary>
        /// 黑龙江
        /// </summary>
        [Display(Name = "黑龙江")]
        HeiLongJiang,

        /// <summary>
        /// 辽宁
        /// </summary>
        [Display(Name = "辽宁")]
        LiaoNing,

        /// <summary>
        /// 吉林
        /// </summary>
        [Display(Name = "吉林")]
        JiLin,
    }

    /// <summary>
    /// 市
    /// </summary>
    public enum City
    {
        鸡西市,
    }

    /// <summary>
    /// 县
    /// </summary>
    public enum County
    {
        虎林市,
    }

    /// <summary>
    /// 镇
    /// </summary>
    public enum Town
    {
        八五六农场,
        八五七农场,
        八五零农场,
        八五八农场,
        八五一一农场,
        兴凯湖农场,
        八五四农场 = 6,
        迎春 = 6,
    }

    /// <summary>
    /// 村级车辆运输目的地
    /// </summary>
    public enum Village
    {
        厂部,
        分厂,
        第一管理区,
        第二管理区,
        第三管理区,
        第四管理区,
        第五管理区,
        第六管理区,
        第七管理区,
        第八管理区,
    }

    /// <summary>
    /// 作业站级车辆运输目的地
    /// </summary>
    public enum WorkStation
    {
        第一作业站,
        第二作业站,
        第三作业站,
        第四作业站,
        第五作业站,
        第六作业站,
        第七作业站,
        第八作业站,
    }
}