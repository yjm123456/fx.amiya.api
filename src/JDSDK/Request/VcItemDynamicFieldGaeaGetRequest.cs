using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcItemDynamicFieldGaeaGetRequest : JdRequestBase<VcItemDynamicFieldGaeaGetResponse>
    {
                                                                                                                   public  		string
              cid3
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.vc.item.dynamicFieldGaea.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("cid3", this.            cid3
);
                                                    }
    }
}





        
 

