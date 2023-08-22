using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LiveReplayInteractionlData.Input;
using Fx.Amiya.Dto.LiveReplayInteractionlData.Result;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class LiveReplayInteractionlDataService : ILiveReplayInteractionlDataService
    {
        private readonly IDalLiveReplayInteractionlData dalLiveReplyProductDealData;
        private IUnitOfWork unitOfWork;

        public LiveReplayInteractionlDataService(IDalLiveReplayInteractionlData dalLiveReplyProductDealData, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.dalLiveReplyProductDealData = dalLiveReplyProductDealData;
        }

        public async Task<List<LiveReplayInteractionlDataInfoDto>> GetListAsync(QueryLiveReplayInteractionlDataDto query)
        {
            List<LiveReplayInteractionlDataInfoDto> LiveReplayInteractionlDataInfoDtoList = new List<LiveReplayInteractionlDataInfoDto>();
            var replayProductDealData = dalLiveReplyProductDealData.GetAll()
                .Where(e => e.LiveReplayId == query.LiveReplayId)
                .Where(e => e.Valid == query.Valid)
                .Where(e => string.IsNullOrEmpty(query.KeyWord) || e.ReplayTarget.Contains(query.KeyWord) || e.QuestionAnalize.Contains(query.KeyWord) || e.LaterPeriodSolution.Contains(query.KeyWord));
            LiveReplayInteractionlDataInfoDtoList = await replayProductDealData.Select(e => new LiveReplayInteractionlDataInfoDto
            {
                Id = e.Id,
                LiveReplayId = e.LiveReplayId,
                ReplayTarget = e.ReplayTarget,
                DataTarget = e.DataTarget,
                LastLivingData = e.LastLivingData,
                LastLivingCompare = e.LastLivingCompare,
                QuestionAnalize = e.QuestionAnalize,
                LaterPeriodSolution = e.LaterPeriodSolution,
                Sort = e.Sort,
            }).OrderBy(e => e.Sort).ToListAsync();
            return LiveReplayInteractionlDataInfoDtoList;
        }
        public async Task AddListAsync(List<AddLiveReplayInteractionlDataDto> addDtoList)
        {
            unitOfWork.BeginTransaction();
            try
            {

                foreach (var addDto in addDtoList)
                {
                    LiveReplayInteractionlData liveReplayInteractionlData = new LiveReplayInteractionlData();
                    liveReplayInteractionlData.Id = Guid.NewGuid().ToString().Replace("-", "");
                    liveReplayInteractionlData.LiveReplayId = addDto.LiveReplayId;
                    liveReplayInteractionlData.ReplayTarget = addDto.ReplayTarget;
                    liveReplayInteractionlData.DataTarget = addDto.DataTarget;
                    liveReplayInteractionlData.LastLivingData = addDto.LastLivingData;
                    liveReplayInteractionlData.LastLivingCompare = addDto.LastLivingCompare;
                    liveReplayInteractionlData.QuestionAnalize = addDto.QuestionAnalize;
                    liveReplayInteractionlData.LaterPeriodSolution = addDto.LaterPeriodSolution;
                    liveReplayInteractionlData.Sort = addDto.Sort;
                    liveReplayInteractionlData.CreateDate = DateTime.Now;
                    liveReplayInteractionlData.Valid = true;
                    await dalLiveReplyProductDealData.AddAsync(liveReplayInteractionlData, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception("更新互动数据时发生错误，请联系管理员！");
            }
        }
        public async Task DeleteByIdListAsync(string liveReplayId)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var result = await dalLiveReplyProductDealData.GetAll().Where(x => x.LiveReplayId == liveReplayId).ToListAsync();
                foreach (var x in result)
                {
                    x.Valid = false;
                    x.DeleteDate = DateTime.Now;
                    await dalLiveReplyProductDealData.UpdateAsync(x, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception("移除互动数据时发生错误，请联系管理员！");
            }
        }
    }
}
