using Fx.Amiya.Dto.HospitalDoctorOperationData;
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
    public class HospitalDoctorOperationDataService : IHospitalDoctorOperationDataService
    {
        private IDalHospitalDoctorOperationData dalHospitalDoctorOperationData;
        private IIndicatorSendHospitalService indicatorSendHospitalService;
        private IUnitOfWork unitOfWork;
        public HospitalDoctorOperationDataService(IDalHospitalDoctorOperationData dalHospitalDoctorOperationData,
            IIndicatorSendHospitalService indicatorSendHospitalService,
            IUnitOfWork unitOfWork)
        {
            this.dalHospitalDoctorOperationData = dalHospitalDoctorOperationData;
            this.indicatorSendHospitalService = indicatorSendHospitalService;
            this.unitOfWork = unitOfWork;
        }



        public async Task<List<HospitalDoctorOperationDataDto>> GetListAsync(string keyword, string indicatorsId, int hospitalId)
        {
            try
            {
                var hospitalDoctorOperationData = from d in dalHospitalDoctorOperationData.GetAll().Include(x => x.HospitalInfo).Include(x => x.HospitalOperationalIndicator)
                                                  where (keyword == null || d.HospitalInfo.Name.Contains(keyword))
                                                  && (d.HospitalId == hospitalId)
                                                  && (d.IndicatorId == indicatorsId)
                                                  && (d.Valid == true)
                                                  select new HospitalDoctorOperationDataDto
                                                  {
                                                      Id = d.Id,
                                                      HospitalId = d.HospitalId,
                                                      IndicatorId = d.IndicatorId,
                                                      DoctorName = d.DoctorName,
                                                      NewCustomerAcceptNum = d.NewCustomerAcceptNum,
                                                      NewCustomerDealNum = d.NewCustomerDealNum,
                                                      NewCustomerDealRate = d.NewCustomerDealRate,
                                                      NewCustomerAchievement = d.NewCustomerAchievement,
                                                      NewCustomerUnitPrice = d.NewCustomerUnitPrice,
                                                      NewCustomerAchievementRate = d.NewCustomerAchievementRate,
                                                      OldCustomerAcceptNum = d.OldCustomerAcceptNum,
                                                      OldCustomerDealNum = d.OldCustomerDealNum,
                                                      OldCustomerDealRate = d.OldCustomerDealRate,
                                                      OldCustomerAchievement = d.OldCustomerAchievement,
                                                      OldCustomerUnitPrice = d.OldCustomerUnitPrice,
                                                      OldCustomerAchievementRate = d.OldCustomerAchievementRate,
                                                      SectionOffice=d.SectionOffice,
                                                      TotalPerformance=d.TotalPerformance
                                                  };

                List<HospitalDoctorOperationDataDto> hospitalDoctorOperationDataList = new List<HospitalDoctorOperationDataDto>();
                hospitalDoctorOperationDataList = await hospitalDoctorOperationData.ToListAsync();
                return hospitalDoctorOperationDataList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



        public async Task AddAsync(AddHospitalDoctorOperationDataDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                HospitalDoctorOperationData hospitalDoctorOperationData = new HospitalDoctorOperationData();
                hospitalDoctorOperationData.Id = Guid.NewGuid().ToString();
                hospitalDoctorOperationData.CreateDate = DateTime.Now;
                hospitalDoctorOperationData.Valid = true;
                hospitalDoctorOperationData.HospitalId = addDto.HospitalId;
                hospitalDoctorOperationData.IndicatorId = addDto.IndicatorId;
                hospitalDoctorOperationData.DoctorName = addDto.DoctorName;
                hospitalDoctorOperationData.SectionOffice = addDto.SectionOffice;
                hospitalDoctorOperationData.NewCustomerAcceptNum = addDto.NewCustomerAcceptNum;
                hospitalDoctorOperationData.NewCustomerDealNum = addDto.NewCustomerDealNum;
                hospitalDoctorOperationData.NewCustomerDealRate = addDto.NewCustomerDealRate;
                hospitalDoctorOperationData.NewCustomerAchievement = addDto.NewCustomerAchievement;
                hospitalDoctorOperationData.NewCustomerUnitPrice = addDto.NewCustomerUnitPrice;
                hospitalDoctorOperationData.NewCustomerAchievementRate = addDto.NewCustomerAchievementRate;
                hospitalDoctorOperationData.OldCustomerAcceptNum = addDto.OldCustomerAcceptNum;
                hospitalDoctorOperationData.OldCustomerDealNum = addDto.OldCustomerDealNum;
                hospitalDoctorOperationData.OldCustomerDealRate = addDto.OldCustomerDealRate;
                hospitalDoctorOperationData.OldCustomerAchievement = addDto.OldCustomerAchievement;
                hospitalDoctorOperationData.OldCustomerUnitPrice = addDto.OldCustomerUnitPrice;
                hospitalDoctorOperationData.OldCustomerAchievementRate = addDto.OldCustomerAchievementRate;
                hospitalDoctorOperationData.TotalPerformance = addDto.TotalPerformance;
                await dalHospitalDoctorOperationData.AddAsync(hospitalDoctorOperationData, true);
                await indicatorSendHospitalService.UpdateSubmitStateAsync(addDto.IndicatorId, addDto.HospitalId);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {

                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<HospitalDoctorOperationDataDto> GetByIdAsync(string id)
        {
            try
            {
                var hospitalDoctorOperationData = await dalHospitalDoctorOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (hospitalDoctorOperationData == null)
                    throw new Exception("机构医生运营指标编号错误");

                HospitalDoctorOperationDataDto hospitalDoctorOperationDataDto = new HospitalDoctorOperationDataDto();
                hospitalDoctorOperationDataDto.Id = hospitalDoctorOperationData.Id;
                hospitalDoctorOperationDataDto.CreateDate = hospitalDoctorOperationData.CreateDate;
                hospitalDoctorOperationDataDto.UpdateDate = hospitalDoctorOperationData.UpdateDate;
                hospitalDoctorOperationDataDto.DeleteDate = hospitalDoctorOperationData.DeleteDate;
                hospitalDoctorOperationDataDto.Valid = hospitalDoctorOperationData.Valid;
                hospitalDoctorOperationDataDto.HospitalId = hospitalDoctorOperationData.HospitalId;
                hospitalDoctorOperationDataDto.IndicatorId = hospitalDoctorOperationData.IndicatorId;
                hospitalDoctorOperationDataDto.DoctorName = hospitalDoctorOperationData.DoctorName;
                hospitalDoctorOperationDataDto.NewCustomerAcceptNum = hospitalDoctorOperationData.NewCustomerAcceptNum;
                hospitalDoctorOperationDataDto.NewCustomerDealNum = hospitalDoctorOperationData.NewCustomerDealNum;
                hospitalDoctorOperationDataDto.NewCustomerDealRate = hospitalDoctorOperationData.NewCustomerDealRate;
                hospitalDoctorOperationDataDto.NewCustomerAchievement = hospitalDoctorOperationData.NewCustomerAchievement;
                hospitalDoctorOperationDataDto.NewCustomerUnitPrice = hospitalDoctorOperationData.NewCustomerUnitPrice;
                hospitalDoctorOperationDataDto.NewCustomerAchievementRate = hospitalDoctorOperationData.NewCustomerAchievementRate;
                hospitalDoctorOperationDataDto.OldCustomerAcceptNum = hospitalDoctorOperationData.OldCustomerAcceptNum;
                hospitalDoctorOperationDataDto.OldCustomerDealNum = hospitalDoctorOperationData.OldCustomerDealNum;
                hospitalDoctorOperationDataDto.OldCustomerDealRate = hospitalDoctorOperationData.OldCustomerDealRate;
                hospitalDoctorOperationDataDto.OldCustomerAchievement = hospitalDoctorOperationData.OldCustomerAchievement;
                hospitalDoctorOperationDataDto.OldCustomerUnitPrice = hospitalDoctorOperationData.OldCustomerUnitPrice;
                hospitalDoctorOperationDataDto.OldCustomerAchievementRate = hospitalDoctorOperationData.OldCustomerAchievementRate;
                hospitalDoctorOperationDataDto.SectionOffice = hospitalDoctorOperationData.SectionOffice;
                hospitalDoctorOperationDataDto.TotalPerformance = hospitalDoctorOperationData.TotalPerformance;
                return hospitalDoctorOperationDataDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(UpdateHospitalDoctorOperationDataDto updateDto)
        {
            try
            {
                var hospitalDoctorOperationData = await dalHospitalDoctorOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (hospitalDoctorOperationData == null)
                    throw new Exception("机构医生运营指标编号错误");

                hospitalDoctorOperationData.HospitalId = updateDto.HospitalId;
                hospitalDoctorOperationData.IndicatorId = updateDto.IndicatorId;
                hospitalDoctorOperationData.DoctorName = updateDto.DoctorName;
                hospitalDoctorOperationData.NewCustomerAcceptNum = updateDto.NewCustomerAcceptNum;
                hospitalDoctorOperationData.NewCustomerDealNum = updateDto.NewCustomerDealNum;
                hospitalDoctorOperationData.NewCustomerDealRate = updateDto.NewCustomerDealRate;
                hospitalDoctorOperationData.NewCustomerAchievement = updateDto.NewCustomerAchievement;
                hospitalDoctorOperationData.NewCustomerUnitPrice = updateDto.NewCustomerUnitPrice;
                hospitalDoctorOperationData.NewCustomerAchievementRate = updateDto.NewCustomerAchievementRate;
                hospitalDoctorOperationData.OldCustomerAcceptNum = updateDto.OldCustomerAcceptNum;
                hospitalDoctorOperationData.OldCustomerDealNum = updateDto.OldCustomerDealNum;
                hospitalDoctorOperationData.OldCustomerDealRate = updateDto.OldCustomerDealRate;
                hospitalDoctorOperationData.OldCustomerAchievement = updateDto.OldCustomerAchievement;
                hospitalDoctorOperationData.OldCustomerUnitPrice = updateDto.OldCustomerUnitPrice;
                hospitalDoctorOperationData.OldCustomerAchievementRate = updateDto.OldCustomerAchievementRate;
                hospitalDoctorOperationData.UpdateDate = DateTime.Now;
                hospitalDoctorOperationData.SectionOffice = updateDto.SectionOffice;
                hospitalDoctorOperationData.TotalPerformance = updateDto.TotalPerformance;

                await dalHospitalDoctorOperationData.UpdateAsync(hospitalDoctorOperationData, true);
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
                var hospitalDoctorOperationData = await dalHospitalDoctorOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalDoctorOperationData == null)
                    throw new Exception("优秀机构运营健康指标编号错误");
                hospitalDoctorOperationData.DeleteDate = DateTime.Now;
                hospitalDoctorOperationData.Valid = false;

                await dalHospitalDoctorOperationData.UpdateAsync(hospitalDoctorOperationData, true);
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
                var hospitalDoctorOperationData = await dalHospitalDoctorOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalDoctorOperationData == null)
                    throw new Exception("优秀机构运营健康指标编号错误");

                await dalHospitalDoctorOperationData.DeleteAsync(hospitalDoctorOperationData, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
