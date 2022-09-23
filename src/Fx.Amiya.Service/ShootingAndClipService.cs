using Fx.Amiya.Dto.ShootingAndClip;
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
using Fx.Amiya.Core.Interfaces.GoodsHospitalPrice;
using Fx.Amiya.Dto;

namespace Fx.Amiya.Service
{
    public class ShootingAndClipService : IShootingAndClipService
    {
        private IDalShootingAndClip dalShootingAndClip;
        public ShootingAndClipService(IDalShootingAndClip dalShootingAndClip)
        {
            this.dalShootingAndClip = dalShootingAndClip;
        }


        /// <summary>
        /// 获取拍剪组数据列表（分页）
        /// </summary>
        /// <param name="shootingEmpId">拍摄人员id</param>
        /// <param name="clipEmpId">剪辑人员id</param>
        /// <param name="liveAnchorId">主播id</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ShootingAndClipDto>> GetListWithPageAsync(int? shootingEmpId, int? clipEmpId, int? liveAnchorId, string keyWord, int pageNum, int pageSize)
        {
            var shootingAndClip = from d in dalShootingAndClip.GetAll().Include(x => x.ShootingEmoloyee).Include(x => x.ClipEmoloyee).Include(x => x.LiveAnchor).ThenInclude(x => x.ContentPlatformOrderList)
                                  where (!shootingEmpId.HasValue || d.ShootingEmpId == shootingEmpId.Value)
                                  where (!clipEmpId.HasValue || d.ClipEmpId == clipEmpId.Value)
                                  where (!liveAnchorId.HasValue || d.LiveAnchorId == liveAnchorId.Value)
                                  where (string.IsNullOrEmpty(keyWord) || d.Title.Contains(keyWord))
                                  select new ShootingAndClipDto
                                  {
                                      Id = d.Id,
                                      ShootingEmpId = d.ShootingEmpId,
                                      ClipEmpId = d.ClipEmpId,
                                      Title = d.Title,
                                      LiveAnchorId = d.LiveAnchorId,
                                      ShootingEmpName = d.ShootingEmoloyee.Name,
                                      ClipEmpName = d.ClipEmoloyee.Name,
                                      LiveAnchorName = d.LiveAnchor.Name,
                                      CreateDate = d.CreateDate,
                                      RecordDate = d.RecordDate,
                                      VideoType = d.VideoType,
                                      VideoTypeText = ServiceClass.GerShootingAndClipVideoTypeText(d.VideoType)
                                  };
            FxPageInfo<ShootingAndClipDto> cityPageInfo = new FxPageInfo<ShootingAndClipDto>();
            cityPageInfo.TotalCount = await shootingAndClip.CountAsync();
            cityPageInfo.List = await shootingAndClip.OrderBy(z => z.RecordDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return cityPageInfo;
        }

        /// <summary>
        /// 获取拍剪组数据列表（报表）
        /// </summary>
        /// <param name="shootingEmpId">拍摄人员id</param>
        /// <param name="clipEmpId">剪辑人员id</param>
        /// <param name="liveAnchorId">主播id</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<ShootingAndClipDto>> GetReportListAsync(DateTime? startDate, DateTime? endDate, int? shootingEmpId, int? clipEmpId, int? liveAnchorId)
        {
            var shootingAndClip = from d in dalShootingAndClip.GetAll().Include(x => x.ShootingEmoloyee).Include(x => x.ClipEmoloyee).Include(x => x.LiveAnchor).ThenInclude(x => x.ContentPlatformOrderList)
                                  where (!shootingEmpId.HasValue || d.ShootingEmpId == shootingEmpId.Value)
                                  where (!clipEmpId.HasValue || d.ClipEmpId == clipEmpId.Value)
                                  where (!liveAnchorId.HasValue || d.LiveAnchorId == liveAnchorId.Value)
                                  where (d.RecordDate >= startDate && d.RecordDate < endDate.Value.AddDays(1).Date)
                                  select new ShootingAndClipDto
                                  {
                                      Id = d.Id,
                                      ShootingEmpId = d.ShootingEmpId,
                                      ClipEmpId = d.ClipEmpId,
                                      Title = d.Title,
                                      LiveAnchorId = d.LiveAnchorId,
                                      ShootingEmpName = d.ShootingEmoloyee.Name,
                                      ClipEmpName = d.ClipEmoloyee.Name,
                                      LiveAnchorName = d.LiveAnchor.Name,
                                      CreateDate = d.CreateDate,
                                      RecordDate = d.RecordDate,
                                      VideoTypeText = ServiceClass.GerShootingAndClipVideoTypeText(d.VideoType)
                                  };
            List<ShootingAndClipDto> shootingAndClipDto = new List<ShootingAndClipDto>();
            shootingAndClipDto = await shootingAndClip.OrderBy(z => z.RecordDate).ToListAsync();
            return shootingAndClipDto;
        }

        /// <summary>
        /// 添加拍剪组数据
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddShootingAndClipDto addDto)
        {
            var isExistData = await this.GetByLiveAnchorIdAndRecordDate(addDto.RecordDate, addDto.LiveAnchorId);
            if (!string.IsNullOrEmpty(isExistData.Id)) { throw new Exception("主播今日拍剪数据已存在，无法重复操作，请检索到对应数据进行编辑！"); }
            ShootingAndClip shootingAndClip = new ShootingAndClip();
            shootingAndClip.Id = Guid.NewGuid().ToString();
            shootingAndClip.ShootingEmpId = addDto.ShootingEmpId;
            shootingAndClip.ClipEmpId = addDto.ClipEmpId;
            shootingAndClip.LiveAnchorId = addDto.LiveAnchorId;
            shootingAndClip.VideoType = addDto.VideoType;
            shootingAndClip.Title = addDto.Title;
            shootingAndClip.RecordDate = addDto.RecordDate;
            shootingAndClip.CreateDate = DateTime.Now;
            await dalShootingAndClip.AddAsync(shootingAndClip, true);
        }

        public async Task<ShootingAndClipDto> GetByIdAsync(string id)
        {
            var shootingAndClip = await dalShootingAndClip.GetAll().Include(x => x.LiveAnchor).SingleOrDefaultAsync(e => e.Id == id);
            if (shootingAndClip == null)
            {
                return new ShootingAndClipDto();
            }

            ShootingAndClipDto shootingAndClipDto = new ShootingAndClipDto();
            shootingAndClipDto.Id = shootingAndClip.Id;
            shootingAndClipDto.ShootingEmpId = shootingAndClip.ShootingEmpId;
            shootingAndClipDto.ClipEmpId = shootingAndClip.ClipEmpId;
            shootingAndClipDto.Title = shootingAndClip.Title;
            shootingAndClipDto.ContentPlatFormId = shootingAndClip.LiveAnchor.ContentPlateFormId;
            shootingAndClipDto.LiveAnchorId = shootingAndClip.LiveAnchorId;
            shootingAndClipDto.CreateDate = shootingAndClip.CreateDate;
            shootingAndClipDto.VideoType = shootingAndClip.VideoType;
            shootingAndClipDto.RecordDate = shootingAndClip.RecordDate;

            return shootingAndClipDto;
        }


        /// <summary>
        /// 修改合作拍剪组数据
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateShootingAndClipDto updateDto)
        {
            var isExistData = await this.GetByLiveAnchorIdAndRecordDate(updateDto.RecordDate, updateDto.LiveAnchorId);
            if (!string.IsNullOrEmpty(isExistData.Id) && isExistData.Id != updateDto.Id) { throw new Exception("主播今日拍剪数据已存在，无法重复操作，请检索到对应数据进行编辑！"); }

            var shootingAndClip = await dalShootingAndClip.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            shootingAndClip.ShootingEmpId = updateDto.ShootingEmpId;
            shootingAndClip.ClipEmpId = updateDto.ClipEmpId;
            shootingAndClip.LiveAnchorId = updateDto.LiveAnchorId;
            shootingAndClip.Title = updateDto.Title;
            shootingAndClip.VideoType = updateDto.VideoType;
            shootingAndClip.RecordDate = updateDto.RecordDate;

            await dalShootingAndClip.UpdateAsync(shootingAndClip, true);
        }



        /// <summary>
        /// 删除拍剪组数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            var shootingAndClip = await dalShootingAndClip.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            await dalShootingAndClip.DeleteAsync(shootingAndClip, true);
        }

        /// <summary>
        /// 根据主播id获取填写天数是否存在数据
        /// </summary>
        /// <param name="recordDate"></param>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        private async Task<ShootingAndClipDto> GetByLiveAnchorIdAndRecordDate(DateTime recordDate, int liveAnchorId)
        {
            var shootingAndClip = await dalShootingAndClip.GetAll().SingleOrDefaultAsync(e => e.RecordDate == recordDate && e.LiveAnchorId == liveAnchorId);
            if (shootingAndClip == null)
            {
                return new ShootingAndClipDto();
            }

            ShootingAndClipDto shootingAndClipDto = new ShootingAndClipDto();
            shootingAndClipDto.Id = shootingAndClip.Id;
            shootingAndClipDto.ShootingEmpId = shootingAndClip.ShootingEmpId;
            shootingAndClipDto.ClipEmpId = shootingAndClip.ClipEmpId;
            shootingAndClipDto.Title = shootingAndClip.Title;
            shootingAndClipDto.LiveAnchorId = shootingAndClip.LiveAnchorId;
            shootingAndClipDto.CreateDate = shootingAndClip.CreateDate;
            shootingAndClipDto.RecordDate = shootingAndClip.RecordDate;
            shootingAndClipDto.VideoType = shootingAndClip.VideoType;

            return shootingAndClipDto;
        }

        public List<BaseIdAndNameDto> GetVideoTypeTextList()
        {
            var sendStatus = Enum.GetValues(typeof(ShootingAndClipVideoType));
            List<BaseIdAndNameDto> orderAppTypeList = new List<BaseIdAndNameDto>();
            foreach (var item in sendStatus)
            {
                BaseIdAndNameDto orderAppType = new BaseIdAndNameDto();
                orderAppType.Id = Convert.ToString(Convert.ToInt16(item));
                orderAppType.Name = ServiceClass.GerShootingAndClipVideoTypeText(Convert.ToInt16(item));
                orderAppTypeList.Add(orderAppType);
            }
            return orderAppTypeList;
        }
    }
}
