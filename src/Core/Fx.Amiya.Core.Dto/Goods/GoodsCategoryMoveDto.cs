using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Goods
{
    /// <summary>
    /// 移动商品分类输入类
    /// </summary>
    public class GoodsCategoryMoveDto
    {
        public int Id { get; set; }
        public bool MoveState { get; set; }
        public int UpdateBy { get; set; }
    }
}
