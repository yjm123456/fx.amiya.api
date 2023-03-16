using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo
{
    /// <summary>
    /// 下拉框专属数据
    /// </summary>
    public class BaseIdAndNameVo
    {
        /// <summary>
        /// 编号（Key）
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 数据值（Value）
        /// </summary>
        public string Name { get; set; }
    }
    public class BaseIdAndNameVo<T>
    {
        /// <summary>
        /// 编号（Key）
        /// </summary>
        public T Id { get; set; }
        /// <summary>
        /// 数据值（Value）
        /// </summary>
        public string Name { get; set; }
    }
}
