using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static web.Models.AllEnum;

namespace web.Data
{
    /// <summary>
    /// 粮食货主信息
    /// </summary>
    [Serializable()]
    public class CerealsBossData : BaseData
    {
        public CerealsType CerealsType { get; set; } = CerealsType.水稻;

        /// <summary>
        /// 出发点
        /// </summary>
        [MaxLength(32)]
        public string StartPoint { get; set; } = string.Empty;

        /// <summary>
        /// 终点
        /// </summary>
        [MaxLength(32)]
        public string EndPoint {get;set;} = string.Empty;

        /// <summary>
        /// 数量 多少吨
        /// </summary>
        public double CerealsCount { get; set; } = 0;

        /// <summary>
        /// 需要车的数量
        /// </summary>
        public int CarCount { get; set; } = 0;

        public BossType BossType { get; set; } = BossType.货主;
    }
}
