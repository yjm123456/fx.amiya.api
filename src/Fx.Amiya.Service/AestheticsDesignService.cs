using Fx.Amiya.Dal;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.AestheticsDesign;
using Fx.Amiya.IService;
using jos_sdk_net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class AestheticsDesignService : IAestheticsDesignService
    {
        private readonly DalAestheticsDesign dalAestheticsDesign;

        public AestheticsDesignService(DalAestheticsDesign dalAestheticsDesign)
        {
            this.dalAestheticsDesign = dalAestheticsDesign;
        }

        public async Task AddAestheticsDesignAsync(AddAestheticsDesignDto addDto)
        {
            AestheticsDesign aestheticsDesign = new AestheticsDesign();
            aestheticsDesign.Id = CreateOrderIdHelper.GetBillNextNumber();
            aestheticsDesign.CreateDate = DateTime.Now;
            aestheticsDesign.AestheticsDesignReportId = addDto.AestheticsDesignReportId;
            aestheticsDesign.Design = addDto.Design;
            aestheticsDesign.SimpleHospitalName = addDto.SimpleHospitalName;
            aestheticsDesign.RecommendDoctor = addDto.RecommendDoctor;
            aestheticsDesign.Valid = true;
            await dalAestheticsDesign.AddAsync(aestheticsDesign, true);
        }

        public async Task<AestheticsDesignInfoDto> GetByReportIdAsync(string reportId)
        {
            var design= dalAestheticsDesign.GetAll().Where(e => e.AestheticsDesignReportId == reportId).SingleOrDefault();
            AestheticsDesignInfoDto aestheticsDesignInfoDto = new AestheticsDesignInfoDto();
            aestheticsDesignInfoDto.Id = design.Id;
            aestheticsDesignInfoDto.AestheticsDesignReportId = design.AestheticsDesignReportId;
            aestheticsDesignInfoDto.Design = design.Design;
            aestheticsDesignInfoDto.SimpleHospitalName = design.SimpleHospitalName;
            aestheticsDesignInfoDto.RecommendDoctor = design.RecommendDoctor;
            return aestheticsDesignInfoDto;
        }
    }
}
