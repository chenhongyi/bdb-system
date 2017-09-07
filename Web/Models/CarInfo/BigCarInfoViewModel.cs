using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models.CarInfo
{
    public class BigCarInfoViewModel
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        [Required(ErrorMessage = "请填写{0}")]
        [Display(Name = "标题")]
        [StringLength(64, ErrorMessage = "{1}长度应该介于{2}与{0}之间", MinimumLength = 2)]
        public string Title { get; set; }

        [Display(Name = "运输范围")]
        public string AreaRange { get; set; }

        [Required(ErrorMessage = "请填写{0}")]
        [Display(Name = "价格")]
        public double Price { get; set; }

        [Display(Name = "描述")]
        [StringLength(256, ErrorMessage = "{1}长度应该介于{2}与{0}之间", MinimumLength = 4)]
        public string Desc { get; set; }

        [Display(Name = "照片")]
        public string Image { get; set; }

        [Display(Name = "小视频")]
        public string Video { get; set; }

        [Display(Name = "所在地区")]
        public InZone InZone { get; set; }

        //[StringLength(32, ErrorMessage = "{1}长度应该介于{2}与{0}之间", MinimumLength = 4)]
        //[Display(Name = "微信号")]
        //public string WeChatId { get; set; }

        [StringLength(8, ErrorMessage = "{1}长度应该介于{2}与{0}之间", MinimumLength = 2)]
        [Display(Name = "联系人姓名")]
        public string Name { get; set; }

        [StringLength(11, ErrorMessage = "{1}长度应该介于{2}与{0}之间", MinimumLength = 11)]
        [Display(Name = "联系人电话")]
        public string Phone { get; set; }

        public static explicit operator BigCarInfoViewModel(Data.CarInfo source)
        {
            return new BigCarInfoViewModel()
            {
                Id = source.Id,
                AreaRange = source.AreaRange,
                Desc = source.Desc,
                Image = source.ImagePath ?? "",
                InZone = (InZone)source.InZone,
                Name = source.Name,
                Phone = source.Phone,
                Price = source.Price,
                Title = source.Title,
                Video = source.VideoPath ?? ""
            };
        }

    }

    /// <summary>
    /// 运输范围
    /// </summary>
    public enum AreaRange
    {
        [Display(Name = "牡丹江管局内")]
        牡丹江管局内,
        [Display(Name = "黑龙江省内")]
        省内,
        [Display(Name = "东三省")]
        省外,
        [Display(Name = "全国")]
        全国,
    }

    ///// <summary>
    ///// 运输范围
    ///// </summary>
    //public enum AreaRange
    //{
    //    /// <summary>
    //    /// 850农场
    //    /// </summary>
    //    [Display(Name = "八五零")]
    //    F850,
    //    /// <summary>
    //    /// 854农场
    //    /// </summary>
    //    [Display(Name = "八五四")]
    //    F854,
    //    /// <summary>
    //    /// 855农场
    //    /// </summary>
    //    [Display(Name = "八五五")]
    //    F855,
    //    /// <summary>
    //    /// 856农场
    //    /// </summary>
    //    [Display(Name = "八五六")]
    //    F856,
    //    /// <summary>
    //    /// 857农场
    //    /// </summary>
    //    [Display(Name = "八五七")]
    //    F857,
    //    /// <summary>
    //    /// 858农场
    //    /// </summary>
    //    [Display(Name = "八五八")]
    //    F858,
    //    /// <summary>
    //    /// 8511农场
    //    /// </summary>
    //    [Display(Name = "八五一一")]
    //    F8511,
    //    /// <summary>
    //    /// 兴凯湖
    //    /// </summary>
    //    [Display(Name = "兴凯湖")] XingKaihu,
    //    /// <summary>
    //    /// 虎林
    //    /// </summary>
    //    [Display(Name = "虎林")] HuLin,
    //    /// <summary>
    //    /// 密山
    //    /// </summary>
    //    [Display(Name = "密山")] MiShan,
    //    /// <summary>
    //    /// 管局
    //    /// </summary>
    //    [Display(Name = "管局")] GuanJu,
    //    /// <summary>
    //    /// 鸡西
    //    /// </summary>
    //    [Display(Name = "鸡西")] JiXi,
    //}

    public enum InZone
    {
        [Display(Name = "八五零")]
        F850,
        [Display(Name = "八五四")]
        F854,
        [Display(Name = "八五五")]
        F855,
        [Display(Name = "八五六")]
        F856,
        [Display(Name = "八五七")]
        F857,
        [Display(Name = "八五八")]
        F858,
        [Display(Name = "八五一一")]
        F8511,
        [Display(Name = "兴凯湖")]
        XingKaiHu,
        [Display(Name = "虎林")]
        HuLin,
        [Display(Name = "密山")]
        MiShan,
        [Display(Name = "管局")]
        GuanJu,
        [Display(Name = "鸡西")]
        JiXi,
    }

}
