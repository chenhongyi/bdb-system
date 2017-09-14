using Senparc.Weixin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using web.Data;
using static web.Models.AllEnum;

namespace web.Models.CerealsViewModels
{
    /// <summary>
    /// 货主信息
    /// </summary>
    public class CerealsBossViewModel : ViewModelBase
    {
        [Display(Name = "粮食类型")]
        public CerealsType CerealsType { get; set; }

        /// <summary>
        /// 出发点
        /// </summary>
        [Required(ErrorMessage = "请填写{0}")]
        [Display(Name = "装车地点")]
        [StringLength(32, ErrorMessage = "{0}长度应该介于{2}与{1}之间", MinimumLength = 2)]
        public string StartPoint { get; set; }

        /// <summary>
        /// 终点
        /// </summary>
        [Required(ErrorMessage = "请填写{0}")]
        [Display(Name = "卸车地点")]
        [StringLength(32, ErrorMessage = "{0}长度应该介于{2}与{1}之间", MinimumLength = 2)]
        public string EndPoint { get; set; }

        /// <summary>
        /// 数量 多少吨
        /// </summary>
        [Required(ErrorMessage = "请填写{0}")]
        [Display(Name = "多少吨")]
        public double CerealsCount { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        [Display(Name = "装货日期")]
        public DateTime NeedTime { get; set; }



        public static explicit operator CerealsBossViewModel(CerealsBossData data)
        {
            DateTime needTime = DateTimeHelper.GetDateTimeFromXml(data.NeedTime);

            DateTime joinTime = DateTimeHelper.GetDateTimeFromXml(data.JoinTime);

            return new CerealsBossViewModel()
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
                Title = data.Title
            };
        }
    }
}
