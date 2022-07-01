using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ContentPlateFormOrder;
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
    public class ContentPlatFormCustomerPictureService : IContentPlatFormCustomerPictureService
    {
        private IDalContentPlatFormCustomerPicture dalContentPlatFormCustomerPicture;

        public ContentPlatFormCustomerPictureService(IDalContentPlatFormCustomerPicture dalContentPlatFormCustomerPicture)
        {
            this.dalContentPlatFormCustomerPicture = dalContentPlatFormCustomerPicture;
        }



        public async Task<FxPageInfo<ContentPlatFormOrderCustomerPictureDto>> GetListWithPageAsync(string contentPlatFormId, int pageNum, int pageSize)
        {
            try
            {
                var contentPlatFormCustomerPicture = from d in dalContentPlatFormCustomerPicture.GetAll()
                                                     where contentPlatFormId == null || d.ContentPlatFormOrderId.Contains(contentPlatFormId)
                                                     select new ContentPlatFormOrderCustomerPictureDto
                                                     {
                                                         Id = d.Id,
                                                         ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                                         CustomerPicture = d.CustomerPicture,
                                                     };

                FxPageInfo<ContentPlatFormOrderCustomerPictureDto> contentPlatFormCustomerPicturePageInfo = new FxPageInfo<ContentPlatFormOrderCustomerPictureDto>();
                contentPlatFormCustomerPicturePageInfo.TotalCount = await contentPlatFormCustomerPicture.CountAsync();
                contentPlatFormCustomerPicturePageInfo.List = await contentPlatFormCustomerPicture.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return contentPlatFormCustomerPicturePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ContentPlatFormOrderCustomerPictureDto>> GetListAsync(string contentPlatFormId)
        {
            try
            {
                var contentPlatFormCustomerPicture = from d in dalContentPlatFormCustomerPicture.GetAll()
                                                     where contentPlatFormId == null || d.ContentPlatFormOrderId.Contains(contentPlatFormId)
                                                     select new ContentPlatFormOrderCustomerPictureDto
                                                     {
                                                         Id = d.Id,
                                                         ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                                         CustomerPicture = d.CustomerPicture,
                                                     };

                List<ContentPlatFormOrderCustomerPictureDto> contentPlatFormCustomerPicturePageInfo = new List<ContentPlatFormOrderCustomerPictureDto>();
                contentPlatFormCustomerPicturePageInfo = await contentPlatFormCustomerPicture.ToListAsync();

                return contentPlatFormCustomerPicturePageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddAsync(AddContentPlatFormCustomerPictureDto addDto)
        {
            try
            {
                ContentPlatFormCustomerPicture contentPlatFormCustomerPicture = new ContentPlatFormCustomerPicture();
                contentPlatFormCustomerPicture.Id = Guid.NewGuid().ToString();
                contentPlatFormCustomerPicture.ContentPlatFormOrderId = addDto.ContentPlatFormOrderId;
                contentPlatFormCustomerPicture.CustomerPicture = addDto.CustomerPicture;

                await dalContentPlatFormCustomerPicture.AddAsync(contentPlatFormCustomerPicture, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<ContentPlatFormOrderCustomerPictureDto> GetByIdAsync(string id)
        {
            try
            {
                var contentPlatFormCustomerPicture = await dalContentPlatFormCustomerPicture.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (contentPlatFormCustomerPicture == null)
                {
                    return new ContentPlatFormOrderCustomerPictureDto()
                    {
                        Id = "",
                        ContentPlatFormOrderId = "",
                        CustomerPicture = "",
                    };
                }

                ContentPlatFormOrderCustomerPictureDto contentPlatFormCustomerPictureDto = new ContentPlatFormOrderCustomerPictureDto();
                contentPlatFormCustomerPictureDto.Id = contentPlatFormCustomerPicture.Id;
                contentPlatFormCustomerPictureDto.ContentPlatFormOrderId = contentPlatFormCustomerPicture.ContentPlatFormOrderId;
                contentPlatFormCustomerPictureDto.CustomerPicture = contentPlatFormCustomerPicture.CustomerPicture;

                return contentPlatFormCustomerPictureDto;
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
                var contentPlatFormCustomerPicture = await dalContentPlatFormCustomerPicture.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (contentPlatFormCustomerPicture == null)
                    throw new Exception("客户图片编号错误");

                await dalContentPlatFormCustomerPicture.DeleteAsync(contentPlatFormCustomerPicture, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task DeleteByContentPlatFormOrderIdAsync(string contentPlatFormOrderId)
        {
            try
            {
                var contentPlatFormCustomerPicture = await dalContentPlatFormCustomerPicture.GetAll().Where(e => e.ContentPlatFormOrderId == contentPlatFormOrderId).ToListAsync();

                if (contentPlatFormCustomerPicture != null)
                {
                    foreach (var x in contentPlatFormCustomerPicture)
                    {
                        await dalContentPlatFormCustomerPicture.DeleteAsync(x, true);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
