using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class HealthcarePushStoreInfoRequest : JdRequestBase<HealthcarePushStoreInfoResponse>
    {
                                                                                                                                              public  		string
              storeAddr
 {get; set;}
                                                          
                                                          public  		string
              storeName
 {get; set;}
                                                          
                                                          public  		string
              storeId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              storeType
 {get; set;}
                                                          
                                                          public  		string
              storePhone
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              channelType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              reportSupport
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              storeLevel
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              storeLat
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              storeLng
 {get; set;}
                                                          
                                                          public  		string
              provinceName
 {get; set;}
                                                          
                                                          public  		string
              cityName
 {get; set;}
                                                          
                                                          public  		string
              countyName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              operateType
 {get; set;}
                                                          
                                                                                           public  		string
              storeHours
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.healthcare.pushStoreInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("storeAddr", this.            storeAddr
);
                                                                                                        parameters.Add("storeName", this.            storeName
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("storeType", this.            storeType
);
                                                                                                        parameters.Add("storePhone", this.            storePhone
);
                                                                                                        parameters.Add("channelType", this.            channelType
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("reportSupport", this.            reportSupport
);
                                                                                                        parameters.Add("storeLevel", this.            storeLevel
);
                                                                                                        parameters.Add("storeLat", this.            storeLat
);
                                                                                                        parameters.Add("storeLng", this.            storeLng
);
                                                                                                        parameters.Add("provinceName", this.            provinceName
);
                                                                                                        parameters.Add("cityName", this.            cityName
);
                                                                                                        parameters.Add("countyName", this.            countyName
);
                                                                                                        parameters.Add("operateType", this.            operateType
);
                                                                                                                                                        parameters.Add("storeHours", this.            storeHours
);
                                                                            }
    }
}





        
 

