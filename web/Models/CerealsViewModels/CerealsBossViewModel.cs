using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
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
        /// 需要车的数量
        /// </summary>
        [Display(Name = "有多少车")] public int CarCount { get; set; }

        /// <summary>
        /// 车主还是货主
        /// </summary>
        public BossType BossType { get; set; }
    }
}
