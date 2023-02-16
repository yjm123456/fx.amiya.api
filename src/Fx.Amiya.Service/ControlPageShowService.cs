using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class ControlPageShowService : IControlPageShowService
    {
        private readonly IDalControlPageShow dalControlPageShow;

        public ControlPageShowService(IDalControlPageShow dalControlPageShow)
        {
            this.dalControlPageShow = dalControlPageShow;
        }
        /// <summary>
        /// 获取是否显示信息
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsShow()
        {
            return dalControlPageShow.GetAll().FirstOrDefault().Show;

        }
    }
}
