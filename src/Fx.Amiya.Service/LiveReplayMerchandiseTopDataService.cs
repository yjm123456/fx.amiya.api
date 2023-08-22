using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LiveReplayMerchandiseTopData.Input;
using Fx.Amiya.Dto.LiveReplayMerchandiseTopData.Result;
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
    public class LiveReplayMerchandiseTopDataService : ILiveReplayMerchandiseTopDataService
    {
        private readonly IDalLiveReplayMerchandiseTopData dalLiveReplyProductDealData;
        private IUnitOfWork unitOfWork;

        public LiveReplayMerchandiseTopDataService(IDalLiveReplayMerchandiseTopData dalLiveReplyProductDealData, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.dalLiveReplyProductDealData = dalLiveReplyProductDealData;
        }

        public async Task<List<LiveReplayMerchandiseTopDataInfoDto>> GetListAsync(QueryLiveReplayMerchandiseTopDataDto query)
        {
            List<LiveReplayMerchandiseTopDataInfoDto> LiveReplayMerchandiseTopDataInfoDtoList = new List<LiveReplayMerchandiseTopDataInfoDto>();
            var replayProductDealData = dalLiveReplyProductDealData.GetAll().Include(x=>x.ItemInfo)
                .Where(e => e.LiveReplayId == query.LiveReplayId)
                .Where(e => e.Valid == query.Valid)
                .Where(e => string.IsNullOrEmpty(query.KeyWord) || e.MerchandiseQuestion.Contains(query.KeyWord));
            LiveReplayMerchandiseTopDataInfoDtoList = await replayProductDealData.Select(e => new LiveReplayMerchandiseTopDataInfoDto
            {
                Id = e.Id,
                LiveReplayId = e.LiveReplayId,
                Sort = e.Sort,
                ItemId = e.ItemId,
                ItemName=e.ItemInfo.Name,
                Gmv = e.Gmv,
                MerchandiseShowNum = e.MerchandiseShowNum,
                MerchandiseVisitNum = e.MerchandiseVisitNum,
                MerchandiseShowVisitRate = e.MerchandiseShowVisitRate,
                MerchandiseCreateOrderNum = e.MerchandiseCreateOrderNum,
                MerchandiseVisitCreateOrderRate = e.MerchandiseVisitCreateOrderRate,
                MerchandiseDealNum = e.MerchandiseDealNum,
                MerchandiseCreateOrderDealRate = e.MerchandiseCreateOrderDealRate,
                MerchandiseQuestion = e.MerchandiseQuestion,
            }).OrderBy(e => e.Sort).ToListAsync();
            return LiveReplayMerchandiseTopDataInfoDtoList;
        }
        public async Task AddListAsync(List<AddLiveReplayMerchandiseTopDataDto> addDtoList)
        {
            unitOfWork.BeginTransaction();
            try
            {

                foreach (var addDto in addDtoList)
                {
                    LiveReplayMerchandiseTopData liveReplayMerchandiseTopData = new LiveReplayMerchandiseTopData();
                    liveReplayMerchandiseTopData.Id = Guid.NewGuid().ToString().Replace("-", "");
                    liveReplayMerchandiseTopData.LiveReplayId = addDto.LiveReplayId;
                    liveReplayMerchandiseTopData.ItemId = addDto.ItemId;
                    liveReplayMerchandiseTopData.Gmv = addDto.Gmv;
                    liveReplayMerchandiseTopData.MerchandiseShowNum = addDto.MerchandiseShowNum;
                    liveReplayMerchandiseTopData.MerchandiseVisitNum = addDto.MerchandiseVisitNum;
                    liveReplayMerchandiseTopData.MerchandiseShowVisitRate = addDto.MerchandiseShowVisitRate;
                    liveReplayMerchandiseTopData.MerchandiseCreateOrderNum = addDto.MerchandiseCreateOrderNum;
                    liveReplayMerchandiseTopData.MerchandiseVisitCreateOrderRate = addDto.MerchandiseVisitCreateOrderRate;
                    liveReplayMerchandiseTopData.MerchandiseDealNum = addDto.MerchandiseDealNum;
                    liveReplayMerchandiseTopData.MerchandiseCreateOrderDealRate = addDto.MerchandiseCreateOrderDealRate;
                    liveReplayMerchandiseTopData.MerchandiseQuestion = addDto.MerchandiseQuestion;
                    liveReplayMerchandiseTopData.Sort = addDto.Sort;
                    liveReplayMerchandiseTopData.CreateDate = DateTime.Now;
                    liveReplayMerchandiseTopData.Valid = true;
                    await dalLiveReplyProductDealData.AddAsync(liveReplayMerchandiseTopData, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception("更新单品TOP10数据时发生错误，请联系管理员！");
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
                throw new Exception("移除单品TOP10数据时发生错误，请联系管理员！");
            }
        }
    }
}
