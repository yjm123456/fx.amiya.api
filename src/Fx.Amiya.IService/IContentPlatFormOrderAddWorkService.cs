using Fx.Amiya.Dto.AmiyaLessonApply;
using Fx.Amiya.Dto.ContentPlatFormOrderAddWork;
using Fx.Amiya.Dto.ContentPlatFormOrderAddWork.Input;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IContentPlatFormOrderAddWorkService
    {
        Task<FxPageInfo<ContentPlatFormOrderAddWorkDto>> GetListByPageAsync(QueryContentPlatFormOrderAddWorkPageDto query);
        Task AddAsync(AddContentPlatFormOrderAddWorkDto addDto);
        Task<ContentPlatFormOrderAddWorkDto> GetByIdAsync(string id);

        Task<ContentPlatFormOrderAddWorkDto> GetByPhoneAsync(string phone);
        Task UpdateAsync(UpdateContentPlatFormOrderAddWorkDto updateContentPlatFormOrderAddWorkDto);

        Task UpdateAcceptByAsync(UpdateAcceptByDto updateAcceptByDto);
        /// <summary>
        /// 审核录单申请工单
        /// </summary>
        /// <param name="updateContentPlatFormOrderAddWorkDto"></param>
        /// <returns></returns>
        Task CheckAsync(CheckContentPlatFormOrderAddWorkDto updateContentPlatFormOrderAddWorkDto);
        Task DeleteAsync(List<string> idList);
    }
}
