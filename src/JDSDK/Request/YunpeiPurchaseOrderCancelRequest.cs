using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class YunpeiPurchaseOrderCancelRequest : JdRequestBase<YunpeiPurchaseOrderCancelResponse>
    {
                                                                                                                   public  		string
                                                                                      orderSn
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.yunpei.purchase.order.cancel";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("order_sn", this.                                                                                    orderSn
);
                                                    }
    }
}





        
 

