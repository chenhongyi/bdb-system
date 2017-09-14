using Senparc.Weixin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using web.Data;
using web.Data.Migrations;
using static web.Models.AllEnum;

namespace web.Models.Person
{
    public class DriverViewModel : ViewModelBase
    {
        /// <summary>
        /// 类型 车找司机还是司机找车
        /// </summary>
        public DriverCarType DriverCarType { get; set; } = DriverCarType.司机找车;

        /// <summary>
        /// 驾龄
        /// </summary>
        [Required(ErrorMessage = "请填写{0}")]
        [Display(Name = "驾龄")]
        public int DriverYears { get; set; } = 1;

        /// <summary>
        /// 出生日期
        /// </summary>
        [Display(Name = "出生日期")]
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// 汽车驾照
        /// </summary>
        [Display(Name = "汽车驾照级别")] public DriverCardType DriverCardType { get; set; } = DriverCardType.A1;

        /// <summary>
        /// 拖拉机驾照
        /// </summary>
        [Display(Name = "拖拉机驾照级别")] public TljDriverCardType TljDriverCardType { get; set; } = TljDriverCardType.G;

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")] public Gender Gender { get; set; } = Gender.男;

        /// <summary>
        /// 车型
        /// </summary>
        [Display(Name = "车型")] public BigCarType BigCarType { get; set; } = BigCarType.卡车;

        [Display(Name = "薪资")]
        new public double Price { get; set; }

        public static explicit operator DriverViewModel(DriverData data)
        {
            var joinTime = DateTimeHelper.GetDateTimeFromXml(data.JoinTime);
            var birthDay = DateTimeHelper.GetDateTimeFromXml(data.BirthDay);
            return new DriverViewModel()
            {
                JoinTime = joinTime,
                Desc = data.Desc,
                DriverYears = data.DriverYears,
                Gender = data.Gender,
                Name = data.Name,
                Phone = data.Phone,
                Price = data.Price,
                BigCarType = data.BigCarType,
                TljDriverCardType = data.TljDriverCardType,
                Title = data.Title,
                DriverCardType = data.DriverCardType,
                Id = data.Id,
                BirthDay = birthDay
            };
        }
    }
}
