using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.AmiyaRemark;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class AmiyaRemarkService : IAmiyaRemarkService
    {
        private readonly IDalAmiyaRemark dalAmiyaRemark;
        private readonly IIndicatorSendHospitalService indicatorSendHospitalService;
        private readonly IUnitOfWork unitOfWork;

        public AmiyaRemarkService(IDalAmiyaRemark dalAmiyaRemark, IIndicatorSendHospitalService indicatorSendHospitalService, IUnitOfWork unitOfWork)
        {
            this.dalAmiyaRemark = dalAmiyaRemark;
            this.indicatorSendHospitalService = indicatorSendHospitalService;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddAsync(AddAmeiyRemarkDto addDto)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var improveRemark = await dalAmiyaRemark.GetAll().Where(e => e.IndicatorId == addDto.IndicatorId && e.HospitalId == addDto.HospitalId && e.Sort == addDto.Sort && e.Type == addDto.Type).SingleOrDefaultAsync();
                if (improveRemark == null)
                {
                    AmiyaRemark improvePlanAndRemark = new AmiyaRemark();
                    improvePlanAndRemark.Id = Guid.NewGuid().ToString();
                    improvePlanAndRemark.IndicatorId = addDto.IndicatorId;
                    improvePlanAndRemark.HospitalId = addDto.HospitalId;
                    improvePlanAndRemark.Type = addDto.Type;
                    improvePlanAndRemark.Content = addDto.Content;
                    improvePlanAndRemark.Sort = addDto.Sort;
                    improvePlanAndRemark.CreateDate = DateTime.Now;
                    improvePlanAndRemark.Valid = true;
                    await dalAmiyaRemark.AddAsync(improvePlanAndRemark, true);
                    await indicatorSendHospitalService.UpdateRemarkStatusAsync(addDto.IndicatorId,addDto.HospitalId);
                }
                else
                {
                    improveRemark.IndicatorId = addDto.IndicatorId;
                    improveRemark.HospitalId = addDto.HospitalId;
                    improveRemark.Type = addDto.Type;
                    improveRemark.Content = addDto.Content;
                    improveRemark.Sort = addDto.Sort;
                    improveRemark.UpdateDate = DateTime.Now;
                    await dalAmiyaRemark.UpdateAsync(improveRemark, true);                  
                }
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }

        public async Task DeleteAsync(string indicatorsId, int hospitalId)
        {
            var remarks = dalAmiyaRemark.GetAll().Where(e => e.HospitalId == hospitalId && e.IndicatorId == indicatorsId).ToList();
            foreach (var item in remarks)
            {
                await dalAmiyaRemark.DeleteAsync(item, true);
            }
        }

        public async Task<Dictionary<string, List<AmeiyRemarkDto>>> GetImproveAndRemark(string indicatorsId, int hospitalId)
        {
            Dictionary<string, List<AmeiyRemarkDto>> dic = new Dictionary<string, List<AmeiyRemarkDto>>();
            dic.Add("运营优点", new List<AmeiyRemarkDto>());
            dic.Add("运营不足", new List<AmeiyRemarkDto>());
            dic.Add("提升计划", new List<AmeiyRemarkDto>());
            dic.Add("运营需求", new List<AmeiyRemarkDto>());
            var remark = dalAmiyaRemark.GetAll().Where(e => e.IndicatorId == indicatorsId && e.HospitalId == hospitalId && e.Valid == true).ToList().GroupBy(e => e.Type);
            foreach (var item in remark)
            {
                var list = item.Select(e => new AmeiyRemarkDto
                {
                    IndicatorId = e.IndicatorId,
                    HospitalId = e.HospitalId,
                    Type = e.Type,
                    Sort = e.Sort,
                    Content = e.Content,
                }).OrderBy(e => e.Sort).ToList();
                dic[item.Key] = list;
                /*dic.Add(item.Key, list);*/
            }

            
            return dic;
        }

        public async Task UpdateImproveAndRemark(UpdateAmeiyRemarkDto updateDto)
        {
            AmiyaRemark remark = new AmiyaRemark();
            remark.Id = Guid.NewGuid().ToString().Replace("-", "");
            remark.IndicatorId = updateDto.IndicatorId;
            remark.HospitalId = updateDto.HospitalId;
            remark.Type = updateDto.Type;
            remark.Sort = updateDto.Sort;
            remark.Content = updateDto.Content;
            remark.CreateDate = DateTime.Now;
            remark.Valid = true;
            dalAmiyaRemark.Add(remark, true);
        }
    }
}
