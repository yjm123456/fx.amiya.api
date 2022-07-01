using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WarehouseOutboundOrderConfirmRequest : JdRequestBase<WarehouseOutboundOrderConfirmResponse>
    {
                                                                                                                                                                                                           public  		string
              stockOutNoList
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.warehouse.outbound.order.confirm";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("stockOutNoList", this.            stockOutNoList
);
                                                                            }
    }
}





        
 

