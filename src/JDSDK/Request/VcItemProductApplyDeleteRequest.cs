using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcItemProductApplyDeleteRequest : JdRequestBase<VcItemProductApplyDeleteResponse>
    {
                                                                                                                   public  		string
                                                                                      applyId
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.vc.item.product.apply.delete";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("apply_id", this.                                                                                    applyId
);
                                                    }
    }
}





        
 

