using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopMiddleWaybillWaybillPickupApiRequest : JdRequestBase<LdopMiddleWaybillWaybillPickupApiResponse>
    {
                                                                                                                                              public  		string
              vendorCode
 {get; set;}
                                                          
                                                          public  		string
              pickupCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ldop.middle.waybill.WaybillPickupApi";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                        parameters.Add("pickupCode", this.            pickupCode
);
                                                                            }
    }
}





        
 

