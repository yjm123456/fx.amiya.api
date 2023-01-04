
using Fx.Amiya.Background.Api.Vo.MemberRankInfo;
using Fx.Amiya.Core.Dto.MemberCard;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
     [FxInternalAuthorize]
    public class MemberRankInfoController : ControllerBase
    {
        private IMemberRankInfo memberRankInfoService;
        public MemberRankInfoController(IMemberRankInfo memberRankInfoService)
        {
            this.memberRankInfoService = memberRankInfoService;
        }


        /// <summary>
        /// 添加会员等级
        /// </summary>
        /// <param name="memberRankInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddMemberRankInfoAsync(MemberRankInfoAddVo memberRankInfo)
        {
            MemberRankInfoAddDto memberRankInfoAddDto = new MemberRankInfoAddDto()
            {
                Name = memberRankInfo.Name,
                MinAmount = memberRankInfo.MinAmount, 
                MaxAmount = memberRankInfo.MaxAmount,
                Sconto = memberRankInfo.Sconto,
                GenerateIntegrationPercent = memberRankInfo.GenerateIntegrationPercent,
                ReferralsIntegrationPercent = memberRankInfo.ReferralsIntegrationPercent,
                Description = memberRankInfo.Description,
                Default = memberRankInfo.Default,
                ImageUrl = memberRankInfo.ImageUrl,
                RankCode = memberRankInfo.RankCode,
            };
            await memberRankInfoService.AddMemberRankInfoAsync(memberRankInfoAddDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 修改会员等级
        /// </summary>
        /// <param name="memberRankInfo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateMemberRankInfoAsync(MemberRankInfoUpdateVo memberRankInfo)
        {
            MemberRankInfoUpdateDto memberRankInfoUpdateDto = new MemberRankInfoUpdateDto()
            {
                ID = memberRankInfo.ID,
                Name = memberRankInfo.Name,
                MinAmount = memberRankInfo.MinAmount,
                MaxAmount = memberRankInfo.MaxAmount,
                Sconto = memberRankInfo.Sconto,
                GenerateIntegrationPercent = memberRankInfo.GenerateIntegrationPercent,
                ReferralsIntegrationPercent = memberRankInfo.ReferralsIntegrationPercent,
                Description = memberRankInfo.Description,
                Default = memberRankInfo.Default,
                ImageUrl = memberRankInfo.ImageUrl,
                RankCode = memberRankInfo.RankCode,
                Valid= memberRankInfo.Valid
            };
            await memberRankInfoService.UpdateMemberRankInfoAsync(memberRankInfoUpdateDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 根据编号获取会员等级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ResultData<MemberRankInfoVo>> GetMemberRankInfoByIDAsync(int id)
        {
            var memberRankInfo = await memberRankInfoService.GetMemberRankInfoByIDAsync(id);
            MemberRankInfoVo memberRank = new MemberRankInfoVo()
            { 
                ID=memberRankInfo.ID,
                Name= memberRankInfo.Name,
                MinAmount= memberRankInfo.MinAmount,
                MaxAmount= memberRankInfo.MaxAmount,
                Sconto= memberRankInfo.Sconto,
                GenerateIntegrationPercent= memberRankInfo.GenerateIntegrationPercent,
                ReferralsIntegrationPercent= memberRankInfo.ReferralsIntegrationPercent,
                Description= memberRankInfo.Description,
                Default= memberRankInfo.Default,
                ImageUrl= memberRankInfo.ImageUrl,
                RankCode= memberRankInfo.RankCode,
                Valid= memberRankInfo.Valid
            };
            return ResultData<MemberRankInfoVo>.Success().AddData("memberRankInfo", memberRank);
        }


        /// <summary>
        /// 获取所有会员等级
        /// </summary>
        /// <returns></returns>
       [HttpGet("list")]
        public async Task<ResultData<List<MemberRankInfoVo>>> GetMemberRankInfosAsync()
        {
            var memberRankInfos = from d in await memberRankInfoService.GetMemberRankInfosAsync()
                                  select new MemberRankInfoVo
                                  { 
                                    ID=d.ID,
                                    Name=d.Name,
                                    MinAmount=d.MinAmount,
                                    MaxAmount=d.MaxAmount,
                                    Sconto=d.Sconto,
                                    GenerateIntegrationPercent=d.GenerateIntegrationPercent,
                                    ReferralsIntegrationPercent=d.ReferralsIntegrationPercent,
                                    Description=d.Description,
                                    Default=d.Default,
                                    ImageUrl=d.ImageUrl,
                                    RankCode=d.RankCode,
                                    Valid=d.Valid
                                  };
            return ResultData<List<MemberRankInfoVo>>.Success().AddData("memberRankInfos",memberRankInfos.ToList());
        }



        /// <summary>
        /// 获取会员卡级别名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("nameList")]
        public async Task<ResultData<List<MemberRankNameVo>>> GetMemberRankNameListAsync()
        {
            var memberRankInfos = from d in await memberRankInfoService.GetMemberRankNameListAsync()
                                  select new MemberRankNameVo
                                  {
                                      Id = d.Id,
                                      Name = d.Name,
                                  };
            return ResultData<List<MemberRankNameVo>>.Success().AddData("memberRankNames", memberRankInfos.ToList());
        }

        /// <summary>
        /// 获取会员卡编码名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("codeList")]
        public async Task<ResultData<List<MemberRankCodeVo>>> GetMemberRankCodeListAsync()
        {
            var memberRankInfos = from d in await memberRankInfoService.GetMemberRankCodeListAsync()
                                  select new MemberRankCodeVo
                                  {
                                       MemberRankCode=d.MemberRankCode,
                                       MemberRankCodeName=d.MemberRankCodeName
                                  };
            return ResultData<List<MemberRankCodeVo>>.Success().AddData("memberRankNames", memberRankInfos.ToList());
        }



        /// <summary>
        /// 获取有效的会员等级列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("validList")]
        public async Task<ResultData<List<MemberRankInfoVo>>> GetValidMemberRankInfosAsync()
        {
            var memberRankInfos = from d in await memberRankInfoService.GetValidMemberRankInfosAsync()
                                  select new MemberRankInfoVo
                                  {
                                      ID = d.ID,
                                      Name = d.Name,
                                      MinAmount = d.MinAmount,
                                      MaxAmount = d.MaxAmount,
                                      Sconto = d.Sconto,
                                      GenerateIntegrationPercent = d.GenerateIntegrationPercent,
                                      ReferralsIntegrationPercent = d.ReferralsIntegrationPercent,
                                      Description = d.Description,
                                      Default = d.Default,
                                      ImageUrl = d.ImageUrl,
                                      RankCode = d.RankCode,
                                      Valid = d.Valid
                                  };
            return ResultData<List<MemberRankInfoVo>>.Success().AddData("memberRankInfos", memberRankInfos.ToList());
        }
    }
}
