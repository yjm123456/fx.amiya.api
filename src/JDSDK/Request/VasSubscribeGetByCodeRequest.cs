using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VasSubscribeGetByCodeRequest : JdRequestBase<VasSubscribeGetByCodeResponse>
    {
                                                                                                                   public  		string
                                                                                      itemCode
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.vas.subscribe.getByCode";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("item_code", this.                                                                                    itemCode
);
                                                                                                    }
    }
}





        
 

