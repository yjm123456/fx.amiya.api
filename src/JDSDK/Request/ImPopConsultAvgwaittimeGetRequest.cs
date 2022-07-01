using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ImPopConsultAvgwaittimeGetRequest : JdRequestBase<ImPopConsultAvgwaittimeGetResponse>
    {
                                                                                                                   public  		string
              waiter
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              date
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.im.pop.consult.avgwaittime.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("waiter", this.            waiter
);
                                                                                                        parameters.Add("date", this.            date
);
                                                    }
    }
}





        
 

