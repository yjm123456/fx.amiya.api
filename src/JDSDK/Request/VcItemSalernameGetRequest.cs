using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcItemSalernameGetRequest : JdRequestBase<VcItemSalernameGetResponse>
    {
                                                                                                                   public  		string
                                                                                      salerCode
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.vc.item.salername.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("saler_code", this.                                                                                    salerCode
);
                                                    }
    }
}





        
 

