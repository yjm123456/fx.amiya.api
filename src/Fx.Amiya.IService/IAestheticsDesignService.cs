using Fx.Amiya.Dto.AestheticsDesign;
using Fx.Amiya.Dto.AestheticsDesignReport;
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
        /// <summary>
        /// 添加图片标签
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAestheticsDesignPictureTagAsync(AddFaceTagDto addDto);
        /// <summary>
        /// 修改美学设计
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAestheticsDesignAsync(UpdateAestheticsDesgnDto updateDto);


    }
}
