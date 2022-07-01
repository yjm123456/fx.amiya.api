using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PurchaseOrderStockOutRequest : JdRequestBase<PurchaseOrderStockOutResponse>
    {
                                                                                                                   public  		Nullable<long>
              purchaseId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              shipmentId
 {get; set;}
                                                          
                                                          public  		string
              shipmentNo
 {get; set;}
                                                          
                                                          public  		string
              tradeNo
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.purchase.order.stock.out";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("purchaseId", this.            purchaseId
);
                                                                                                        parameters.Add("shipmentId", this.            shipmentId
);
                                                                                                        parameters.Add("shipmentNo", this.            shipmentNo
);
                                                                                                        parameters.Add("tradeNo", this.            tradeNo
);
                                                    }
    }
}





        
 

