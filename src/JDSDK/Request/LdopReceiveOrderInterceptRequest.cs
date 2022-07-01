using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopReceiveOrderInterceptRequest : JdRequestBase<LdopReceiveOrderInterceptResponse>
    {
                                                                                                                                              public  		string
              vendorCode
 {get; set;}
                                                          
                                                          public  		string
              deliveryId
 {get; set;}
                                                          
                                                          public  		string
              interceptReason
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              cancelOperatorCodeType
 {get; set;}
                                                          
                                                                                           public  		Nullable<DateTime>
              cancelTime
 {get; set;}
                                                          
                                                                                           public  		string
              cancelOperator
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ldop.receive.order.intercept";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                        parameters.Add("deliveryId", this.            deliveryId
);
                                                                                                        parameters.Add("interceptReason", this.            interceptReason
);
                                                                                                                                                        parameters.Add("cancelOperatorCodeType", this.            cancelOperatorCodeType
);
                                                                                                                                                        parameters.Add("cancelTime", this.            cancelTime
);
                                                                                                                                                        parameters.Add("cancelOperator", this.            cancelOperator
);
                                                                            }
    }
}





        
 

