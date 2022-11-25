using Fx.Amiya.Dto.IndicatorOrderData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IIndicatorOrderDataService
    {
       
        public Task AddAsync(AddIndicatorOrderDataDto addDto);
        public Task<IndicatorOrderDataDto> GetInfoByIndicatorIdAndHospitalId(string indicatorId,int hospitalId);
    }
}
