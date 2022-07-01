using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ImPopSessionlistGetRequest : JdRequestBase<ImPopSessionlistGetResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                    		public  		string
  waiter {get; set; }
                                                                                                                                                                                                public  		Nullable<DateTime>
              startTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endTime
 {get; set;}
                                                          
                                                          public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.im.pop.sessionlist.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("waiter", this.            waiter
);
                                                                                                                                parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                    }
    }
}





        
 

