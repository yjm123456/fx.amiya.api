using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnicTraceGettracelistRequest : JdRequestBase<OmnicTraceGettracelistResponse>
    {
                                                                                                                                              public  		string
              authKey
 {get; set;}
                                                          
                                                                                                                                                                                        public  		Nullable<int>
              dateType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              statusType
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDate
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              currentPage
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startDate
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.omnic.trace.gettracelist";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("authKey", this.            authKey
);
                                                                                                                                                                                                                                                parameters.Add("dateType", this.            dateType
);
                                                                                                        parameters.Add("statusType", this.            statusType
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("currentPage", this.            currentPage
);
                                                                                                        parameters.Add("startDate", this.            startDate
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                    }
    }
}





        
 

