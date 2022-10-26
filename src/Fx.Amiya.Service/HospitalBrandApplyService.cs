using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.GoodsDemand;
using Fx.Amiya.Dto.HospitalInfo;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using Fx.Infrastructure.DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class HospitalBrandApplyService : IHospitalBrandApplyService
    {
        private IDalHospitalBrandApply dalHospitalBrandApply;
        private ITmallGoodsSkuService _tmallGoodsSkuService;
        private readonly IUnitOfWork _unitOfWork;

        public HospitalBrandApplyService(IDalHospitalBrandApply dalHospitalBrandApply,
            ITmallGoodsSkuService tmallGoodsSkuService,
            IUnitOfWork unitOfWork)
        {
            this.dalHospitalBrandApply = dalHospitalBrandApply;
            _tmallGoodsSkuService = tmallGoodsSkuService;
            _unitOfWork = unitOfWork;
        }



        public async Task<FxPageInfo<HospitalBrandApplyDto>> GetListWithPageAsync(string keyword, string hospitalLinkMan, string hospitalLinkManPhone, int pageNum, int pageSize)
        {
            try
            {
                var hospitalBrandApply = from d in dalHospitalBrandApply.GetAll()
                                         where (string.IsNullOrWhiteSpace(keyword) || d.HospitalName.Contains(keyword) || d.GoodsId.Contains(keyword))
                                        && (string.IsNullOrWhiteSpace(hospitalLinkMan) || d.HospitalLinkMan == hospitalLinkMan)
                                        && (string.IsNullOrWhiteSpace(hospitalLinkManPhone) || d.HospitalLinkManPhone == hospitalLinkManPhone)
                                         select new HospitalBrandApplyDto
                                         {
                                             Id = d.Id,
                                             HospitalName = d.HospitalName,
                                             GoodsId = d.GoodsId,
                                             GoodsType = d.GoodsType,
                                             GoodsUrl = d.GoodsUrl,
                                             AllSaleNum = d.AllSaleNum,
                                             ExceededReason = d.ExceededReason,
                                             BusinessLicenseName = d.BusinessLicenseName,
                                             HospitalLinkMan = d.HospitalLinkMan,
                                             HospitalLinkManPhone = d.HospitalLinkManPhone
                                         };

                FxPageInfo<HospitalBrandApplyDto> hospitalBrandApplyPageInfo = new FxPageInfo<HospitalBrandApplyDto>();
                hospitalBrandApplyPageInfo.TotalCount = await hospitalBrandApply.CountAsync();
                hospitalBrandApplyPageInfo.List = await hospitalBrandApply.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return hospitalBrandApplyPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AddHospitalBrandApplyDto addDto)
        {
            try
            {
                var hospitalName = await dalHospitalBrandApply.GetAll().FirstOrDefaultAsync(e => e.HospitalName == addDto.HospitalName && e.GoodsId == addDto.GoodsId);
                if (hospitalName != null)
                { throw new Exception("您已参与过报名信息，请勿重复提交！"); }
                HospitalBrandApply hospitalBrandApply = new HospitalBrandApply();
                hospitalBrandApply.Id = Guid.NewGuid().ToString();
                hospitalBrandApply.HospitalName = addDto.HospitalName;
                hospitalBrandApply.HospitalLinkMan = addDto.HospitalLinkMan;
                hospitalBrandApply.HospitalLinkManPhone = addDto.HospitalLinkManPhone;
                hospitalBrandApply.BusinessLicenseName = addDto.BusinessLicenseName;
                hospitalBrandApply.GoodsId = addDto.GoodsId;
                hospitalBrandApply.GoodsType = addDto.GoodsType;
                hospitalBrandApply.GoodsUrl = addDto.GoodsUrl;
                hospitalBrandApply.AllSaleNum = addDto.AllSaleNum;
                hospitalBrandApply.ExceededReason = addDto.ExceededReason;
                await dalHospitalBrandApply.AddAsync(hospitalBrandApply, true);

                foreach (var x in addDto.TmallGoodsSkuDto)
                {
                    x.CreateHospital = hospitalBrandApply.HospitalName;
                    await _tmallGoodsSkuService.AddAsync(x);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<HospitalBrandApplyDto> GetByIdAsync(string id)
        {
            try
            {
                var hospitalBrandApply = await dalHospitalBrandApply.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (hospitalBrandApply == null)
                {
                    return new HospitalBrandApplyDto()
                    {
                        Id = "",
                        HospitalName = "",
                        BusinessLicenseName = "",
                        HospitalLinkMan = "",
                        HospitalLinkManPhone = "",
                        GoodsId = "",
                        GoodsType = "",
                        GoodsUrl = "",
                        AllSaleNum = 0,
                        ExceededReason = ""
                    };
                }

                HospitalBrandApplyDto hospitalBrandApplyDto = new HospitalBrandApplyDto();
                hospitalBrandApplyDto.Id = hospitalBrandApply.Id;
                hospitalBrandApplyDto.HospitalName = hospitalBrandApply.HospitalName;
                hospitalBrandApplyDto.BusinessLicenseName = hospitalBrandApply.BusinessLicenseName;
                hospitalBrandApplyDto.HospitalLinkMan = hospitalBrandApply.HospitalLinkMan;
                hospitalBrandApplyDto.HospitalLinkManPhone = hospitalBrandApply.HospitalLinkManPhone;
                hospitalBrandApplyDto.GoodsId = hospitalBrandApply.GoodsId;
                hospitalBrandApplyDto.GoodsType = hospitalBrandApply.GoodsType;
                hospitalBrandApplyDto.GoodsUrl = hospitalBrandApply.GoodsUrl;
                hospitalBrandApplyDto.AllSaleNum = hospitalBrandApply.AllSaleNum;
                hospitalBrandApplyDto.ExceededReason = hospitalBrandApply.ExceededReason;
                return hospitalBrandApplyDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<HospitalBrandApplyDto> GetByGoodsIdAndHospitalNameAsync(string goodsId, string hospitalName)
        {
            try
            {
                var hospitalBrandApply = await dalHospitalBrandApply.GetAll().FirstOrDefaultAsync(e => e.GoodsId == goodsId && e.HospitalName == hospitalName);
                if (hospitalBrandApply == null)
                {
                    return new HospitalBrandApplyDto()
                    {
                        Id = "",
                        HospitalName = "",
                        GoodsId = "",
                        GoodsUrl = "",
                        AllSaleNum = 0,
                        ExceededReason = ""
                    };
                }

                HospitalBrandApplyDto hospitalBrandApplyDto = new HospitalBrandApplyDto();
                hospitalBrandApplyDto.Id = hospitalBrandApply.Id;
                hospitalBrandApplyDto.HospitalName = hospitalBrandApply.HospitalName;
                hospitalBrandApplyDto.BusinessLicenseName = hospitalBrandApply.BusinessLicenseName;
                hospitalBrandApplyDto.HospitalLinkMan = hospitalBrandApply.HospitalLinkMan;
                hospitalBrandApplyDto.HospitalLinkManPhone = hospitalBrandApply.HospitalLinkManPhone;

                hospitalBrandApplyDto.GoodsId = hospitalBrandApply.GoodsId;
                hospitalBrandApplyDto.GoodsType = hospitalBrandApply.GoodsType;
                hospitalBrandApplyDto.GoodsUrl = hospitalBrandApply.GoodsUrl;
                hospitalBrandApplyDto.AllSaleNum = hospitalBrandApply.AllSaleNum;
                hospitalBrandApplyDto.ExceededReason = hospitalBrandApply.ExceededReason;
                return hospitalBrandApplyDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateHospitalBrandApplyDto updateDto)
        {
            try
            {
                var hospitalBrandApply = await dalHospitalBrandApply.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                await _tmallGoodsSkuService.DeleteBySkuIdAndHospitalNameAsync(hospitalBrandApply.GoodsId, hospitalBrandApply.HospitalName);
                if (hospitalBrandApply == null)
                    throw new Exception("医院品牌报名编号错误！");

                hospitalBrandApply.HospitalName = updateDto.HospitalName;
                hospitalBrandApply.BusinessLicenseName = updateDto.BusinessLicenseName;
                hospitalBrandApply.HospitalLinkMan = updateDto.HospitalLinkMan;
                hospitalBrandApply.HospitalLinkManPhone = updateDto.HospitalLinkManPhone;
                hospitalBrandApply.GoodsId = updateDto.GoodsId;
                hospitalBrandApply.GoodsType = updateDto.GoodsType;
                hospitalBrandApply.GoodsUrl = updateDto.GoodsUrl;
                hospitalBrandApply.AllSaleNum = updateDto.AllSaleNum;
                hospitalBrandApply.ExceededReason = updateDto.ExceededReason;
                await dalHospitalBrandApply.UpdateAsync(hospitalBrandApply, true);

                foreach (var x in updateDto.TmallGoodsSkuDto)
                {
                    x.CreateHospital = hospitalBrandApply.HospitalName;
                    await _tmallGoodsSkuService.AddAsync(x);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(string id)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                var hospitalBrandApply = await dalHospitalBrandApply.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalBrandApply == null)
                    throw new Exception("医院品牌报名编号错误");

                await dalHospitalBrandApply.DeleteAsync(hospitalBrandApply, true);
                await _tmallGoodsSkuService.DeleteBySkuIdAndHospitalNameAsync(hospitalBrandApply.GoodsId, hospitalBrandApply.HospitalName);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw ex;
            }
        }


        public async Task<List<ExportHospitalBrandApplyAndTmallGoodsDto>> GetDetailAsync(string keyword)
        {
            try
            {
                List<ExportHospitalBrandApplyAndTmallGoodsDto> returnResult = new List<ExportHospitalBrandApplyAndTmallGoodsDto>();
                var hospitalBrandApply = await _tmallGoodsSkuService.GetAllAsync();
                foreach (var x in hospitalBrandApply)
                {
                    ExportHospitalBrandApplyAndTmallGoodsDto result = new ExportHospitalBrandApplyAndTmallGoodsDto();
                    result.SkuName = x.SkuName;
                    result.Price = x.Price;
                    result.AllCount = x.AllCount;
                    result.GoodsId = x.GoodsId;
                    var brandApplyInfo = await this.GetByGoodsIdAndHospitalNameAsync(x.GoodsId, x.CreateHospital);
                    result.GoodsType = brandApplyInfo.GoodsType;
                    result.GooodsUrl = brandApplyInfo.GoodsUrl;
                    result.HospitalName = brandApplyInfo.HospitalName;
                    result.BusinessLicenseName = brandApplyInfo.BusinessLicenseName;
                    result.HospitalLinkMan = brandApplyInfo.HospitalLinkMan;
                    result.HospitalLinkManPhone = brandApplyInfo.HospitalLinkManPhone;
                    result.HospitalName = brandApplyInfo.HospitalName;
                    result.HospitalName = brandApplyInfo.HospitalName;
                    result.AllSaleNum = brandApplyInfo.AllSaleNum;
                    result.ExceededReason = brandApplyInfo.ExceededReason;
                    returnResult.Add(result);
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    returnResult = returnResult.Where(z => z.HospitalName.Contains(keyword) || z.GoodsId.Contains(keyword)).ToList();
                }
                return returnResult.OrderByDescending(z => z.HospitalName).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
