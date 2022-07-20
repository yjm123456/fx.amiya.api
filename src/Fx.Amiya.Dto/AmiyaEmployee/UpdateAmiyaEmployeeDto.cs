using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.AmiyaEmployee
{
   public class UpdateAmiyaEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public bool Valid { get; set; }
        public int PositionId { get; set; }
        public string Email { get; set; }
        public bool IsCustomerService { get; set; }
        /// <summary>
        /// 当为客服/运营咨询情况下上传绑定主播ID
        /// </summary>
        public List<int> LiveAnchorIds { get; set; }
    }
}
