using Fx.Amiya.Background.Api.Vo.WareHouse.AmiyaWareHouse.Input;
using Fx.Amiya.Background.Api.Vo.WareHouse.AmiyaWareHouse.OutWareHouse;
using Fx.Amiya.Dto.OperationLog;
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
    /// 出库管理数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AmiyaOutWarehouseController : ControllerBase
    {
        private IAmiyaOutWareHouseService _amiyaOutWarehouseService;
        private IHttpContextAccessor httpContextAccessor;
        private IOperationLogService operationLogService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amiyaOutWarehouseService"></param>
        public AmiyaOutWarehouseController(IAmiyaOutWareHouseService amiyaOutWarehouseService,

            IHttpContextAccessor httpContextAccessor, IOperationLogService operationLogService)
        {
            _amiyaOutWarehouseService = amiyaOutWarehouseService;
            this.httpContextAccessor = httpContextAccessor;
            this.operationLogService = operationLogService;
        }


        /// <summary>
        /// 获取出库管理信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]

        public async Task<ResultData<FxPageInfo<AmiyaOutWarehouseVo>>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, string wareHouseInfoId, string warehouseStorageRacksId, string keyword, int pageNum, int pageSize)
        {
            try
            {
                var q = await _amiyaOutWarehouseService.GetListWithPageAsync(startDate, endDate, keyword, wareHouseInfoId,warehouseStorageRacksId, pageNum, pageSize);

                var amiyaOutWarehouse = from d in q.List
                                        select new AmiyaOutWarehouseVo
                                        {
                                            Id = d.Id,
                                            GoodsName = d.GoodsName,
                                            Unit = d.Unit,
                                            WareHouseName = d.WareHouseName,
                                            StorageRacksName=d.StorageRacksName,
                                            SinglePrice = d.SinglePrice,
                                            Num = d.Num,
                                            AllPrice = d.AllPrice,
                                            Department=d.Department,
                                            UseEmployee=d.UseEmployee,
                                            Remark = d.Remark,
                                            CreateByEmpName = d.CreateByEmpName,
                                            CreateDate = d.CreateDate,
                                        };

                FxPageInfo<AmiyaOutWarehouseVo> amiyaOutWarehousePageOutfo = new FxPageInfo<AmiyaOutWarehouseVo>();
                amiyaOutWarehousePageOutfo.TotalCount = q.TotalCount;
                amiyaOutWarehousePageOutfo.List = amiyaOutWarehouse;

                return ResultData<FxPageInfo<AmiyaOutWarehouseVo>>.Success().AddData("amiyaOutWarehouseOutfo", amiyaOutWarehousePageOutfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<AmiyaOutWarehouseVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 出库导出
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="keyword">关键字</param>
        /// <param name="wareHouseInfoId">归属仓库id</param>
        /// <returns></returns>
        [HttpGet("AmiyaOutWareHouseExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> AmiyaOutWareHouseExportAsync([FromQuery] QueryAmiyaOutWareHouseExportVo query)
        {
            OperationAddDto operationAddDto = new OperationAddDto();
            operationAddDto.Code = 0;
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                operationAddDto.OperationBy = employeeId;
                var q = await _amiyaOutWarehouseService.ExportListAsync(query.StartDate, query.EndDate, query.Keyword, query.WareHouseInfoId,query.WarehouseStorageRacksId);
                var res = from d in q
                          select new AmiyaOutWarehouseExportVo()
                          {
                              GoodsName = d.GoodsName,
                              Unit = d.Unit,
                              WareHouseName = d.WareHouseName,
                              SinglePrice = d.SinglePrice,
                              Num = d.Num,
                              StorageRacksName=d.StorageRacksName,
                              AllPrice = d.AllPrice,
                              Remark = d.Remark,
                              Department = d.Department,
                              UseEmployee = d.UseEmployee,
                              CreateByEmpName = d.CreateByEmpName,
                              CreateDate = d.CreateDate,
                          };
                var exportOrderWriteOff = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "出库报表.xls");
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
                
                operationAddDto.Parameters = JsonConvert.SerializeObject(query);
                operationAddDto.RequestType = (int)RequestType.Export;
                operationAddDto.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationAddDto);
            }
        }
    }
}
