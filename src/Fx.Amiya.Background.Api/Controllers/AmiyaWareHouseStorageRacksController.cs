using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.WareHouse.WareHouseStorageRacks.Input;
using Fx.Amiya.Background.Api.Vo.WareHouse.WareHouseStorageRacks.Output;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.Dto.WareHouse.WareHouseStorageRacksDto.Input;
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
    /// 货架管理数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AmiyaWareHouseStorageRacksController : ControllerBase
    {
        private IAmiyaWareHouseStorageRacksService _amiyaWareHouseStorageRacksService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amiyaWareHouseStorageRacksService"></param>
        public AmiyaWareHouseStorageRacksController(IAmiyaWareHouseStorageRacksService amiyaWareHouseStorageRacksService,

            IHttpContextAccessor httpContextAccessor)
        {
            _amiyaWareHouseStorageRacksService = amiyaWareHouseStorageRacksService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取货架管理信息列表（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        
        public async Task<ResultData<FxPageInfo<AmiyaWareHouseStorageRacksVo>>> GetListWithPageAsync( [FromQuery] QueryAmiyaWareHouseStorageRacksVo query)
        {
            try
            {
                QueryAmiyaWareHouseStorageRacksDto queryAmiyaWareHouseStorageRacksDto = new QueryAmiyaWareHouseStorageRacksDto();
                queryAmiyaWareHouseStorageRacksDto.PageNum = query.PageNum;
                queryAmiyaWareHouseStorageRacksDto.PageSize = query.PageSize;
                queryAmiyaWareHouseStorageRacksDto.KeyWord = query.KeyWord;
                queryAmiyaWareHouseStorageRacksDto.WarehouseId = query.WarehouseId;
                queryAmiyaWareHouseStorageRacksDto.Valid = query.Valid;
                var q = await _amiyaWareHouseStorageRacksService.GetListWithPageAsync(queryAmiyaWareHouseStorageRacksDto);

                var amiyaWareHouseStorageRacks = from d in q.List
                              select new AmiyaWareHouseStorageRacksVo
                              {
                                  Id = d.Id,
                                  WareHouseId = d.WareHouseId,
                                  WareHouseName = d.WareHouseName,
                                  CreateDate = d.CreateDate,
                                  CreateBy = d.CreateBy,
                                  CreateByEmpName=d.CreateByEmpName,
                                  Valid = d.Valid,
                                  DeleteDate = d.DeleteDate,
                              };

                FxPageInfo<AmiyaWareHouseStorageRacksVo> amiyaWareHouseStorageRacksPageInfo = new FxPageInfo<AmiyaWareHouseStorageRacksVo>();
                amiyaWareHouseStorageRacksPageInfo.TotalCount = q.TotalCount;
                amiyaWareHouseStorageRacksPageInfo.List = amiyaWareHouseStorageRacks;

                return ResultData<FxPageInfo<AmiyaWareHouseStorageRacksVo>>.Success().AddData("amiyaWareHouseStorageRacksInfo", amiyaWareHouseStorageRacksPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<AmiyaWareHouseStorageRacksVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加货架管理信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
       
        public async Task<ResultData> AddAsync(AmiyaWareHouseStorageRacksAddVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            try
            {
                AmiyaWareHouseStorageRacksAddDto addDto = new AmiyaWareHouseStorageRacksAddDto();
                addDto.WareHouseId = addVo.WareHouseId;
                addDto.CreateBy = employeeId;
                addDto.Name = addVo.Name;
                await _amiyaWareHouseStorageRacksService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据货架管理编号获取货架管理信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
       
        public async Task<ResultData<AmiyaWareHouseStorageRacksVo>> GetByIdAsync(string id)
        {
            try
            {
                var amiyaWareHouseStorageRacks = await _amiyaWareHouseStorageRacksService.GetByIdAsync(id);
                AmiyaWareHouseStorageRacksVo amiyaWareHouseStorageRacksVo = new AmiyaWareHouseStorageRacksVo();
                amiyaWareHouseStorageRacksVo.Id = amiyaWareHouseStorageRacks.Id;
                amiyaWareHouseStorageRacksVo.Name = amiyaWareHouseStorageRacks.Name;
                amiyaWareHouseStorageRacksVo.WareHouseId = amiyaWareHouseStorageRacks.WareHouseId;
                amiyaWareHouseStorageRacksVo.CreateBy = amiyaWareHouseStorageRacks.CreateBy;
                amiyaWareHouseStorageRacksVo.CreateDate = amiyaWareHouseStorageRacks.CreateDate;
                amiyaWareHouseStorageRacksVo.UpdateDate = amiyaWareHouseStorageRacks.UpdateDate;
                amiyaWareHouseStorageRacksVo.DeleteDate = amiyaWareHouseStorageRacks.DeleteDate;
                amiyaWareHouseStorageRacksVo.Valid = amiyaWareHouseStorageRacks.Valid;
                return ResultData<AmiyaWareHouseStorageRacksVo>.Success().AddData("amiyaWareHouseStorageRacksInfo", amiyaWareHouseStorageRacksVo);
            }
            catch (Exception ex)
            {
                return ResultData<AmiyaWareHouseStorageRacksVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改货架管理信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("update")]
       
        public async Task<ResultData> UpdateAsync(AmiyaWareHouseStorageRacksUpdateVo updateVo)
        {
            try
            {
                AmiyaWareHouseStorageRacksUpdateDto updateDto = new AmiyaWareHouseStorageRacksUpdateDto();
                updateDto.Id = updateVo.Id;
                updateDto.WareHouseId = updateVo.WareHouseId;
                updateDto.Name = updateVo.Name;
                await _amiyaWareHouseStorageRacksService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 删除货架管理信息(软删除)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _amiyaWareHouseStorageRacksService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 根据仓库id获取货架
        /// </summary>
        /// <param name="wareHouseId">仓库id</param>
        /// <returns></returns>
        [HttpGet("getAmiyawareHouseStorageRacks")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetOperatingConsultingNameListAsync(string wareHouseId)
        {
            var result = from d in await _amiyaWareHouseStorageRacksService.GetValidByWareHouseIdAsync(wareHouseId)
                           select new BaseIdAndNameVo
                           {
                               Id = d.Key,
                               Name = d.Value
                           };
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("amiyawareHouseStorageRacks", result.ToList());
        }

    }
}
