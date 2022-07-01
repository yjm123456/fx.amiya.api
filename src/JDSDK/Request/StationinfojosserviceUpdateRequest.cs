using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class StationinfojosserviceUpdateRequest : JdRequestBase<StationinfojosserviceUpdateResponse>
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
                                                          
                                                          public  		string
              orgCode
 {get; set;}
                                                          
                                                          public  		string
              lat
 {get; set;}
                                                          
                                                          public  		string
              lng
 {get; set;}
                                                          
                                                          public  		string
              provinceName
 {get; set;}
                                                          
                                                          public  		string
              cityName
 {get; set;}
                                                          
                                                          public  		string
              countryName
 {get; set;}
                                                          
                                                          public  		string
              townName
 {get; set;}
                                                          
                                                          public  		string
              orgName
 {get; set;}
                                                          
                                                          public  		string
              areaCode
 {get; set;}
                                                          
                                                          public  		string
              areaName
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.stationinfojosservice.update";}
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
                                                                                                        parameters.Add("orgCode", this.            orgCode
);
                                                                                                        parameters.Add("lat", this.            lat
);
                                                                                                        parameters.Add("lng", this.            lng
);
                                                                                                        parameters.Add("provinceName", this.            provinceName
);
                                                                                                        parameters.Add("cityName", this.            cityName
);
                                                                                                        parameters.Add("countryName", this.            countryName
);
                                                                                                        parameters.Add("townName", this.            townName
);
                                                                                                        parameters.Add("orgName", this.            orgName
);
                                                                                                        parameters.Add("areaCode", this.            areaCode
);
                                                                                                        parameters.Add("areaName", this.            areaName
);
                                                                            }
    }
}





        
 

