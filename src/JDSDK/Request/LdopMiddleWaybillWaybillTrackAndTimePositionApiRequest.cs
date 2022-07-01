using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopMiddleWaybillWaybillTrackAndTimePositionApiRequest : JdRequestBase<LdopMiddleWaybillWaybillTrackAndTimePositionApiResponse>
    {
                                                                                                                                              public  		string
              waybillCode
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              gpsTime
 {get; set;}
                                                          
                                                          public  		string
              customerCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ldop.middle.waybill.WaybillTrackAndTimePositionApi";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("waybillCode", this.            waybillCode
);
                                                                                                        parameters.Add("gpsTime", this.            gpsTime
);
                                                                                                        parameters.Add("customerCode", this.            customerCode
);
                                                                            }
    }
}





        
 

