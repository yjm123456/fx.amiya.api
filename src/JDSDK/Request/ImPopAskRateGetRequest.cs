using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ImPopAskRateGetRequest : JdRequestBase<ImPopAskRateGetResponse>
    {
                                                                                                                   public  		Nullable<DateTime>
              startTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endTime
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.im.pop.askRate.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                    }
    }
}





        
 

