using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class StationinfojosserviceInvalidateRequest : JdRequestBase<StationinfojosserviceInvalidateResponse>
    {
                                                                                                                                              public  		string
              companyCode
 {get; set;}
                                                          
                                                          public  		string
              stationCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.stationinfojosservice.invalidate";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("companyCode", this.            companyCode
);
                                                                                                        parameters.Add("stationCode", this.            stationCode
);
                                                                            }
    }
}





        
 

