using Fx.Amiya.Dto.TrackTypeThemeModel;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Amiya.DbModels.Model;
using Fx.Common;
using Fx.Infrastructure.DataAccess;

namespace Fx.Amiya.Service
{
    public class TrackTypeThemeModelService : ITrackTypeThemeModelService
    {
        private IDalTrackTypeThemeModel dalTrackTypeThemeModel;
        private IUnitOfWork unitOfWork;
        public TrackTypeThemeModelService(IUnitOfWork unitOfWork, IDalTrackTypeThemeModel dalTrackTypeThemeModel)
        {
            this.dalTrackTypeThemeModel = dalTrackTypeThemeModel;
            this.unitOfWork = unitOfWork;
        }


        /// <summary>
        /// 获取回访模板列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<TrackTypeThemeModelDto>> GetListAsync(int? trackTypeId)
        {
            var trackTypeThemeModel = from d in dalTrackTypeThemeModel.GetAll().Include(x=>x.TrackTheme).Include(x=>x.TrackType)
                                      where trackTypeId == null || d.TrackTypeId == trackTypeId
                                      select new TrackTypeThemeModelDto
                                      {
                                          Id = d.Id,
                                          TrackTypeId = d.TrackTypeId,
                                          TrackTypeName=d.TrackType.Name,
                                          TrackThemeId = d.TrackThemeId,
                                          TrackThemeName=d.TrackTheme.Name,
                                          DaysLater = d.DaysLater,
                                          TrackPlan = d.TrackPlan,
                                      };
            var result = await trackTypeThemeModel.ToListAsync();
            return result;
        }



        /// <summary>
        /// 添加回访模板
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(List<AddTrackTypeThemeModelDto> addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {

                var model = await dalTrackTypeThemeModel.GetAll().Where(x => x.TrackTypeId == addDto[0].TrackTypeId).ToListAsync();
                foreach (var x in model)
                {
                    await dalTrackTypeThemeModel.DeleteAsync(x, true);
                }
                foreach (var x in addDto)
                {
                    TrackTypeThemeModel trackTypeThemeModel = new TrackTypeThemeModel();
                    trackTypeThemeModel.Id = Guid.NewGuid().ToString();
                    trackTypeThemeModel.TrackTypeId = x.TrackTypeId;
                    trackTypeThemeModel.TrackPlan = x.TrackPlan;
                    trackTypeThemeModel.TrackThemeId = x.TrackThemeId;
                    trackTypeThemeModel.DaysLater = x.DaysLater;
                    await dalTrackTypeThemeModel.AddAsync(trackTypeThemeModel, true);
                }
                unitOfWork.Commit();
            }
            catch(Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception(err.Message.ToString());
            }
        }
    }
}
