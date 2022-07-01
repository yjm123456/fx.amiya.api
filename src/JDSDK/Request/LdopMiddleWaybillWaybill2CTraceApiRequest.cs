using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopMiddleWaybillWaybill2CTraceApiRequest : JdRequestBase<LdopMiddleWaybillWaybill2CTraceApiResponse>
    {
                                                                                                                                              public  		string
              tradeCode
 {get; set;}
                                                          
                                                          public  		string
              waybillCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ldop.middle.waybill.Waybill2CTraceApi";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("tradeCode", this.            tradeCode
);
                                                                                                        parameters.Add("waybillCode", this.            waybillCode
);
                                                                            }
    }
}





        
 

