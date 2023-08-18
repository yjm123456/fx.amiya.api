using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Infrastructure;
using Fx.Amiya.Dto.Activity;
using Fx.Amiya.DbModels.Model;
using Fx.Infrastructure.DataAccess;
using Fx.Common;

namespace Fx.Amiya.Service
{
    public class ActivityService : IActivityService
    {
        private IDalActivityInfo dalActivityInfo;
        private IDalActivityItemDetail dalActivityItemDetail;
        private IUnitOfWork unitOfWork;
        private IDalHospitalPartakeItem dalHospitalPartakeItem;

        public ActivityService(IDalActivityInfo dalActivityInfo, IDalActivityItemDetail dalActivityItemDetail,
            IUnitOfWork unitOfWork, IDalHospitalPartakeItem dalHospitalPartakeItem)
        {
            this.dalActivityInfo = dalActivityInfo;
            this.dalActivityItemDetail = dalActivityItemDetail;
            this.unitOfWork = unitOfWork;
            this.dalHospitalPartakeItem = dalHospitalPartakeItem;
        }


        /// <summary>
        /// 获取活动信息列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="activityName"></param>
        /// <param name="status">0=已完成，1=未完成</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ActivityInfoDto>> GetInfoListWithPageAsync(DateTime? startDate, DateTime? endDate, string activityName, int? status,bool valid, int pageNum, int pageSize)
        {
            var q = from d in dalActivityInfo.GetAll()
                    where (string.IsNullOrWhiteSpace(activityName) || d.Name.Contains(activityName))
                    &&d.Valid==valid
                    select d;
            if (startDate != null)
            {
                DateTime startrq = ((DateTime)startDate).Date;
                DateTime endrq = ((DateTime)endDate).Date;
                q = q.Where(e => startrq <= e.EndDate.Date && endrq >= e.StartDate.Date);

            }
            if (status != null)
            {
                if ((int)status == 0)
                    q = q.Where(e => e.EndDate.Date < DateTime.Now.Date);

                if ((int)status == 1)
                    q = q.Where(e => e.EndDate.Date >= DateTime.Now.Date);
            }


            var activity = from d in q
                           select new ActivityInfoDto
                           {
                               Id = d.Id,
                               Name = d.Name,
                               Description = d.Description,
                               StartDate = d.StartDate,
                               EndDate = d.EndDate,
                               CreateBy = d.CreateBy,
                               CreateName = d.CreateByAmiyaEmployee.Name,
                               Valid = d.Valid,
                               CreateDate = d.CreateDate,
                               UpdateBy = d.UpdateBy,
                               UpdateName = d.UpdateByAmiyaEmployee.Name,
                               UpdateDate = d.UpdateDate,
                           };

            FxPageInfo<ActivityInfoDto> activityPageInfo = new FxPageInfo<ActivityInfoDto>();
            activityPageInfo.TotalCount = await activity.CountAsync();
            activityPageInfo.List = await activity.OrderByDescending(x=>x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return activityPageInfo;

        }




        /// <summary>
        /// 获取有效的活动信息列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ActivityInfoSimpleDto>> GetValidListAsync(int hospitalId, int pageNum, int pageSize)
        {
            var activityInfos = from d in dalActivityInfo.GetAll()
                                where d.Valid && d.EndDate.Date >= DateTime.Now.Date
                                select new ActivityInfoSimpleDto
                                {
                                    Id = d.Id,
                                    Name = d.Name,
                                    Description = d.Description,
                                    StartDate = d.StartDate,
                                    EndDate = d.EndDate,
                                    IsPartake = d.HospitalPartakeItemList.Count(e => e.HospitalId == hospitalId) > 0 ? true : false,
                                    CreateDate=d.CreateDate
                                };

            FxPageInfo<ActivityInfoSimpleDto> activityPageInfo = new FxPageInfo<ActivityInfoSimpleDto>();
            activityPageInfo.TotalCount = await activityInfos.CountAsync();
            activityPageInfo.List = await activityInfos.OrderByDescending(x=>x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return activityPageInfo;
        }




        public async Task AddInfoAsync(AddActivityInfoDto addDto, int employeeId)
        {
            DateTime date = DateTime.Now;
            if (addDto.StartDate.Date < date.Date)
                throw new Exception("开始时间必须大于或等于今天");

            if (addDto.EndDate.Date <= addDto.StartDate.Date)
                throw new Exception("结束时间必须大于开始时间");

            var activityCount = await dalActivityInfo.GetAll().CountAsync(e => e.Valid && e.StartDate <= addDto.EndDate && addDto.StartDate <= e.EndDate);
            if (activityCount > 0)
                throw new Exception("存在时间冲突的报价活动");

            ActivityInfo activityInfo = new ActivityInfo();
            activityInfo.Name = addDto.Name;
            activityInfo.Description = addDto.Description;
            activityInfo.StartDate = addDto.StartDate;
            activityInfo.EndDate = addDto.EndDate;
            activityInfo.CreateBy = employeeId;
            activityInfo.CreateDate = date;
            activityInfo.Valid = true;
            await dalActivityInfo.AddAsync(activityInfo, true);
        }



        public async Task<ActivityInfoDto> GetInfoByIdAsync(int activityId)
        {
            var activity = await dalActivityInfo.GetAll()
                .Include(e => e.CreateByAmiyaEmployee)
                .Include(e => e.UpdateByAmiyaEmployee)
                .SingleOrDefaultAsync(e => e.Id == activityId);
            if (activity == null)
                throw new Exception("活动编号错误");

            ActivityInfoDto activityInfoDto = new ActivityInfoDto();
            activityInfoDto.Id = activity.Id;
            activityInfoDto.Name = activity.Name;
            activityInfoDto.Description = activity.Description;
            activityInfoDto.StartDate = activity.StartDate;
            activityInfoDto.EndDate = activity.EndDate;
            activityInfoDto.Valid = activity.Valid;
            activityInfoDto.CreateBy = activity.CreateBy;
            activityInfoDto.CreateName = activity.CreateByAmiyaEmployee.Name;
            activityInfoDto.CreateDate = activity.CreateDate;
            activityInfoDto.UpdateBy = activity.UpdateBy;
            activityInfoDto.UpdateDate = activity.UpdateDate;
            activityInfoDto.UpdateName = activity.UpdateByAmiyaEmployee?.Name;
            return activityInfoDto;
        }



        public async Task UpdateInfoAsync(UpdateActivityInfoDto updateDto, int employeeId)
        {
            DateTime date = DateTime.Now;
            if (updateDto.EndDate.Date <= date.Date)
                throw new Exception("结束时间必须大于今天");

            var activity = await dalActivityInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (activity == null)
                throw new Exception("活动编号错误");

            var activityCount = await dalActivityInfo.GetAll().CountAsync(e => e.Valid && e.StartDate <= updateDto.EndDate && updateDto.StartDate <= e.EndDate && e.Id != updateDto.Id);
            if (activityCount > 0)
                throw new Exception("存在时间冲突的报价活动");


            activity.Name = updateDto.Name;
            activity.Description = updateDto.Description;
            activity.StartDate = updateDto.StartDate;
            activity.EndDate = updateDto.EndDate;
            activity.UpdateBy = employeeId;
            activity.UpdateDate = date;
            activity.Valid = updateDto.Valid;
            await dalActivityInfo.UpdateAsync(activity, true);
        }


        public async Task DeleteInfoAsync(int activityId)
        {
            var activity = await dalActivityInfo.GetAll()
                .Include(e => e.ActivityItemDetailList)
                .SingleOrDefaultAsync(e => e.Id == activityId);
            if (activity == null)
                throw new Exception("活动编号错误");

            if (activity.ActivityItemDetailList.Count > 0)
                throw new Exception("该活动已有报价项目，删除失败");
            await dalActivityInfo.DeleteAsync(activity, true);
        }


        /// <summary>
        /// 根据活动编号获取明细中已存在的项目编号集合
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public async Task<List<int>> GetAlreadyExistItemIdListByActivityId(int activityId)
        {
            var detail = await dalActivityItemDetail.GetAll().Where(e => e.ActityId == activityId).ToListAsync();
            List<int> itemIds = new List<int>();
            foreach (var item in detail)
            {
                itemIds.Add(item.ItemId);
            }
            return itemIds;
        }





        /// <summary>
        /// 批量添加报价活动项目
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddDetailAsync(AddActivityItemDetailDto addDto)
        {
            try
            {
                unitOfWork.BeginTransaction();
                List<ActivityItemDetail> activityItemDetailList = new List<ActivityItemDetail>();
                var details = await dalActivityItemDetail.GetAll().Where(e => e.ActityId == addDto.ActivityId).ToListAsync();

                foreach (var item in details)
                {
                    if (!addDto.AddActivityItemList.Exists(e => e.ItemId == item.ItemId))
                    {
                        await dalActivityItemDetail.DeleteAsync(item, true);
                    }
                }


                foreach (var item in addDto.AddActivityItemList)
                {
                    if (!details.Exists(e => e.ItemId == item.ItemId))
                    {
                        ActivityItemDetail activityItemDetail = new ActivityItemDetail();
                        activityItemDetail.ActityId = addDto.ActivityId;
                        activityItemDetail.ItemId = item.ItemId;
                        activityItemDetail.SalePrice = item.SalePrice;
                        activityItemDetail.LivePrice = item.LivePrice;
                        activityItemDetailList.Add(activityItemDetail);
                    }
                    else
                    {
                        var detail = details.SingleOrDefault(e => e.ItemId == item.ItemId);
                        detail.SalePrice = item.SalePrice;
                        detail.LivePrice = item.LivePrice;

                        await dalActivityItemDetail.UpdateAsync(detail, true);
                    }
                }

                await dalActivityItemDetail.AddCollectionAsync(activityItemDetailList, true);
                unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }



        /// <summary>
        /// 根据活动编号报价活动项目列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="activityId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ActivityItemDetailDto>> GetDetailListByActivityIdWithPageAsync(string keyword, int activityId, int pageNum, int pageSize)
        {
            var detail = from d in dalActivityItemDetail.GetAll()
                         where d.ActityId == activityId
                         && (keyword == null || d.ItemInfo.Name.Contains(keyword)
                         || d.ItemInfo.Description.Contains(keyword) || d.ItemInfo.Parts.Contains(keyword))
                         select new ActivityItemDetailDto
                         {
                             Id = d.Id,
                             ActivityId = d.ActityId,
                             ItemId = d.ItemId,
                             ThumbPicUrl = d.ItemInfo.ThumbPicUrl,
                             Name = d.ItemInfo.Name,
                             Description = d.ItemInfo.Description,
                             Standard = d.ItemInfo.Standard,
                             Parts = d.ItemInfo.Parts,
                             SalePrice = d.SalePrice,
                             IsLimitBuy=d.ItemInfo.IsLimitBuy,
                             LivePrice = d.LivePrice,
                             LimitBuyQuantity = d.ItemInfo.LimitBuyQuantity,
                             Remark = d.ItemInfo.Remark
                         };
            FxPageInfo<ActivityItemDetailDto> detailPageInfo = new FxPageInfo<ActivityItemDetailDto>();
            detailPageInfo.TotalCount = await detail.CountAsync();
            detailPageInfo.List = await detail.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return detailPageInfo;
        }



        /// <summary>
        /// 根据活动编号报价活动项目列表
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public async Task<List<ActivityItemDetailDto>> GetDetailListByActivityIdAsync(int activityId)
        {
            var details = from d in dalActivityItemDetail.GetAll()
                          where d.ActityId == activityId
                          && d.ItemInfo.Valid == true
                          select new ActivityItemDetailDto
                          {
                              Id = d.Id,
                              ActivityId = d.ActityId,
                              ItemId = d.ItemId,
                              ThumbPicUrl = d.ItemInfo.ThumbPicUrl,
                              Name = d.ItemInfo.Name,
                              Description = d.ItemInfo.Description,
                              Standard = d.ItemInfo.Standard,
                              Parts = d.ItemInfo.Parts,
                              SalePrice = d.SalePrice,
                              LivePrice = d.LivePrice,
                              IsLimitBuy = d.ItemInfo.IsLimitBuy,
                              LimitBuyQuantity = d.ItemInfo.LimitBuyQuantity,
                              Remark = d.ItemInfo.Remark
                          };
            return await details.ToListAsync();
        }




        public async Task<FxPageInfo<ActivityInfoDto>> GetListByHospitalIdAsync(int hospitalId, string keyword, int pageNum, int pageSize)
        {
            var activitys = from d in dalActivityInfo.GetAll()
                            where d.HospitalPartakeItemList.Count(e => e.HospitalId == hospitalId) > 0
                            && (string.IsNullOrWhiteSpace(keyword) || d.Name.Contains(keyword) || d.Description.Contains(keyword))
                            select new ActivityInfoDto
                            {
                                Id = d.Id,
                                Name = d.Name,
                                Description = d.Description,
                                StartDate = d.StartDate,
                                EndDate = d.EndDate,
                                Valid = d.Valid,
                                CreateBy = d.CreateBy,
                                CreateDate = d.CreateDate,
                                CreateName = d.CreateByAmiyaEmployee.Name,
                                UpdateBy = d.UpdateBy,
                                UpdateDate = d.UpdateDate,
                                UpdateName = d.UpdateByAmiyaEmployee.Name

                            };
            FxPageInfo<ActivityInfoDto> activityPageInfo = new FxPageInfo<ActivityInfoDto>();
            activityPageInfo.TotalCount = await activitys.CountAsync();
            activityPageInfo.List = await activitys.OrderByDescending(x=>x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return activityPageInfo;
        }


        /// <summary>
        /// 获取所有活动名称列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ActivityNameDto>> GetNameListAsync(string keyword, int pageNum, int pageSize)
        {
            var activitys = from d in dalActivityInfo.GetAll()
                            where (string.IsNullOrWhiteSpace(keyword) || d.Name.Contains(keyword) || d.Description.Contains(keyword))
                            orderby d.CreateDate descending
                            select new ActivityNameDto
                            {
                                Id = d.Id,
                                Name = d.Name
                            };
            FxPageInfo<ActivityNameDto> activityPageInfo = new FxPageInfo<ActivityNameDto>();
            activityPageInfo.TotalCount = await activitys.CountAsync();
            activityPageInfo.List = await activitys.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return activityPageInfo;
        }
    }
}
