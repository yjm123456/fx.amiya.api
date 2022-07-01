using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpInsideCancelUlOrderRequest : JdRequestBase<EclpInsideCancelUlOrderResponse>
    {
                                                                                                                                              public  		string
              ulNo
 {get; set;}
                                                          
                                                          public  		string
              outUlNo
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              wareHouseNo
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.inside.cancelUlOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("ulNo", this.            ulNo
);
                                                                                                        parameters.Add("outUlNo", this.            outUlNo
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("wareHouseNo", this.            wareHouseNo
);
                                                                                                                            }
    }
}





        
 

