using Fx.Amiya.Dto.HospitalOperationIndicator;
using Fx.Amiya.Dto.IndicatorSendHospital;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{

    public class IndicatorSendHospitalService : IIndicatorSendHospitalService
    {
        private IDalIndicatorSendHospital dalIndicatorSendHospital;

        public IndicatorSendHospitalService(IDalIndicatorSendHospital dalIndicatorSendHospital)
        {
            this.dalIndicatorSendHospital = dalIndicatorSendHospital;
        }

        public async Task<FxPageInfo<HospitalOperationIndicatorCollectDto>> GetHospitalOperationIndicatorCollectList(string indicatorId, int? hospitalId, int pageNum, int pageSize, bool? isSubmit)
        {
            FxPageInfo<HospitalOperationIndicatorCollectDto> fxPageInfo = new FxPageInfo<HospitalOperationIndicatorCollectDto>();
            var list = dalIndicatorSendHospital.GetAll().Include(e => e.HospitalInfo).Include(e => e.HospitalOperationalIndicator).Where(e => (indicatorId == null || e.IndicatorId == indicatorId) && (hospitalId == null || e.HospitalId == hospitalId) && (isSubmit == null || e.SubmitStatus == isSubmit)).Select(
                    e => new HospitalOperationIndicatorCollectDto
                    {
                        HospitalId = e.HospitalId,
                        IndicatorId = e.IndicatorId,
                        IndicatorName = e.HospitalOperationalIndicator.Name,
                        HospitalName = e.HospitalInfo.Name,
                        HospitalAddress = e.HospitalInfo.Address,
                        IsSubmit = e.SubmitStatus
                    }
                );
            fxPageInfo.TotalCount = list.Count();
            fxPageInfo.List = list.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            return fxPageInfo;
        }

        public async Task<FxPageInfo<HospitalIndicatorFillDto>> GetHospitalOperationIndicatorFillList(int? hospitalId, int pageNum, int pageSize, bool? isSumbit)
        {
            FxPageInfo<HospitalIndicatorFillDto> fxPageInfo = new FxPageInfo<HospitalIndicatorFillDto>();
            var list = dalIndicatorSendHospital.GetAll().Include(e => e.HospitalInfo).Include(e => e.HospitalOperationalIndicator).Where(e => (hospitalId == null || e.HospitalId == hospitalId) && e.Valid == true && e.HospitalOperationalIndicator.Valid == true  && (isSumbit == null || e.SubmitStatus == isSumbit)).Select(
                    e => new HospitalIndicatorFillDto
                    {
                        HospitalId = e.HospitalId,
                        IndicatorId = e.IndicatorId,
                        IndicatorName = e.HospitalOperationalIndicator.Name,
                        Describe = e.HospitalOperationalIndicator.Describe,
                        StartDate = e.HospitalOperationalIndicator.StartDate,
                        EndDate = e.HospitalOperationalIndicator.EndDate
                    }
                );
            fxPageInfo.TotalCount = list.Count();
            fxPageInfo.List = list.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            return fxPageInfo;
        }

        /// <summary>
        /// 修改提交状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateSubmitStateAsync(string IndicatorId, int hospitalId)
        {
            try
            {
                var greatHospitalOperationHealth = await dalIndicatorSendHospital.GetAll().SingleOrDefaultAsync(e => e.IndicatorId == IndicatorId && e.HospitalId == hospitalId);

                if (greatHospitalOperationHealth == null)
                    throw new Exception("派发医院编号错误");
                greatHospitalOperationHealth.UpdateDate = DateTime.Now;
                greatHospitalOperationHealth.SubmitStatus = true;

                await dalIndicatorSendHospital.UpdateAsync(greatHospitalOperationHealth, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 修改批注状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateRemarkStatusAsync(string IndicatorId, int hospitalId)
        {
            try
            {
                var greatHospitalOperationHealth = await dalIndicatorSendHospital.GetAll().SingleOrDefaultAsync(e => e.IndicatorId == IndicatorId && e.HospitalId == hospitalId);

                if (greatHospitalOperationHealth == null)
                    throw new Exception("派发医院编号错误");
                greatHospitalOperationHealth.UpdateDate = DateTime.Now;
                greatHospitalOperationHealth.RemarkStatus = true;

                await dalIndicatorSendHospital.UpdateAsync(greatHospitalOperationHealth, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
