using Fx.Amiya.Background.Api.Vo.CallRecord;
using Fx.Amiya.Common;
using Fx.Infrastructure.DataAccess.Mongodb.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api
{
    public class FxCallRecordMongoRepository : FxMongoRepository<CallRecordVo>
    {
        public FxCallRecordMongoRepository(FxAppGlobal fxAppGlobal)
            :base(fxAppGlobal.AppConfig.CallCenterConfig.CallRecordStoreAddress,"CallCenterDB","CallRecords")
        {

        }
    }
}
