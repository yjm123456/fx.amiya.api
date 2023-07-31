using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TakeGoods
{
    public class GMVDataDto
    {
        /// <summary>
        /// 下单gmv
        /// </summary>
        public decimal OrderGmv { get; set; }
        /// <summary>
        /// 下单gmv目标完成率
        /// </summary>
        public decimal OrderGmvCompleteRate { get; set; }
        /// <summary>
        /// 下单GMV环比
        /// </summary>
        public decimal OrderGMVChainRatio { get; set; }
        /// <summary>
        /// 下单GMV同比
        /// </summary>
        public decimal OrderGMVYearOnYear { get; set; }
        /// <summary>
        /// 下单gmv对比时间进度
        /// </summary>
        public decimal OrderGMVToDateSchedule { get; set; }
        /// <summary>
        /// 下单gmv对比时间进度偏差
        /// </summary>
        public decimal OrderGMVDeviation { get; set; }
        /// <summary>
        /// 下单gmv距目标达成后期每天需完成
        /// </summary>
        public decimal LaterCompleteEveryDayOrderGMV { get; set; }
        /// <summary>
        /// 千川投放金额
        /// </summary>
        public decimal QianChuanPutIn{ get; set; }
        /// <summary>
        /// 千川投放金额完成率
        /// </summary>
        public decimal QianChuanPutInCompleteRate { get; set; }
        /// <summary>
        /// 千川投放金额环比
        /// </summary>
        public decimal QianChuanPutInChainRatio { get; set; }
        /// <summary>
        /// 千川投放金额同比
        /// </summary>
        public decimal QianChuanPutInYearOnYear { get; set; }
        /// <summary>
        /// 千川投流对比时间进度
        /// </summary>
        public decimal QianChuanToDateSchedule { get; set; }
        /// <summary>
        /// 千川投流对比时间进度偏差
        /// </summary>
        public decimal QianChuanDeviation { get; set; }
        /// <summary>
        /// 千川投流距目标达成后期每天需完成
        /// </summary>
        public decimal LaterCompleteEveryDayQianChuan { get; set; }
        /// <summary>
        /// 刀刀下单gmv
        /// </summary>
        public decimal DaoDaoOrderGmv { get; set; }
        /// <summary>
        /// 刀刀下单gmv完成率
        /// </summary>
        public decimal DaoDaoOrderGmvCompleteRate { get; set; }
        /// <summary>
        /// 刀刀下单gmv环比
        /// </summary>
        public decimal DaoDaoOrderGMVChainRatio { get; set; }
        /// <summary>
        /// 刀刀下单gmv同比
        /// </summary>
        public decimal DaoDaoOrderGMVYearOnYear { get; set; }
        /// <summary>
        /// 刀刀组gmv占比
        /// </summary>
        public decimal DaoDaoGMVProportion { get; set; }
        /// <summary>
        /// 刀刀组下单gmv对比时间进度
        /// </summary>
        public decimal DaoDaoOrderGMVToDateSchedule { get; set; }
        /// <summary>
        /// 刀刀组下单gmv对比时间进度偏差
        /// </summary>
        public decimal DaoDaoOrderGMVDeviation { get; set; }
        /// <summary>
        /// 刀刀组下单gmv距目标达成后期每天需完成
        /// </summary>
        public decimal LaterCompleteEveryDayDaoDaoOrderGMV { get; set; }

        /// <summary>
        /// 吉娜下单gmv
        /// </summary>
        public decimal JiNaOrderGmv { get; set; }
        /// <summary>
        /// 吉娜下单gmv完成率
        /// </summary>
        public decimal JiNaOrderGmvCompleteRate { get; set; }
        /// <summary>
        /// 吉娜下单gmv环比
        /// </summary>
        public decimal JiNaOrderGMVChainRatio { get; set; }
        /// <summary>
        /// 吉娜下单gmv同比
        /// </summary>
        public decimal JiNaOrderGMVYearOnYear { get; set; }
        /// <summary>
        /// 吉娜组gmv占比
        /// </summary>
        public decimal JinaGMVProportion { get; set; }
        /// <summary>
        /// 吉娜组下单gmv对比时间进度
        /// </summary>
        public decimal JinaOrderGMVToDateSchedule { get; set; }
        /// <summary>
        /// 吉娜组下单gmv对比时间进度偏差
        /// </summary>
        public decimal JinaOrderGMVDeviation { get; set; }
        /// <summary>
        /// 吉娜组下单gmv距目标达成后期每天需完成
        /// </summary>
        public decimal LaterCompleteEveryDayJInaOrderGMV { get; set; }
        /// <summary>
        /// 退款gmv
        /// </summary>
        public decimal RefunGMV { get; set; }
        /// <summary>
        /// 退款gmv完成率
        /// </summary>
        public decimal RefunGMVCompleteRate { get; set; }
        /// <summary>
        /// 退款gmv环比
        /// </summary>
        public decimal RefunGMVChainRatio { get; set; }
        /// <summary>
        /// 退款gmv同比
        /// </summary>
        public decimal RefunGMVYearOnYear { get; set; }
    }
}
