using Senparc.Weixin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using web.Models.CerealsViewModels;
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
        public string EndPoint { get; set; } = string.Empty;

        /// <summary>
        /// 数量 多少吨
        /// </summary>
        public double CerealsCount { get; set; } = 0;


        /// <summary>
        /// 预约时间
        /// </summary>
        public long NeedTime { get; set; }


        public static explicit operator CerealsBossData (CerealsBossViewModel data)
        {
            long needTime = DateTimeHelper.GetWeixinDateTime(data.NeedTime);

            long joinTime = DateTimeHelper.GetWeixinDateTime(DateTime.Now);

            return new CerealsBossData()
            {
                EndPoint = data.EndPoint,
                NeedTime = needTime,
                CerealsCount = data.CerealsCount,
                CerealsType = data.CerealsType,
                Desc = data.Desc,
                Id = data.Id,
                JoinTime = joinTime,
                Name = data.Name,
                Phone = data.Phone,
                Price = data.Price,
                StartPoint = data.StartPoint,
                Title = data.Title, 
            };
        }
    }
}
