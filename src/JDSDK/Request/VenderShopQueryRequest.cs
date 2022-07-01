using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VenderShopQueryRequest : JdRequestBase<VenderShopQueryResponse>
    {
                                                                     public override string ApiName
            {
                get{return "jingdong.vender.shop.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                            }
    }
}





        
 

