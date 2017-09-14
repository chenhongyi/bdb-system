using Senparc.Weixin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using web.Models.Person;
using static web.Models.AllEnum;

namespace web.Data
{
    /// <summary>
    /// 雇佣信息
    /// </summary>
    [Serializable()]
    public class HireData : BaseData
    {
        /// <summary>
        /// 需求人数
        /// </summary>
        public int PersonCount { get; set; } = 1;

        /// <summary>
        /// 工作种类
        /// </summary>
        public WorkType WorkType { get; set; } = WorkType.短工;

        /// <summary>
        /// 工作时间
        /// </summary>
        [MaxLength(32)]
        public string WorkTime { get; set; } 

        /// <summary>
        /// 开始时间
        /// </summary>
        public long StartTime { get; set; }

        /// <summary>
        /// 性别要求
        /// </summary>
        public GenderRequired GenderRequired { get; set; } = GenderRequired.男女不限;

        /// <summary>
        /// 年龄要求
        /// </summary>
        public AgeRequired AgeRequired { get; set; } = AgeRequired.不限;

        /// <summary>
        /// 工作强度
        /// </summary>
        public WorkStrong WorkStrong { get; set; } = WorkStrong.一般;

        /// <summary>
        /// 结算方式
        /// </summary>
        public PayType PayType { get; set; }

        public static explicit operator HireData(HireViewModel data)
        {
            long joinTime = DateTimeHelper.GetWeixinDateTime(DateTime.Now);
            long startTime = DateTimeHelper.GetWeixinDateTime(data.StartTime);
            return new HireData()
            {
                JoinTime = joinTime,
                AgeRequired = data.AgeRequired,
                Desc = data.Desc,
                GenderRequired = data.GenderRequired,
                Name = data.Name,
                PayType = data.PayType,
                PersonCount = data.PersonCount,
                Phone = data.Phone,
                Price = data.Price,
                StartTime = startTime,
                Title = data.Title,
                WorkStrong = data.WorkStrong,
                WorkTime = data.WorkTime,
                WorkType = data.WorkType
            };
        }
    }
}
