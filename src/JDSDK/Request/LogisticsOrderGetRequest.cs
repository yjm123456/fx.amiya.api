using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LogisticsOrderGetRequest : JdRequestBase<LogisticsOrderGetResponse>
    {
                                                                                  public  		string
                                                                                      receiptNo
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.logistics.order.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("receipt_no", this.                                                                                    receiptNo
);
                                                                                                    }
    }
}





        
 

