using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public static class AllEnum
    {
        public enum InZone
        {
            [Display(Name = "八五零")]
            八五零,
            [Display(Name = "八五四")]
            八五四,
            [Display(Name = "八五五")]
            八五五,
            [Display(Name = "八五六")]
            八五六,
            [Display(Name = "八五七")]
            八五七,
            [Display(Name = "八五八")]
            八五八,
            [Display(Name = "八五一一")]
            八五一一,
            [Display(Name = "兴凯湖")]
            兴凯湖,
            [Display(Name = "虎林")]
            虎林,
            [Display(Name = "密山")]
            密山,
            [Display(Name = "管局")]
            管局,
            [Display(Name = "鸡西")]
            鸡西,
        }

        public enum LoadWeight
        {
            [Display(Name = "40吨以下")]
            W40,
            [Display(Name = "40到50吨")]
            W40T50,
            [Display(Name = "50到60吨")]
            W50T60,
            [Display(Name = "60到70吨")]
            W60T70,
            [Display(Name = "70吨以上")]
            W70
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
            [Display(Name = "八五六农场")]
            八五六农场,
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


        public enum CarType
        {
            侧翻,
            挂车,
            仓兰,

            /// <summary>
            /// 载重量多少吨以上
            /// </summary>
            大型拉粮卡车,

            收割机,

            农用拖拉机,

            物流配货车,

            工程车辆,

        }


        /// <summary>
        /// 车辆状态
        /// </summary>
        public enum CarStatus
        {
            /// <summary>
            /// 空闲车辆
            /// </summary>
            [Display(Name = "空闲")]
            Free,

            /// <summary>
            /// 已预约
            /// </summary>
            [Display(Name = "已预约")]
            Ordered,

            /// <summary>
            /// 已接单
            /// </summary>
            [Display(Name = "已接单")]
            GetOrder,

            /// <summary>
            /// 运输中
            /// </summary>
            [Display(Name = "运输中")]
            Transiting,

            /// <summary>
            /// 卸货中
            /// </summary>
            [Display(Name = "卸货中")]
            UnLoading,

            /// <summary>
            /// 返程中
            /// </summary>
            [Display(Name = "返程中")]
            BackHome,

            /// <summary>
            /// 休息中
            /// </summary>
            [Display(Name = "休息中")]
            Resting,
        }

        /// <summary>
        /// 省
        /// </summary>
        public enum Province
        {
            /// <summary>
            /// 黑龙江
            /// </summary>
            [Display(Name = "黑龙江")]
            HeiLongJiang,

            /// <summary>
            /// 辽宁
            /// </summary>
            [Display(Name = "辽宁")]
            LiaoNing,

            /// <summary>
            /// 吉林
            /// </summary>
            [Display(Name = "吉林")]
            JiLin,
        }

        /// <summary>
        /// 市
        /// </summary>
        public enum City
        {
            鸡西市,
        }

        /// <summary>
        /// 县
        /// </summary>
        public enum County
        {
            虎林市,
        }

        /// <summary>
        /// 镇
        /// </summary>
        [Flags]
        public enum Town
        {
            八五六农场,
            八五七农场,
            八五零农场,
            八五八农场,
            八五一一农场,
            兴凯湖农场,
            八五四农场 = 6,
            迎春 = 6,
        }

        /// <summary>
        /// 村级车辆运输目的地
        /// </summary>
        public enum Village
        {
            厂部,
            分厂,
            第一管理区,
            第二管理区,
            第三管理区,
            第四管理区,
            第五管理区,
            第六管理区,
            第七管理区,
            第八管理区,
        }

        /// <summary>
        /// 作业站级车辆运输目的地
        /// </summary>
        public enum WorkStation
        {
            第一作业站,
            第二作业站,
            第三作业站,
            第四作业站,
            第五作业站,
            第六作业站,
            第七作业站,
            第八作业站,
        }


        /// <summary>
        /// 收割车辆型号分类
        /// </summary>
        public enum ReapCarType
        {
            大型收割机,
            小型收割机,
        }

        /// <summary>
        /// 车辆当前状态
        /// </summary>
        public enum ReapCarStatus
        {
            空闲,
            工作中,
            休息,
        }

        /// <summary>
        /// 品牌
        /// </summary>
        public enum Brand
        {
            久保田,
        }

        /// <summary>
        /// 车辆品牌
        /// </summary>
        public enum CarBrand
        {
            手动填写,
            大众,
            本田,
            奥迪,
            奔驰,
            宝马,
            凯迪拉克,
            克莱斯勒,
            福特,
            雪佛兰,
            别克,
            丰田
        }

        /// <summary>
        /// 车辆手续
        /// </summary>
        public enum Procedure
        {
            有,
            无,
        }

        public enum Auto
        {
            自动,
            手动,
        }

        /// <summary>
        /// 买车还是卖车
        /// </summary>
        public enum BuyOrSell
        {
            买,
            卖,
        }

        /// <summary>
        /// 粮食类型
        /// </summary>
        public enum CerealsType
        {
            苞米,
            水稻,
            小麦,
            大麦,
            西瓜,
            其他农作物
        }

        public enum BossType
        {
            车主,
            货主,
        }

        /// <summary>
        /// 工作类型
        /// </summary>
        public enum WorkType
        {
            短工,
            长工,
            插秧,
            翻地,
            开车,
            拉粮,
            扣大棚
        }

        /// <summary>
        /// 性别要求
        /// </summary>
        public enum GenderRequired
        {
            男,
            女,
            男女不限
        }

        /// <summary>
        /// 性别
        /// </summary>
        public enum Gender
        {
            男,
            女
        }

        /// <summary>
        /// 年龄
        /// </summary>
        public enum AgeRequired
        {
            三十岁以下,
            四十岁以下,
            五十岁以下,
            六十岁以下,
            不限
        }

        /// <summary>
        /// 工作强度
        /// </summary>
        public enum WorkStrong
        {
            轻松,
            一般,
            很累
        }

        /// <summary>
        /// 结算方式
        /// </summary>
        public enum PayType
        {
            日结,
            月结
        }

        public enum DriverCarType
        {
            司机找车,
            车找司机
        }

        /// <summary>
        /// 驾照类型
        /// </summary>
        public enum DriverCardType
        {
            C1,
            C2,
            B1,
            B2,
            A1,
            A2,
            A3,
            无照
        }

        /// <summary>
        /// 拖拉机驾驶照类型
        /// </summary>
        public enum TljDriverCardType
        {
            G,
            H,
            K
        }

        /// <summary>
        /// 大车车型
        /// </summary>
        public enum BigCarType
        {
            卡车,
            拖拉机,
            小车,
        }
    }
}
