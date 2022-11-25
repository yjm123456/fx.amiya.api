using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.IndicatorOrderData;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class IndicatorOrderDataService : IIndicatorOrderDataService
    {
        private readonly IDalIndicatorOrderData dalIndicatorOrderData;

        public IndicatorOrderDataService(IDalIndicatorOrderData dalIndicatorOrderData)
        {
            this.dalIndicatorOrderData = dalIndicatorOrderData;
        }

        public async Task AddAsync(AddIndicatorOrderDataDto addDto)
        {
            var orderData = dalIndicatorOrderData.GetAll().Where(e => e.IndicatorId == addDto.IndicatorId && e.HospitalId == addDto.HospitalId).SingleOrDefault();
            if (orderData != null)
            {
                orderData.AllSendorderCount = addDto.AllSendorderCount;
                orderData.LocalSendorderCount = addDto.LocalSendorderCount;
                orderData.OtherPlaceSendorderCount = addDto.OtherPlaceSendorderCount;
                orderData.InvalidSendorderCount = addDto.InvalidSendorderCount;
                orderData.EpidemicCount = addDto.EpidemicCount;
                orderData.OtherQuestion = addDto.OtherQuestion;
                orderData.UpdateDate = DateTime.Now;
                await dalIndicatorOrderData.UpdateAsync(orderData, true);
            }
            else
            {
                IndicatorOrderData indicatorOrderData = new IndicatorOrderData();
                indicatorOrderData.Id = Guid.NewGuid().ToString().Replace("-", "");
                indicatorOrderData.HospitalId = addDto.HospitalId;
                indicatorOrderData.IndicatorId = addDto.IndicatorId;
                indicatorOrderData.AllSendorderCount = addDto.AllSendorderCount;
                indicatorOrderData.LocalSendorderCount = addDto.LocalSendorderCount;
                indicatorOrderData.OtherPlaceSendorderCount = addDto.OtherPlaceSendorderCount;
                indicatorOrderData.InvalidSendorderCount = addDto.InvalidSendorderCount;
                indicatorOrderData.EpidemicCount = addDto.EpidemicCount;
                indicatorOrderData.OtherQuestion = addDto.OtherQuestion;
                indicatorOrderData.CreateDate = DateTime.Now;
                indicatorOrderData.Valid = true;
                await dalIndicatorOrderData.AddAsync(indicatorOrderData, true);
            }
        }

        public async Task<IndicatorOrderDataDto> GetInfoByIndicatorIdAndHospitalId(string indicatorId, int hospitalId)
        {
            var orderData =dalIndicatorOrderData.GetAll().Where(e => e.IndicatorId == indicatorId && e.HospitalId == hospitalId&&e.Valid==true).Select(e => new IndicatorOrderDataDto
            {
                HospitalId = e.HospitalId,
                IndicatorId = e.IndicatorId,
                AllSendorderCount = e.AllSendorderCount,
                LocalSendorderCount = e.LocalSendorderCount,
                OtherPlaceSendorderCount = e.OtherPlaceSendorderCount,
                InvalidSendorderCount = e.InvalidSendorderCount,
                EpidemicCount = e.EpidemicCount,
                OtherQuestion = e.OtherQuestion
            }).SingleOrDefault();
            return orderData;

        }
    }
}
