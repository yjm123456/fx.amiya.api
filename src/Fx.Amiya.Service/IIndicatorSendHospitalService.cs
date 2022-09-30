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
        /// <summary>
        /// 系统端指标填报数据汇总
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isSumbit"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 获取机构提报数据
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isSumbit"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<HospitalIndicatorFillDto>> GetHospitalOperationIndicatorFillList(int? hospitalId, int pageNum, int pageSize, bool? isSumbit)
        {
            FxPageInfo<HospitalIndicatorFillDto> fxPageInfo = new FxPageInfo<HospitalIndicatorFillDto>();
            var list = dalIndicatorSendHospital.GetAll().Include(e => e.HospitalInfo).Include(e => e.HospitalOperationalIndicator).Where(e => (hospitalId == null || e.HospitalId == hospitalId) && e.Valid == true && e.HospitalOperationalIndicator.Valid == true && (isSumbit == null || e.SubmitStatus == isSumbit)).Select(
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
                var greatHospitalOperationHealth = await dalIndicatorSendHospital.GetAll().FirstOrDefaultAsync(e => e.IndicatorId == IndicatorId && e.Valid == true && e.HospitalId == hospitalId);

                if (greatHospitalOperationHealth == null)
                    throw new Exception("派发医院编号错误");
                if (greatHospitalOperationHealth.SubmitStatus == true) return;
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
                var greatHospitalOperationHealth = await dalIndicatorSendHospital.GetAll().FirstOrDefaultAsync(e => e.IndicatorId == IndicatorId && e.Valid == true && e.HospitalId == hospitalId);
                
                if (greatHospitalOperationHealth == null)
                    throw new Exception("派发医院编号错误");
                if (greatHospitalOperationHealth.RemarkStatus == true) return;
                greatHospitalOperationHealth.UpdateDate = DateTime.Now;
                greatHospitalOperationHealth.RemarkStatus = true;

                await dalIndicatorSendHospital.UpdateAsync(greatHospitalOperationHealth, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 根据指标id获取提报和批注状态
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        public async Task<HospitalReamrkAndSumbitStatusDto> SubmitAndRemarkStatusAsync(string indicatorId)
        {
            var unSubmitCount=dalIndicatorSendHospital.GetAll().Where(e => e.IndicatorId == indicatorId && e.SubmitStatus == false).Count();
            var unRemarkCount = dalIndicatorSendHospital.GetAll().Where(e => e.IndicatorId == indicatorId && e.RemarkStatus == false).Count();
            HospitalReamrkAndSumbitStatusDto status = new HospitalReamrkAndSumbitStatusDto {
                SumbitStatus=unSubmitCount==0,
                RemarkStatus=unRemarkCount==0
            };
            return status;
        }
    }
}
