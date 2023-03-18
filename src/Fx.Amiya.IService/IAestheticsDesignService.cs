using Fx.Amiya.Dto.AestheticsDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAestheticsDesignService
    {
        /// <summary>
        /// 添加美学设计
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAestheticsDesignAsync(AddAestheticsDesignDto addDto);
        /// <summary>
        /// 根据美学报告获取美学设计信息
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        Task<AestheticsDesignInfoDto> GetByReportIdAsync(string reportId);
        
    }
}
