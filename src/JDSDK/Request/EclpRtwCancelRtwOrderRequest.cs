using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpRtwCancelRtwOrderRequest : JdRequestBase<EclpRtwCancelRtwOrderResponse>
    {
                                                                                                                                              public  		string
              isvRtwNum
 {get; set;}
                                                          
                                                          public  		string
              eclpRtwNum
 {get; set;}
                                                          
                                                                                           public  		string
              cancelReson
 {get; set;}
                                                          
                                                          public  		string
              ownerNo
 {get; set;}
                                                          
                                                          public  		string
              orderInType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.rtw.cancelRtwOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("isvRtwNum", this.            isvRtwNum
);
                                                                                                        parameters.Add("eclpRtwNum", this.            eclpRtwNum
);
                                                                                                                                                        parameters.Add("cancelReson", this.            cancelReson
);
                                                                                                        parameters.Add("ownerNo", this.            ownerNo
);
                                                                                                        parameters.Add("orderInType", this.            orderInType
);
                                                                            }
    }
}





        
 

