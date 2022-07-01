using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WarehouseOutboundOrderQueryDetailWareRequest : JdRequestBase<WarehouseOutboundOrderQueryDetailWareResponse>
    {
                                                                                                                                                                               public  		string
              stockOutNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.warehouse.outbound.order.query.detail.ware";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("stockOutNo", this.            stockOutNo
);
                                                                            }
    }
}





        
 

