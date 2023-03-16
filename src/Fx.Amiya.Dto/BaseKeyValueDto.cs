using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto
{
    public class BaseKeyValueDto<T> {
        /// <summary>
        /// 编号
        /// </summary>
        public T Key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
    }
    /// <summary>
    /// 获取枚举下拉框专用类
    /// </summary>
    public class BaseKeyValueDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
    }
}
