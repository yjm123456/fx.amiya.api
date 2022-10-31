using Fx.Amiya.Dto.AmiyaLessonApply;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Vo.AmiyaLessonApply;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    public class AmiyaLessonApplyController : ControllerBase
    {
        private IAmiyaLessonApplyService amiyaLessonApplyService;
        private TokenReader _tokenReader;
        private IMiniSessionStorage _sessionStorage;
        public AmiyaLessonApplyController(
            IAmiyaLessonApplyService amiyaLessonApplyService,
            TokenReader tokenReader,
            IMiniSessionStorage sessionStorage)
        {
           this.amiyaLessonApplyService = amiyaLessonApplyService;
            _tokenReader = tokenReader;
            _sessionStorage = sessionStorage;
        }


        /// <summary>
        /// 添加报名信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddAmiyaLessonApplyInfoVo addVo)
        {
            try
            {

                AddAmiyaLessonApplyDto addDto = new AddAmiyaLessonApplyDto();
                addDto.Name = addVo.Name;
                addDto.Phone = addVo.Phone;
                addDto.Position = addVo.Position;
                addDto.City = addVo.City;
                await amiyaLessonApplyService.AddAsync(addDto);

                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
    }
}
