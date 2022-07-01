using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Goods
{
    public record GoodsCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SimpleCode { get; set; }
        public string ShowDirectionTypeName { get; set; }

        public int? ShowDirectionType { get; set; }
        public bool Valid { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}
