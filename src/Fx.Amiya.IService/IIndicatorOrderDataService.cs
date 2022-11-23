using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IIndicatorOrderDataService
    {
        public Task AddAsync { get; set; }
        public Task MyProperty { get; set; }
    }
}
