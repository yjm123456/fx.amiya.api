using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Infrastructure.DataAccess;
using Fx.Amiya.Dto.ContentPlatFormOrderDealDetails.Result;
using Fx.Amiya.Dto.ContentPlatFormOrderDealDetails.Input;
using Fx.Amiya.Dto;

namespace Fx.Amiya.Service
{
    public class ContentPlatFormOrderDealDetailsService : IContentPlatFormOrderDealDetailsService
    {
        private IDalContentPlatFormOrderDealDetails dalContentPlatFormOrderDealDetailsService;
        private IAmiyaEmployeeService _amiyaEmployeeService;
        public ContentPlatFormOrderDealDetailsService(IDalContentPlatFormOrderDealDetails dalContentPlatFormOrderDealDetailsService, IAmiyaEmployeeService amiyaEmployeeService)
        {
            this.dalContentPlatFormOrderDealDetailsService = dalContentPlatFormOrderDealDetailsService;
            this._amiyaEmployeeService = amiyaEmployeeService;
        }



        public async Task<FxPageInfo<ContentPlatFormOrderDealDetailsDto>> GetListAsync(QueryContentPlatFormOrderDealDetailsDto query)
        {
            try
            {
                var contentPlatFormOrderDealDetailsService = from d in dalContentPlatFormOrderDealDetailsService.GetAll()
                                                             where (string.IsNullOrEmpty(query.ContentPlatFormOrderDealId) || d.ContentPlatFormOrderDealId == query.ContentPlatFormOrderDealId)
                                                             && (string.IsNullOrEmpty(query.ContentPlatFormOrderId) || d.ContentPlatFormOrderId == query.ContentPlatFormOrderId)
                                                             && (!query.StartDate.HasValue || d.CreateDate >= query.StartDate.Value)
                                                             && (!query.EndDate.HasValue || d.CreateDate <= query.EndDate.Value.AddDays(1).AddMilliseconds(-1))
                                                             && (d.Valid == true)
                                                             select new ContentPlatFormOrderDealDetailsDto
                                                             {
                                                                 Id = d.Id,
                                                                 CreateBy = d.CreateBy,
                                                                 CreateDate = d.CreateDate,
                                                                 UpdateDate = d.UpdateDate,
                                                                 DeleteDate = d.DeleteDate,
                                                                 Valid = d.Valid,
                                                                 GoodsName = d.GoodsName,
                                                                 GoodsSpec = d.GoodsSpec,
                                                                 Quantity = d.Quantity,
                                                                 Price = d.Price,
                                                                 ContentPlatFormOrderDealId = d.ContentPlatFormOrderDealId,
                                                                 ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                                             };
                FxPageInfo<ContentPlatFormOrderDealDetailsDto> contentPlatFormOrderDealDetailsServicePageInfo = new FxPageInfo<ContentPlatFormOrderDealDetailsDto>();
                contentPlatFormOrderDealDetailsServicePageInfo.TotalCount = await contentPlatFormOrderDealDetailsService.CountAsync();
                contentPlatFormOrderDealDetailsServicePageInfo.List = await contentPlatFormOrderDealDetailsService.OrderByDescending(x => x.CreateDate).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToListAsync();

                foreach (var x in contentPlatFormOrderDealDetailsServicePageInfo.List)
                {
                    if (x.CreateBy != 0)
                    {
                        var empInfo = await _amiyaEmployeeService.GetByIdAsync(x.CreateBy);
                        x.CreateByEmpName = empInfo.Name.ToString();
                    }
                    else
                    {
                        x.CreateByEmpName = "医院创建";
                    }
                }
                return contentPlatFormOrderDealDetailsServicePageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task AddAsync(AddContentPlatFormOrderDealDetailsDto addDto)
        {
            try
            {
                ContentPlatFormOrderDealDetails contentPlatFormOrderDealDetailsService = new ContentPlatFormOrderDealDetails();
                contentPlatFormOrderDealDetailsService.Id = Guid.NewGuid().ToString();
                contentPlatFormOrderDealDetailsService.CreateBy = addDto.CreateBy;
                contentPlatFormOrderDealDetailsService.GoodsName = addDto.GoodsName;
                contentPlatFormOrderDealDetailsService.GoodsSpec = addDto.GoodsSpec;
                contentPlatFormOrderDealDetailsService.Quantity = addDto.Quantity;
                contentPlatFormOrderDealDetailsService.Price = addDto.Price;
                contentPlatFormOrderDealDetailsService.ContentPlatFormOrderDealId = addDto.ContentPlatFormOrderDealId;
                contentPlatFormOrderDealDetailsService.ContentPlatFormOrderId = addDto.ContentPlatFormOrderId;
                contentPlatFormOrderDealDetailsService.Valid = true;
                contentPlatFormOrderDealDetailsService.CreateDate = DateTime.Now;

                await dalContentPlatFormOrderDealDetailsService.AddAsync(contentPlatFormOrderDealDetailsService, true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task<ContentPlatFormOrderDealDetailsDto> GetByIdAsync(string id)
        {
            try
            {
                var contentPlatFormOrderDealDetailsService = await dalContentPlatFormOrderDealDetailsService.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (contentPlatFormOrderDealDetailsService == null)
                    throw new Exception("成交详情编号错误！");
                ContentPlatFormOrderDealDetailsDto contentPlatFormOrderDealDetailsServiceResult = new ContentPlatFormOrderDealDetailsDto();
                contentPlatFormOrderDealDetailsServiceResult.Id = contentPlatFormOrderDealDetailsService.Id;
                contentPlatFormOrderDealDetailsServiceResult.CreateBy = contentPlatFormOrderDealDetailsService.CreateBy;
                contentPlatFormOrderDealDetailsServiceResult.CreateDate = contentPlatFormOrderDealDetailsService.CreateDate;
                contentPlatFormOrderDealDetailsServiceResult.UpdateDate = contentPlatFormOrderDealDetailsService.UpdateDate;
                contentPlatFormOrderDealDetailsServiceResult.Valid = contentPlatFormOrderDealDetailsService.Valid;
                contentPlatFormOrderDealDetailsServiceResult.DeleteDate = contentPlatFormOrderDealDetailsService.DeleteDate;
                contentPlatFormOrderDealDetailsServiceResult.GoodsName = contentPlatFormOrderDealDetailsService.GoodsName;
                contentPlatFormOrderDealDetailsServiceResult.GoodsSpec = contentPlatFormOrderDealDetailsService.GoodsSpec;
                contentPlatFormOrderDealDetailsServiceResult.Quantity = contentPlatFormOrderDealDetailsService.Quantity;
                contentPlatFormOrderDealDetailsServiceResult.Price = contentPlatFormOrderDealDetailsService.Price;
                return contentPlatFormOrderDealDetailsServiceResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(UpdateContentPlatFormOrderDealDetailsDto updateDto)
        {
            try
            {
                var contentPlatFormOrderDealDetailsService = await dalContentPlatFormOrderDealDetailsService.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (contentPlatFormOrderDealDetailsService == null)
                    throw new Exception("成交详情编号错误！");
                var empInfo = await _amiyaEmployeeService.GetByIdAsync(contentPlatFormOrderDealDetailsService.CreateBy);
                if (empInfo.IsDirector == false)
                {
                    if (updateDto.CreateBy != contentPlatFormOrderDealDetailsService.CreateBy)
                    {
                        throw new Exception("该笔成交订单为他人提交，您暂无修改权限，请联系管理员");
                    }
                }
                contentPlatFormOrderDealDetailsService.GoodsName = updateDto.GoodsName;
                contentPlatFormOrderDealDetailsService.GoodsSpec = updateDto.GoodsSpec;
                contentPlatFormOrderDealDetailsService.Quantity = updateDto.Quantity;
                contentPlatFormOrderDealDetailsService.Price = updateDto.Price;
                contentPlatFormOrderDealDetailsService.UpdateDate = DateTime.Now;
                await dalContentPlatFormOrderDealDetailsService.UpdateAsync(contentPlatFormOrderDealDetailsService, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task ConfirmOrderAsync(ConfirmContentPlatFormOrderDealDetailsDto updateDto)
        {
            try
            {
                var contentPlatFormOrderDealDetailsService = await dalContentPlatFormOrderDealDetailsService.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (contentPlatFormOrderDealDetailsService == null)
                    throw new Exception("成交详情编号错误！");
                var empInfo = await _amiyaEmployeeService.GetByIdAsync(contentPlatFormOrderDealDetailsService.CreateBy);
                if (empInfo.IsDirector == false)
                {
                    if (updateDto.CreateBy != contentPlatFormOrderDealDetailsService.CreateBy)
                    {
                        throw new Exception("该笔成交订单为他人/医院提交，您暂无修改权限，请联系管理员");
                    }
                }
                contentPlatFormOrderDealDetailsService.ContentPlatFormOrderDealId = updateDto.ContentPlatFormOrderDealId;
                contentPlatFormOrderDealDetailsService.ContentPlatFormOrderId = updateDto.ContentPlatFormOrderId;
                contentPlatFormOrderDealDetailsService.UpdateDate = DateTime.Now;
                await dalContentPlatFormOrderDealDetailsService.UpdateAsync(contentPlatFormOrderDealDetailsService, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task DeleteByDealIdAsync(DeleteContentPlatFormOrderDealDetailsByDealIdDto deleteDto)
        {
            try
            {
                var contentPlatFormOrderDealDetailsService = await dalContentPlatFormOrderDealDetailsService.GetAll().Where(e => e.ContentPlatFormOrderDealId == deleteDto.DealId).ToListAsync();
                foreach (var x in contentPlatFormOrderDealDetailsService)
                {
                    var empInfo = await _amiyaEmployeeService.GetByIdAsync(x.CreateBy);
                    if (empInfo.IsDirector == false)
                    {
                        if (deleteDto.CreateBy != x.CreateBy)
                        {
                            continue;
                        }
                    }
                    x.Valid = false;
                    x.DeleteDate = DateTime.Now;
                    await dalContentPlatFormOrderDealDetailsService.DeleteAsync(x, true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task DeleteAsync(DeleteContentPlatFormOrderDealDetailsDto deleteDto)
        {
            try
            {
                var contentPlatFormOrderDealDetailsService = await dalContentPlatFormOrderDealDetailsService.GetAll().SingleOrDefaultAsync(e => e.Id == deleteDto.Id);
                if (contentPlatFormOrderDealDetailsService == null)
                    throw new Exception("成交详情编号错误！");
                var empInfo = await _amiyaEmployeeService.GetByIdAsync(contentPlatFormOrderDealDetailsService.CreateBy);
                if (empInfo.IsDirector == false)
                {
                    if (deleteDto.CreateBy != contentPlatFormOrderDealDetailsService.CreateBy)
                    {
                        throw new Exception("该笔成交订单为他人提交，您暂无修改权限，请联系管理员");
                    }
                }
                contentPlatFormOrderDealDetailsService.Valid = false;
                contentPlatFormOrderDealDetailsService.DeleteDate = DateTime.Now;
                await dalContentPlatFormOrderDealDetailsService.UpdateAsync(contentPlatFormOrderDealDetailsService, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

    }
}
