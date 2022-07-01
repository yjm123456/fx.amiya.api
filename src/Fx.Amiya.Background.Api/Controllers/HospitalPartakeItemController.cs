using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.HospitalPartakeItem;
using Fx.Amiya.Background.Api.Vo.ItemInfo;
using Fx.Amiya.Dto.HospitalPartakeItem;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class HospitalPartakeItemController : ControllerBase
    {
        private IHospitalPartakeItemService hospitalPartakeItemService;
        private IHttpContextAccessor httpContextAccessor;
        public HospitalPartakeItemController(IHospitalPartakeItemService hospitalPartakeItemService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.hospitalPartakeItemService = hospitalPartakeItemService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 医院参与报价项目
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        [FxTenantAuthorize]
        public async Task<ResultData> AddAsync(AddHospitalPartakeItemVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            int hospitalId = employee.HospitalId;

            AddHospitalPartakeItemDto addDto = new AddHospitalPartakeItemDto();
            addDto.ActivityId = addVo.ActivityId;
            List<ItemInfoDto> ItemInfoListDto = new List<ItemInfoDto>();

            foreach (var x in addVo.ItemInfoList)
            {
                ItemInfoDto itemInfo = new ItemInfoDto();
                itemInfo.ItemId = x.ItemId;
                itemInfo.IsAgreeLivingPrice = x.IsAgreeLivingPrice;
                itemInfo.HospitalPrice = x.HospitalPrice;
                ItemInfoListDto.Add(itemInfo);
            }
            addDto.ItemInfoList = ItemInfoListDto;
            await hospitalPartakeItemService.AddAsync(addDto, hospitalId);
            return ResultData.Success();
        }



        /// <summary>
        /// 根据活动编号获取医院参与的报价项目列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="activityId"></param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listByActityId")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<HospitalPartakeItemVo>>> GetListByActivityIdAsync(int? hospitalId, int activityId, string keyword, int pageNum, int pageSize)
        {
            FxPageInfo<HospitalPartakeItemVo> pageInfo = new FxPageInfo<HospitalPartakeItemVo>();
            if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
                hospitalId = tenant.HospitalId;

            if (hospitalId == null)
                throw new Exception("医院编号不能为空");

            var q = await hospitalPartakeItemService.GetListByActivityIdAsync((int)hospitalId, activityId, keyword, pageNum, pageSize);
            var hospitalQuotedPriceItemInfo = from d in q.List
                                              select new HospitalPartakeItemVo
                                              {
                                                  Id = d.Id,
                                                  HospitalId = d.HospitalId,
                                                  HospitalName = d.HospitalName,
                                                  ItemId = d.ItemId,
                                                  ThumbPicUrl = d.ThumbPicUrl,
                                                  Name = d.Name,
                                                  Description = d.Description,
                                                  Standard = d.Standard,
                                                  Parts = d.Parts,
                                                  SalePrice = d.SalePrice,
                                                  LivePrice = d.LivePrice,
                                                  IsLimitBuy = d.IsLimitBuy,
                                                  LimitBuyQuantity = d.LimitBuyQuantity,
                                                  ForenoonCanAppointmentQuantity = d.ForenoonCanAppointmentQuantity,
                                                  AfternoonCanAppointmentQuantity = d.AfternoonCanAppointmentQuantity,
                                                  IsAgreeLivingPrice = d.IsAgreeLivingPrice,
                                                  HospitalPrice = d.HospitalPrice
                                              };

            pageInfo.TotalCount = q.TotalCount;
            pageInfo.List = hospitalQuotedPriceItemInfo;
            return ResultData<FxPageInfo<HospitalPartakeItemVo>>.Success().AddData("hospitalPartakeItem", pageInfo);
        }





        /// <summary>
        /// 医院获取已参与过并且在该活动存在的项目编号集合
        /// </summary>
        /// <returns></returns>
        [HttpGet("itemIds/{activityId}")]
        [FxTenantAuthorize]
        public async Task<ResultData<List<ItemSimpleListVo>>> GetItemIdListByHospitalIdAsync(int activityId)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            int hospitalId = employee.HospitalId;
            var itemSimpleInfos = await hospitalPartakeItemService.GetItemIdListByHospitalIdAsync(hospitalId, activityId);
            List<ItemSimpleListVo> returnResult = new List<ItemSimpleListVo>();
            foreach (var x in itemSimpleInfos)
            {
                ItemSimpleListVo simpleInfoVo = new ItemSimpleListVo();
                simpleInfoVo.Id = x.Id;
                simpleInfoVo.IsAgreeLivingPrice = x.IsAgreeLivingPrice;
                simpleInfoVo.HospitalPrice = x.HospitalPrice;
                returnResult.Add(simpleInfoVo);
            }
            return ResultData<List<ItemSimpleListVo>>.Success().AddData("itemIds", returnResult);
        }







        /// <summary>
        /// 根据项目编号获取参与的医院列表（分页）
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="itemId">项目，为0查询所有</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("hospitalListByItemIdWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<PartakeHospitalInfoVo>>> GetHospitalListByItemIdWithPageAsync(int? activityId, int itemId, int pageNum, int pageSize)
        {
            var q = await hospitalPartakeItemService.GetHospitalListByItemIdWithPageAsync(activityId, itemId, pageNum, pageSize);
            var partakeHospitals = from d in q.List
                                   select new PartakeHospitalInfoVo
                                   {
                                       HospitalId = d.HospitalId,
                                       Name = d.HospitalName,
                                       ThumbPicUrl = d.ThumbPicUrl,
                                       Address = d.Address,
                                       LivingPrice = d.LivingPrice,
                                       IsAgreeLivingPrice = d.IsAgreeLivingPrice,
                                       HospitalPrice = d.HospitalPrice
                                   };
            FxPageInfo<PartakeHospitalInfoVo> pageInfo = new FxPageInfo<PartakeHospitalInfoVo>();
            pageInfo.TotalCount = q.TotalCount;
            pageInfo.List = partakeHospitals;
            return ResultData<FxPageInfo<PartakeHospitalInfoVo>>.Success().AddData("partakeHospitals", pageInfo);
        }








        /// <summary>
        /// 根据医院编号获取参与的项目列表（分页）
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("itemListByHospitalIdWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<PartakeItemInfoVo>>> GetItemListByHospitalIdWithPageAsync(int? activityId, int hospitalId, int pageNum, int pageSize)
        {
            var q = await hospitalPartakeItemService.GetItemListByHospitalIdWithPageAsync(activityId, hospitalId, pageNum, pageSize);
            var partakeItems = from d in q.List
                               select new PartakeItemInfoVo
                               {
                                   ItemId = d.ItemId,
                                   ThumbPicUrl = d.ThumbPicUrl,
                                   Name = d.Name,
                                   Description = d.Description,
                                   Standard = d.Standard,
                                   Parts = d.Parts,
                                   LivePrice = d.LivePrice,
                                   IsAgreeLivingPrice = d.IsAgreeLivingPrice,
                                   HospitalPrice = d.HospitalPrice,
                                   IsLimitBuy = d.IsLimitBuy,
                                   LimitBuyQuantity = d.LimitBuyQuantity,
                               };
            FxPageInfo<PartakeItemInfoVo> partakeItemPageInfo = new FxPageInfo<PartakeItemInfoVo>();
            partakeItemPageInfo.TotalCount = q.TotalCount;
            partakeItemPageInfo.List = partakeItems;
            return ResultData<FxPageInfo<PartakeItemInfoVo>>.Success().AddData("partakeItems", partakeItemPageInfo);
        }






        /// <summary>
        /// 根据城市和项目获取参与的医院列表（分页）
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="cityId"></param>
        /// <param name="itemId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("hospitalListByCityWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<PartakeHospitalInfoVo>>> GetHospitalListByCityWithPageAsync(int? activityId, int cityId, int itemId, int pageNum, int pageSize)
        {
            var q = await hospitalPartakeItemService.GetHospitalListByCityWithPageAsync(activityId, cityId, itemId, pageNum, pageSize);
            var partakeHospitals = from d in q.List
                                   select new PartakeHospitalInfoVo
                                   {
                                       HospitalId = d.HospitalId,
                                       Name = d.HospitalName,
                                       ThumbPicUrl = d.ThumbPicUrl,
                                       Address = d.Address,
                                       LivingPrice = d.LivingPrice,
                                       IsAgreeLivingPrice = d.IsAgreeLivingPrice,
                                       HospitalPrice = d.HospitalPrice
                                   };
            FxPageInfo<PartakeHospitalInfoVo> pageInfo = new FxPageInfo<PartakeHospitalInfoVo>();
            pageInfo.TotalCount = q.TotalCount;
            pageInfo.List = partakeHospitals;
            return ResultData<FxPageInfo<PartakeHospitalInfoVo>>.Success().AddData("partakeHospitals", pageInfo);
        }





        /// <summary>
        /// 根据城市和项目导出医院列表
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="cityId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet("exportHospitalListByCity")]
        [FxInternalAuthorize]
        public async Task<IActionResult> ExportHospitalListByCity(int? activityId, int cityId, int itemId)
        {

            string fileName = $"{Guid.NewGuid().ToString("N")}.xlsx";
            var stream = new MemoryStream();
            var partakeHospitals = await hospitalPartakeItemService.GetHospitalListByCityAsync(activityId, cityId, itemId);

            //ExcelPackage 操作excel的主要对象
            using (ExcelPackage package = new ExcelPackage(stream))
            {
                // 添加worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Conversation Message");
                //添加头
                worksheet.Cells[1, 1].Value = "医院";
                worksheet.Cells[1, 2].Value = "地址";
                worksheet.Cells[1, 3].Value = "是否同意直播价";
                worksheet.Cells[1, 4].Value = "直播价";
                worksheet.Cells[1, 5].Value = "医院提报价格";

                var rowNum = 2;
                foreach (var item in partakeHospitals)
                {
                    worksheet.Cells["A" + rowNum].Value = item.HospitalName;
                    worksheet.Cells["B" + rowNum].Value = item.Address;
                    worksheet.Cells["C" + rowNum].Value = item.IsAgreeLivingPrice == true ? "是" : "否";
                    worksheet.Cells["D" + rowNum].Value = item.LivingPrice;
                    worksheet.Cells["E" + rowNum].Value = item.HospitalPrice;
                    rowNum++;
                }

                package.Save();
            }
            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }




        /// <summary>
        /// 根据医院编号导出参与的项目列表
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        [HttpGet("exportItemListByHospitalId")]
        [FxInternalAuthorize]
        public async Task<IActionResult> ExportItemListByHospitalIdAsync(int? activityId, int hospitalId)
        {

            string fileName = $"{Guid.NewGuid().ToString("N")}.xlsx";
            var stream = new MemoryStream();
            var partakeItems = await hospitalPartakeItemService.GetItemListByHospitalIdAsync(activityId, hospitalId);
            using (ExcelPackage package = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Conversation Message");
                worksheet.Cells[1, 1].Value = "项目";
                worksheet.Cells[1, 2].Value = "简介";
                worksheet.Cells[1, 3].Value = "规格";
                worksheet.Cells[1, 4].Value = "是否限购";
                worksheet.Cells[1, 5].Value = "限购数量";
                worksheet.Cells[1, 6].Value = "是否同意直播价";
                worksheet.Cells[1, 7].Value = "直播价";
                worksheet.Cells[1, 8].Value = "医院提报价格";


                int rowNum = 2;
                foreach (var item in partakeItems)
                {
                    worksheet.Cells["A" + rowNum].Value = item.Name;
                    worksheet.Cells["B" + rowNum].Value = item.Description;
                    worksheet.Cells["C" + rowNum].Value = item.Standard;
                    worksheet.Cells["D" + rowNum].Value = item.IsLimitBuy == true ? "是" : "否";
                    worksheet.Cells["E" + rowNum].Value = item.SalePrice;
                    worksheet.Cells["F" + rowNum].Value = item.LimitBuyQuantity;
                    worksheet.Cells["G" + rowNum].Value = item.IsAgreeLivingPrice == true ? "是" : "否";
                    worksheet.Cells["H" + rowNum].Value = item.LivePrice;
                    worksheet.Cells["I" + rowNum].Value = item.HospitalPrice;

                    rowNum++;
                }
                package.Save();
            }
            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }




        /// <summary>
        /// 根据项目编号导出参与的医院列表
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet("exportHospitalListByItemId")]
        [FxInternalAuthorize]
        public async Task<IActionResult> ExportHospitalListByItemIdAsync(int? activityId, int itemId)
        {
            var partakeHoapitals = await hospitalPartakeItemService.GetHospitalListByItemIdAsync(activityId, itemId);

            string fileName = $"{Guid.NewGuid().ToString("N")}.xlsx";
            var stream = new MemoryStream();
            using (ExcelPackage package = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Conversation Message");
                worksheet.Cells[1, 1].Value = "医院";
                worksheet.Cells[1, 2].Value = "地址";
                worksheet.Cells[1, 3].Value = "是否同意直播价";
                worksheet.Cells[1, 4].Value = "直播价";
                worksheet.Cells[1, 5].Value = "医院提报价格";

                int rowNum = 2;
                foreach (var item in partakeHoapitals)
                {
                    worksheet.Cells["A" + rowNum].Value = item.HospitalName;
                    worksheet.Cells["B" + rowNum].Value = item.Address;
                    worksheet.Cells["C" + rowNum].Value = item.IsAgreeLivingPrice == true ? "是" : "否";
                    worksheet.Cells["D" + rowNum].Value = item.LivingPrice;
                    worksheet.Cells["E" + rowNum].Value = item.HospitalPrice;
                    rowNum++;
                }
                package.Save();
            }
            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}