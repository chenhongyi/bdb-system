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
    /// 简历数据
    /// </summary>
    [Serializable()]
    public class ResumeData : BaseData
    {
        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; } = Gender.男;

        /// <summary>
        /// 出生日期
        /// </summary>
        public long BirthDay { get; set; }


        /// <summary>
        /// 籍贯
        /// </summary>
        [MaxLength(128)]
        public string JiGuan { get; set; }

        /// <summary>
        /// 目前所在地
        /// </summary>
        [MaxLength(128)]
        public string CurPoint { get; set; }

        /// <summary>
        /// 期望工作地点
        /// </summary>
        [MaxLength(32)]
        public string WorkPoint { get; set; }

        public static explicit operator ResumeData(ResumeViewModel data)
        {
            var joinTime = DateTimeHelper.GetWeixinDateTime(DateTime.Now);
            var birthDay = DateTimeHelper.GetWeixinDateTime(data.BirthDay);
            return new ResumeData()
            {
                JoinTime = joinTime,
                BirthDay = birthDay,
                CurPoint = data.CurPoint,
                Desc = data.Desc,
                JiGuan = data.JiGuan,
                Name = data.Name,
                Phone = data.Phone,
                Title = data.Title,
                WorkPoint = data.WorkPoint,
                Gender = data.Gender,
            };
        }
    }
}
