using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOrderOrderSplitCommitXmlApiRequest : JdRequestBase<PopOrderOrderSplitCommitXmlApiResponse>
    {
                                                                                  public  		string
              param
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.order.orderSplitCommitXmlApi";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("param", this.            param
);
                                                                                                    }
    }
}





        
 

