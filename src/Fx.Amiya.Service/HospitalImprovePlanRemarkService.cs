using Fx.Amiya.Background.Api.Vo.HospitalImprovePlan;
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
    public class HospitalImprovePlanRemarkService : IHospitalImprovePlanRemarkService
    {
        private IDalHospitalImprovePlanRemark dalHospitalImprovePlanRemark;

        public HospitalImprovePlanRemarkService(IDalHospitalImprovePlanRemark dalHospitalImprovePlanRemark)
        {
            this.dalHospitalImprovePlanRemark = dalHospitalImprovePlanRemark;
        }

        public async Task AddHospitalImprovePlan(AddHospitalImprovePlanDto addDto)
        {
            HospitalImprovePlanRemark remark = new HospitalImprovePlanRemark
            {
                Id = Guid.NewGuid().ToString(),
                IndicatorId = addDto.IndicatorId,
                HospitalId = addDto.HospitalId,
                HospitalImprovePlan = addDto.HospitalImprovePlan,
                AmiyaImprovePlanRemark = addDto.AmiyaImprovePlanRemark,
                HospitalShareSuccessCase = addDto.HospitalShareSuccessCase,
                AmiyaShareSuccessCase = addDto.AmiyaShareSuccessCase,
                ImproveSuggestionToAmiya = addDto.ImproveSuggestionToAmiya,
                AmiyaImproveSuggestionRemark = addDto.AmiyaImproveSuggestionRemark,
                ImproveDemandToAmiya = addDto.ImproveDemandToAmiya,
                AmiyaImproveDemandRemark = addDto.AmiyaImproveDemandRemark,
                CreateDate = DateTime.Now,
                Valid=true
            };
            await dalHospitalImprovePlanRemark.AddAsync(remark,true);
        }

        public async Task<HospitalImprovePlanDto> GetHospitalImprovePlan(string indicatorId, int hospitalId)
        {
            var remark = dalHospitalImprovePlanRemark.GetAll().Where(e=>e.IndicatorId==indicatorId&&e.HospitalId==hospitalId&&e.Valid==true).SingleOrDefault();
            if (remark == null) return new HospitalImprovePlanDto();
            return new HospitalImprovePlanDto {
                Id = remark.Id,
                IndicatorId = remark.IndicatorId,
                HospitalId = remark.HospitalId,
                HospitalImprovePlan = remark.HospitalImprovePlan,
                AmiyaImprovePlanRemark = remark.AmiyaImprovePlanRemark,
                HospitalShareSuccessCase = remark.HospitalShareSuccessCase,
                AmiyaShareSuccessCase = remark.AmiyaShareSuccessCase,
                ImproveSuggestionToAmiya = remark.ImproveSuggestionToAmiya,
                AmiyaImproveSuggestionRemark = remark.AmiyaImproveSuggestionRemark,
                ImproveDemandToAmiya = remark.ImproveDemandToAmiya,
                AmiyaImproveDemandRemark = remark.AmiyaImproveDemandRemark,
            };
        }

        public async Task UpdateHospitalImprovePlan(UpdateHospitalImprovePlanDto updateDto)
        {
            var remark = dalHospitalImprovePlanRemark.GetAll().Where(e=>e.Id==updateDto.Id).SingleOrDefault();
            remark.Id = updateDto.Id;
            remark.IndicatorId = updateDto.IndicatorId;
            remark.HospitalId = updateDto.HospitalId;
            remark.HospitalImprovePlan = updateDto.HospitalImprovePlan;
            remark.AmiyaImprovePlanRemark = updateDto.AmiyaImprovePlanRemark;
            remark.HospitalShareSuccessCase = updateDto.HospitalShareSuccessCase;
            remark.AmiyaShareSuccessCase = updateDto.AmiyaShareSuccessCase;
            remark.ImproveSuggestionToAmiya = updateDto.ImproveSuggestionToAmiya;
            remark.AmiyaImproveSuggestionRemark = updateDto.AmiyaImproveSuggestionRemark;
            remark.ImproveDemandToAmiya = updateDto.ImproveDemandToAmiya;
            remark.AmiyaImproveDemandRemark = updateDto.AmiyaImproveDemandRemark;
            remark.UpdateDate = DateTime.Now;
            await dalHospitalImprovePlanRemark.UpdateAsync(remark,true);
        }
    }
}
