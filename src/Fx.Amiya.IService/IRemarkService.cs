using Fx.Amiya.Background.Api.Vo.Remark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IRemarkService
    {
        /// <summary>
        /// 获取优秀机构批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task<AmiyaRemarkDto> GetAmiyaRemark(string indicatorId);
        /// <summary>
        /// 添加优秀机构批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task AddAmiyaRemark(AddAmiyaRemarkDto add);
        /// <summary>
        /// 修改优秀机构批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task UpdateAmiyaRemark(UpdateAmiyaRemarkDto update);

    }
}
