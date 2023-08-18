using Fx.Amiya.Dto.HospitalConsulationOperationData;
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
    public class HospitalConsulationOperationDataService : IHospitalConsulationOperationDataService
    {
        private IDalHospitalConsulationOperationData dalHospitalConsulationOperationData;
        private IIndicatorSendHospitalService indicatorSendHospitalService;
        private IUnitOfWork unitOfWork;
        public HospitalConsulationOperationDataService(IDalHospitalConsulationOperationData dalHospitalConsulationOperationData,
            IIndicatorSendHospitalService indicatorSendHospitalService,
            IUnitOfWork unitOfWork)
        {
            this.dalHospitalConsulationOperationData = dalHospitalConsulationOperationData;
            this.indicatorSendHospitalService = indicatorSendHospitalService;
            this.unitOfWork = unitOfWork;
        }



        public async Task<List<HospitalConsulationOperationDataDto>> GetListAsync(string keyword, string indicatorsId, int hospitalId)
        {
            try
            {
                var hospitalConsulationOperationData = from d in dalHospitalConsulationOperationData.GetAll().Include(x => x.HospitalInfo).Include(x => x.HospitalOperationalIndicator)
                                                       where (keyword == null || d.HospitalInfo.Name.Contains(keyword))
                                                       && (d.HospitalId == hospitalId)
                                                       && (d.IndicatorId == indicatorsId)
                                                       && (d.Valid == true)
                                                       select new HospitalConsulationOperationDataDto
                                                       {
                                                           Id = d.Id,
                                                           HospitalId = d.HospitalId,
                                                           IndicatorId = d.IndicatorId,
                                                           ConsulationName = d.ConsulationName,
                                                           SendOrderNum = d.SendOrderNum,
                                                           NewCustomerVisitNum = d.NewCustomerVisitNum,
                                                           NewCustomerVisitRate = d.NewCustomerVisitRate,
                                                           NewCustomerDealNum = d.NewCustomerDealNum,
                                                           NewCustomerDealRate = d.NewCustomerDealRate,
                                                           NewCustomerDealPrice = d.NewCustomerDealPrice,
                                                           NewCustomerUnitPrice = d.NewCustomerUnitPrice,

                                                           OldCustomerVisitNum = d.OldCustomerVisitNum,
                                                           OldCustomerDealNum = d.OldCustomerDealNum,
                                                           OldCustomerDealRate = d.OldCustomerDealRate,
                                                           OldCustomerDealPrice = d.OldCustomerDealPrice,
                                                           OldCustomerUnitPrice = d.OldCustomerUnitPrice,

                                                           OldCustomerAchievementRate = d.OldCustomerAchievementRate,
                                                           LasttMonthTotalAchievement = d.LasttMonthTotalAchievement,
                                                           SectionOffice=d.SectionOffice
                                                       };

                List<HospitalConsulationOperationDataDto> hospitalConsulationOperationDataList = new List<HospitalConsulationOperationDataDto>();
                hospitalConsulationOperationDataList = await hospitalConsulationOperationData.ToListAsync();
                return hospitalConsulationOperationDataList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



        public async Task AddAsync(AddHospitalConsulationOperationDataDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                HospitalConsulationOperationData hospitalConsulationOperationData = new HospitalConsulationOperationData();
                hospitalConsulationOperationData.Id = Guid.NewGuid().ToString();
                hospitalConsulationOperationData.CreateDate = DateTime.Now;
                hospitalConsulationOperationData.Valid = true;
                hospitalConsulationOperationData.HospitalId = addDto.HospitalId;
                hospitalConsulationOperationData.IndicatorId = addDto.IndicatorId;
                hospitalConsulationOperationData.ConsulationName = addDto.ConsulationName;
                hospitalConsulationOperationData.SendOrderNum = addDto.SendOrderNum;
                hospitalConsulationOperationData.NewCustomerVisitNum = addDto.NewCustomerVisitNum;
                hospitalConsulationOperationData.NewCustomerVisitRate = addDto.NewCustomerVisitRate;
                hospitalConsulationOperationData.NewCustomerDealNum = addDto.NewCustomerDealNum;
                hospitalConsulationOperationData.NewCustomerDealRate = addDto.NewCustomerDealRate;
                hospitalConsulationOperationData.NewCustomerDealPrice = addDto.NewCustomerDealPrice;
                hospitalConsulationOperationData.NewCustomerUnitPrice = addDto.NewCustomerUnitPrice;

                hospitalConsulationOperationData.OldCustomerVisitNum = addDto.OldCustomerVisitNum;
                hospitalConsulationOperationData.OldCustomerDealNum = addDto.OldCustomerDealNum;
                hospitalConsulationOperationData.OldCustomerDealRate = addDto.OldCustomerDealRate;
                hospitalConsulationOperationData.OldCustomerDealPrice = addDto.OldCustomerDealPrice;
                hospitalConsulationOperationData.OldCustomerUnitPrice = addDto.OldCustomerUnitPrice;

                hospitalConsulationOperationData.OldCustomerAchievementRate = addDto.OldCustomerAchievementRate;
                hospitalConsulationOperationData.LasttMonthTotalAchievement = addDto.LasttMonthTotalAchievement;
                hospitalConsulationOperationData.SectionOffice = addDto.SectionOffice;
                await dalHospitalConsulationOperationData.AddAsync(hospitalConsulationOperationData, true);


                await indicatorSendHospitalService.UpdateSubmitStateAsync(addDto.IndicatorId, addDto.HospitalId);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<HospitalConsulationOperationDataDto> GetByIdAsync(string id)
        {
            try
            {
                var hospitalConsulationOperationData = await dalHospitalConsulationOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (hospitalConsulationOperationData == null)
                    throw new Exception("机构咨询师运营数据编号错误");

                HospitalConsulationOperationDataDto hospitalConsulationOperationDataDto = new HospitalConsulationOperationDataDto();
                hospitalConsulationOperationDataDto.Id = hospitalConsulationOperationData.Id;
                hospitalConsulationOperationDataDto.CreateDate = hospitalConsulationOperationData.CreateDate;
                hospitalConsulationOperationDataDto.UpdateDate = hospitalConsulationOperationData.UpdateDate;
                hospitalConsulationOperationDataDto.DeleteDate = hospitalConsulationOperationData.DeleteDate;
                hospitalConsulationOperationDataDto.Valid = hospitalConsulationOperationData.Valid;
                hospitalConsulationOperationDataDto.HospitalId = hospitalConsulationOperationData.HospitalId;
                hospitalConsulationOperationDataDto.IndicatorId = hospitalConsulationOperationData.IndicatorId;
                hospitalConsulationOperationDataDto.HospitalId = hospitalConsulationOperationData.HospitalId;
                hospitalConsulationOperationDataDto.IndicatorId = hospitalConsulationOperationData.IndicatorId;
                hospitalConsulationOperationDataDto.ConsulationName = hospitalConsulationOperationData.ConsulationName;
                hospitalConsulationOperationDataDto.SendOrderNum = hospitalConsulationOperationData.SendOrderNum;
                hospitalConsulationOperationDataDto.NewCustomerVisitNum = hospitalConsulationOperationData.NewCustomerVisitNum;
                hospitalConsulationOperationDataDto.NewCustomerVisitRate = hospitalConsulationOperationData.NewCustomerVisitRate;
                hospitalConsulationOperationDataDto.NewCustomerDealNum = hospitalConsulationOperationData.NewCustomerDealNum;
                hospitalConsulationOperationDataDto.NewCustomerDealRate = hospitalConsulationOperationData.NewCustomerDealRate;
                hospitalConsulationOperationDataDto.NewCustomerDealPrice = hospitalConsulationOperationData.NewCustomerDealPrice;
                hospitalConsulationOperationDataDto.NewCustomerUnitPrice = hospitalConsulationOperationData.NewCustomerUnitPrice;

                hospitalConsulationOperationDataDto.OldCustomerVisitNum = hospitalConsulationOperationData.OldCustomerVisitNum;
                hospitalConsulationOperationDataDto.OldCustomerDealNum = hospitalConsulationOperationData.OldCustomerDealNum;
                hospitalConsulationOperationDataDto.OldCustomerDealRate = hospitalConsulationOperationData.OldCustomerDealRate;
                hospitalConsulationOperationDataDto.OldCustomerDealPrice = hospitalConsulationOperationData.OldCustomerDealPrice;
                hospitalConsulationOperationDataDto.OldCustomerUnitPrice = hospitalConsulationOperationData.OldCustomerUnitPrice;

                hospitalConsulationOperationDataDto.OldCustomerAchievementRate = hospitalConsulationOperationData.OldCustomerAchievementRate;
                hospitalConsulationOperationDataDto.LasttMonthTotalAchievement = hospitalConsulationOperationData.LasttMonthTotalAchievement;
                hospitalConsulationOperationDataDto.SectionOffice= hospitalConsulationOperationData.SectionOffice;
                return hospitalConsulationOperationDataDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(UpdateHospitalConsulationOperationDataDto updateDto)
        {
            try
            {
                var hospitalConsulationOperationData = await dalHospitalConsulationOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (hospitalConsulationOperationData == null)
                    throw new Exception("机构咨询师运营数据编号错误");

                hospitalConsulationOperationData.HospitalId = updateDto.HospitalId;
                hospitalConsulationOperationData.IndicatorId = updateDto.IndicatorId;
                hospitalConsulationOperationData.HospitalId = updateDto.HospitalId;
                hospitalConsulationOperationData.IndicatorId = updateDto.IndicatorId;
                hospitalConsulationOperationData.ConsulationName = updateDto.ConsulationName;
                hospitalConsulationOperationData.SendOrderNum = updateDto.SendOrderNum;
                hospitalConsulationOperationData.NewCustomerVisitNum = updateDto.NewCustomerVisitNum;
                hospitalConsulationOperationData.NewCustomerVisitRate = updateDto.NewCustomerVisitRate;
                hospitalConsulationOperationData.NewCustomerDealNum = updateDto.NewCustomerDealNum;
                hospitalConsulationOperationData.NewCustomerDealRate = updateDto.NewCustomerDealRate;
                hospitalConsulationOperationData.NewCustomerDealPrice = updateDto.NewCustomerDealPrice;
                hospitalConsulationOperationData.NewCustomerUnitPrice = updateDto.NewCustomerUnitPrice;

                hospitalConsulationOperationData.OldCustomerVisitNum = updateDto.OldCustomerVisitNum;
                hospitalConsulationOperationData.OldCustomerDealNum = updateDto.OldCustomerDealNum;
                hospitalConsulationOperationData.OldCustomerDealRate = updateDto.OldCustomerDealRate;
                hospitalConsulationOperationData.OldCustomerDealPrice = updateDto.OldCustomerDealPrice;
                hospitalConsulationOperationData.OldCustomerUnitPrice = updateDto.OldCustomerUnitPrice;

                hospitalConsulationOperationData.OldCustomerAchievementRate = updateDto.OldCustomerAchievementRate;
                hospitalConsulationOperationData.LasttMonthTotalAchievement = updateDto.LasttMonthTotalAchievement;
                hospitalConsulationOperationData.SectionOffice = updateDto.SectionOffice;
                hospitalConsulationOperationData.UpdateDate = DateTime.Now;

                await dalHospitalConsulationOperationData.UpdateAsync(hospitalConsulationOperationData, true);
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
                var hospitalConsulationOperationData = await dalHospitalConsulationOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalConsulationOperationData == null)
                    throw new Exception("机构咨询师运营数据编号错误");
                hospitalConsulationOperationData.DeleteDate = DateTime.Now;
                hospitalConsulationOperationData.Valid = false;

                await dalHospitalConsulationOperationData.UpdateAsync(hospitalConsulationOperationData, true);
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
                var hospitalConsulationOperationData = await dalHospitalConsulationOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalConsulationOperationData == null)
                    throw new Exception("机构咨询师运营数据编号错误");

                await dalHospitalConsulationOperationData.DeleteAsync(hospitalConsulationOperationData, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
