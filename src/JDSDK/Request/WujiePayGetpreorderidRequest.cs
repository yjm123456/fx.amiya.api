using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WujiePayGetpreorderidRequest : JdRequestBase<WujiePayGetpreorderidResponse>
    {
                                                                                                                                              public  		string
              brandId
 {get; set;}
                                                          
                                                          public  		string
              bizId
 {get; set;}
                                                          
                                                          public  		string
              exStoreId
 {get; set;}
                                                          
                                                          public  		string
              outTradeNo
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              amount
 {get; set;}
                                                          
                                                          public  		string
              notifyUrl
 {get; set;}
                                                          
                                                          public  		string
              extMap
 {get; set;}
                                                          
                                                          public  		string
              merchantNo
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  storePrice {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  exSkuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  count {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  activityPrice {get; set; }
                                                                                                                                                                                                public  		string
              returnUrl
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              venderId
 {get; set;}
                                                          
                                                          public  		string
              scene
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              activityAmount
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.wujie.pay.getpreorderid";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("brandId", this.            brandId
);
                                                                                                        parameters.Add("bizId", this.            bizId
);
                                                                                                        parameters.Add("exStoreId", this.            exStoreId
);
                                                                                                        parameters.Add("outTradeNo", this.            outTradeNo
);
                                                                                                        parameters.Add("amount", this.            amount
);
                                                                                                        parameters.Add("notifyUrl", this.            notifyUrl
);
                                                                                                        parameters.Add("extMap", this.            extMap
);
                                                                                                        parameters.Add("merchantNo", this.            merchantNo
);
                                                                                                                                                                                        parameters.Add("storePrice", this.            storePrice
);
                                                                                                        parameters.Add("exSkuId", this.            exSkuId
);
                                                                                                        parameters.Add("count", this.            count
);
                                                                                                        parameters.Add("activityPrice", this.            activityPrice
);
                                                                                                                                                        parameters.Add("returnUrl", this.            returnUrl
);
                                                                                                        parameters.Add("venderId", this.            venderId
);
                                                                                                        parameters.Add("scene", this.            scene
);
                                                                                                        parameters.Add("activityAmount", this.            activityAmount
);
                                                                            }
    }
}





        
 

