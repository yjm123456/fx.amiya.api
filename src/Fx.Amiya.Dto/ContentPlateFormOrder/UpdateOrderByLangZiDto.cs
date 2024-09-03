using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlateFormOrder
{
    public class UpdateOrderByLangZiDto
    {
        /// <summary>
        /// id
        /// </summary>
        public string OrderId { get; set; }
        public int OrderStatus { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsRepeateOrder { get; set; }
        public string HospitalConsulationEmployeeName { get; set; }

        public string RepeateOrderPicture { get; set; }
    }
}
