using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static web.Models.AllEnum;

namespace web.Data
{
    [Serializable()]
    public class CarBaseData
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
        /// 所在区域
        /// </summary>
        public int InZone { get; set; }
        /// <summary>
        /// 车辆状态
        /// </summary>
        public CarStatus CarStatus { get; set; } = CarStatus.Free;
        /// <summary>
        /// 车辆类型
        /// </summary>
        public CarType CarType { get; set; } = CarType.大型拉粮卡车;
        /// <summary>
        /// 收录时间
        /// </summary>
        public long JoinTime { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public long CheckTime { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        [MaxLength(8)] public string Name { get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        [MaxLength(11)] public string Phone { get; set; }
    }
}
