using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PurchaseOrderGetInfoRequest : JdRequestBase<PurchaseOrderGetInfoResponse>
    {
                                                                                                                   public  		Nullable<long>
              purchaseId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.purchase.order.get.info";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("purchaseId", this.            purchaseId
);
                                                    }
    }
}





        
 

