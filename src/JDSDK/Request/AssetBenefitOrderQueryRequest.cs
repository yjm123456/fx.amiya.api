using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AssetBenefitOrderQueryRequest : JdRequestBase<AssetBenefitOrderQueryResponse>
    {
                                                                                                                                              public  		string
                                                                                      requestId
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.asset.benefit.order.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("request_id", this.                                                                                    requestId
);
                                                                            }
    }
}





        
 

