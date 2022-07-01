using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpPoCancalPoOrderRequest : JdRequestBase<EclpPoCancalPoOrderResponse>
    {
                                                                                  public  		string
              poOrderNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.po.cancalPoOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("poOrderNo", this.            poOrderNo
);
                                                                                                    }
    }
}





        
 

