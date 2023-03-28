using Fx.Amiya.Background.Api.Vo.WareHouse.AmiyaWareHouse.Input;
using Fx.Amiya.Background.Api.Vo.WareHouse.AmiyaWareHouse.InWareHouse;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 入库管理数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AmiyaInWarehouseController : ControllerBase
    {
        private IAmiyaInWareHouseService _amiyaInWarehouseService;
        private IHttpContextAccessor httpContextAccessor;
        private IOperationLogService operationLogService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amiyaInWarehouseService"></param>
        public AmiyaInWarehouseController(IAmiyaInWareHouseService amiyaInWarehouseService,

            IHttpContextAccessor httpContextAccessor, IOperationLogService operationLogService)
        {
            _amiyaInWarehouseService = amiyaInWarehouseService;
            this.httpContextAccessor = httpContextAccessor;
            this.operationLogService = operationLogService;
        }


        /// <summary>
        /// 获取入库管理信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]

        public async Task<ResultData<FxPageInfo<AmiyaInWarehouseVo>>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, string keyword, string wareHouseInfoId, int pageNum, int pageSize)
        {
            try
            {
                var q = await _amiyaInWarehouseService.GetListWithPageAsync(startDate, endDate, keyword, wareHouseInfoId, pageNum, pageSize);

                var amiyaInWarehouse = from d in q.List
                                       select new AmiyaInWarehouseVo
                                       {
                                           Id = d.Id,
                                           WareHouseName = d.WareHouseName,
                                           Unit = d.Unit,
                                           GoodsName = d.GoodsName,
                                           SinglePrice = d.SinglePrice,
                                           Num = d.Num,
                                           AllPrice = d.AllPrice,
                                           Remark = d.Remark,
                                           CreateByEmpName = d.CreateByEmpName,
                                           CreateDate = d.CreateDate,
                                       };

                FxPageInfo<AmiyaInWarehouseVo> amiyaInWarehousePageInfo = new FxPageInfo<AmiyaInWarehouseVo>();
                amiyaInWarehousePageInfo.TotalCount = q.TotalCount;
                amiyaInWarehousePageInfo.List = amiyaInWarehouse;

                return ResultData<FxPageInfo<AmiyaInWarehouseVo>>.Success().AddData("amiyaInWarehouseInfo", amiyaInWarehousePageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<AmiyaInWarehouseVo>>.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 入库导出
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="keyword">关键字</param>
        /// <param name="wareHouseInfoId">归属仓库id</param>
        /// <returns></returns>
        [HttpGet("AmiyaInWareHouseExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> AmiyaInWareHouseExportAsync([FromQuery]QueryAmiyaInWareHouseExportVo query)
        {
            OperationAddDto operationAddDto = new OperationAddDto();
            operationAddDto.Code = 0;
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                operationAddDto.OperationBy = employeeId;
                var q = await _amiyaInWarehouseService.ExportListAsync(query.StartDate, query.EndDate, query.Keyword, query.WareHouseInfoId);
                var res = from d in q
                          select new AmiyaInWarehouseExportVo()
                          {
                              GoodsName = d.GoodsName,
                              Unit = d.Unit,
                              WareHouseName = d.WareHouseName,
                              SinglePrice = d.SinglePrice,
                              Num = d.Num,
                              AllPrice = d.AllPrice,
                              Remark = d.Remark,
                              CreateByEmpName = d.CreateByEmpName,
                              CreateDate = d.CreateDate,
                          };
                var exportOrderWriteOff = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "入库报表.xls");
                return result;
            }
            catch (Exception err)
            {
                operationAddDto.Code = -1;
                operationAddDto.Message = err.Message.ToString();
                throw new Exception(err.Message.ToString());
            }
            finally
            {
                operationAddDto.Message = "";
                operationAddDto.Parameters = JsonConvert.SerializeObject(query);
                operationAddDto.RequestType = (int)RequestType.Export;
                operationAddDto.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationAddDto);
            }
        }

    }
}
