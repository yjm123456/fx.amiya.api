using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ImprovePlanAndRemark;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure.DataAccess;
using Fx.Infrastructure.DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class ImprovePlanAndRemarkService : IImprovePlanAndRemarkService
    {
        private readonly IDalImprovePlanAndRemark dalImprovePlanAndRemark;
        private readonly IIndicatorSendHospitalService indicatorSendHospitalService;
        private readonly IUnitOfWork unitOfWork;

        public ImprovePlanAndRemarkService(IDalImprovePlanAndRemark dalImprovePlanAndRemark, IIndicatorSendHospitalService indicatorSendHospitalService, IUnitOfWork unitOfWork)
        {
            this.dalImprovePlanAndRemark = dalImprovePlanAndRemark;
            this.indicatorSendHospitalService = indicatorSendHospitalService;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddAsync(AddImprovePlanAndRemarkDto addDto)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var improveRemark = await dalImprovePlanAndRemark.GetAll().Where(e => e.IndicatorId == addDto.IndicatorId && e.HospitalId == addDto.HospitalId && e.Sort == addDto.Sort && e.Type == addDto.Type).SingleOrDefaultAsync();
                if (improveRemark == null)
                {
                    ImprovePlanAndRemark improvePlanAndRemark = new ImprovePlanAndRemark();
                    improvePlanAndRemark.Id = Guid.NewGuid().ToString();
                    improvePlanAndRemark.IndicatorId = addDto.IndicatorId;
                    improvePlanAndRemark.HospitalId = addDto.HospitalId;
                    improvePlanAndRemark.Type = addDto.Type;
                    improvePlanAndRemark.Content = addDto.Content;
                    improvePlanAndRemark.Sort = addDto.Sort;
                    improvePlanAndRemark.CreateDate = DateTime.Now;
                    improvePlanAndRemark.Valid = true;
                    await dalImprovePlanAndRemark.AddAsync(improvePlanAndRemark, true);
                    await indicatorSendHospitalService.UpdateRemarkStatusAsync(addDto.IndicatorId, addDto.HospitalId);
                }
                else
                {
                    improveRemark.IndicatorId = addDto.IndicatorId;
                    improveRemark.HospitalId = addDto.HospitalId;
                    improveRemark.Type = addDto.Type;
                    improveRemark.Content = addDto.Content;
                    improveRemark.Sort = addDto.Sort;
                    improveRemark.UpdateDate = DateTime.Now;
                    await dalImprovePlanAndRemark.UpdateAsync(improveRemark, true);
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
            var remarks = dalImprovePlanAndRemark.GetAll().Where(e => e.HospitalId == hospitalId && e.IndicatorId == indicatorsId).ToList();
            foreach (var item in remarks)
            {
                await dalImprovePlanAndRemark.DeleteAsync(item, true);
            }
        }

        public async Task<Dictionary<string, List<ImprovePlanAndRemarkDto>>> GetImproveAndRemark(string indicatorsId, int hospitalId)
        {
            Dictionary<string, List<ImprovePlanAndRemarkDto>> dic = new Dictionary<string, List<ImprovePlanAndRemarkDto>>();
            var remark = dalImprovePlanAndRemark.GetAll().Where(e => e.IndicatorId == indicatorsId && e.HospitalId == hospitalId && e.Valid == true).ToList().GroupBy(e => e.Type);
            foreach (var item in remark) {
                var list= item.Select(e=> new ImprovePlanAndRemarkDto
                {
                    IndicatorId = e.IndicatorId,
                    HospitalId = e.HospitalId,
                    Type = e.Type,
                    Sort = e.Sort,
                    Content = e.Content,                  
                }).OrderBy(e => e.Sort).ToList();
                dic.Add(item.Key, list);
            }
            /*var remark2 = remark.Select(e =>
            {
                var itemList = e.Select(e => new ImprovePlanAndRemarkDto
                {                   
                    IndicatorId = e.IndicatorId,
                    HospitalId = e.HospitalId,
                    Type = e.Type,
                    Sort = e.Sort,
                    Content=e.Content,
                    Remark=e.Remark
                }).OrderBy(e => e.Sort).ToList();
                dic.Add(e.Key, itemList);
                return itemList;
            });*/

            if (remark == null) return new Dictionary<string, List<ImprovePlanAndRemarkDto>>();
            return dic;
        }

        public async Task UpdateImproveAndRemark(UpdateImprovePlanAndRemarkDto updateDto)
        {           
            ImprovePlanAndRemark remark = new ImprovePlanAndRemark();
            remark.Id = Guid.NewGuid().ToString().Replace("-", "");
            remark.IndicatorId = updateDto.IndicatorId;
            remark.HospitalId = updateDto.HospitalId;
            remark.Type = updateDto.Type;
            remark.Sort = updateDto.Sort;
            remark.Content = updateDto.Content;
            remark.CreateDate = DateTime.Now;
            remark.Valid = true;
            dalImprovePlanAndRemark.Add(remark, true);
        }
    }
}
