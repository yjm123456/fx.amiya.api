using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LiveReplayProductDealData.Input;
using Fx.Amiya.Dto.LiveReplayProductDealData.Result;
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
    public class LiveReplayProductDealDataService : ILiveReplayProductDealDataService
    {
        private readonly IDalLiveReplayProductDealData dalLiveReplyProductDealData;
        private IUnitOfWork unitOfWork;

        public LiveReplayProductDealDataService(IDalLiveReplayProductDealData dalLiveReplyProductDealData, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.dalLiveReplyProductDealData = dalLiveReplyProductDealData;
        }

        public async Task<List<LiveReplayProductDealDataInfoDto>> GetListAsync(QueryLiveReplayProductDealDataDto query)
        {
            List<LiveReplayProductDealDataInfoDto> fxPageInfo = new List<LiveReplayProductDealDataInfoDto>();
            var replay = dalLiveReplyProductDealData.GetAll()
                .Where(e => e.LiveReplayId == query.LiveReplayId)
                .Where(e => e.Valid == query.Valid)
                .Where(e => string.IsNullOrEmpty(query.KeyWord) || e.ReplayTarget.Contains(query.KeyWord) || e.QuestionAnalize.Contains(query.KeyWord) || e.LaterPeriodSolution.Contains(query.KeyWord));
            fxPageInfo = await replay.Select(e => new LiveReplayProductDealDataInfoDto
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
            }).OrderByDescending(e => e.Sort).Skip((query.PageSize.Value - 1) * query.PageNum.Value).Take(query.PageSize.Value).ToListAsync();
            return fxPageInfo;
        }
        public async Task AddListAsync(List<AddLiveReplayProductDealDataDto> addDtoList)
        {
            unitOfWork.BeginTransaction();
            try
            {

                foreach (var addDto in addDtoList)
                {
                    LiveReplayProductDealData liveReplayProductDealData = new LiveReplayProductDealData();
                    liveReplayProductDealData.Id = Guid.NewGuid().ToString().Replace("-", "");
                    liveReplayProductDealData.LiveReplayId = addDto.LiveReplayId;
                    liveReplayProductDealData.ReplayTarget = addDto.ReplayTarget;
                    liveReplayProductDealData.DataTarget = addDto.DataTarget;
                    liveReplayProductDealData.LastLivingData = addDto.LastLivingData;
                    liveReplayProductDealData.LastLivingCompare = addDto.LastLivingCompare;
                    liveReplayProductDealData.QuestionAnalize = addDto.QuestionAnalize;
                    liveReplayProductDealData.LaterPeriodSolution = addDto.LaterPeriodSolution;
                    liveReplayProductDealData.Sort = addDto.Sort;
                    liveReplayProductDealData.CreateDate = DateTime.Now;
                    liveReplayProductDealData.Valid = true;
                    await dalLiveReplyProductDealData.AddAsync(liveReplayProductDealData, true);
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
                throw new Exception("移除成交数据时发生错误，请联系管理员！");
            }
        }
    }
}
