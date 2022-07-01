using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnicShipUpdatestatusRequest : JdRequestBase<OmnicShipUpdatestatusResponse>
    {
                                                                                                                                              public  		string
              authKey
 {get; set;}
                                                          
                                                                                                                                                                                        public  		string
              deliveryId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              operateTime
 {get; set;}
                                                          
                                                          public  		string
              operateName
 {get; set;}
                                                          
                                                          public  		string
              contactPhone
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.omnic.ship.updatestatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("authKey", this.            authKey
);
                                                                                                                                                                                                                                                parameters.Add("deliveryId", this.            deliveryId
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("operateTime", this.            operateTime
);
                                                                                                        parameters.Add("operateName", this.            operateName
);
                                                                                                        parameters.Add("contactPhone", this.            contactPhone
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                    }
    }
}





        
 

