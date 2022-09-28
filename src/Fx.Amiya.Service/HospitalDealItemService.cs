using Fx.Amiya.Dto.GreatHospitalOperationHealth;
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
using Fx.Amiya.Background.Api.Vo.HospitalDealGoodsOperation;
using Fx.Infrastructure.DataAccess;

namespace Fx.Amiya.Service
{
    public class HospitalDealItemService : IHospitalDealItemService
    {
        private IDalHospitalDealItem dalHospitalDealItem;
        private IIndicatorSendHospitalService indicatorSendHospitalService;
        private IUnitOfWork unitOfWork;

        public HospitalDealItemService(IDalHospitalDealItem dalHospitalDealItem,
            IIndicatorSendHospitalService indicatorSendHospitalService,
            IUnitOfWork unitOfWork)
        {
            this.dalHospitalDealItem = dalHospitalDealItem;
            this.indicatorSendHospitalService = indicatorSendHospitalService;
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<HospitalDealItemOperationDto>> GetListAsync(string keyword, string indicatorsId,int hospitalId)
        {
            try
            {
                var greatHospitalOperationHealth = from d in dalHospitalDealItem.GetAll().Include(x => x.HospitalInfo).Include(x => x.HospitalOperationalIndicator)
                                                   where (keyword == null || d.HospitalInfo.Name.Contains(keyword))
                                                   && (d.HospitalId == hospitalId)
                                                   && (d.IndicatorId == indicatorsId)
                                                   && (d.Valid == true)
                                                   select new HospitalDealItemOperationDto
                                                   {
                                                       Id = d.Id,
                                                       HospitalId = d.HospitalId,
                                                       IndicatorId = d.IndicatorId,
                                                       DealItemName = d.ItemName,
                                                       DealCount = d.DealCount,
                                                       DealPrice = d.DealPrice,
                                                       PerformanceRatio = d.PerformanceRatio,
                                                   };

                List<HospitalDealItemOperationDto> hospitalDealItemOperationList = new List<HospitalDealItemOperationDto>();
                hospitalDealItemOperationList = await greatHospitalOperationHealth.ToListAsync();
                return hospitalDealItemOperationList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task AddAsync(AddHospitalDealItemOperationDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                HospitalDealItem hospitalDealItemOperation = new HospitalDealItem();
                hospitalDealItemOperation.Id = Guid.NewGuid().ToString();
                hospitalDealItemOperation.CreateDate = DateTime.Now;
                hospitalDealItemOperation.Valid = true;
                hospitalDealItemOperation.HospitalId = addDto.HospitalId;
                hospitalDealItemOperation.IndicatorId = addDto.IndicatorId;
                hospitalDealItemOperation.ItemName = addDto.DealItemName;
                hospitalDealItemOperation.DealCount = addDto.DealCount;
                hospitalDealItemOperation.DealPrice = addDto.DealPrice;
                hospitalDealItemOperation.PerformanceRatio = addDto.PerformanceRatio;
                await dalHospitalDealItem.AddAsync(hospitalDealItemOperation, true);
                await indicatorSendHospitalService.UpdateSubmitStateAsync(addDto.IndicatorId, addDto.HospitalId);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }

        public async Task<HospitalDealItemOperationDto> GetByIdAsync(string id)
        {
            try
            {
                var hospitalDealItemOperation = await dalHospitalDealItem.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (hospitalDealItemOperation == null)
                    throw new Exception("优秀机构运营健康指标编号错误");

                HospitalDealItemOperationDto hospitalDealItemOperationDto = new HospitalDealItemOperationDto();
                hospitalDealItemOperationDto.Id = hospitalDealItemOperation.Id;
                hospitalDealItemOperationDto.CreateDate = hospitalDealItemOperation.CreateDate;
                hospitalDealItemOperationDto.UpdateDate = hospitalDealItemOperation.UpdateDate;
                hospitalDealItemOperationDto.DeleteDate = hospitalDealItemOperation.DeleteDate;
                hospitalDealItemOperationDto.Valid = hospitalDealItemOperation.Valid;
                hospitalDealItemOperationDto.HospitalId = hospitalDealItemOperation.HospitalId;
                hospitalDealItemOperationDto.IndicatorId = hospitalDealItemOperation.IndicatorId;
                hospitalDealItemOperationDto.DealItemName = hospitalDealItemOperation.ItemName;
                hospitalDealItemOperationDto.DealCount = hospitalDealItemOperation.DealCount;
                hospitalDealItemOperationDto.DealPrice = hospitalDealItemOperation.DealPrice;
                hospitalDealItemOperationDto.PerformanceRatio = hospitalDealItemOperation.PerformanceRatio;
                return hospitalDealItemOperationDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateHospitalDealItemOperationDto updateDto)
        {
            try
            {
                var hospitalDealItemOperation = await dalHospitalDealItem.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (hospitalDealItemOperation == null)
                    throw new Exception("优秀机构运营健康指标编号错误");

                hospitalDealItemOperation.HospitalId = updateDto.HospitalId;
                hospitalDealItemOperation.IndicatorId = updateDto.IndicatorId;
                hospitalDealItemOperation.UpdateDate = DateTime.Now;
                hospitalDealItemOperation.ItemName = updateDto.DealItemName;
                hospitalDealItemOperation.DealCount = updateDto.DealCount;
                hospitalDealItemOperation.DealPrice = updateDto.DealPrice;
                hospitalDealItemOperation.PerformanceRatio = updateDto.PerformanceRatio;
                await dalHospitalDealItem.UpdateAsync(hospitalDealItemOperation, true);
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
                var hospitalDealItemOperation = await dalHospitalDealItem.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalDealItemOperation == null)
                    throw new Exception("机构成交品项编号错误");
                hospitalDealItemOperation.DeleteDate = DateTime.Now;
                hospitalDealItemOperation.Valid = false;

                await dalHospitalDealItem.UpdateAsync(hospitalDealItemOperation, true);
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
                var hospitalDealItemOperation = await dalHospitalDealItem.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalDealItemOperation == null)
                    throw new Exception("机构成交品项编号错误");

                await dalHospitalDealItem.DeleteAsync(hospitalDealItemOperation, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
