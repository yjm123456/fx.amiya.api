using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Core.Interfaces.GoodsHospitalPrice;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Vo.HospitalInfo;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    public class HospitalInfoController : ControllerBase
    {
        private IHospitalInfoService hospitalInfoService;
        private ITagInfoService _tagInfoService;
        private IGoodsHospitalsPrice _goodsHospitalPrice;
        public HospitalInfoController(IHospitalInfoService hospitalInfoService, IGoodsHospitalsPrice goodsHospitalPrice, ITagInfoService tagInfoService)
        {
            this.hospitalInfoService = hospitalInfoService;
            _goodsHospitalPrice = goodsHospitalPrice;
            _tagInfoService = tagInfoService;
        }


        /// <summary>
        /// 获取医院列表
        /// </summary>
        /// <param name="keyword">搜索关键字，可空</param>
        /// <param name="city">定位城市，可空</param>
        /// <returns></returns>
        [HttpGet("simpleList")]
        public async Task<ResultData<List<HospitalInfoSimpleVo>>> GetSimpleListAsync(string keyword, string city)
        {
            try
            {
                var hospital = from d in await hospitalInfoService.GetSimpleListAsync(keyword, city)
                               select new HospitalInfoSimpleVo
                               {
                                   Id = d.Id,
                                   Name = d.Name,
                                   ThumbPicUrl = d.ThumbPicUrl,
                                   Longitude = d.Longitude,
                                   Latitude = d.Latitude,
                                   IsRecommend = d.IsRecommend,
                                   Address = d.Address,
                                   BusinessHours = d.BusinessHours
                               };
                return ResultData<List<HospitalInfoSimpleVo>>.Success().AddData("hospitalInfoList", hospital.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalInfoSimpleVo>>.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 根据商品id获取门店医院
        /// </summary>
        /// <param name="goodsId">商品id</param>
        /// <param name="city">定位城市，可空</param>
        /// <returns></returns>
        [HttpGet("GoodsOfflineDoor")]
        public async Task<ResultData<List<HospitalInfoSimpleVo>>> GetHospitalsAsync(
        [System.ComponentModel.DataAnnotations.Required] string goodsId, string city)
        {
            try
            {
                var goodsHospitalPriceResult = await _goodsHospitalPrice.GetByGoodsId(goodsId);
                if (goodsHospitalPriceResult.Count == 0)
                {
                    List<HospitalInfoSimpleVo> returnNullList = new List<HospitalInfoSimpleVo>();
                    return ResultData<List<HospitalInfoSimpleVo>>.Success().AddData("hospitalInfoList", returnNullList.ToList());
                }

                List<HospitalInfoSimpleVo> hospitalInfoSimpleVoList = new List<HospitalInfoSimpleVo>();
                foreach (var x in goodsHospitalPriceResult)
                {
                    var hospitalInfo = await hospitalInfoService.GetBaseByIdAsync(x.HospitalId);
                    HospitalInfoSimpleVo hospitalInfoSimpleVo = new HospitalInfoSimpleVo();
                    hospitalInfoSimpleVo.Id = hospitalInfo.Id;
                    hospitalInfoSimpleVo.Name = hospitalInfo.Name;
                    hospitalInfoSimpleVo.ThumbPicUrl = hospitalInfo.ThumbPicUrl;
                    hospitalInfoSimpleVo.Longitude = hospitalInfo.Longitude;
                    hospitalInfoSimpleVo.Latitude = hospitalInfo.Latitude;
                    hospitalInfoSimpleVo.Address = hospitalInfo.Address;
                    hospitalInfoSimpleVo.BusinessHours = hospitalInfo.BusinessHours;
                    hospitalInfoSimpleVo.Phone = hospitalInfo.Phone;
                    hospitalInfoSimpleVo.HospitalSalePrice = x.Price;
                    if (!string.IsNullOrEmpty(city))
                    {
                        if (city == hospitalInfo.CityId.ToString())
                            hospitalInfoSimpleVoList.Add(hospitalInfoSimpleVo);
                    }
                    else
                    {
                        hospitalInfoSimpleVoList.Add(hospitalInfoSimpleVo);
                    }

                }
                return ResultData<List<HospitalInfoSimpleVo>>.Success().AddData("hospitalInfoList", hospitalInfoSimpleVoList);
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalInfoSimpleVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据项目名称获取医院详细列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="city">定位城市，可空</param>
        /// <param name="itemInfoId"></param>
        /// <returns></returns>
        [HttpGet("lsitWithPage")]
        public async Task<ResultData<FxPageInfo<WxHospitalInfoVo>>> GetListWithPageOfWxAsync(int pageNum, int pageSize, string city, int itemInfoId)
        {
            try
            {
                var q = await hospitalInfoService.GetListWithPageOfWxAsync(pageNum, pageSize, city, itemInfoId);
                var hospital = from h in q.List
                               select new WxHospitalInfoVo
                               {
                                   Id = h.Id,
                                   Name = h.Name,
                                   Address = h.Address,
                                   Longitude = h.Longitude,
                                   Latitude = h.Latitude,
                                   Phone = h.Phone,
                                   ThumbPicUrl = h.ThumbPicUrl,
                                   IsRecommend = h.IsRecommend,

                                   DocterList = (from d in h.DocterList
                                                 select new DocterVo
                                                 {
                                                     Id = d.Id,
                                                     Name = d.Name,
                                                     PicUrl = d.PicUrl,
                                                     Position = d.Position,
                                                     WorkYearNumer = d.WorkYearNumer,
                                                     Description = d.Description,
                                                 }).ToList(),

                                   ScaleTagList = (from s in h.ScaleTagList
                                                   select new WxHospitalTagInfoVo
                                                   {
                                                       Id = s.Id,
                                                       Name = s.Name
                                                   }).ToList(),

                                   FacilityTagList = (from s in h.FacilityTagList
                                                      select new WxHospitalTagInfoVo
                                                      {
                                                          Id = s.Id,
                                                          Name = s.Name
                                                      }).ToList()
                               };

                FxPageInfo<WxHospitalInfoVo> hospitalPageInfo = new FxPageInfo<WxHospitalInfoVo>();
                hospitalPageInfo.TotalCount = q.TotalCount;
                hospitalPageInfo.List = hospital;
                return ResultData<FxPageInfo<WxHospitalInfoVo>>.Success().AddData("hospitalInfo", hospitalPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<WxHospitalInfoVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据标签，名称，城市等筛选获取医院列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="city">城市名称</param>
        /// <param name="hospitalName">医院名称</param>
        /// <param name="tags">标签(选中多个用逗号隔开,例：2,3,4)</param>
        /// <returns></returns>
        [HttpGet("getListHospital")]
        public async Task<ResultData<FxPageInfo<WxHospitalInfoVo>>> GetListHospitalAsync(int pageNum, int pageSize, string city, string hospitalName,string tags)
        {
            try
            {
                List<string> Tags = new List<string>();
                if (!string.IsNullOrEmpty(tags))
                {
                    Tags = tags.Split(',').ToList();
                }
                var q = await hospitalInfoService.GetListHosPitalAsync(pageNum, pageSize, city, hospitalName,Tags);
                var hospital = from h in q.List
                               select new WxHospitalInfoVo
                               {
                                   Id = h.Id,
                                   Name = h.Name,
                                   Address = h.Address,
                                   Longitude = h.Longitude,
                                   Latitude = h.Latitude,
                                   Phone = h.Phone,
                                   ThumbPicUrl = h.ThumbPicUrl,
                                   IsRecommend = h.IsRecommend,

                                   DocterList = (from d in h.DocterList
                                                 select new DocterVo
                                                 {
                                                     Id = d.Id,
                                                     Name = d.Name,
                                                     PicUrl = d.PicUrl,
                                                     Position = d.Position,
                                                     WorkYearNumer = d.WorkYearNumer,
                                                     Description = d.Description,
                                                 }).ToList(),

                                   ScaleTagList = (from s in h.ScaleTagList
                                                   select new WxHospitalTagInfoVo
                                                   {
                                                       Id = s.Id,
                                                       Name = s.Name
                                                   }).ToList(),

                                   FacilityTagList = (from s in h.FacilityTagList
                                                      select new WxHospitalTagInfoVo
                                                      {
                                                          Id = s.Id,
                                                          Name = s.Name
                                                      }).ToList()
                               };

                FxPageInfo<WxHospitalInfoVo> hospitalPageInfo = new FxPageInfo<WxHospitalInfoVo>();
                hospitalPageInfo.TotalCount = q.TotalCount;
                hospitalPageInfo.List = hospital;
                return ResultData<FxPageInfo<WxHospitalInfoVo>>.Success().AddData("hospitalInfo", hospitalPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<WxHospitalInfoVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据类型获取标签列表
        /// </summary>
        /// <param name="type">0=医院规模,1=医院设施，null=全部</param>
        /// <returns></returns>
        [HttpGet("nameList")]
        public async Task<ResultData<List<TagNameVo>>> GetNameListAsync(byte? type)
        {
            try
            {
                var tagInfo = from d in await _tagInfoService.GetNameListAsync(type)
                              select new TagNameVo
                              {
                                  Id = d.Id,
                                  Name = d.Name
                              };
                return ResultData<List<TagNameVo>>.Success().AddData("tagInfo", tagInfo.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<TagNameVo>>.Fail(ex.Message);
            }
        }
    }
}