using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class ContentPlatFormOrderDealInfoService: IContentPlatFormOrderDealInfoService
    {
        private IDalContentPlatFormOrderDealInfo dalContentPlatFormOrderDealInfo;
        private IHospitalInfoService _hospitalInfoService;

        public ContentPlatFormOrderDealInfoService(IDalContentPlatFormOrderDealInfo dalContentPlatFormOrderDealInfo,
            IHospitalInfoService hospitalInfoService)
        {
            this.dalContentPlatFormOrderDealInfo = dalContentPlatFormOrderDealInfo;
            _hospitalInfoService = hospitalInfoService;
        }



        public async Task<FxPageInfo<ContentPlatFormOrderDealInfoDto>> GetListWithPageAsync(string contentPlafFormOrderId, int pageNum, int pageSize)
        {
            try
            {
                var ContentPlatFOrmOrderDealInfo = from d in dalContentPlatFormOrderDealInfo.GetAll()
                                                   where string.IsNullOrEmpty(contentPlafFormOrderId )|| d.ContentPlatFormOrderId == contentPlafFormOrderId
                                                   select new ContentPlatFormOrderDealInfoDto
                                                   {
                                                       Id = d.Id,
                                                       ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                                       CreateDate = d.CreateDate,
                                                       IsDeal = d.IsDeal,
                                                       IsToHospital = d.IsToHospital,
                                                       ToHospitalDate=d.ToHospitalDate,
                                                       LastDealHospitalId=d.LastDealHospitalId,
                                                       DealPicture=d.DealPicture,
                                                       Remark=d.Remark,
                                                       Price=d.Price
                              };

                FxPageInfo<ContentPlatFormOrderDealInfoDto> ContentPlatFOrmOrderDealInfoPageInfo = new FxPageInfo<ContentPlatFormOrderDealInfoDto>();
                ContentPlatFOrmOrderDealInfoPageInfo.TotalCount = await ContentPlatFOrmOrderDealInfo.CountAsync();
                ContentPlatFOrmOrderDealInfoPageInfo.List = await ContentPlatFOrmOrderDealInfo.OrderByDescending(x=>x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach(var z in ContentPlatFOrmOrderDealInfoPageInfo.List)
                {
                    if(z.LastDealHospitalId.HasValue)
                    {
                        var dealHospital = await _hospitalInfoService.GetBaseByIdAsync(z.LastDealHospitalId.Value);
                        z.LastDealHospital = dealHospital.Name;
                    }
                }
                return ContentPlatFOrmOrderDealInfoPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AddContentPlatFormOrderDealInfoDto addDto)
        {
            try
            {
                ContentPlatformOrderDealInfo ContentPlatFOrmOrderDealInfo = new ContentPlatformOrderDealInfo();
                ContentPlatFOrmOrderDealInfo.Id = Guid.NewGuid().ToString();
                ContentPlatFOrmOrderDealInfo.ContentPlatFormOrderId = addDto.ContentPlatFormOrderId;
                ContentPlatFOrmOrderDealInfo.CreateDate = addDto.CreateDate;
                ContentPlatFOrmOrderDealInfo.IsToHospital = addDto.IsToHospital;
                ContentPlatFOrmOrderDealInfo.ToHospitalDate = addDto.ToHospitalDate;
                ContentPlatFOrmOrderDealInfo.LastDealHospitalId = addDto.LastDealHospitalId;
                ContentPlatFOrmOrderDealInfo.IsDeal = addDto.IsDeal;
                ContentPlatFOrmOrderDealInfo.DealPicture = addDto.DealPicture;
                ContentPlatFOrmOrderDealInfo.Remark = addDto.Remark;
                ContentPlatFOrmOrderDealInfo.Price = addDto.Price;
                await dalContentPlatFormOrderDealInfo.AddAsync(ContentPlatFOrmOrderDealInfo, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<ContentPlatFormOrderDealInfoDto> GetByIdAsync(string id)
        {
            try
            {
                var ContentPlatFOrmOrderDealInfo = await dalContentPlatFormOrderDealInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (ContentPlatFOrmOrderDealInfo == null)
                {
                    throw new Exception("未找到该成交信息");
                }

                ContentPlatFormOrderDealInfoDto ContentPlatFOrmOrderDealInfoDto = new ContentPlatFormOrderDealInfoDto();
                ContentPlatFOrmOrderDealInfoDto.Id = ContentPlatFOrmOrderDealInfo.Id;
                ContentPlatFOrmOrderDealInfoDto.ContentPlatFormOrderId = ContentPlatFOrmOrderDealInfo.ContentPlatFormOrderId;
                ContentPlatFOrmOrderDealInfoDto.CreateDate = ContentPlatFOrmOrderDealInfo.CreateDate;
                ContentPlatFOrmOrderDealInfoDto.IsToHospital = ContentPlatFOrmOrderDealInfo.IsToHospital;
                ContentPlatFOrmOrderDealInfoDto.ToHospitalDate = ContentPlatFOrmOrderDealInfo.ToHospitalDate;
                ContentPlatFOrmOrderDealInfoDto.LastDealHospitalId = ContentPlatFOrmOrderDealInfo.LastDealHospitalId;
                ContentPlatFOrmOrderDealInfoDto.IsDeal = ContentPlatFOrmOrderDealInfo.IsDeal;
                ContentPlatFOrmOrderDealInfoDto.DealPicture = ContentPlatFOrmOrderDealInfo.DealPicture;
                ContentPlatFOrmOrderDealInfoDto.Remark = ContentPlatFOrmOrderDealInfo.Remark;
                ContentPlatFOrmOrderDealInfoDto.Price = ContentPlatFOrmOrderDealInfo.Price;
                return ContentPlatFOrmOrderDealInfoDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateContentPlatFormOrderDealInfoDto updateDto)
        {
            try
            {
                var ContentPlatFOrmOrderDealInfo = await dalContentPlatFormOrderDealInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (ContentPlatFOrmOrderDealInfo == null)
                    throw new Exception("未找到该成交信息！");

                ContentPlatFOrmOrderDealInfo.Id = updateDto.Id;
                ContentPlatFOrmOrderDealInfo.ContentPlatFormOrderId = updateDto.ContentPlatFormOrderId;
                ContentPlatFOrmOrderDealInfo.CreateDate = updateDto.CreateDate;
                ContentPlatFOrmOrderDealInfo.IsToHospital = updateDto.IsToHospital;
                ContentPlatFOrmOrderDealInfo.ToHospitalDate = updateDto.ToHospitalDate;
                ContentPlatFOrmOrderDealInfo.LastDealHospitalId = updateDto.LastDealHospitalId;
                ContentPlatFOrmOrderDealInfo.IsDeal = updateDto.IsDeal;
                ContentPlatFOrmOrderDealInfo.DealPicture = updateDto.DealPicture;
                ContentPlatFOrmOrderDealInfo.Remark = updateDto.Remark;
                ContentPlatFOrmOrderDealInfo.Price = updateDto.Price;
                await dalContentPlatFormOrderDealInfo.UpdateAsync(ContentPlatFOrmOrderDealInfo, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var ContentPlatFOrmOrderDealInfo = await dalContentPlatFormOrderDealInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (ContentPlatFOrmOrderDealInfo == null)
                    throw new Exception("未找到该成交信息");

                await dalContentPlatFormOrderDealInfo.DeleteAsync(ContentPlatFOrmOrderDealInfo, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
