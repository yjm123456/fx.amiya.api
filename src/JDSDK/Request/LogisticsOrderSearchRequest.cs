using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LogisticsOrderSearchRequest : JdRequestBase<LogisticsOrderSearchResponse>
    {
                                                                                  public  		string
                                                                                      receiptNos
 {get; set;}
                                                                                                                                  
                                                          public  		string
              status
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.logistics.order.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("receipt_nos", this.                                                                                    receiptNos
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                    }
    }
}





        
 

