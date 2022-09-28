using Fx.Amiya.Background.Api.Vo.Remark;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{

    public class RemarkService : IRemarkService
    {
        private readonly IDalRemark dalRemark;

        public RemarkService(IDalRemark dalRemark)
        {
            this.dalRemark = dalRemark;
        }

        public Task AddAmiyaRemark(AddAmiyaRemarkDto addAmiyaRemarkDto)
        {
            /* Remark remark = new Remark() {
                 Id = Guid.NewGuid().ToString(),
                 IndicatorId=indicatorId,CreateDate=DateTime.Now,
                 re
             };*/
            throw new NotImplementedException();

        }

        public Task<AmiyaRemarkDto> GetAmiyaRemark(string indicatorId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAmiyaRemark(UpdateAmiyaRemarkDto update)
        {
            throw new NotImplementedException();
        }
    }
}
