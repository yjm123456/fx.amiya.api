using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerVenderInfoGetRequest : JdRequestBase<SellerVenderInfoGetResponse>
    {
                                                                                                                                                                               public  		string
                                                                                                                      extJsonParam
 {get; set;}
                                                                                                                                                          
                                             public override string ApiName
            {
                get{return "jingdong.seller.vender.info.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("ext_json_param", this.                                                                                                                    extJsonParam
);
                                                                            }
    }
}





        
 

