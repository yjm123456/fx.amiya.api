using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpDeliveryApiWaybillQueryApiRequest : JdRequestBase<EclpDeliveryApiWaybillQueryApiResponse>
    {
                                                                                  public  		string
              waybillCode
 {get; set;}
                                                          
                                                          public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              settleType
 {get; set;}
                                                          
                                                          public  		string
              traderCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.delivery.api.WaybillQueryApi";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("waybillCode", this.            waybillCode
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("settleType", this.            settleType
);
                                                                                                        parameters.Add("traderCode", this.            traderCode
);
                                                                                                    }
    }
}





        
 

