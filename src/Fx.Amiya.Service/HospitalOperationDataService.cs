using Fx.Amiya.Dto.HospitalOperationData;
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
    public class HospitalOperationDataService : IHospitalOperationDataService
    {
        private IDalHospitalOperationData dalHospitalOperationData;
        private IHospitalOperationIndicatorService hospitalOperationIndicatorService;
        private IIndicatorSendHospitalService indicatorSendHospitalService;
        private IGreatHospitalDataWriteService greatHospitalDataWriteService;
        private IContentPlatformOrderSendService contentPlatformOrderSendService;
        private IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private IHospitalPerformanceService hospitalPerformanceService;
        private IUnitOfWork unitOfWork;
        public HospitalOperationDataService(IDalHospitalOperationData dalHospitalOperationData,
            IHospitalOperationIndicatorService hospitalOperationIndicatorService,
            IIndicatorSendHospitalService indicatorSendHospitalService,
            IGreatHospitalDataWriteService greatHospitalDataWriteService,
            IUnitOfWork unitOfWork, IContentPlatformOrderSendService contentPlatformOrderSendService, IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService, IHospitalPerformanceService hospitalPerformanceService)
        {
            this.dalHospitalOperationData = dalHospitalOperationData;
            this.hospitalOperationIndicatorService = hospitalOperationIndicatorService;
            this.indicatorSendHospitalService = indicatorSendHospitalService;
            this.unitOfWork = unitOfWork;
            this.greatHospitalDataWriteService = greatHospitalDataWriteService;
            this.contentPlatformOrderSendService = contentPlatformOrderSendService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.hospitalPerformanceService = hospitalPerformanceService;
        }



        public async Task<List<HospitalOperationDataDto>> GetListAsync(string keyword, string indicatorsId, int hospitalId)
        {
            try
            {
                var hospitalOperationData = from d in dalHospitalOperationData.GetAll().Include(x => x.HospitalInfo).Include(x => x.HospitalOperationalIndicator)
                                            where (keyword == null || d.HospitalInfo.Name.Contains(keyword))
                                            && (d.IndicatorsId == indicatorsId)
                                            && (d.HospitalId == hospitalId)
                                            && (d.Valid == true)
                                            select new HospitalOperationDataDto
                                            {
                                                Id = d.Id,
                                                HospitalId = d.HospitalId,
                                                IndicatorsId = d.IndicatorsId,
                                                OperationName = d.OperationName,
                                                LastMonthData = d.LastMonthData,
                                                BeforeMonthData = d.BeforeMonthData,
                                                ChainRatio = d.ChainRatio,
                                                IndicatorCalculation=d.IndicatorCalculation,
                                                Sort = d.Sort,
                                            };

                List<HospitalOperationDataDto> hospitalOperationDataList = new List<HospitalOperationDataDto>();
                hospitalOperationDataList = await hospitalOperationData.ToListAsync();
                foreach (var x in hospitalOperationDataList)
                {
                    var greatHospitalDataWrite = await greatHospitalDataWriteService.GetByNameAndIndicatorIdAsync(x.IndicatorsId, x.OperationName);
                    x.GreatHospital = greatHospitalDataWrite.OperationValue;
                }
                return hospitalOperationDataList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



        public async Task AddAsync(List<AddHospitalOperationDataDto> addDtoList)
        {

            unitOfWork.BeginTransaction();
            try
            {
                //获取主表优秀机构名称
                var hospitalOperationInfo = await hospitalOperationIndicatorService.GetByIdAsync(addDtoList.First().IndicatorsId);
                foreach (var x in addDtoList)
                {
                    HospitalOperationData hospitalOperationData = new HospitalOperationData();
                    hospitalOperationData.Id = Guid.NewGuid().ToString();
                    hospitalOperationData.CreateDate = DateTime.Now;
                    hospitalOperationData.Valid = true;
                    hospitalOperationData.HospitalId = x.HospitalId;
                    hospitalOperationData.IndicatorsId = x.IndicatorsId;
                    hospitalOperationData.OperationName = x.OperationName;
                    hospitalOperationData.LastMonthData = x.LastMonthData;
                    hospitalOperationData.BeforeMonthData = x.BeforeMonthData;
                    hospitalOperationData.ChainRatio = x.ChainRatio;
                    hospitalOperationData.Sort = x.Sort;
                    hospitalOperationData.GreatHospital = hospitalOperationInfo.ExcellentHospital;
                    hospitalOperationData.IndicatorCalculation = x.IndicatorCalculation;
                    await dalHospitalOperationData.AddAsync(hospitalOperationData, true);
                }

                await indicatorSendHospitalService.UpdateSubmitStateAsync(addDtoList.First().IndicatorsId, addDtoList.First().HospitalId);
                unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<HospitalOperationDataDto> GetByIdAsync(string id)
        {
            try
            {
                var hospitalOperationData = await dalHospitalOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (hospitalOperationData == null)
                    throw new Exception("机构运营数据分析编号错误");

                HospitalOperationDataDto hospitalOperationDataDto = new HospitalOperationDataDto();
                hospitalOperationDataDto.Id = hospitalOperationData.Id;
                hospitalOperationDataDto.CreateDate = hospitalOperationData.CreateDate;
                hospitalOperationDataDto.UpdateDate = hospitalOperationData.UpdateDate;
                hospitalOperationDataDto.DeleteDate = hospitalOperationData.DeleteDate;
                hospitalOperationDataDto.Valid = hospitalOperationData.Valid;
                hospitalOperationDataDto.HospitalId = hospitalOperationData.HospitalId;
                hospitalOperationDataDto.IndicatorsId = hospitalOperationData.IndicatorsId;
                hospitalOperationDataDto.OperationName = hospitalOperationData.OperationName;
                hospitalOperationDataDto.LastMonthData = hospitalOperationData.LastMonthData;
                hospitalOperationDataDto.BeforeMonthData = hospitalOperationData.BeforeMonthData;
                hospitalOperationDataDto.ChainRatio = hospitalOperationData.ChainRatio;
                hospitalOperationDataDto.Sort = hospitalOperationData.Sort;
                hospitalOperationDataDto.GreatHospital = hospitalOperationData.GreatHospital;
                hospitalOperationDataDto.IndicatorCalculation = hospitalOperationData.IndicatorCalculation;
                return hospitalOperationDataDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(UpdateHospitalOperationDataDto updateDto)
        {
            try
            {
                var hospitalOperationData = await dalHospitalOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (hospitalOperationData == null)
                    throw new Exception("机构运营数据分析编号错误");

                hospitalOperationData.HospitalId = updateDto.HospitalId;
                hospitalOperationData.IndicatorsId = updateDto.IndicatorsId;
                hospitalOperationData.OperationName = updateDto.OperationName;
                hospitalOperationData.LastMonthData = updateDto.LastMonthData;
                hospitalOperationData.BeforeMonthData = updateDto.BeforeMonthData;
                hospitalOperationData.ChainRatio = updateDto.ChainRatio;
                hospitalOperationData.IndicatorCalculation = updateDto.IndicatorCalculation;
                hospitalOperationData.UpdateDate = DateTime.Now;

                await dalHospitalOperationData.UpdateAsync(hospitalOperationData, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
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
                var hospitalOperationData = await dalHospitalOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalOperationData == null)
                    throw new Exception("机构运营数据分析编号错误");
                hospitalOperationData.DeleteDate = DateTime.Now;
                hospitalOperationData.Valid = false;

                await dalHospitalOperationData.UpdateAsync(hospitalOperationData, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
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
                var hospitalOperationData = await dalHospitalOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalOperationData == null)
                    throw new Exception("机构运营数据分析编号错误");

                await dalHospitalOperationData.DeleteAsync(hospitalOperationData, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
        /// <summary>
        /// 获取医院运营数据列表
        /// </summary>
        /// <param name="indicatorsId"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<HospitalOperationTotalDataDto> GetHospitalOperationDataList(string indicatorsId, int hospitalId)
        {
            var hospitalOperationInfo = await hospitalOperationIndicatorService.GetByIdAsync(indicatorsId);
            var date = hospitalOperationInfo.StartDate;
            return await hospitalPerformanceService.GetHospitalOperationMonthData(hospitalId, date);                      
        }
    }
}
