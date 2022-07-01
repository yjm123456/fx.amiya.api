using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcItemProductApplyGetRequest : JdRequestBase<VcItemProductApplyGetResponse>
    {
                                                                                                                   public  		string
              applyId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.vc.item.product.apply.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("applyId", this.            applyId
);
                                                    }
    }
}





        
 

