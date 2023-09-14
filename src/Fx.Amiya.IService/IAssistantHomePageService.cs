using Fx.Amiya.Dto.AssistantHomePage.Input;
using Fx.Amiya.Dto.AssistantHomePage.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAssistantHomePageService
    {
        Task<MonthPerformanceCompleteSituationDataDto> GetMonthPerformanceCompleteSituationDataAsync(QueryAssistantHomePageDataDto query);
    }
}
