using Fx.Amiya.Dto.HospitalOperationIndicator;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fx.Amiya.DbModels.Model;
using Fx.Common;
using Fx.Infrastructure.DataAccess;

namespace Fx.Amiya.Service
{
    public class HospitalOperationIndicatorService : IHospitalOperationIndicatorService
    {
        private IUnitOfWork unitOfWork;
        private IDalHospitalOperationIndicator dalHospitalOperationIndicator;
        private IDalIndicatorSendHospital dalIndicatorSendHospital;
        public HospitalOperationIndicatorService(IDalHospitalOperationIndicator dalHospitalOperationIndicator, IDalIndicatorSendHospital dalIndicatorSendHospital, IUnitOfWork unitOfWork)
        {
            this.dalHospitalOperationIndicator = dalHospitalOperationIndicator;
            this.dalIndicatorSendHospital = dalIndicatorSendHospital;
            this.unitOfWork = unitOfWork;
        }


        /// <summary>
        /// 获取运营指标列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="valid"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<HospitalOperationIndicatorDto>> GetListAsync(string keyword, bool? valid, int pageNum, int pageSize)
        {
            try
            {
                FxPageInfo<HospitalOperationIndicatorDto> fxPageInfo = new FxPageInfo<HospitalOperationIndicatorDto>();
                var hospitalOperationIndicator = from d in dalHospitalOperationIndicator.GetAll().Where(e => (keyword == null || (e.Name.Contains(keyword) || e.Describe.Contains(keyword))) && (valid == null || e.Valid == valid)).Include(e => e.IndicatorSendHospitalList)
                                                 select new HospitalOperationIndicatorDto
                                                 {
                                                     Id = d.Id,
                                                     Name = d.Name,
                                                     Describe = d.Describe,
                                                     StartDate = d.StartDate,
                                                     EndDate = d.EndDate,
                                                     ExcellentHospital = d.ExcellentHospital,
                                                     SubmitStatus = d.SubmitStatus,
                                                     RemarkStatus = d.RemarkStatus,
                                                     CreateDate = d.CreateDate,
                                                     Valid = d.Valid
                                                 };
                fxPageInfo.TotalCount = hospitalOperationIndicator.Count();
                fxPageInfo.List = hospitalOperationIndicator.OrderByDescending(x => x.StartDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
                return fxPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 添加运营指标
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddHospitalOperationIndicatorDto addDto)
        {
            try
            {
                unitOfWork.BeginTransaction();
                HospitalOperationalIndicator hospitalOperationalIndicator = new HospitalOperationalIndicator();
                hospitalOperationalIndicator.Id = Guid.NewGuid().ToString();
                hospitalOperationalIndicator.Name = addDto.Name;
                hospitalOperationalIndicator.Describe = addDto.Describe;
                hospitalOperationalIndicator.StartDate = addDto.StartDate;
                hospitalOperationalIndicator.EndDate = addDto.EndDate;
                hospitalOperationalIndicator.ExcellentHospital = addDto.ExcellentHospital;
                hospitalOperationalIndicator.CreateDate = DateTime.Now;
                hospitalOperationalIndicator.Valid = addDto.Valid;

                await dalHospitalOperationIndicator.AddAsync(hospitalOperationalIndicator, true);
                List<IndicatorSendHospital> indicatorSendHospitalList = new List<IndicatorSendHospital>();
                foreach (var item in addDto.SendHospital)
                {
                    IndicatorSendHospital indicatorSendHospital = new IndicatorSendHospital
                    {
                        Id = Guid.NewGuid().ToString(),
                        IndicatorId = hospitalOperationalIndicator.Id,
                        HospitalId = item.HospitalId,
                        CreateDate = DateTime.Now,
                        Valid = true,
                    };
                    indicatorSendHospitalList.Add(indicatorSendHospital);
                }
                await dalIndicatorSendHospital.AddCollectionAsync(indicatorSendHospitalList, true);
                unitOfWork.Commit();
            }

            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }

        public async Task<HospitalOperationIndicatorDto> GetByIdAsync(string id)
        {
            try
            {
                var hospitalOperationIndicator = await dalHospitalOperationIndicator.GetAll().Where(e => e.Id == id).Include(e => e.IndicatorSendHospitalList).ThenInclude(h => h.HospitalInfo).SingleOrDefaultAsync();
                if (hospitalOperationIndicator == null)
                    throw new Exception("运营指标编号错误");

                HospitalOperationIndicatorDto hospitalOperationIndicatorDto = new HospitalOperationIndicatorDto();
                hospitalOperationIndicatorDto.Id = hospitalOperationIndicator.Id;
                hospitalOperationIndicatorDto.CreateDate = hospitalOperationIndicator.CreateDate;
                hospitalOperationIndicatorDto.UpdateDate = hospitalOperationIndicator.UpdateDate;
                hospitalOperationIndicatorDto.DeleteDate = hospitalOperationIndicator.DeleteDate;
                hospitalOperationIndicatorDto.Valid = hospitalOperationIndicator.Valid;
                hospitalOperationIndicatorDto.Name = hospitalOperationIndicator.Name;
                hospitalOperationIndicatorDto.Describe = hospitalOperationIndicator.Describe;
                hospitalOperationIndicatorDto.StartDate = hospitalOperationIndicator.StartDate;
                hospitalOperationIndicatorDto.EndDate = hospitalOperationIndicator.EndDate;
                hospitalOperationIndicatorDto.ExcellentHospital = hospitalOperationIndicator.ExcellentHospital;
                hospitalOperationIndicatorDto.SendHospital = hospitalOperationIndicator.IndicatorSendHospitalList.Where(e => e.Valid == true).Select(e =>
                    new HospitalNameListDto
                    {
                        HospitalId = e.HospitalId,
                        HospitalName = e.HospitalInfo.Name
                    }).ToList();

                return hospitalOperationIndicatorDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return null;
        }

        public async Task UpdateAsync(UpdateHospitalOperationIndicatorDto updateDto)
        {
            try
            {
                var hospitalOperationIndicator = await dalHospitalOperationIndicator.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (hospitalOperationIndicator == null)
                    throw new Exception("运营指标编号错误");
                hospitalOperationIndicator.Name = updateDto.Name;
                hospitalOperationIndicator.Describe = updateDto.Describe;
                hospitalOperationIndicator.StartDate = updateDto.StartDate;
                hospitalOperationIndicator.EndDate = updateDto.EndDate;
                hospitalOperationIndicator.ExcellentHospital = updateDto.ExcellentHospital;
                hospitalOperationIndicator.UpdateDate = DateTime.Now;
                hospitalOperationIndicator.Valid = updateDto.Valid;
                var sendList = updateDto.SendHospital.Select(e => e.HospitalId).ToList();
                var sendHospitals = dalIndicatorSendHospital.GetAll().Where(e => e.Valid == true && e.IndicatorId == updateDto.Id).Select(e => e.HospitalId).ToList();
                foreach (var item in sendHospitals)
                {
                    var sendHospital = dalIndicatorSendHospital.GetAll().Where(e=> e.HospitalId == item && e.IndicatorId == updateDto.Id).SingleOrDefault();
                    await dalIndicatorSendHospital.DeleteAsync(sendHospital,true);
                }
                List<IndicatorSendHospital> indicatorSendHospitalList = new List<IndicatorSendHospital>();
                foreach (var item in sendList)
                {
                    IndicatorSendHospital indicatorSendHospital = new IndicatorSendHospital
                    {
                        Id = Guid.NewGuid().ToString(),
                        IndicatorId = updateDto.Id,
                        CreateDate = DateTime.Now,
                        Valid = true,
                        HospitalId = item,
                    };
                    indicatorSendHospitalList.Add(indicatorSendHospital);
                }
                await dalIndicatorSendHospital.AddCollectionAsync(indicatorSendHospitalList, true);
                await dalHospitalOperationIndicator.UpdateAsync(hospitalOperationIndicator, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            try
            {
                var hospitalOperationIndicator = await dalHospitalOperationIndicator.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalOperationIndicator == null)
                    throw new Exception("运营健康指标编号错误");
                hospitalOperationIndicator.DeleteDate = DateTime.Now;
                hospitalOperationIndicator.Valid = false;

                await dalHospitalOperationIndicator.UpdateAsync(hospitalOperationIndicator, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 数据库删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteDataAsync(string id)
        {
            try
            {
                var hospitalOperationIndicator = await dalHospitalOperationIndicator.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalOperationIndicator == null)
                    throw new Exception("运营指标编号错误");

                await dalHospitalOperationIndicator.DeleteAsync(hospitalOperationIndicator, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<IndicatorNameList>> GetIndicatorListAsync()
        {
            var hospitalOperationIndicator = from d in dalHospitalOperationIndicator.GetAll().OrderByDescending(x => x.StartDate).Where(e => e.Valid == true)
                                             select new IndicatorNameList
                                             {
                                                 Id = d.Id,
                                                 IndicatorName = d.Name,
                                             };

            return await hospitalOperationIndicator.ToListAsync();
        }
        /// <summary>
        /// 获取未提报/未批注的运营指标
        /// </summary>
        /// <returns></returns>
        public async Task<List<OperationIndicatorSubmitAndRemarkDto>> GetUnSumbitAndUnRemarkIndicatorAsync()
        {
            var month = DateTime.Now.Month;
            var lastMonth = DateTime.Now.AddMonths(-1);
            var startDate = new DateTime(lastMonth.Year, lastMonth.Month,1);
            var nextMonth = DateTime.Now.AddMonths(1);
            var endDate = new DateTime(nextMonth.Year, nextMonth.Month,1);
            var indicatorList= dalHospitalOperationIndicator.GetAll().Where(e=>e.Valid==true&&e.StartDate>=startDate&&e.EndDate<=endDate&&(e.RemarkStatus==false||e.SubmitStatus==false)).Select(e=>new OperationIndicatorSubmitAndRemarkDto {
                Id=e.Id,
                SubmitStatus=e.SubmitStatus,
                RemarkStatus=e.RemarkStatus
            }).ToList();
            return indicatorList;
        }
        /// <summary>
        /// 修改运营指标提报和批注状态
        /// </summary>
        /// <returns></returns>
        public async Task UpdateRemarkAndSubmitStatusAsync(UpdateSubmitAndRemarkStatus updateDto)
        {
            var indicator =await dalHospitalOperationIndicator.GetAll().Where(e=>e.Id==updateDto.Id).SingleOrDefaultAsync();
            indicator.SubmitStatus = updateDto.SubmitStatus;
            indicator.RemarkStatus = updateDto.RemarkStatus;
            indicator.UpdateDate = DateTime.Now;
            await dalHospitalOperationIndicator.UpdateAsync(indicator,true);
        }
    }
}
