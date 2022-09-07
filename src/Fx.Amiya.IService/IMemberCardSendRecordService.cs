using Fx.Amiya.Dto.MemberCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IMemberCardSendRecordService
    {
        /// <summary>
        /// 添加会员卡发放记录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task AddAsync(MemberCardSendRecordDto dto);
    }
}
