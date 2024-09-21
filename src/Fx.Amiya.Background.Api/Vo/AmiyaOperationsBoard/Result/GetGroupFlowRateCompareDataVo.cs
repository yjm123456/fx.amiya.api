using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    /// <summary>
    /// 流量分析占比展示
    /// </summary>
    public class GetGroupFlowRateCompareDataVo
    {

        /// <summary>
        /// 整体流量分析
        /// </summary>
        public OperationBoardContentPlatFormDataVo TotalFlowRateByContentPlatForm { get; set; }
        /// <summary>
        /// 刀刀组流量分析
        /// </summary>
        public OperationBoardContentPlatFormDataVo GroupDaoDaoFlowRateByContentPlatForm { get; set; }
        /// <summary>
        /// 吉娜组流量分析
        /// </summary>
        public OperationBoardContentPlatFormDataVo GroupJiNaFlowRateByContentPlatForm { get; set; }


        /// <summary>
        /// 整体部门分析
        /// </summary>
        public OperationBoardDepartmentDataVo TotalFlowRateByDepartment { get; set; }
        /// <summary>
        /// 刀刀组部门分析
        /// </summary>
        public OperationBoardDepartmentDataVo GroupDaoDaoFlowRateByDepartment { get; set; }
        /// <summary>
        /// 吉娜组部门分析
        /// </summary>
        public OperationBoardDepartmentDataVo GroupJiNaFlowRateByDepartment { get; set; }


        /// <summary>
        /// 分组流量分析-总线索
        /// </summary>
        public decimal TotalFlowRate { get; set; }
        /// <summary>
        /// 刀刀组线索分析
        /// </summary>
        public decimal GroupDaoDaoFlowRate { get; set; }
        /// <summary>
        /// 吉娜组线索分析
        /// </summary>
        public decimal GroupJiNaFlowRate { get; set; }



        /// <summary>
        /// 整体有效/潜在分析
        /// </summary>
        public OperationBoardIsEffictiveDataVo TotalFlowRateByIsEffictive { get; set; }
        /// <summary>
        /// 刀刀组有效/潜在分析
        /// </summary>
        public OperationBoardIsEffictiveDataVo GroupDaoDaoFlowRateByIsEffictive { get; set; }
        /// <summary>
        /// 吉娜组有效/潜在分析
        /// </summary>
        public OperationBoardIsEffictiveDataVo GroupJiNaFlowRateByIsEffictive { get; set; }


    }

    public class OperationBoardContentPlatFormDataVo
    {
        /// <summary>
        /// 抖音（占比）
        /// </summary>
        public decimal? DouYinRate { get; set; }
        /// <summary>
        /// 视频号（占比）
        /// </summary>
        public decimal? VideoNumberRate { get; set; }

        /// <summary>
        /// 小红书（占比）
        /// </summary>
        public decimal? XiaoHongShuRate { get; set; }

        /// <summary>
        /// 私域（占比）
        /// </summary>
        public decimal? PrivateDataRate { get; set; }
        /// <summary>
        /// 抖音（数值）
        /// </summary>
        public decimal? DouYinNumber { get; set; }
        /// <summary>
        /// 视频号（数值）
        /// </summary>
        public decimal? VideoNumberNumber { get; set; }

        /// <summary>
        /// 小红书（数值）
        /// </summary>
        public decimal? XiaoHongShuNumber { get; set; }

        /// <summary>
        /// 私域（数值）
        /// </summary>
        public decimal? PrivateDataNumber { get; set; }
        /// <summary>
        /// 总线索量
        /// </summary>
        public decimal? TotalFlowRateNumber { get; set; }
    }

    public class OperationBoardDepartmentDataVo
    {
        /// <summary>
        /// 直播前（占比）
        /// </summary>
        public decimal? BeforeLivingRate { get; set; }
        /// <summary>
        /// 直播中（占比）
        /// </summary>
        public decimal? LivingRate { get; set; }

        /// <summary>
        /// 直播后（占比）
        /// </summary>
        public decimal? AftereLivingRate { get; set; }

        /// <summary>
        /// 其他（占比）
        /// </summary>
        public decimal? OtherRate { get; set; }
        /// <summary>
        /// 直播前（数值）
        /// </summary>
        public decimal? BeforeLivingNumber { get; set; }
        /// <summary>
        /// 直播中（数值）
        /// </summary>
        public decimal? LivingNumber { get; set; }

        /// <summary>
        /// 直播后（数值）
        /// </summary>
        public decimal? AfterLivingNumber { get; set; }

        /// <summary>
        /// 其他（数值）
        /// </summary>
        public decimal? OtherNumber { get; set; }
        /// <summary>
        /// 总线索量
        /// </summary>
        public decimal? TotalFlowRateNumber { get; set; }
    }

    public class OperationBoardIsEffictiveDataVo
    {
        /// <summary>
        /// 有效（占比）
        /// </summary>
        public decimal? EffictiveRate { get; set; }
        /// <summary>
        /// 潜在（占比）
        /// </summary>
        public decimal? NotEffictiveRate { get; set; }
        /// <summary>
        /// 有效（数值）
        /// </summary>
        public decimal? EffictiveNumber { get; set; }
        /// <summary>
        /// 潜在（数值）
        /// </summary>
        public decimal? NotEffictiveNumber { get; set; }
        /// <summary>
        /// 总线索量
        /// </summary>
        public decimal? TotalFlowRateNumber { get; set; }
    }

}

