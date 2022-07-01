using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopAfsSoaRefundapplyUpdateWarehouseStatusRequest : JdRequestBase<PopAfsSoaRefundapplyUpdateWarehouseStatusResponse>
    {
                                                                                                                   public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              refId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.pop.afs.soa.refundapply.updateWarehouseStatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("refId", this.            refId
);
                                                                                                        parameters.Add("status", this.            status
);
                                                    }
    }
}





        
 

