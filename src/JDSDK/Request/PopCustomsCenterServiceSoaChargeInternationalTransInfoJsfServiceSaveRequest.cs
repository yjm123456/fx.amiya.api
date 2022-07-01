using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopCustomsCenterServiceSoaChargeInternationalTransInfoJsfServiceSaveRequest : JdRequestBase<PopCustomsCenterServiceSoaChargeInternationalTransInfoJsfServiceSaveResponse>
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
              interWayBillNo
 {get; set;}
                                                          
                                                          public  		string
              interTransName
 {get; set;}
                                                          
                                                          public  		string
              interTransMode
 {get; set;}
                                                          
                                                          public  		string
              fromCity
 {get; set;}
                                                          
                                                          public  		string
              toCity
 {get; set;}
                                                          
                                                          public  		string
              actualW
 {get; set;}
                                                          
                                                          public  		string
              chargedW
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.customs.center.service.soa.charge.InternationalTransInfoJsfService.save";}
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
                                                                                                        parameters.Add("interWayBillNo", this.            interWayBillNo
);
                                                                                                        parameters.Add("interTransName", this.            interTransName
);
                                                                                                        parameters.Add("interTransMode", this.            interTransMode
);
                                                                                                        parameters.Add("fromCity", this.            fromCity
);
                                                                                                        parameters.Add("toCity", this.            toCity
);
                                                                                                        parameters.Add("actualW", this.            actualW
);
                                                                                                        parameters.Add("chargedW", this.            chargedW
);
                                                                            }
    }
}





        
 

