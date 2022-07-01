using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class YipOrderGetOrderCustomeInfosRequest : JdRequestBase<YipOrderGetOrderCustomeInfosResponse>
    {
                                                                                                                                              public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              subSkuId
 {get; set;}
                                                          
                                                          public  		string
              appId
 {get; set;}
                                                          
                                                          public  		string
              source
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  customFields {get; set; }
                                                                                                                                                                                                public  		string
              skuId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.yip.order.getOrderCustomeInfos";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("subSkuId", this.            subSkuId
);
                                                                                                        parameters.Add("appId", this.            appId
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                                                                                                parameters.Add("customFields", this.            customFields
);
                                                                                                                                parameters.Add("skuId", this.            skuId
);
                                                                                                                            }
    }
}





        
 

