using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.AmiyaPositionInfo;
using Fx.Amiya.Dto.AmiyaPositionInfo;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 啊美雅职位 API
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AmiyaPositionInfoController : ControllerBase
    {
        private IAmiyaPositionInfoService amiyaPositionInfoService;
        private IHttpContextAccessor httpContextAccessor;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amiyaPositionInfoService"></param>
        /// <param name="httpContextAccessor"></param>
        public AmiyaPositionInfoController(IAmiyaPositionInfoService amiyaPositionInfoService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.amiyaPositionInfoService = amiyaPositionInfoService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取啊美雅职位列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<List<AmiyaPositionInfoVo>>> GetListAsync()
        {
            try
            {
                var positionInfos = from d in await amiyaPositionInfoService.GetListAsync()
                                    select new AmiyaPositionInfoVo
                                    {
                                        Id = d.Id,
                                        Name = d.Name,
                                        CreateDate = d.CreateDate,
                                        UpdateDate = d.UpdateDate,
                                        UpdateBy = d.UpdateBy,
                                        UpdateName = d.UpdateName,
                                        IsDirector = d.IsDirector,
                                        DepartmentId = d.DepartmentId,
                                        DepartmentName = d.DepartmentName,
                                        ReadDataCenter=d.ReadDataCenter,
                                        ReadLiveAnchorData=d.ReadLiveAnchorData,
                                        ReadCooperateLiveAnchorData=d.ReadCooperateLiveAnchorData,
                                        ReadSelfLiveAnchorData=d.ReadSelfLiveAnchorData,
                                        ReadTakeGoodsData=d.ReadTakeGoodsData
                                    };
                return ResultData<List<AmiyaPositionInfoVo>>.Success().AddData("positionInfo", positionInfos.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<AmiyaPositionInfoVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加啊美雅职位
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<ResultData> AddAsync(AddAmiyaPositionInfoVo addVo)
        {
            try
            {
                AddAmiyaPositionInfoDto addDto = new AddAmiyaPositionInfoDto();
                addDto.Name = addVo.Name;
                addDto.DepartmentId = addVo.DepartmentId;
                addDto.IsDirector = addVo.IsDirector;
                addDto.ReadDataCenter = addVo.ReadDataCenter;
                addDto.ReadLiveAnchorData = addVo.ReadLiveAnchorData;
                addDto.ReadSelfLiveAnchorData=addVo.ReadSelfLiveAnchorData;
                addDto.ReadCooperateLiveAnchorData = addVo.ReadCooperateLiveAnchorData;
                addDto.ReadTakeGoodsData= addVo.ReadTakeGoodsData;
                await amiyaPositionInfoService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据职位编号获取啊美雅职位信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<AmiyaPositionInfoVo>> GetByIdAsync(int id)
        {
            try
            {
                var position = await amiyaPositionInfoService.GetByIdAsync(id);
                AmiyaPositionInfoVo positionInfoVo = new AmiyaPositionInfoVo();
                positionInfoVo.Id = position.Id;
                positionInfoVo.Name = position.Name;
                positionInfoVo.CreateDate = position.CreateDate;
                positionInfoVo.UpdateBy = position.UpdateBy;
                positionInfoVo.UpdateDate = position.UpdateDate;
                positionInfoVo.UpdateName = position.UpdateName;
                positionInfoVo.IsDirector = position.IsDirector;
                positionInfoVo.DepartmentId = position.DepartmentId;
                positionInfoVo.DepartmentName = position.DepartmentName;
                positionInfoVo.ReadDataCenter = position.ReadDataCenter;
                positionInfoVo.ReadLiveAnchorData = position.ReadLiveAnchorData;
                positionInfoVo.ReadSelfLiveAnchorData = position.ReadSelfLiveAnchorData;
                positionInfoVo.ReadCooperateLiveAnchorData = position.ReadCooperateLiveAnchorData;
                positionInfoVo.ReadTakeGoodsData = position.ReadTakeGoodsData;
                return ResultData<AmiyaPositionInfoVo>.Success().AddData("positionInfo", positionInfoVo);
            }
            catch (Exception ex)
            {
                return ResultData<AmiyaPositionInfoVo>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据部门编号获取啊美雅职位信息
        /// </summary>
        /// <param name="departmentId">部门id</param>
        /// <returns></returns>
        [HttpGet("byDepartmentId/{departmentId}")]
        public async Task<ResultData<List<AmiyaPositionInfoVo>>> GetByDepartmentIdAsync(int departmentId)
        {
            try
            {
                var position = await amiyaPositionInfoService.GetByDepartmentIdAsync(departmentId);
                List<AmiyaPositionInfoVo> amiyaPositionInfoVos = new List<AmiyaPositionInfoVo>();
                foreach (var x in position)
                {
                    AmiyaPositionInfoVo positionInfoVo = new AmiyaPositionInfoVo();
                    positionInfoVo.Id = x.Id;
                    positionInfoVo.Name = x.Name;
                    positionInfoVo.CreateDate = x.CreateDate;
                    positionInfoVo.UpdateBy = x.UpdateBy;
                    positionInfoVo.UpdateDate = x.UpdateDate;
                    positionInfoVo.UpdateName = x.UpdateName;
                    positionInfoVo.IsDirector = x.IsDirector;
                    positionInfoVo.DepartmentId = x.DepartmentId;
                    positionInfoVo.DepartmentName = x.DepartmentName;
                    positionInfoVo.ReadDataCenter = x.ReadDataCenter;
                    positionInfoVo.ReadLiveAnchorData = x.ReadLiveAnchorData;
                    positionInfoVo.ReadSelfLiveAnchorData = x.ReadSelfLiveAnchorData;
                    positionInfoVo.ReadCooperateLiveAnchorData = x.ReadCooperateLiveAnchorData;
                    positionInfoVo.ReadTakeGoodsData = x.ReadTakeGoodsData;
                    amiyaPositionInfoVos.Add(positionInfoVo);
                }

                return ResultData<List<AmiyaPositionInfoVo>>.Success().AddData("positionInfo", amiyaPositionInfoVos);
            }
            catch (Exception ex)
            {
                return ResultData<List<AmiyaPositionInfoVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改啊美雅职位
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateAmiyaPositionInfoVo updateVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                UpdateAmiyaPositionInfoDto updateDto = new UpdateAmiyaPositionInfoDto();
                updateDto.Id = updateVo.Id;
                updateDto.Name = updateVo.Name;
                updateDto.DepartmentId = updateVo.DepartmentId;
                updateDto.IsDirector = updateVo.IsDirector;
                updateDto.ReadDataCenter = updateVo.ReadDataCenter;
                updateDto.ReadLiveAnchorData = updateVo.ReadLiveAnchorData;
                updateDto.ReadTakeGoodsData=updateVo.ReadTakeGoodsData;
                updateDto.ReadCooperateLiveAnchorData = updateVo.ReadCooperateLiveAnchorData;
                updateDto.ReadSelfLiveAnchorData = updateVo.ReadSelfLiveAnchorData;
                await amiyaPositionInfoService.UpdateAsync(updateDto, employeeId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据职位编号删除啊美雅职位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(int id)
        {
            try
            {
                await amiyaPositionInfoService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


    }
}