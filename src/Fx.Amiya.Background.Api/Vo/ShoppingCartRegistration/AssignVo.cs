using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ShoppingCartRegistration
{
    public class AssignVo
    {
        public string Id { get; set; }

        /// <summary>
        /// 指派人
        /// </summary>
        public int AssignBy { get; set; }
    }
    public class AssignListVo
    {

        public List<string> IdList { get; set; }

        /// <summary>
        /// 指派人
        /// </summary>
        public int AssignBy { get; set; }
    }
}
