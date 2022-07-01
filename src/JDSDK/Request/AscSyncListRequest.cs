using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscSyncListRequest : JdRequestBase<AscSyncListResponse>
    {
                                                                                                                                                                                                                                                 public  		string
              buId
 {get; set;}
                                                          
                                                          public  		string
              operatePin
 {get; set;}
                                                          
                                                          public  		string
              operateNick
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              serviceId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              serviceStatus
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderType
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              updateTimeBegin
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              updateTimeEnd
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              freightUpdateDateBegin
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              freightUpdateDateEnd
 {get; set;}
                                                          
                                                                                                                      public  		string
              pageNumber
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                                                           public  		string
              extJsonStr
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.sync.list";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                        parameters.Add("buId", this.            buId
);
                                                                                                        parameters.Add("operatePin", this.            operatePin
);
                                                                                                        parameters.Add("operateNick", this.            operateNick
);
                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("serviceStatus", this.            serviceStatus
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                        parameters.Add("updateTimeBegin", this.            updateTimeBegin
);
                                                                                                        parameters.Add("updateTimeEnd", this.            updateTimeEnd
);
                                                                                                        parameters.Add("freightUpdateDateBegin", this.            freightUpdateDateBegin
);
                                                                                                        parameters.Add("freightUpdateDateEnd", this.            freightUpdateDateEnd
);
                                                                                                                                                parameters.Add("pageNumber", this.            pageNumber
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                parameters.Add("extJsonStr", this.            extJsonStr
);
                                                                            }
    }
}





        
 

