
using Fx.Amiya.Background.Api.Vo.MemberCard;
using Fx.Amiya.Core.Dto.MemberCard;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class MemberCardController : ControllerBase
    {
        private IMemberCard memberCardService;
        private IHttpContextAccessor httpContextAccessor;
        private ICustomerService customerService;
        public MemberCardController(IMemberCard memberCardService, IHttpContextAccessor httpContextAccessor,
            ICustomerService customerService)
        {
            this.memberCardService = memberCardService;
            this.httpContextAccessor = httpContextAccessor;
            this.customerService = customerService;
        }

        private static readonly AsyncLock _mutex = new AsyncLock();

        /// <summary>
        /// 手动发放会员卡
        /// </summary>
        /// <param name="issueMemberCard"></param>
        /// <returns></returns>
        [HttpPost("issue")]
        public async Task<ResultData> IssueMemberCardAsync(IssueMemberCardAddVo issueMemberCard)
        {

            using (await _mutex.LockAsync())
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                IssueMemberCardAddDto issueMemberCardAddDto = new IssueMemberCardAddDto()
                {
                    CustomerID = issueMemberCard.CustomerId,
                    MemberRankID = issueMemberCard.MemberRankId,
                    HandleBy = Convert.ToInt32(employee.Id),
                    MemberCardNum=issueMemberCard.MemberCardNum
                };
               await memberCardService.IssueMemberCardAsync(issueMemberCardAddDto);
                return ResultData.Success();
            }
        }




    }
}
