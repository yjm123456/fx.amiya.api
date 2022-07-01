using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class StationinfojosserviceGetStationInfoRequest : JdRequestBase<StationinfojosserviceGetStationInfoResponse>
    {
                                                                                                                                              public  		string
              companyCode
 {get; set;}
                                                          
                                                          public  		string
              stationCode
 {get; set;}
                                                          
                                                          public  		string
              stationName
 {get; set;}
                                                          
                                                          public  		string
              stationAddress
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              provinceId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cityId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              countyId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              townId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.stationinfojosservice.getStationInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("companyCode", this.            companyCode
);
                                                                                                        parameters.Add("stationCode", this.            stationCode
);
                                                                                                        parameters.Add("stationName", this.            stationName
);
                                                                                                        parameters.Add("stationAddress", this.            stationAddress
);
                                                                                                        parameters.Add("provinceId", this.            provinceId
);
                                                                                                        parameters.Add("cityId", this.            cityId
);
                                                                                                        parameters.Add("countyId", this.            countyId
);
                                                                                                        parameters.Add("townId", this.            townId
);
                                                                            }
    }
}





        
 

