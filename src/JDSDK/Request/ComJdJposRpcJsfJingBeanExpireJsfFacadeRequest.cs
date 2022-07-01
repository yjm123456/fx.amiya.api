using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ComJdJposRpcJsfJingBeanExpireJsfFacadeRequest : JdRequestBase<ComJdJposRpcJsfJingBeanExpireJsfFacadeResponse>
    {
                                                                                  public  		string
              pin
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.com.jd.jpos.rpc.jsf.JingBeanExpireJsfFacade";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("pin", this.            pin
);
                                                    }
    }
}





        
 

