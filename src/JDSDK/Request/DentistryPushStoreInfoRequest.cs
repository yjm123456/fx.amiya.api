using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DentistryPushStoreInfoRequest : JdRequestBase<DentistryPushStoreInfoResponse>
    {
                                                                                                                                              public  		Nullable<long>
              channelType
 {get; set;}
                                                          
                                                          public  		string
              storeName
 {get; set;}
                                                          
                                                          public  		string
              operateType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                          public  		string
              storeImg
 {get; set;}
                                                          
                                                          public  		string
              cityName
 {get; set;}
                                                          
                                                          public  		string
              provinceName
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              storeLat
 {get; set;}
                                                          
                                                          public  		string
              storePhone
 {get; set;}
                                                          
                                                          public  		string
              storeAddr
 {get; set;}
                                                          
                                                          public  		string
              countyName
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              storeLng
 {get; set;}
                                                          
                                                          public  		string
              storeId
 {get; set;}
                                                          
                                                                                           public  		string
              storeHours
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              reportSupport
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dentistry.pushStoreInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("channelType", this.            channelType
);
                                                                                                        parameters.Add("storeName", this.            storeName
);
                                                                                                        parameters.Add("operateType", this.            operateType
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("storeImg", this.            storeImg
);
                                                                                                        parameters.Add("cityName", this.            cityName
);
                                                                                                        parameters.Add("provinceName", this.            provinceName
);
                                                                                                        parameters.Add("storeLat", this.            storeLat
);
                                                                                                        parameters.Add("storePhone", this.            storePhone
);
                                                                                                        parameters.Add("storeAddr", this.            storeAddr
);
                                                                                                        parameters.Add("countyName", this.            countyName
);
                                                                                                        parameters.Add("storeLng", this.            storeLng
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                                                                        parameters.Add("storeHours", this.            storeHours
);
                                                                                                        parameters.Add("reportSupport", this.            reportSupport
);
                                                                            }
    }
}





        
 

