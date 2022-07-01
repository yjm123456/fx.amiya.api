using Fx.Amiya.Background.Api.Vo.WareHouse.InventoryList;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 盘库管理数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class InventoryListController : ControllerBase
    {
        private IInventoryListService _inventoryListService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inventoryListService"></param>
        public InventoryListController(IInventoryListService inventoryListService,

            IHttpContextAccessor httpContextAccessor)
        {
            _inventoryListService = inventoryListService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取盘库管理信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        
        public async Task<ResultData<FxPageInfo<InventoryListVo>>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, string keyword, string wareHouseInfoId, int pageNum, int pageSize)
        {
            try
            {
                var q = await _inventoryListService.GetListWithPageAsync(startDate, endDate,keyword, wareHouseInfoId, pageNum, pageSize);

                var inventoryList = from d in q.List
                              select new InventoryListVo
                              {
                                  Id = d.Id,
                                  GoodsName = d.GoodsName,
                                  Unit=d.Unit,
                                  WareHouseName=d.WareHouseName,
                                  InventoryStateText=d.InventoryStateText,
                                  InventoryNum=d.InventoryNum,
                                  InventoryPrice=d.InventoryPrice,
                                  BeforeInventorySinglePrice = d.BeforeInventorySinglePrice,
                                  BeforeInventoryNum = d.BeforeInventoryNum,
                                  BeforeInventoryAllPrice = d.BeforeInventoryAllPrice,
                                  AfterInventorySinglePrice = d.AfterInventorySinglePrice,
                                  AfterInventoryNum = d.AfterInventoryNum,
                                  AfterInventoryAllPrice = d.AfterInventoryAllPrice,
                                  CreateByEmpName = d.CreateByEmpName,
                                  CreateDate = d.CreateDate,
                                  Remark=d.Remark
                              };

                FxPageInfo<InventoryListVo> inventoryListPageInfo = new FxPageInfo<InventoryListVo>();
                inventoryListPageInfo.TotalCount = q.TotalCount;
                inventoryListPageInfo.List = inventoryList;

                return ResultData<FxPageInfo<InventoryListVo>>.Success().AddData("inventoryListInfo", inventoryListPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<InventoryListVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 盘库导出
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="keyword">关键字</param>
        /// <param name="wareHouseInfoId">归属仓库id</param>
        /// <returns></returns>
        [HttpGet("InventoryListExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> InventoryListExportAsync(DateTime? startDate, DateTime? endDate, string keyword, string wareHouseInfoId)
        {
            var q = await _inventoryListService.ExportListAsync(startDate, endDate, keyword, wareHouseInfoId);
            var res = from d in q
                      select new InventoryListExportVo()
                      {
                          GoodsName = d.GoodsName,
                          Unit=d.Unit,
                          WareHouseName=d.WareHouseName,
                          InventoryStateText = d.InventoryStateText,
                          InventoryNum = d.InventoryNum,
                          InventoryPrice = d.InventoryPrice,
                          BeforeInventorySinglePrice = d.BeforeInventorySinglePrice,
                          BeforeInventoryNum = d.BeforeInventoryNum,
                          BeforeInventoryAllPrice = d.BeforeInventoryAllPrice,
                          AfterInventorySinglePrice = d.AfterInventorySinglePrice,
                          AfterInventoryNum = d.AfterInventoryNum,
                          AfterInventoryAllPrice = d.AfterInventoryAllPrice,
                          CreateByEmpName = d.CreateByEmpName,
                          CreateDate = d.CreateDate,
                          Remark = d.Remark
                      };
            var exportOrderWriteOff = res.ToList();
            var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
            var result = File(stream, "application/vnd.ms-excel", $"" + startDate.Value.ToString("yyyy年MM月dd日") + "-" + endDate.Value.ToString("yyyy年MM月dd日") + "盘库报表.xls");
            return result;
        }

    }
}
