using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LiveReplayFlowOptimize.Input;
using Fx.Amiya.Dto.LiveReplayFlowOptimize.Result;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class LiveReplayFlowOptimizeService : ILiveReplayFlowOptimizeService
    {
        private readonly IDalLiveReplayFlowOptimize dalLiveReplayFlowOptimize;
        private readonly IUnitOfWork unitOfWork;
        public LiveReplayFlowOptimizeService(IDalLiveReplayFlowOptimize dalLiveReplayFlowOptimize, IUnitOfWork unitOfWork)
        {
            this.dalLiveReplayFlowOptimize = dalLiveReplayFlowOptimize;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddListAsync(List<AddLiveReplayFlowOptimizeDataDto> addDtoList)
        {
            unitOfWork.BeginTransaction();
            try
            {

                foreach (var addDto in addDtoList)
                {
                    LiveReplayFlowOptimize liveReplayFlowOptimizeData = new LiveReplayFlowOptimize();
                    liveReplayFlowOptimizeData.Id = Guid.NewGuid().ToString().Replace("-", "");
                    liveReplayFlowOptimizeData.LiveReplayId = addDto.LiveReplayId;
                    liveReplayFlowOptimizeData.FlowSource = addDto.FlowSource;
                    liveReplayFlowOptimizeData.Proportion = addDto.Proportion;
                    liveReplayFlowOptimizeData.DrainageCount = addDto.DrainageCount;
                    liveReplayFlowOptimizeData.LastDrainageCount = addDto.LastDrainageCount;
                    liveReplayFlowOptimizeData.LastDrainageProportion = addDto.LastDrainageProportion;
                    liveReplayFlowOptimizeData.ProblemAnalysis = addDto.ProblemAnalysis;
                    liveReplayFlowOptimizeData.LaterSolution = addDto.LaterSolution;
                    liveReplayFlowOptimizeData.Sort = addDto.Sort;
                    liveReplayFlowOptimizeData.CreateDate = DateTime.Now;
                    liveReplayFlowOptimizeData.Valid = true;
                    await dalLiveReplayFlowOptimize.AddAsync(liveReplayFlowOptimizeData, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception("更新成交数据时发生错误，请联系管理员！");
            }
        }

        public async Task DeleteByIdListAsync(string liveReplayId)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var result = await dalLiveReplayFlowOptimize.GetAll().Where(x => x.LiveReplayId == liveReplayId).ToListAsync();
                foreach (var x in result)
                {
                    x.Valid = false;
                    x.DeleteDate = DateTime.Now;
                    await dalLiveReplayFlowOptimize.UpdateAsync(x, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception("移除成交数据时发生错误，请联系管理员！");
            }
        }

        public async Task<List<LiveReplayFlowOptimizeDataInfoDto>> GetListAsync(QueryLiveReplayFlowOptimizeDataDto query)
        {
            List<LiveReplayFlowOptimizeDataInfoDto> LiveReplayFlowOptimizeDataInfoDtoList = new List<LiveReplayFlowOptimizeDataInfoDto>();
            var replayFlowOptimizeData = dalLiveReplayFlowOptimize.GetAll()
                .Where(e => e.LiveReplayId == query.LiveReplayId)
                .Where(e => e.Valid == query.Valid)
                .Where(e => string.IsNullOrEmpty(query.KeyWord) || e.FlowSource.Contains(query.KeyWord) || e.ProblemAnalysis.Contains(query.KeyWord) || e.LaterSolution.Contains(query.KeyWord));
            LiveReplayFlowOptimizeDataInfoDtoList = await replayFlowOptimizeData.Select(e => new LiveReplayFlowOptimizeDataInfoDto
            {
                Id = e.Id,
                LiveReplayId = e.LiveReplayId,
                FlowSource = e.FlowSource,
                Proportion = e.Proportion,
                DrainageCount = e.DrainageCount,
                LastDrainageCount = e.LastDrainageCount,
                ProblemAnalysis = e.ProblemAnalysis,
                LastDrainageProportion = e.LastDrainageProportion,
                LaterSolution = e.LaterSolution,
                Sort = e.Sort,
            }).OrderBy(e => e.Sort).ToListAsync();
            return LiveReplayFlowOptimizeDataInfoDtoList;
        }
    }
}
