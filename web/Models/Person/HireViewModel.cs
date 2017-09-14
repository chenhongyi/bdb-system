using Senparc.Weixin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using web.Data;
using static web.Models.AllEnum;

namespace web.Models.Person
{
    /// <summary>
    /// 雇佣人工信息
    /// </summary>
    public class HireViewModel : ViewModelBase
    {
        /// <summary>
        /// 需求人数
        /// </summary>
        [Display(Name = "需求人数")]
        [Required(ErrorMessage = "请填写{0}")]
        public int PersonCount { get; set; } = 1;

        /// <summary>
        /// 工作种类
        /// </summary>
        [Display(Name = "工作种类")]
        [Required(ErrorMessage = "请填写{0}")]
        public WorkType WorkType { get; set; } = WorkType.短工;

        /// <summary>
        /// 工作时间
        /// </summary>
        [Display(Name = "工作周期(几个月)")]
        [Required(ErrorMessage = "请填写{0}")]
        [StringLength(32, ErrorMessage = "{0}长度应该介于{2}与{1}之间", MinimumLength = 1)]
        public string WorkTime { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Display(Name = "工作起始时间")]
        [Required(ErrorMessage = "请填写{0}")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 性别要求
        /// </summary>
        [Display(Name = "性别要求")]
        [Required(ErrorMessage = "请填写{0}")]
        public GenderRequired GenderRequired { get; set; } = GenderRequired.男女不限;

        /// <summary>
        /// 年龄要求
        /// </summary>
        [Display(Name = "年龄要求")]
        [Required(ErrorMessage = "请填写{0}")]
        public AgeRequired AgeRequired { get; set; } = AgeRequired.不限;

        /// <summary>
        /// 工作强度
        /// </summary>
        [Display(Name = "工作强度")]
        [Required(ErrorMessage = "请填写{0}")]
        public WorkStrong WorkStrong { get; set; } = WorkStrong.一般;

        /// <summary>
        /// 结算方式
        /// </summary>
        [Display(Name = "结算方式")]
        [Required(ErrorMessage = "请填写{0}")]
        public PayType PayType { get; set; }
        public static explicit operator HireViewModel(HireData data)
        {
            DateTime joinTime = DateTimeHelper.GetDateTimeFromXml(data.JoinTime);
            DateTime startTime = DateTimeHelper.GetDateTimeFromXml(data.StartTime);
            return new HireViewModel()
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
                WorkType = data.WorkType,
                Id = data.Id
            };
        }
    }
}
