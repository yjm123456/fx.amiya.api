using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.CustomerTagInfo;
using Fx.Amiya.Dto.CustomerTagInfo;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 客户标签板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class CustomerTagInfoController : ControllerBase
    {
        private ICustomerTagInfoService customerTagInfoService;
        private IOrderService _orderService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="customerTagInfoService"></param>
        public CustomerTagInfoController(ICustomerTagInfoService customerTagInfoService, IOrderService orderService)
        {
            this.customerTagInfoService = customerTagInfoService;
            _orderService = orderService;
        }


        /// <summary>
        /// 获取客户标签信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="categoryId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<CustomerTagInfoVo>>> GetListWithPageAsync(string keyword,int? categoryId, int pageNum, int pageSize)
        {
            try
            {
                var q = await customerTagInfoService.GetListWithPageAsync(keyword, categoryId, pageNum, pageSize);

                var customerTagInfo = from d in q.List
                              select new CustomerTagInfoVo
                              {
                                  Id = d.Id,
                                  TagName = d.TagName,
                                  TagCategory=d.TagCategory,
                                  TagCategoryName =d.TagCategoryName,
                                  CreateDate = d.CreateDate,
                                  Valid = d.Valid
                              };

                FxPageInfo<CustomerTagInfoVo> customerTagInfoPageInfo = new FxPageInfo<CustomerTagInfoVo>();
                customerTagInfoPageInfo.TotalCount = q.TotalCount;
                customerTagInfoPageInfo.List = customerTagInfo;

                return ResultData<FxPageInfo<CustomerTagInfoVo>>.Success().AddData("customerTagInfoInfo", customerTagInfoPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<CustomerTagInfoVo>>.Fail(ex.Message);
            }
        }


        ///// <summary>
        ///// 获取客户标签id和名称（下拉框使用）
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("getCustomerTagInfoList")]
        //public async Task<ResultData<List<CustomerTagInfoIdAndNameVo>>> getCustomerTagInfoList()
        //{
        //    try
        //    {
        //        var q = await customerTagInfoService.GetIdAndNames();

        //        var customerTagInfo = from d in q
        //                      select new CustomerTagInfoIdAndNameVo
        //                      {
        //                          Id = d.Id,
        //                          CustomerTagInfoName = d.CustomerTagInfoName
        //                      };

        //        return ResultData<List<CustomerTagInfoIdAndNameVo>>.Success().AddData("CustomerTagInfoList", customerTagInfo.ToList());
        //    }
        //    catch (Exception ex)
        //    {
        //        return ResultData<List<CustomerTagInfoIdAndNameVo>>.Fail().AddData("CustomerTagInfoList", new List<CustomerTagInfoIdAndNameVo>());
        //    }
        //}


        /// <summary>
        /// 添加客户标签信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddCustomerTagInfoVo addVo)
        {
            try
            {
                AddCustomerTagInfoDto addDto = new AddCustomerTagInfoDto();
                addDto.TagName = addVo.TagName;
                addDto.TagCategory = addVo.TagCategory;
                await customerTagInfoService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据客户标签编号获取客户标签信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<CustomerTagInfoVo>> GetByIdAsync(string id)
        {
            try
            {
                var customerTagInfo = await customerTagInfoService.GetByIdAsync(id);
                CustomerTagInfoVo customerTagInfoVo = new CustomerTagInfoVo();
                customerTagInfoVo.Id = customerTagInfo.Id;
                customerTagInfoVo.TagName = customerTagInfo.TagName;
                customerTagInfoVo.Valid = customerTagInfo.Valid;
                customerTagInfoVo.TagCategory = customerTagInfo.TagCategory;
                customerTagInfoVo.TagCategoryName = customerTagInfo.TagCategoryName;
                return ResultData<CustomerTagInfoVo>.Success().AddData("customerTagInfoInfo", customerTagInfoVo);
            }
            catch (Exception ex)
            {
                return ResultData<CustomerTagInfoVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改客户标签信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateCustomerTagInfoVo updateVo)
        {
            try
            {
                UpdateCustomerTagInfoDto updateDto = new UpdateCustomerTagInfoDto();
                updateDto.Id = updateVo.Id;
                updateDto.TagName = updateVo.TagName;
                updateDto.Valid = updateVo.Valid;
                updateDto.TagCategory = updateVo.TagCategory;
                await customerTagInfoService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除客户标签信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await customerTagInfoService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
        /// <summary>
        /// 获取用户标签名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("customerTagNameList")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetCustomerTagNameList() {
            var list=(await customerTagInfoService.GetCustomerTagNameList()).Select(e=>new BaseIdAndNameVo { 
                Id=e.Key,
                Name=e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("customerTagNameList",list);
        }
        /// <summary>
        /// 获取面部标签名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("faceTagNameList")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetFaceTagNameList()
        {
            var list = (await customerTagInfoService.GetFaceTagNameList()).Select(e => new BaseIdAndNameVo
            {
                Id = e.Key,
                Name = e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("faceTagNameList", list);
        }
        /// <summary>
        /// 获取标签类别名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("tagCategoryNameList")]
        public async Task<ResultData<List<TagCategoryIdAndNameVo>>> GetTagCategoryNameList() { 
            var list= (await customerTagInfoService.GetTagCategoryNameListAsync()).Select(e => new TagCategoryIdAndNameVo
            {
                Id = Convert.ToInt32(e.Key),
                Name = e.Value
            }).ToList();
            return ResultData<List<TagCategoryIdAndNameVo>>.Success().AddData("tagCategoryNameList", list);
        }

    }
}
