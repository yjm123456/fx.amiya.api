using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpOrderQueryOrderCartonBySoNoRequest : JdRequestBase<EclpOrderQueryOrderCartonBySoNoResponse>
    {
                                                                                  public  		string
              soNo
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.eclp.order.queryOrderCartonBySoNo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("soNo", this.            soNo
);
                                                    }
    }
}





        
 

