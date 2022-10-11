using Fx.Amiya.Dto.GreatHospitalDataWrite;
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
    public class GreatHospitalDataWriteService : IGreatHospitalDataWriteService
    {
        private IDalGreatHospitalDataWrite dalGreatHospitalDataWrite;
        public GreatHospitalDataWriteService(IDalGreatHospitalDataWrite dalGreatHospitalDataWrite)
        {
            this.dalGreatHospitalDataWrite = dalGreatHospitalDataWrite;
        }



        public async Task<List<GreatHospitalDataWriteDto>> GetListAsync(string keyword, string indicatorsId)
        {
            try
            {
                var greatHospitalDataWrite = from d in dalGreatHospitalDataWrite.GetAll().Include(x => x.HospitalOperationalIndicator)
                                             where (keyword == null || d.OperationName.Contains(keyword))
                                             && (d.IndicatorId == indicatorsId)
                                             && (d.Valid == true)

                                             select new GreatHospitalDataWriteDto
                                             {
                                                 Id = d.Id,
                                                 IndicatorId = d.IndicatorId,
                                                 IndicatorName = d.HospitalOperationalIndicator.Name,
                                                 GreatHospitalName = d.HospitalOperationalIndicator.ExcellentHospital,
                                                 OperationName = d.OperationName,
                                                 OperationValue = d.OperationValue,
                                             };

                List<GreatHospitalDataWriteDto> greatHospitalDataWriteList = new List<GreatHospitalDataWriteDto>();
                greatHospitalDataWriteList = await greatHospitalDataWrite.ToListAsync();
                return greatHospitalDataWriteList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task AddAsync(List<AddGreatHospitalDataWriteDto> addDto)
        {
            try
            {
                foreach (var x in addDto)
                {
                    GreatHospitalDataWrite greatHospitalDataWrite = new GreatHospitalDataWrite();
                    greatHospitalDataWrite.Id = Guid.NewGuid().ToString();
                    greatHospitalDataWrite.CreateDate = DateTime.Now;
                    greatHospitalDataWrite.Valid = true;
                    greatHospitalDataWrite.IndicatorId = x.IndicatorId;
                    greatHospitalDataWrite.OperationValue = x.OperationValue;
                    greatHospitalDataWrite.OperationName = x.OperationName;
                    await dalGreatHospitalDataWrite.AddAsync(greatHospitalDataWrite, true);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<GreatHospitalDataWriteDto> GetByIdAsync(string id)
        {
            try
            {
                var greatHospitalDataWrite = await dalGreatHospitalDataWrite.GetAll().SingleOrDefaultAsync(e => e.Id == id && e.Valid == true);
                if (greatHospitalDataWrite == null)
                    throw new Exception("优秀机构运营数据填报编号错误");

                GreatHospitalDataWriteDto greatHospitalDataWriteDto = new GreatHospitalDataWriteDto();
                greatHospitalDataWriteDto.Id = greatHospitalDataWrite.Id;
                greatHospitalDataWriteDto.CreateDate = greatHospitalDataWrite.CreateDate;
                greatHospitalDataWriteDto.UpdateDate = greatHospitalDataWrite.UpdateDate;
                greatHospitalDataWriteDto.DeleteDate = greatHospitalDataWrite.DeleteDate;
                greatHospitalDataWriteDto.Valid = greatHospitalDataWrite.Valid;
                greatHospitalDataWriteDto.IndicatorId = greatHospitalDataWrite.IndicatorId;
                greatHospitalDataWriteDto.OperationValue = greatHospitalDataWrite.OperationValue;
                greatHospitalDataWriteDto.OperationName = greatHospitalDataWrite.OperationName;
                return greatHospitalDataWriteDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<GreatHospitalDataWriteDto> GetByNameAndIndicatorIdAsync(string indicatorId, string operationName)
        {
            try
            {
                var greatHospitalDataWrite = await dalGreatHospitalDataWrite.GetAll().SingleOrDefaultAsync(e => e.IndicatorId == indicatorId && e.OperationName == operationName);
                if (greatHospitalDataWrite == null)
                    return new GreatHospitalDataWriteDto();

                GreatHospitalDataWriteDto greatHospitalDataWriteDto = new GreatHospitalDataWriteDto();
                greatHospitalDataWriteDto.Id = greatHospitalDataWrite.Id;
                greatHospitalDataWriteDto.CreateDate = greatHospitalDataWrite.CreateDate;
                greatHospitalDataWriteDto.UpdateDate = greatHospitalDataWrite.UpdateDate;
                greatHospitalDataWriteDto.DeleteDate = greatHospitalDataWrite.DeleteDate;
                greatHospitalDataWriteDto.Valid = greatHospitalDataWrite.Valid;
                greatHospitalDataWriteDto.IndicatorId = greatHospitalDataWrite.IndicatorId;
                greatHospitalDataWriteDto.OperationValue = greatHospitalDataWrite.OperationValue;
                greatHospitalDataWriteDto.OperationName = greatHospitalDataWrite.OperationName;
                return greatHospitalDataWriteDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateGreatHospitalDataWriteDto updateDto)
        {
            try
            {
                var greatHospitalDataWrite = await dalGreatHospitalDataWrite.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (greatHospitalDataWrite == null)
                    throw new Exception("优秀机构运营健康指标编号错误");

                greatHospitalDataWrite.IndicatorId = updateDto.IndicatorId;
                greatHospitalDataWrite.OperationValue = updateDto.OperationValue;
                greatHospitalDataWrite.OperationName = updateDto.OperationName;
                greatHospitalDataWrite.UpdateDate = DateTime.Now;

                await dalGreatHospitalDataWrite.UpdateAsync(greatHospitalDataWrite, true);
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
                var greatHospitalDataWrite = await dalGreatHospitalDataWrite.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (greatHospitalDataWrite == null)
                    throw new Exception("优秀机构运营健康指标编号错误");
                greatHospitalDataWrite.DeleteDate = DateTime.Now;
                greatHospitalDataWrite.Valid = false;

                await dalGreatHospitalDataWrite.UpdateAsync(greatHospitalDataWrite, true);
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
                var greatHospitalDataWrite = await dalGreatHospitalDataWrite.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (greatHospitalDataWrite == null)
                    throw new Exception("优秀机构运营健康指标编号错误");

                await dalGreatHospitalDataWrite.DeleteAsync(greatHospitalDataWrite, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
