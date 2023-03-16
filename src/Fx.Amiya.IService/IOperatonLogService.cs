using Fx.Amiya.Dto;
using Fx.Amiya.Dto.OperationLog;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IOperatonLogService
    {
        /// <summary>
        /// 添加操作日志
        /// </summary>
        /// <param name="operationAdd"></param>
        /// <returns></returns>
        Task AddOperationLogAsync(OperationAddDto operationAdd);
        /// <summary>
        /// 获取操作日志
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>

        Task<FxPageInfo<OperationLogInfoDto>> GetListByPageAsync(OperationLogSearchDto searchDto);
        /// <summary>
        /// 获取请求类型名称列表
        /// </summary>
        /// <returns></returns>

        List<BaseKeyValueDto<int>> GetRequestTypeNameList();
    }
}
