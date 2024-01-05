using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.AmiyaEmployee
{
   public class AddAmiyaEmployeeDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PositionId { get; set; }
        public string Email { get; set; }
        public bool IsCustomerService { get; set; }
        /// <summary>
        /// 绑定的主播id
        /// </summary>
        public string LiveAnchorBaseId { get; set; }
        /// <summary>
        /// 新客提成
        /// </summary>
        public decimal? NewCustomerCommission { get; set; }
        /// <summary>
        /// 老客提成
        /// </summary>
        public decimal? OldCustomerCommission { get; set; }
        /// <summary>
        /// 稽查提成
        /// </summary>
        public decimal? InspectionCommission { get; set; }
    }
}
