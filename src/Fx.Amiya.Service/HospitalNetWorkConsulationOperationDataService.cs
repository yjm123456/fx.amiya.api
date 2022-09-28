using Fx.Amiya.Dto.HospitalNetWorkConsulationOperationData;
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

namespace Fx.Amiya.Service
{
    public class HospitalNetWorkConsulationOperationDataService : IHospitalNetWorkConsulationOperationDataService
    {
        private IDalHospitalNetWorkConsulationOperationData dalHospitalNetWorkConsulationOperationData;
        public HospitalNetWorkConsulationOperationDataService(IDalHospitalNetWorkConsulationOperationData dalHospitalNetWorkConsulationOperationData)
        {
            this.dalHospitalNetWorkConsulationOperationData = dalHospitalNetWorkConsulationOperationData;
        }



        public async Task<List<HospitalNetWorkConsulationOperationDataDto>> GetListAsync(string keyword, string indicatorsId)
        {
            try
            {
                var hospitalNetWorkConsulationOperationData = from d in dalHospitalNetWorkConsulationOperationData.GetAll().Include(x => x.HospitalInfo).Include(x => x.HospitalOperationalIndicator)
                                                              where (keyword == null || d.HospitalInfo.Name.Contains(keyword))
                                                              && (d.IndicatorId == indicatorsId)
                                                              && (d.Valid == true)
                                                              select new HospitalNetWorkConsulationOperationDataDto
                                                              {
                                                                  Id = d.Id,
                                                                  HospitalId = d.HospitalId,
                                                                  HospitalName = d.HospitalInfo.Name,
                                                                  IndicatorsId = d.IndicatorId,
                                                                  IndicatorsName = d.HospitalOperationalIndicator.Name,
                                                                  ConsulationName = d.ConsulationName,
                                                                  SendOrderNum = d.SendOrderNum,
                                                                  NewCustomerVisitNum = d.NewCustomerVisitNum,
                                                                  NewCustomerVisitRate = d.NewCustomerVisitRate,
                                                              };

                List<HospitalNetWorkConsulationOperationDataDto> hospitalNetWorkConsulationOperationDataList = new List<HospitalNetWorkConsulationOperationDataDto>();
                hospitalNetWorkConsulationOperationDataList = await hospitalNetWorkConsulationOperationData.ToListAsync();
                return hospitalNetWorkConsulationOperationDataList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task AddAsync(AddHospitalNetWorkConsulationOperationDataDto addDto)
        {
            try
            {
                HospitalNetWorkConsulationOperationData hospitalNetWorkConsulationOperationData = new HospitalNetWorkConsulationOperationData();
                hospitalNetWorkConsulationOperationData.Id = Guid.NewGuid().ToString();
                hospitalNetWorkConsulationOperationData.CreateDate = DateTime.Now;
                hospitalNetWorkConsulationOperationData.Valid = true;
                hospitalNetWorkConsulationOperationData.HospitalId = addDto.HospitalId;
                hospitalNetWorkConsulationOperationData.IndicatorId = addDto.IndicatorId;
                hospitalNetWorkConsulationOperationData.ConsulationName = addDto.ConsulationName;
                hospitalNetWorkConsulationOperationData.SendOrderNum = addDto.SendOrderNum;
                hospitalNetWorkConsulationOperationData.NewCustomerVisitNum = addDto.NewCustomerVisitNum;
                hospitalNetWorkConsulationOperationData.NewCustomerVisitRate = addDto.NewCustomerVisitRate;
                await dalHospitalNetWorkConsulationOperationData.AddAsync(hospitalNetWorkConsulationOperationData, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<HospitalNetWorkConsulationOperationDataDto> GetByIdAsync(string id)
        {
            try
            {
                var hospitalNetWorkConsulationOperationData = await dalHospitalNetWorkConsulationOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (hospitalNetWorkConsulationOperationData == null)
                    throw new Exception("机构网咨运营数据编号错误");

                HospitalNetWorkConsulationOperationDataDto hospitalNetWorkConsulationOperationDataDto = new HospitalNetWorkConsulationOperationDataDto();
                hospitalNetWorkConsulationOperationDataDto.Id = hospitalNetWorkConsulationOperationData.Id;
                hospitalNetWorkConsulationOperationDataDto.CreateDate = hospitalNetWorkConsulationOperationData.CreateDate;
                hospitalNetWorkConsulationOperationDataDto.UpdateDate = hospitalNetWorkConsulationOperationData.UpdateDate;
                hospitalNetWorkConsulationOperationDataDto.DeleteDate = hospitalNetWorkConsulationOperationData.DeleteDate;
                hospitalNetWorkConsulationOperationDataDto.Valid = hospitalNetWorkConsulationOperationData.Valid;
                hospitalNetWorkConsulationOperationDataDto.HospitalId = hospitalNetWorkConsulationOperationData.HospitalId;
                hospitalNetWorkConsulationOperationDataDto.IndicatorsId = hospitalNetWorkConsulationOperationData.IndicatorId;
                hospitalNetWorkConsulationOperationDataDto.ConsulationName = hospitalNetWorkConsulationOperationData.ConsulationName;
                hospitalNetWorkConsulationOperationDataDto.SendOrderNum = hospitalNetWorkConsulationOperationData.SendOrderNum;
                hospitalNetWorkConsulationOperationDataDto.NewCustomerVisitNum = hospitalNetWorkConsulationOperationData.NewCustomerVisitNum;
                hospitalNetWorkConsulationOperationDataDto.NewCustomerVisitRate = hospitalNetWorkConsulationOperationData.NewCustomerVisitRate;
                return hospitalNetWorkConsulationOperationDataDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateHospitalNetWorkConsulationOperationDataDto updateDto)
        {
            try
            {
                var hospitalNetWorkConsulationOperationData = await dalHospitalNetWorkConsulationOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (hospitalNetWorkConsulationOperationData == null)
                    throw new Exception("机构网咨运营数据编号错误");

                hospitalNetWorkConsulationOperationData.HospitalId = updateDto.HospitalId;
                hospitalNetWorkConsulationOperationData.IndicatorId = updateDto.IndicatorsId;
                hospitalNetWorkConsulationOperationData.ConsulationName = updateDto.ConsulationName;
                hospitalNetWorkConsulationOperationData.SendOrderNum = updateDto.SendOrderNum;
                hospitalNetWorkConsulationOperationData.NewCustomerVisitNum = updateDto.NewCustomerVisitNum;
                hospitalNetWorkConsulationOperationData.NewCustomerVisitRate = updateDto.NewCustomerVisitRate;
                hospitalNetWorkConsulationOperationData.UpdateDate = DateTime.Now;

                await dalHospitalNetWorkConsulationOperationData.UpdateAsync(hospitalNetWorkConsulationOperationData, true);
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
                var hospitalNetWorkConsulationOperationData = await dalHospitalNetWorkConsulationOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalNetWorkConsulationOperationData == null)
                    throw new Exception("机构网咨运营数据编号错误");
                hospitalNetWorkConsulationOperationData.DeleteDate = DateTime.Now;
                hospitalNetWorkConsulationOperationData.Valid = false;

                await dalHospitalNetWorkConsulationOperationData.UpdateAsync(hospitalNetWorkConsulationOperationData, true);
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
                var hospitalNetWorkConsulationOperationData = await dalHospitalNetWorkConsulationOperationData.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalNetWorkConsulationOperationData == null)
                    throw new Exception("机构网咨运营数据编号错误");

                await dalHospitalNetWorkConsulationOperationData.DeleteAsync(hospitalNetWorkConsulationOperationData, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
