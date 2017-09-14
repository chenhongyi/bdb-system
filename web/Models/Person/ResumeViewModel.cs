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
    public class ResumeViewModel : ViewModelBase
    {
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "请填写{0}")]
        [StringLength(64, ErrorMessage = "{0}长度应该介于{2}与{1}之间", MinimumLength = 2)]
        public new string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        public Gender Gender { get; set; } = Gender.男;

        /// <summary>
        /// 出生日期
        /// </summary>
        [Display(Name = "生日")]
        public DateTime BirthDay { get; set; }

        [Display(Name = "自我介绍")]
        [StringLength(256, ErrorMessage = "{0}长度应该介于{2}与{1}之间", MinimumLength = 2)]
        new public string Desc { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        [Display(Name = "籍贯")]
        [StringLength(128, ErrorMessage = "{0}长度应该介于{2}与{1}之间", MinimumLength = 2)]
        public string JiGuan { get; set; }

        /// <summary>
        /// 目前所在地
        /// </summary>
        [Display(Name = "目前所在地")]
        [StringLength(128, ErrorMessage = "{0}长度应该介于{2}与{1}之间", MinimumLength = 2)]
        public string CurPoint { get; set; }

        /// <summary>
        /// 期望工作地点
        /// </summary>
        [Display(Name = "期望工作地点")]
        [StringLength(32, ErrorMessage = "{0}长度应该介于{2}与{1}之间", MinimumLength = 2)]
        public string WorkPoint { get; set; }


        public static explicit operator ResumeViewModel(ResumeData data)
        {
            var joinTime = DateTimeHelper.GetDateTimeFromXml(data.JoinTime);
            var birthDay = DateTimeHelper.GetDateTimeFromXml(data.BirthDay);
            return new ResumeViewModel()
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
                Id = data.Id
            };
        }
    }
}
