using Senparc.Weixin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Models.Person;
using static web.Models.AllEnum;

namespace web.Data
{
    [Serializable()]
    public class DriverData : BaseData
    {
        /// <summary>
        /// 类型 车找司机还是司机找车
        /// </summary>
        public DriverCarType DriverCarType { get; set; } = DriverCarType.司机找车;

        /// <summary>
        /// 驾龄
        /// </summary>
        public int DriverYears { get; set; } = 1;

        /// <summary>
        /// 汽车驾照
        /// </summary>
        public DriverCardType DriverCardType { get; set; } = DriverCardType.A1;

        /// <summary>
        /// 拖拉机驾照
        /// </summary>
        public TljDriverCardType TljDriverCardType { get; set; } = TljDriverCardType.G;
        /// <summary>
        /// 出生日期
        /// </summary>
        public long BirthDay { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; } = Gender.男;

        /// <summary>
        /// 车型
        /// </summary>
        public BigCarType BigCarType { get; set; } = BigCarType.卡车;

        public static explicit operator DriverData(DriverViewModel data)
        {
            var joinTime = DateTimeHelper.GetWeixinDateTime(DateTime.Now);
            var birthDay = DateTimeHelper.GetWeixinDateTime(data.BirthDay);

            return new DriverData()
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
                BirthDay = birthDay,
            };
        }
    }
}
