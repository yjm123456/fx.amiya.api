using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LogisticsPoGetRequest : JdRequestBase<LogisticsPoGetResponse>
    {
                                                                                  public  		string
                                                                                      inboundNo
 {get; set;}
                                                                                                                                  
                                                                              public override string ApiName
            {
                get{return "jingdong.logistics.po.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("inbound_no", this.                                                                                    inboundNo
);
                                                                                                                                                    }
    }
}





        
 

