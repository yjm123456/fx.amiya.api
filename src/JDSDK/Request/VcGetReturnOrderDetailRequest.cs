using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcGetReturnOrderDetailRequest : JdRequestBase<VcGetReturnOrderDetailResponse>
    {
                                                                                                                                              public  		Nullable<long>
              returnId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.vc.get.return.order.detail";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("returnId", this.            returnId
);
                                                                                                                            }
    }
}





        
 

