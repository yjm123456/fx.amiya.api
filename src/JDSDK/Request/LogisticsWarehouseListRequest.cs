using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LogisticsWarehouseListRequest : JdRequestBase<LogisticsWarehouseListResponse>
    {
                                                                     public override string ApiName
            {
                get{return "jingdong.logistics.warehouse.list";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                            }
    }
}





        
 

