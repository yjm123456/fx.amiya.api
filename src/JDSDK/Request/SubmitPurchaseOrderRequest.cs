using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SubmitPurchaseOrderRequest : JdRequestBase<SubmitPurchaseOrderResponse>
    {
                                                                                                                                              public  		string
              source
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              projectId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              shopId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              paymentId
 {get; set;}
                                                          
                                                          public  		string
              totalPrice
 {get; set;}
                                                          
                                                                                           public  		string
              bizToken
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  skuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  skuNum {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  purchasePrice {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.submitPurchaseOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("source", this.            source
);
                                                                                                        parameters.Add("projectId", this.            projectId
);
                                                                                                        parameters.Add("shopId", this.            shopId
);
                                                                                                        parameters.Add("paymentId", this.            paymentId
);
                                                                                                        parameters.Add("totalPrice", this.            totalPrice
);
                                                                                                                                                        parameters.Add("bizToken", this.            bizToken
);
                                                                                                                                                                                                                parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("skuNum", this.            skuNum
);
                                                                                                        parameters.Add("purchasePrice", this.            purchasePrice
);
                                                                                                    }
    }
}





        
 

