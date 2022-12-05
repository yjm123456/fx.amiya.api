using Fx.Amiya.Dto.GrowthPoints;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.GrowthPoints;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
    public class GrowthPointsAccountController : ControllerBase
    {
        private readonly IGrowthPointsAccountService growthPointsAccountService;
        private readonly IGrowthPointsRecordService growthPointsRecordService;
        private TokenReader _tokenReader;
        private IMiniSessionStorage _sessionStorage;
        private readonly IMemberCardService memberCardService;


        public GrowthPointsAccountController(IGrowthPointsAccountService growthPointsAccountService, IGrowthPointsRecordService growthPointsRecordService, TokenReader tokenReader, IMiniSessionStorage sessionStorage, IMemberCardService memberCardService)
        {
            this.growthPointsAccountService = growthPointsAccountService;
            this.growthPointsRecordService = growthPointsRecordService;
            _tokenReader = tokenReader;
            _sessionStorage = sessionStorage;
            this.memberCardService = memberCardService;
        }
        /// <summary>
        /// 获取用户成长值
        /// </summary>
        /// <returns></returns>
        [HttpGet("balance")]
        public async Task<ResultData<GrowthPointsVo>> GetGrowthPointsAccount() {
            GrowthPointsVo pointsVo = new GrowthPointsVo();
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var balance = await growthPointsAccountService.GetGrowthPointAccountByCustomerId(customerId);
            
            if (balance==null) {
                CreateGrowthPointsAccountDto createGrowth = new CreateGrowthPointsAccountDto
                {
                    CustomerId = customerId,
                    Balance=0m
                };
                await growthPointsAccountService.AddAsync(createGrowth);
            }
            var upgrade = await memberCardService.GetUpgradeInfoAsync(balance.Balance,customerId);
            pointsVo.Balance = balance.Balance;
            pointsVo.UpgradeGrowthPoints = upgrade.UpgardeNeedGrowthPoints;
            pointsVo.NextLeaveText = upgrade.NextLeaveText;
            return ResultData<GrowthPointsVo>.Success().AddData("growthBalanceInfo",pointsVo);
        }
        /// <summary>
        /// 分页获取用户成长值记录列表
        /// </summary>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<GrowthPointsInfoListVo>>> GetGrowthPointsRecordList(int pageNum,int pageSize=10) {
            FxPageInfo<GrowthPointsInfoListVo> pageInfo = new FxPageInfo<GrowthPointsInfoListVo>();
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var result = await growthPointsRecordService.GetGrowthPointsRecordListPageByCustomerId(customerId,pageNum,pageSize);
            pageInfo.TotalCount = result.TotalCount;
            pageInfo.List=result.List.Select(s => new GrowthPointsInfoListVo
            {
                IsExpire = s.IsExpire,
                ExpireDate = s.ExpireDate,
                Quantity = s.Quantity,
                CreateDate = s.CreateDate,
                Type = s.Type
            });
            return ResultData<FxPageInfo<GrowthPointsInfoListVo>>.Success().AddData("growthpointslist",pageInfo);
            
        }
    }
}
