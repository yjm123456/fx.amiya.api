using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bGxptPurchaseOrderErpServiceFindErpOrderRequest : JdRequestBase<B2bGxptPurchaseOrderErpServiceFindErpOrderResponse>
    {
                                                                                  public  		Nullable<long>
              venderId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              purchaseOrderId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              jdOrderId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.b2b.gxpt.purchaseOrderErpService.findErpOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("venderId", this.            venderId
);
                                                                                                        parameters.Add("purchaseOrderId", this.            purchaseOrderId
);
                                                                                                        parameters.Add("jdOrderId", this.            jdOrderId
);
                                                                                                    }
    }
}





        
 

