using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    public class ExportContentPlatFormOrderDealInfoSearchVo
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SendStartDate { get; set; }
        public DateTime? SendEndDate { get; set; }
        public decimal? MinAddOrderPrice { get; set; }
        public decimal? MaxAddOrderPrice { get; set; }
        public int? ConsultationType { get; set; }
        public bool? IsToHospital { get; set; }
        public DateTime? TohospitalStartDate { get; set; }
        public DateTime? ToHospitalEndDate { get; set; }
        public int? ToHospitalType { get; set; }
        public bool? IsDeal { get; set; }
        public int? LastDealHospitalId { get; set; }
        public bool? IsAccompanying { get; set; }
        public bool? IsOldCustomer { get; set; }
        public int? CheckState { get; set; }
        public DateTime? CheckStartDate { get; set; }
        public DateTime? CheckEndDate { get; set; }
        public bool? IsCreateBill { get; set; }
        public bool? IsReturnBakcPrice { get; set; }
        public DateTime? ReturnBackPriceStartDate { get; set; }
        public DateTime? ReturnBackPriceEndDate { get; set; }
        public int? CustomerServiceId { get; set; }
        public string BelongCompanyId { get; set; }
        public string KeyWord { get; set; }
    }
}
