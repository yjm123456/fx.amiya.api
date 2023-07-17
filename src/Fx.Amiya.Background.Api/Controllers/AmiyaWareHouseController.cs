using Fx.Amiya.Background.Api.Vo.WareHouse.AmiyaWareHouse;
using Fx.Amiya.Background.Api.Vo.WareHouse.AmiyaWareHouse.Input;
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
    /// 库存管理数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AmiyaWareHouseController : ControllerBase
    {
        private IAmiyaWareHouseService _amiyaWareHouseService;
        private IHttpContextAccessor httpContextAccessor;
        private IOperationLogService operationLogService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amiyaWareHouseService"></param>
        public AmiyaWareHouseController(IAmiyaWareHouseService amiyaWareHouseService,

            IHttpContextAccessor httpContextAccessor, IOperationLogService operationLogService)
        {
            _amiyaWareHouseService = amiyaWareHouseService;
            this.httpContextAccessor = httpContextAccessor;
            this.operationLogService = operationLogService;
        }


        /// <summary>
        /// 获取库存管理信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        
        public async Task<ResultData<FxPageInfo<AmiyaWareHouseVo>>> GetListWithPageAsync( string keyword, string wareHouseInfoId, int pageNum, int pageSize)
        {
            try
            {
                var q = await _amiyaWareHouseService.GetListWithPageAsync(keyword,wareHouseInfoId, pageNum, pageSize);

                var amiyaWareHouse = from d in q.List
                              select new AmiyaWareHouseVo
                              {
                                  Id = d.Id,
                                  Unit = d.Unit,
                                  GoodsName = d.GoodsName,
                                  GoodsSourceName = d.GoodsSourceName,
                                  StorageRacks=d.StorageRacks,
                                  SinglePrice = d.SinglePrice,
                                  Amount = d.Amount,
                                  TotalPrice = d.TotalPrice,
                              };

                FxPageInfo<AmiyaWareHouseVo> amiyaWareHousePageInfo = new FxPageInfo<AmiyaWareHouseVo>();
                amiyaWareHousePageInfo.TotalCount = q.TotalCount;
                amiyaWareHousePageInfo.List = amiyaWareHouse;

                return ResultData<FxPageInfo<AmiyaWareHouseVo>>.Success().AddData("amiyaWareHouseInfo", amiyaWareHousePageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<AmiyaWareHouseVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加库存管理信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
       
        public async Task<ResultData> AddAsync(AmiyaWareHouseAddVo addVo)
        {
            try
            {
                AmiyaWareHouseAddDto addDto = new AmiyaWareHouseAddDto();
                addDto.Unit = addVo.Unit;
                addDto.GoodsName = addVo.GoodsName;
                addDto.GoodsSourceId = addVo.GoodsSourceId;
                addDto.SinglePrice = addVo.SinglePrice;
                addDto.StorageRacksId = addVo.StorageRacksId;
                addDto.Amount = addVo.Amount;
                addDto.TotalPrice = addVo.TotalPrice;
                await _amiyaWareHouseService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据库存管理编号获取库存管理信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
       
        public async Task<ResultData<AmiyaWareHouseVo>> GetByIdAsync(string id)
        {
            try
            {
                var amiyaWareHouse = await _amiyaWareHouseService.GetByIdAsync(id);
                AmiyaWareHouseVo amiyaWareHouseVo = new AmiyaWareHouseVo();
                amiyaWareHouseVo.Id = amiyaWareHouse.Id;
                amiyaWareHouseVo.Unit = amiyaWareHouse.Unit;
                amiyaWareHouseVo.GoodsName = amiyaWareHouse.GoodsName;
                amiyaWareHouseVo.GoodsSourceId = amiyaWareHouse.GoodsSourceId;
                amiyaWareHouseVo.StorageRacksId = amiyaWareHouse.StorageRacksId;
                amiyaWareHouseVo.SinglePrice = amiyaWareHouse.SinglePrice;
                amiyaWareHouseVo.Amount = amiyaWareHouse.Amount;
                amiyaWareHouseVo.TotalPrice = amiyaWareHouse.TotalPrice;
                return ResultData<AmiyaWareHouseVo>.Success().AddData("amiyaWareHouseInfo", amiyaWareHouseVo);
            }
            catch (Exception ex)
            {
                return ResultData<AmiyaWareHouseVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改库存管理信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("update")]
       
        public async Task<ResultData> UpdateAsync(AmiyaWareHouseUpdateVo updateVo)
        {
            try
            {
                AmiyaWareHouseUpdateDto updateDto = new AmiyaWareHouseUpdateDto();
                updateDto.Id = updateVo.Id;
                updateDto.Unit = updateVo.Unit;
                updateDto.StorageRacksId = updateVo.StorageRacksId;
                updateDto.GoodsName = updateVo.GoodsName;
                updateDto.GoodsSourceId = updateVo.GoodsSourceId;
                await _amiyaWareHouseService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 盘库
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("InventoryWareHouse")]
       
        public async Task<ResultData> InventoryWareHouseAsync(InventoryWareHouseVo updateVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                AmiyaWareHouseUpdateDto updateDto = new AmiyaWareHouseUpdateDto();
                updateDto.Id = updateVo.Id;
                updateDto.SinglePrice = updateVo.SinglePrice;
                updateDto.Amount = updateVo.Amount;
                updateDto.TotalPrice = updateVo.TotalPrice;
                updateDto.CreateBy = employeeId;
                updateDto.Remark = updateVo.Remark;
                await _amiyaWareHouseService.InventoryWareHouseAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("OutWareHouse")]

        public async Task<ResultData> OutWareHouseAsync(InventoryWareHouseVo updateVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                AmiyaWareHouseUpdateDto updateDto = new AmiyaWareHouseUpdateDto();
                updateDto.Id = updateVo.Id;
                updateDto.SinglePrice = updateVo.SinglePrice;
                updateDto.DepartmentId = updateVo.DepartmentId;
                updateDto.EmployeeId = updateVo.EmployeeId;
                updateDto.Amount = updateVo.Amount;
                updateDto.TotalPrice = updateVo.TotalPrice;
                updateDto.CreateBy = employeeId;
                updateDto.Remark = updateVo.Remark;
                await _amiyaWareHouseService.OutWareHouseAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("InWareHouse")]

        public async Task<ResultData> InWareHouseAsync(InventoryWareHouseVo updateVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                AmiyaWareHouseUpdateDto updateDto = new AmiyaWareHouseUpdateDto();
                updateDto.Id = updateVo.Id;
                updateDto.SinglePrice = updateVo.SinglePrice;
                updateDto.Amount = updateVo.Amount;
                updateDto.TotalPrice = updateVo.TotalPrice;
                updateDto.CreateBy = employeeId;
                updateDto.Remark = updateVo.Remark;
                await _amiyaWareHouseService.InWareHouseAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 删除库存管理信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _amiyaWareHouseService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 库存报表导出
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="wareHouseInfoId"></param>
        /// <returns></returns>
        [HttpGet("AmiyaWareHouseExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> AmiyaWareHouseExportAsync([FromQuery]QueryAmiyaWareHouseExportVo query)
        {
            OperationAddDto operationAddDto = new OperationAddDto();
            operationAddDto.Code = 0;
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                operationAddDto.OperationBy = employeeId;
                var q = await _amiyaWareHouseService.ExportListAsync(query.Keyword, query.WareHouseInfoId);
                var res = from d in q
                          select new ExportAmiyaWareHouseVo()
                          {
                              Unit = d.Unit,
                              GoodsName = d.GoodsName,
                              GoodsSourceName = d.GoodsSourceName,
                              SinglePrice = d.SinglePrice,
                              StorageRacks = d.StorageRacks,
                              Amount = d.Amount,
                              TotalPrice = d.TotalPrice,
                          };
                var exportOrderWriteOff = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
                var result = File(stream, "application/vnd.ms-excel", $"库存报表.xls");
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
