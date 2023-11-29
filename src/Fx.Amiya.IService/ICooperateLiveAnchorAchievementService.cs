
using Fx.Amiya.Dto.CooperateLiveAnchorAchievement;
using Fx.Amiya.Dto.CooperateLiveAnchorAchievement.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ICooperateLiveAnchorAchievementService
    {
        Task<List<CooperateLiveAnchorAchievementDto>> GetCooperateLiveAnchorAchievementAsync(DateTime checkDate);
        Task<List<CooperateLiveAnchorHospitalAchievementDto>> GetCooperateLiveAnchorHospitalAchieementsAsync(DateTime checkDate);
    }
}
