using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OneorderqueryRequest : JdRequestBase<OneorderqueryResponse>
    {
                                                                                                                                                    public  		Nullable<DateTime>
              startDate
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDate
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderStatus
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sortType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              dateType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              operationType
 {get; set;}
                                                          
                                                          public  		string
              extStr
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.oneorderquery";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                parameters.Add("startDate", this.            startDate
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("orderStatus", this.            orderStatus
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("sortType", this.            sortType
);
                                                                                                        parameters.Add("dateType", this.            dateType
);
                                                                                                        parameters.Add("operationType", this.            operationType
);
                                                                                                        parameters.Add("extStr", this.            extStr
);
                                                    }
    }
}





        
 

