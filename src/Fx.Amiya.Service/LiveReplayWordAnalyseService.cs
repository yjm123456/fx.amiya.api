using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LiveReplayWordAnalyse.Input;
using Fx.Amiya.Dto.LiveReplayWordAnalyse.Result;
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
    public class LiveReplayWordAnalyseService : ILiveReplayWordAnalyseService
    {
        private readonly IDalLiveReplayWordAnalyse dalLiveReplayWordAnalyse;
        private readonly IUnitOfWork unitOfWork;

        public LiveReplayWordAnalyseService(IDalLiveReplayWordAnalyse dalLiveReplayWordAnalyse, IUnitOfWork unitOfWork)
        {
            this.dalLiveReplayWordAnalyse = dalLiveReplayWordAnalyse;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddListAsync(List<AddLiveReplayWordAnalyseDataDto> addDtoList)
        {
            unitOfWork.BeginTransaction();
            try
            {

                foreach (var addDto in addDtoList)
                {
                    LiveReplayWordAnalyse liveReplayWordAnalyseData = new LiveReplayWordAnalyse();
                    liveReplayWordAnalyseData.Id = Guid.NewGuid().ToString().Replace("-", "");
                    liveReplayWordAnalyseData.LiveReplayId = addDto.LiveReplayId;
                    liveReplayWordAnalyseData.ReplayContent = addDto.ReplayContent;
                    liveReplayWordAnalyseData.WordManifestation = addDto.WordManifestation;
                    liveReplayWordAnalyseData.ProblemAnalysis = addDto.ProblemAnalysis;
                    liveReplayWordAnalyseData.LaterSolution = addDto.LaterSolution;
                    liveReplayWordAnalyseData.Sort = addDto.Sort;
                    liveReplayWordAnalyseData.CreateDate = DateTime.Now;
                    liveReplayWordAnalyseData.Valid = true;
                    await dalLiveReplayWordAnalyse.AddAsync(liveReplayWordAnalyseData, true);
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
                var result = await dalLiveReplayWordAnalyse.GetAll().Where(x => x.LiveReplayId == liveReplayId).ToListAsync();
                foreach (var x in result)
                {
                    x.Valid = false;
                    x.DeleteDate = DateTime.Now;
                    await dalLiveReplayWordAnalyse.UpdateAsync(x, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception("移除成交数据时发生错误，请联系管理员！");
            }
        }

        public async Task<List<LiveReplayWordAnalyseDataInfoDto>> GetListAsync(QueryLiveReplayWordAnalyseDataDto query)
        {
            List<LiveReplayWordAnalyseDataInfoDto> LiveReplayWordAnalyseDataInfoDtoList = new List<LiveReplayWordAnalyseDataInfoDto>();
            var replayWordAnalyseData = dalLiveReplayWordAnalyse.GetAll()
                .Where(e => e.LiveReplayId == query.LiveReplayId)
                .Where(e => e.Valid == query.Valid)
                .Where(e => string.IsNullOrEmpty(query.KeyWord) || e.ReplayContent.Contains(query.KeyWord) || e.ProblemAnalysis.Contains(query.KeyWord) || e.LaterSolution.Contains(query.KeyWord) ||e.WordManifestation.Contains(query.KeyWord));
            LiveReplayWordAnalyseDataInfoDtoList = await replayWordAnalyseData.Select(e => new LiveReplayWordAnalyseDataInfoDto
            {
                Id = e.Id,
                LiveReplayId = e.LiveReplayId,
                ReplayContent = e.ReplayContent,
                WordManifestation = e.WordManifestation,
                ProblemAnalysis = e.ProblemAnalysis,
                LaterSolution = e.LaterSolution,
                Sort = e.Sort,
            }).OrderBy(e => e.Sort).ToListAsync();
            return LiveReplayWordAnalyseDataInfoDtoList;
        }
    }
}
