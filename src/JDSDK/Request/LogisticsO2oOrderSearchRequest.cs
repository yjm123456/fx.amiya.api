using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LogisticsO2oOrderSearchRequest : JdRequestBase<LogisticsO2oOrderSearchResponse>
    {
                                                                                                                   public  		string
                                                                                      stationNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      orderId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      orderState
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      orderTimeStart
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                                                      orderTimeEnd
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                                                                                      orderUpdateTimeStart
 {get; set;}
                                                                                                                                                                                  
                                                          public  		string
                                                                                                                                                      orderUpdateTimeEnd
 {get; set;}
                                                                                                                                                                                  
                                                          public  		string
                                                                                      currentPage
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.logistics.o2o.order.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("station_no", this.                                                                                    stationNo
);
                                                                                                        parameters.Add("order_id", this.                                                                                    orderId
);
                                                                                                        parameters.Add("order_state", this.                                                                                    orderState
);
                                                                                                        parameters.Add("order_time_start", this.                                                                                                                    orderTimeStart
);
                                                                                                        parameters.Add("order_time_end", this.                                                                                                                    orderTimeEnd
);
                                                                                                        parameters.Add("order_update_time_start", this.                                                                                                                                                    orderUpdateTimeStart
);
                                                                                                        parameters.Add("order_update_time_end", this.                                                                                                                                                    orderUpdateTimeEnd
);
                                                                                                        parameters.Add("current_page", this.                                                                                    currentPage
);
                                                    }
    }
}





        
 

