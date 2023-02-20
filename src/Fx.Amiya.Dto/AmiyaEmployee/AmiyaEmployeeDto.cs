using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.AmiyaEmployee
{
    public class AmiyaEmployeeDto
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; }

        public bool Valid { get; set; }
        public string Email { get; set; }
        public bool IsCustomerService { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string UserId { get; set; }
        public string Code { get; set; }
        public bool ReadDataCenter { get; set; }

        public List<int> LiveAnchorIds { get; set; }
    }
}
