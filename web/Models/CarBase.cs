using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class CarBase
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        [Required(ErrorMessage = "请填写{0}")]
        [Display(Name = "标题")]
        [StringLength(64, ErrorMessage = "{0}长度应该介于{2}与{1}之间", MinimumLength = 2)]
        public string Title { get; set; }


        [Required(ErrorMessage = "请填写{0}")]
        [Display(Name = "价格")]
        public double Price { get; set; }

        [StringLength(8, ErrorMessage = "{0}长度应该介于{2}与{1}之间", MinimumLength = 2)]
        [Display(Name = "联系人姓名")]
        public string Name { get; set; }

        [StringLength(11, ErrorMessage = "{0}长度应该介于{2}与{1}之间", MinimumLength = 11)]
        [Display(Name = "联系人电话")]
        public string Phone { get; set; }

        public DateTime JoinTime { get; set; }
        //[StringLength(32, ErrorMessage = "{1}长度应该介于{2}与{0}之间", MinimumLength = 4)]
        //[Display(Name = "微信号")]
        //public string WeChatId { get; set; }

        [Display(Name = "描述")]
        [StringLength(256, ErrorMessage = "{0}长度应该介于{2}与{1}之间", MinimumLength = 4)]
        public string Desc { get; set; }
    }
}
