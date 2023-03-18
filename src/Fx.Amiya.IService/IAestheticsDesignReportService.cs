using Fx.Amiya.Dto.AestheticsDesignReport;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAestheticsDesignReportService
    {
        /// <summary>
        /// 添加美学报告
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAestheticsDesignReportAsync(AddAestheticsDesignReportDto addDto);
        /// <summary>
        /// 根据id获取美学报告信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AestheticsDesignReportInfoDto> GetById(string id);
        /// <summary>
        /// 获取美学报告列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="designed">是否完成美学设计</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<AestheticsDesignReportInfoDto>> GetListByPage(string customerId,int? designed,int pageNum,int pageSize);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task DeleteAsync(string id,string customerId);
        /// <summary>
        /// 修改美学报告信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateAestheticsDesignReportInfoDto updateDto);




             


    }
}
