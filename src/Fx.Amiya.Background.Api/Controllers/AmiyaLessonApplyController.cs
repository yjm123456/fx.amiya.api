using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.AmiyaLessonApplyInfo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Dto.ExpressManage;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 报名板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AmiyaLessonApplyController : ControllerBase
    {
        private IAmiyaLessonApplyService amiyaLessonApplyService;
        public AmiyaLessonApplyController(
            IAmiyaLessonApplyService amiyaLessonApplyService)
        {
            this.amiyaLessonApplyService = amiyaLessonApplyService;
        }



        /// <summary>
        /// 获取报名列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("infoList")]
        public async Task<ResultData<FxPageInfo<AmiyaLessonApplyInfoVo>>> GetAmiyaLessonApplyInfoListAsync(string keyword, int pageNum, int pageSize)
        {

            var q = await amiyaLessonApplyService.GetListWithPageAsync(keyword, pageNum, pageSize);
            var amiyaLessonApplyInfos = from d in q.List
                                        select new AmiyaLessonApplyInfoVo
                                        {
                                            Id = d.Id,
                                            Name = d.Name,
                                            Phone = d.Phone,
                                            City = d.City,
                                            Position = d.Position,
                                        };
            FxPageInfo<AmiyaLessonApplyInfoVo> amiyaLessonApplyPageInfo = new FxPageInfo<AmiyaLessonApplyInfoVo>();
            amiyaLessonApplyPageInfo.TotalCount = q.TotalCount;
            amiyaLessonApplyPageInfo.List = amiyaLessonApplyInfos;
            return ResultData<FxPageInfo<AmiyaLessonApplyInfoVo>>.Success().AddData("amiyaLessonApplyInfos", amiyaLessonApplyPageInfo);
        }

    }
}
