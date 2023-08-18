using Fx.Amiya.Dto.RecommendHospital;
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
using Fx.Infrastructure.DataAccess;
using Fx.Common;

namespace Fx.Amiya.Service
{
    public class RecommendHospitalService : IRecommendHospitalService
    {
        private IDalRecommendHospitalInfo dalRecommendHospitalInfo;
        private IUnitOfWork unitOfWork;

        public RecommendHospitalService(IDalRecommendHospitalInfo dalRecommendHospitalInfo, IUnitOfWork unitOfWork)
        {
            this.dalRecommendHospitalInfo = dalRecommendHospitalInfo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<FxPageInfo<RecommendHospitalInfoDto>> GetListWithPageAsync(string hospitalName, DateTime? startDate, DateTime? endDate, int pageNum, int pageSize)
        {
            try
            {

                IQueryable<RecommendHospitalInfo> recommendHospital;
                if (startDate == null || endDate == null)
                {
                    recommendHospital = from d in dalRecommendHospitalInfo.GetAll()
                                        where hospitalName == null || d.HospitalInfo.Name.Contains(hospitalName)
                                        select d;
                }
                else
                {
                    DateTime startrq = ((DateTime)startDate).Date;
                    DateTime endrq = ((DateTime)endDate).Date.AddDays(1);

                    recommendHospital = from d in dalRecommendHospitalInfo.GetAll()
                                        where (hospitalName == null || d.HospitalInfo.Name.Contains(hospitalName))
                                        && (endrq>d.StartDate&&startrq<=d.EndDate)
                                        select d;
                }

                var recommendHospitalInfo = from d in recommendHospital
                                            select new RecommendHospitalInfoDto
                                            {
                                                Id = d.Id,
                                                HospitalId = d.HospitalId,
                                                HospitalName = d.HospitalInfo.Name,
                                                RecommendIndex = d.RecommendIndex,
                                                StartDate = d.StartDate,
                                                EndDate = d.EndDate,
                                                Valid = d.Valid,
                                                CreateDate = d.CreateDate,
                                                CreateBy = d.CreateBy,
                                                CreateName = d.CreateByAmiyaEmployee.Name,
                                                UpdateBy = d.UpdateBy,
                                                UpdateName = d.UpdateByAmiyaEmployee.Name
                                            };


                FxPageInfo<RecommendHospitalInfoDto> recommendPageInfo = new FxPageInfo<RecommendHospitalInfoDto>();
                recommendPageInfo.TotalCount = await recommendHospitalInfo.CountAsync();
                recommendPageInfo.List = await recommendHospitalInfo.OrderBy(e => e.RecommendIndex).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return recommendPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task AddAsync(AddRecommendHospitalInfoDto addDto, int employeeId)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var recommendHospital = from d in dalRecommendHospitalInfo.GetAll()
                                        where d.Valid
                                        && d.HospitalId == addDto.HospitalId
                                        && d.StartDate.Date < addDto.EndDate.Date
                                        && d.EndDate.Date >= addDto.StartDate.Date
                                        select d;

                if (await recommendHospital.CountAsync() > 0)
                    throw new Exception("该医院推荐存在时间冲突");


                var recommend = from d in dalRecommendHospitalInfo.GetAll()
                                where d.Valid
                                && d.RecommendIndex == addDto.RecommendIndex
                                && d.StartDate.Date < addDto.EndDate.Date
                                && d.EndDate.Date >= addDto.StartDate.Date
                                select d;


                if (await recommend.CountAsync() > 0)
                {
                    foreach (var item in await recommend.ToListAsync())
                    {
                        item.RecommendIndex = item.RecommendIndex + 1;
                        await dalRecommendHospitalInfo.UpdateAsync(item, true);
                    }
                }

                RecommendHospitalInfo recommendHospitalInfo = new RecommendHospitalInfo();
                recommendHospitalInfo.HospitalId = addDto.HospitalId;
                recommendHospitalInfo.RecommendIndex = addDto.RecommendIndex;
                recommendHospitalInfo.StartDate = addDto.StartDate.Date;
                recommendHospitalInfo.EndDate = addDto.EndDate.Date;
                recommendHospitalInfo.Valid = true;
                recommendHospitalInfo.CreateDate = DateTime.Now;
                recommendHospitalInfo.CreateBy = employeeId;
                await dalRecommendHospitalInfo.AddAsync(recommendHospitalInfo, true);

                unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task<RecommendHospitalInfoDto> GetByIdAsync(int id)
        {
            try
            {
                var recommendHospital = await dalRecommendHospitalInfo.GetAll()
                    .Include(e => e.HospitalInfo)
                    .Include(e => e.CreateByAmiyaEmployee)
                    .Include(e => e.UpdateByAmiyaEmployee)
                    .SingleOrDefaultAsync(e => e.Id == id);

                if (recommendHospital == null)
                    throw new Exception("医院推荐编号错误");

                RecommendHospitalInfoDto recommendHospitalInfo = new RecommendHospitalInfoDto();
                recommendHospitalInfo.Id = recommendHospital.Id;
                recommendHospitalInfo.HospitalId = recommendHospital.HospitalId;
                recommendHospitalInfo.HospitalName = recommendHospital.HospitalInfo.Name;
                recommendHospitalInfo.RecommendIndex = recommendHospital.RecommendIndex;
                recommendHospitalInfo.StartDate = recommendHospital.StartDate;
                recommendHospitalInfo.EndDate = recommendHospital.EndDate;
                recommendHospitalInfo.Valid = recommendHospital.Valid;
                recommendHospitalInfo.CreateDate = recommendHospital.CreateDate;
                recommendHospitalInfo.CreateBy = recommendHospital.CreateBy;
                recommendHospitalInfo.CreateName = recommendHospital.CreateByAmiyaEmployee.Name;
                recommendHospitalInfo.UpdateBy = recommendHospital.UpdateBy;
                recommendHospitalInfo.UpdateName = recommendHospital.UpdateByAmiyaEmployee?.Name;


                return recommendHospitalInfo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(UpdateRecommendHospitalInfoDto updateDto, int employeeId)
        {
            try
            {
                unitOfWork.BeginTransaction();

                if (updateDto.EndDate.Date <= DateTime.Now.Date)
                    throw new Exception("截止日期必须大于今天");

                var recommendHospitalInfo = await dalRecommendHospitalInfo.GetAll()
                    .SingleOrDefaultAsync(e => e.Id == updateDto.Id);

                if (recommendHospitalInfo == null)
                    throw new Exception("医院推荐编号错误");


                var recommendHospital = from d in dalRecommendHospitalInfo.GetAll()
                                        where d.Valid
                                        && d.HospitalId != recommendHospitalInfo.HospitalId
                                        && d.StartDate.Date < updateDto.EndDate.Date
                                        && d.EndDate.Date >= updateDto.StartDate.Date
                                        select d;

                if (await recommendHospital.CountAsync() > 0)
                    throw new Exception("该医院推荐存在时间冲突");


                var recommend = from d in dalRecommendHospitalInfo.GetAll()
                                where d.Valid
                                && d.RecommendIndex == updateDto.RecommendIndex
                                && d.StartDate.Date < updateDto.EndDate.Date
                                && d.EndDate.Date >= updateDto.StartDate.Date
                                select d;

                if (await recommend.CountAsync() > 0)
                {
                    foreach (var item in await recommend.ToListAsync())
                    {
                        item.RecommendIndex = item.RecommendIndex + 1;
                        await dalRecommendHospitalInfo.UpdateAsync(item, true);
                    }
                }

                recommendHospitalInfo.RecommendIndex = updateDto.RecommendIndex;
                recommendHospitalInfo.StartDate = updateDto.StartDate;
                recommendHospitalInfo.EndDate = updateDto.EndDate;
                recommendHospitalInfo.Valid = updateDto.Valid;
                recommendHospitalInfo.UpdateBy = employeeId;
                recommendHospitalInfo.UpdateDate = DateTime.Now;

                await dalRecommendHospitalInfo.UpdateAsync(recommendHospitalInfo, true);

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task DeleteAsync(int id)
        {
            try
            {
                var recommendHospitalInfo = await dalRecommendHospitalInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                await dalRecommendHospitalInfo.DeleteAsync(recommendHospitalInfo,true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
