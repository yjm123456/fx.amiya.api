using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WarehouseInboundOrderQueryDetailWareRequest : JdRequestBase<WarehouseInboundOrderQueryDetailWareResponse>
    {
                                                                                                                                                                               public  		string
              docNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.warehouse.inbound.order.query.detail.ware";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("docNo", this.            docNo
);
                                                                            }
    }
}





        
 

