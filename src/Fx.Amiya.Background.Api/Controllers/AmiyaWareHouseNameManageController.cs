using Fx.Amiya.Background.Api.Vo.WareHouse.AmiyaWareHouseName;
using Fx.Amiya.Dto.WareHouse.WareHouseNameManage;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 仓库名称管理数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AmiyaWareHouseNameManageController : ControllerBase
    {
        private IAmiyaWareHouseNameManageService _amiyaWareHouseNameManageService;
        private IHttpContextAccessor httpContextAccessor;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amiyaWareHouseNameManageService"></param>
        public AmiyaWareHouseNameManageController(IAmiyaWareHouseNameManageService amiyaWareHouseNameManageService,

            IHttpContextAccessor httpContextAccessor)
        {
            _amiyaWareHouseNameManageService = amiyaWareHouseNameManageService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取仓库名称管理信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        
        public async Task<ResultData<FxPageInfo<AmiyaWareHouseNameManageVo>>> GetListWithPageAsync( string keyword, int pageNum, int pageSize)
        {
            try
            {
                var q = await _amiyaWareHouseNameManageService.GetListWithPageAsync(keyword, pageNum, pageSize);

                var amiyaWareHouseNameManage = from d in q.List
                              select new AmiyaWareHouseNameManageVo
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                                  Valid = d.Valid,
                              };

                FxPageInfo<AmiyaWareHouseNameManageVo> amiyaWareHouseNameManagePageInfo = new FxPageInfo<AmiyaWareHouseNameManageVo>();
                amiyaWareHouseNameManagePageInfo.TotalCount = q.TotalCount;
                amiyaWareHouseNameManagePageInfo.List = amiyaWareHouseNameManage;

                return ResultData<FxPageInfo<AmiyaWareHouseNameManageVo>>.Success().AddData("amiyaWareHouseNameManageInfo", amiyaWareHouseNameManagePageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<AmiyaWareHouseNameManageVo>>.Fail(ex.Message);
            }
        }
        [HttpGet("getIdAndName")]

        public async Task<ResultData<List<AmiyaWareHouseNameBaseInfoVo>>> GetIdAndNameAsync()
        {
            try
            {
                var q = await _amiyaWareHouseNameManageService.GetIdAndNameAsync();

                var amiyaWareHouseNameManage = from d in q
                                               select new AmiyaWareHouseNameBaseInfoVo
                                               {
                                                   Id = d.Id,
                                                   Name = d.Name
                                               };
                var result =  amiyaWareHouseNameManage.ToList();
                return ResultData<List<AmiyaWareHouseNameBaseInfoVo>>.Success().AddData("amiyaWareHouseNameManageInfo", result);
            }
            catch (Exception ex)
            {
                return ResultData<List<AmiyaWareHouseNameBaseInfoVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 添加仓库名称管理信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        
        public async Task<ResultData> AddAsync(AddAmiyaWareHouseNameManageVo addVo)
        {
            try
            {
                AmiyaWareHouseNameManageAddDto addDto = new AmiyaWareHouseNameManageAddDto();
                addDto.Name = addVo.Name;
                await _amiyaWareHouseNameManageService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据仓库名称管理编号获取仓库名称管理信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        
        public async Task<ResultData<AmiyaWareHouseNameManageVo>> GetByIdAsync(string id)
        {
            try
            {
                var amiyaWareHouseNameManage = await _amiyaWareHouseNameManageService.GetByIdAsync(id);
                AmiyaWareHouseNameManageVo amiyaWareHouseNameManageVo = new AmiyaWareHouseNameManageVo();
                amiyaWareHouseNameManageVo.Id = amiyaWareHouseNameManage.Id;
                amiyaWareHouseNameManageVo.Name = amiyaWareHouseNameManage.Name;
                amiyaWareHouseNameManageVo.Valid = amiyaWareHouseNameManage.Valid;
                return ResultData<AmiyaWareHouseNameManageVo>.Success().AddData("amiyaWareHouseNameManageInfo", amiyaWareHouseNameManageVo);
            }
            catch (Exception ex)
            {
                return ResultData<AmiyaWareHouseNameManageVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改仓库名称管理信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        
        public async Task<ResultData> UpdateAsync(UpdateAmiyaWareHouseNameManageVo updateVo)
        {
            try
            {
                AmiyaWareHouseNameManageUpdateDto updateDto = new AmiyaWareHouseNameManageUpdateDto();
                updateDto.Id = updateVo.Id;
                updateDto.Name = updateVo.Name;
                updateDto.Valid = updateVo.Valid;
                await _amiyaWareHouseNameManageService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除仓库名称管理信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _amiyaWareHouseNameManageService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
