using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpMasterCancelBjkServiceOrderRequest : JdRequestBase<EclpMasterCancelBjkServiceOrderResponse>
    {
                                                                                  public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              serviceNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.master.cancelBjkServiceOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("serviceNo", this.            serviceNo
);
                                                                                                    }
    }
}





        
 

