using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.AestheticsDesignReport.Output
{
    /// <summary>
    /// 美学设计报告列表展示类
    /// </summary>
    public class AestheticsDesignReportSimpleInfoVo
    {
        /// <summary>
        /// 美学设计报告编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 正面图片
        /// </summary>
        public string FrontPicture { get; set; }
        /// <summary>
        /// 侧面图片
        /// </summary>
        public string SidePicture { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 状态文本
        /// </summary>
        public string StatusText { get; set; }
    }
}
