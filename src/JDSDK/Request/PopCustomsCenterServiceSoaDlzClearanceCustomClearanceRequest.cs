using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopCustomsCenterServiceSoaDlzClearanceCustomClearanceRequest : JdRequestBase<PopCustomsCenterServiceSoaDlzClearanceCustomClearanceResponse>
    {
                                                                                                                                              public  		string
              customsId
 {get; set;}
                                                          
                                                          public  		string
              serviceId
 {get; set;}
                                                          
                                                                                                                                                                                                                         public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              platformId
 {get; set;}
                                                          
                                                          public  		string
              result
 {get; set;}
                                                          
                                                          public  		string
              message
 {get; set;}
                                                          
                                                          public  		string
              goodsCheck
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.customs.center.service.soa.dlz.clearance.customClearance";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("customsId", this.            customsId
);
                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                                                                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("platformId", this.            platformId
);
                                                                                                        parameters.Add("result", this.            result
);
                                                                                                        parameters.Add("message", this.            message
);
                                                                                                        parameters.Add("goodsCheck", this.            goodsCheck
);
                                                                            }
    }
}





        
 

