using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OrderTraceByWaybillServiceGetOrderTraceByWaybillIdAndVenderCodeRequest : JdRequestBase<OrderTraceByWaybillServiceGetOrderTraceByWaybillIdAndVenderCodeResponse>
    {
                                                                                                                                                                               public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		string
              waybillId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.orderTraceByWaybillService.getOrderTraceByWaybillIdAndVenderCode";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("waybillId", this.            waybillId
);
                                                                            }
    }
}





        
 

