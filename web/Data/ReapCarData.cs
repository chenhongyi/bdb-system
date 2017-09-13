using Senparc.Weixin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static web.Models.AllEnum;

namespace web.Data
{
    [Serializable()]
    public class ReapCarData : BaseData
    {
        /// <summary>
        /// 品牌
        /// </summary>
        public Brand Brand { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public ReapCarType ReapCarType { get; set; }

        /// <summary>
        /// 土地数量
        /// </summary>
        public double Land { get; set; }

        /// <summary>
        /// 车辆数量
        /// </summary>
        public int CarCount { get; set; }

       
    }
}
