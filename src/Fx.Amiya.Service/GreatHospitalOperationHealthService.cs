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

namespace Fx.Amiya.Service
{
    public class GreatHospitalOperationHealthService : IGreatHospitalOperationHealthService
    {
        private IDalGreatHospitalOperationHealth dalGreatHospitalOperationHealth;
        public GreatHospitalOperationHealthService(IDalGreatHospitalOperationHealth dalGreatHospitalOperationHealth)
        {
            this.dalGreatHospitalOperationHealth = dalGreatHospitalOperationHealth;
        }



        public async Task<List<GreatHospitalOperationHealthDto>> GetListAsync(string keyword, string indicatorsId)
        {
            try
            {
                var greatHospitalOperationHealth = from d in dalGreatHospitalOperationHealth.GetAll().Include(x => x.HospitalInfo).Include(x => x.HospitalOperationalIndicator)
                                                   where (keyword == null || d.HospitalInfo.Name.Contains(keyword))
                                                   && (d.IndicatorId == indicatorsId)
                                                   && (d.Valid == true)
                                                   select new GreatHospitalOperationHealthDto
                                                   {
                                                       Id = d.Id,
                                                       HospitalId = d.HospitalId,
                                                       HospitalName = d.HospitalInfo.Name,
                                                       IndicatorId = d.IndicatorId,
                                                       IndicatorsName = d.HospitalOperationalIndicator.Name,
                                                       LastNewCustomerVisitRate = d.LastNewCustomerVisitRate,
                                                       ThisNewCustomerVisitRate = d.ThisNewCustomerVisitRate,
                                                       NewCustomerVisitChainRatio = d.NewCustomerVisitChainRatio,
                                                       LastNewCustomerDealRate = d.LastNewCustomerDealRate,
                                                       ThisNewCustomerDealRate = d.ThisNewCustomerDealRate,
                                                       NewCustomerDealChainRatio = d.NewCustomerDealChainRatio,
                                                       LastNewCustomerUnitPrice = d.LastNewCustomerUnitPrice,
                                                       ThisNewCustomerUnitPrice = d.ThisNewCustomerUnitPrice,
                                                       NewCustomerUnitPriceChainRatio = d.NewCustomerUnitPriceChainRatio,
                                                   };

                List<GreatHospitalOperationHealthDto> greatHospitalOperationHealthList = new List<GreatHospitalOperationHealthDto>();
                greatHospitalOperationHealthList = await greatHospitalOperationHealth.ToListAsync();
                return greatHospitalOperationHealthList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task AddAsync(AddGreatHospitalOperationHealthDto addDto)
        {
            try
            {
                GreatHospitalOperationHealth greatHospitalOperationHealth = new GreatHospitalOperationHealth();
                greatHospitalOperationHealth.Id = Guid.NewGuid().ToString();
                greatHospitalOperationHealth.CreateDate = DateTime.Now;
                greatHospitalOperationHealth.Valid = true;
                greatHospitalOperationHealth.HospitalId = addDto.HospitalId;
                greatHospitalOperationHealth.IndicatorId = addDto.IndicatorsId;
                greatHospitalOperationHealth.LastNewCustomerVisitRate = addDto.LastNewCustomerVisitRate;
                greatHospitalOperationHealth.ThisNewCustomerVisitRate = addDto.ThisNewCustomerVisitRate;
                greatHospitalOperationHealth.NewCustomerVisitChainRatio = addDto.NewCustomerVisitChainRatio;
                greatHospitalOperationHealth.LastNewCustomerDealRate = addDto.LastNewCustomerDealRate;
                greatHospitalOperationHealth.ThisNewCustomerDealRate = addDto.ThisNewCustomerDealRate;
                greatHospitalOperationHealth.NewCustomerDealChainRatio = addDto.NewCustomerDealChainRatio;
                greatHospitalOperationHealth.LastNewCustomerUnitPrice = addDto.LastNewCustomerUnitPrice;
                greatHospitalOperationHealth.ThisNewCustomerUnitPrice = addDto.ThisNewCustomerUnitPrice;
                greatHospitalOperationHealth.NewCustomerUnitPriceChainRatio = addDto.NewCustomerUnitPriceChainRatio;
                await dalGreatHospitalOperationHealth.AddAsync(greatHospitalOperationHealth, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<GreatHospitalOperationHealthDto> GetByIdAsync(string id)
        {
            try
            {
                var greatHospitalOperationHealth = await dalGreatHospitalOperationHealth.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (greatHospitalOperationHealth == null)
                    throw new Exception("优秀机构运营健康指标编号错误");

                GreatHospitalOperationHealthDto greatHospitalOperationHealthDto = new GreatHospitalOperationHealthDto();
                greatHospitalOperationHealthDto.Id = greatHospitalOperationHealth.Id;
                greatHospitalOperationHealthDto.CreateDate = greatHospitalOperationHealth.CreateDate;
                greatHospitalOperationHealthDto.UpdateDate = greatHospitalOperationHealth.UpdateDate;
                greatHospitalOperationHealthDto.DeleteDate = greatHospitalOperationHealth.DeleteDate;
                greatHospitalOperationHealthDto.Valid = greatHospitalOperationHealth.Valid;
                greatHospitalOperationHealthDto.HospitalId = greatHospitalOperationHealth.HospitalId;
                greatHospitalOperationHealthDto.IndicatorId = greatHospitalOperationHealth.IndicatorId;
                greatHospitalOperationHealthDto.LastNewCustomerVisitRate = greatHospitalOperationHealth.LastNewCustomerVisitRate;
                greatHospitalOperationHealthDto.ThisNewCustomerVisitRate = greatHospitalOperationHealth.ThisNewCustomerVisitRate;
                greatHospitalOperationHealthDto.NewCustomerVisitChainRatio = greatHospitalOperationHealth.NewCustomerVisitChainRatio;
                greatHospitalOperationHealthDto.LastNewCustomerDealRate = greatHospitalOperationHealth.LastNewCustomerDealRate;
                greatHospitalOperationHealthDto.ThisNewCustomerDealRate = greatHospitalOperationHealth.ThisNewCustomerDealRate;
                greatHospitalOperationHealthDto.NewCustomerDealChainRatio = greatHospitalOperationHealth.NewCustomerDealChainRatio;
                greatHospitalOperationHealthDto.LastNewCustomerUnitPrice = greatHospitalOperationHealth.LastNewCustomerUnitPrice;
                greatHospitalOperationHealthDto.ThisNewCustomerUnitPrice = greatHospitalOperationHealth.ThisNewCustomerUnitPrice;
                greatHospitalOperationHealthDto.NewCustomerUnitPriceChainRatio = greatHospitalOperationHealth.NewCustomerUnitPriceChainRatio;
                return greatHospitalOperationHealthDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateGreatHospitalOperationHealthDto updateDto)
        {
            try
            {
                var greatHospitalOperationHealth = await dalGreatHospitalOperationHealth.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (greatHospitalOperationHealth == null)
                    throw new Exception("优秀机构运营健康指标编号错误");

                greatHospitalOperationHealth.HospitalId = updateDto.HospitalId;
                greatHospitalOperationHealth.IndicatorId = updateDto.IndicatorsId;
                greatHospitalOperationHealth.LastNewCustomerVisitRate = updateDto.LastNewCustomerVisitRate;
                greatHospitalOperationHealth.ThisNewCustomerVisitRate = updateDto.ThisNewCustomerVisitRate;
                greatHospitalOperationHealth.NewCustomerVisitChainRatio = updateDto.NewCustomerVisitChainRatio;
                greatHospitalOperationHealth.LastNewCustomerDealRate = updateDto.LastNewCustomerDealRate;
                greatHospitalOperationHealth.ThisNewCustomerDealRate = updateDto.ThisNewCustomerDealRate;
                greatHospitalOperationHealth.NewCustomerDealChainRatio = updateDto.NewCustomerDealChainRatio;
                greatHospitalOperationHealth.LastNewCustomerUnitPrice = updateDto.LastNewCustomerUnitPrice;
                greatHospitalOperationHealth.ThisNewCustomerUnitPrice = updateDto.ThisNewCustomerUnitPrice;
                greatHospitalOperationHealth.NewCustomerUnitPriceChainRatio = updateDto.NewCustomerUnitPriceChainRatio;
                greatHospitalOperationHealth.UpdateDate = DateTime.Now;

                await dalGreatHospitalOperationHealth.UpdateAsync(greatHospitalOperationHealth, true);
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
                var greatHospitalOperationHealth = await dalGreatHospitalOperationHealth.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);

                if (greatHospitalOperationHealth == null)
                    throw new Exception("优秀机构运营健康指标编号错误");
                greatHospitalOperationHealth.DeleteDate = DateTime.Now;
                greatHospitalOperationHealth.Valid = false;

                await dalGreatHospitalOperationHealth.UpdateAsync(greatHospitalOperationHealth, true);
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
                var greatHospitalOperationHealth = await dalGreatHospitalOperationHealth.GetAll().Include(e => e.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);

                if (greatHospitalOperationHealth == null)
                    throw new Exception("优秀机构运营健康指标编号错误");

                await dalGreatHospitalOperationHealth.DeleteAsync(greatHospitalOperationHealth, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
