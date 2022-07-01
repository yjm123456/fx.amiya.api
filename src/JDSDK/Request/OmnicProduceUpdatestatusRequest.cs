using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnicProduceUpdatestatusRequest : JdRequestBase<OmnicProduceUpdatestatusResponse>
    {
                                                                                                                                              public  		string
              authKey
 {get; set;}
                                                          
                                                                                                                                                                                        public  		string
              storeType
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              operateTime
 {get; set;}
                                                          
                                                          public  		string
              storeId
 {get; set;}
                                                          
                                                          public  		string
              operateName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                          public  		string
              courierId
 {get; set;}
                                                          
                                                          public  		string
              courierName
 {get; set;}
                                                          
                                                          public  		string
              courierPhone
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.omnic.produce.updatestatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("authKey", this.            authKey
);
                                                                                                                                                                                                                                                parameters.Add("storeType", this.            storeType
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("operateTime", this.            operateTime
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("operateName", this.            operateName
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("courierId", this.            courierId
);
                                                                                                        parameters.Add("courierName", this.            courierName
);
                                                                                                        parameters.Add("courierPhone", this.            courierPhone
);
                                                                                                                                                    }
    }
}





        
 

