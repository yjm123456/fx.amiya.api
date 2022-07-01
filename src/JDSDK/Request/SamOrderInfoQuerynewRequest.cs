using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SamOrderInfoQuerynewRequest : JdRequestBase<SamOrderInfoQuerynewResponse>
    {
                                                                                                                                                                                                                public  		Nullable<int>
              orderStatus
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              payStartTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              payEndTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNum
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.sam.order.info.querynew";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("orderStatus", this.            orderStatus
);
                                                                                                        parameters.Add("payStartTime", this.            payStartTime
);
                                                                                                        parameters.Add("payEndTime", this.            payEndTime
);
                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("pageNum", this.            pageNum
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                            }
    }
}





        
 

