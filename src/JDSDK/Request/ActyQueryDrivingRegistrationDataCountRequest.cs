using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ActyQueryDrivingRegistrationDataCountRequest : JdRequestBase<ActyQueryDrivingRegistrationDataCountResponse>
    {
                                                                                                                   public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		string
              beginDate
 {get; set;}
                                                          
                                                          public  		string
              endDate
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.acty.queryDrivingRegistrationDataCount";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("beginDate", this.            beginDate
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                    }
    }
}





        
 

