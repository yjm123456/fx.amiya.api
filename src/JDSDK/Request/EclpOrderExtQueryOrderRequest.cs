using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpOrderExtQueryOrderRequest : JdRequestBase<EclpOrderExtQueryOrderResponse>
    {
                                                                                                                                                                          public  		string
              isvUUID
 {get; set;}
                                                          
                                                                                      public  		string
              spSoNos
 {get; set;}
                                                          
                                                          public  		string
              isvSource
 {get; set;}
                                                          
                                                          public  		string
              departmentNo
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.order.ext.queryOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("isvUUID", this.            isvUUID
);
                                                                                                        parameters.Add("spSoNos", this.            spSoNos
);
                                                                                                        parameters.Add("isvSource", this.            isvSource
);
                                                                                                        parameters.Add("departmentNo", this.            departmentNo
);
                                                                                                                            }
    }
}





        
 

