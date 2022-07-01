using Fx.Amiya.Background.Api.Vo.AmiyaGoodsDemand;
using Fx.Amiya.Dto.GoodsDemand;
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
    /// 商品需求数据板块接口
    /// </summary>

    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AmiyaGoodsDemandController : ControllerBase
    {

        private IAmiyaGoodsDemandService amiyaGoodsDemandService;
        private IAmiyaHospitalDepartmentService _amiyaHospitalDepartmentService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amiyaGoodsDemandService"></param>
        public AmiyaGoodsDemandController(IAmiyaGoodsDemandService amiyaGoodsDemandService, IAmiyaHospitalDepartmentService amiyaHospitalDepartmentService)
        {
            this.amiyaGoodsDemandService = amiyaGoodsDemandService;
            _amiyaHospitalDepartmentService = amiyaHospitalDepartmentService;
        }


        /// <summary>
        /// 获取商品需求信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<AmiyaGoodsDemandVo>>> GetListWithPageAsync(string keyword, int pageNum, int pageSize)
        {
            try
            {
                var q = await amiyaGoodsDemandService.GetListWithPageAsync(keyword, pageNum, pageSize);

                var amiyaGoodsDemand = from d in q.List
                              select new AmiyaGoodsDemandVo
                              {
                                  Id = d.Id,
                                  ProjectNname = d.ProjectNname,
                                  HospitalDepartmentId=d.HospitalDepartmentId,
                                  HospitalDepartmentName = _amiyaHospitalDepartmentService.GetByIdAsync(d.HospitalDepartmentId).Result.DepartmentName,
                                  Description = d.Description,
                                  ThumbPictureUrl=d.ThumbPictureUrl,
                                  Valid = d.Valid
                              };

                FxPageInfo<AmiyaGoodsDemandVo> amiyaGoodsDemandPageInfo = new FxPageInfo<AmiyaGoodsDemandVo>();
                amiyaGoodsDemandPageInfo.TotalCount = q.TotalCount;
                amiyaGoodsDemandPageInfo.List = amiyaGoodsDemand;

                return ResultData<FxPageInfo<AmiyaGoodsDemandVo>>.Success().AddData("amiyaGoodsDemandInfo", amiyaGoodsDemandPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<AmiyaGoodsDemandVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 获取商品需求id和名称（下拉框使用）【可根据科室id进行筛选】
        /// </summary>
        /// <param name="hospitalDepartmentId"></param>
        /// <returns></returns>
        [HttpGet("getAmiyaGoodsDemandList")]
        public async Task<ResultData<List<AmiyaGoodsDemandIdAndNameVo>>> getAmiyaGoodsDemandList(string hospitalDepartmentId)
        {
            try
            {
                var q = await amiyaGoodsDemandService.GetIdAndNames(hospitalDepartmentId);

                var amiyaGoodsDemand = from d in q
                              select new AmiyaGoodsDemandIdAndNameVo
                              {
                                  Id = d.Id,
                                  ProjectName = d.ProjectNname
                              };

                return ResultData<List<AmiyaGoodsDemandIdAndNameVo>>.Success().AddData("AmiyaGoodsDemandList", amiyaGoodsDemand.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<AmiyaGoodsDemandIdAndNameVo>>.Fail().AddData("AmiyaGoodsDemandList", new List<AmiyaGoodsDemandIdAndNameVo>());
            }
        }


        /// <summary>
        /// 添加商品需求信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddAmiyaGoodsDemandVo addVo)
        {
            try
            {
                AddAmiyaGoodsDemandDto addDto = new AddAmiyaGoodsDemandDto();
                addDto.ProjectNname = addVo.ProjectName;
                addDto.HospitalDepartmentId = addVo.HospitalDepartmentId;
                addDto.Description = addVo.Description;
                addDto.ThumbPictureUrl = addVo.ThumbPictureUrl;
                await amiyaGoodsDemandService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据商品需求编号获取商品需求信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<AmiyaGoodsDemandVo>> GetByIdAsync(string id)
        {
            try
            {
                var amiyaGoodsDemand = await amiyaGoodsDemandService.GetByIdAsync(id);
                AmiyaGoodsDemandVo amiyaGoodsDemandVo = new AmiyaGoodsDemandVo();
                amiyaGoodsDemandVo.Id = amiyaGoodsDemand.Id;
                amiyaGoodsDemandVo.ProjectNname = amiyaGoodsDemand.ProjectNname;
                amiyaGoodsDemandVo.HospitalDepartmentId = amiyaGoodsDemand.HospitalDepartmentId;
                amiyaGoodsDemandVo.HospitalDepartmentName = amiyaGoodsDemand.HospitalDepartmentName;
                amiyaGoodsDemandVo.ThumbPictureUrl = amiyaGoodsDemand.ThumbPictureUrl;
                amiyaGoodsDemandVo.Description = amiyaGoodsDemand.Description;
                amiyaGoodsDemandVo.Valid = amiyaGoodsDemand.Valid;
                return ResultData<AmiyaGoodsDemandVo>.Success().AddData("amiyaGoodsDemandInfo", amiyaGoodsDemandVo);
            }
            catch (Exception ex)
            {
                return ResultData<AmiyaGoodsDemandVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改商品需求信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateAmiyaGoodsDemandVo updateVo)
        {
            try
            {
                UpdateAmiyaGoodsDemandDto updateDto = new UpdateAmiyaGoodsDemandDto();
                updateDto.Id = updateVo.Id;
                updateDto.ProjectNname = updateVo.ProjectNname;
                updateDto.HospitalDepartmentId = updateVo.HospitalDepartmentId;
                updateDto.Description = updateVo.Description;
                updateDto.ThumbPictureUrl = updateVo.ThumbPictureUrl;
                updateDto.Valid = updateVo.Valid;
                await amiyaGoodsDemandService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除商品需求信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await amiyaGoodsDemandService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
