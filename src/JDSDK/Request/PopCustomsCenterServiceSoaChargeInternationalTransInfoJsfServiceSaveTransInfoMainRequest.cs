using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopCustomsCenterServiceSoaChargeInternationalTransInfoJsfServiceSaveTransInfoMainRequest : JdRequestBase<PopCustomsCenterServiceSoaChargeInternationalTransInfoJsfServiceSaveTransInfoMainResponse>
    {
                                                                                                                                              public  		string
              customsId
 {get; set;}
                                                          
                                                          public  		string
              venderId
 {get; set;}
                                                          
                                                                                                                                                                                                                         public  		string
              mainOrderNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderAmount
 {get; set;}
                                                          
                                                          public  		string
              fromPortDate
 {get; set;}
                                                          
                                                          public  		string
              toPortDate
 {get; set;}
                                                          
                                                          public  		string
              interTransMode
 {get; set;}
                                                          
                                                          public  		string
              shipId
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
                                                          
                                                          public  		string
              ex1
 {get; set;}
                                                          
                                                          public  		string
              ex2
 {get; set;}
                                                          
                                                          public  		string
              ex3
 {get; set;}
                                                          
                                                          public  		string
              ex4
 {get; set;}
                                                          
                                                          public  		string
              ex5
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.customs.center.service.soa.charge.InternationalTransInfoJsfService.saveTransInfoMain";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("customsId", this.            customsId
);
                                                                                                        parameters.Add("venderId", this.            venderId
);
                                                                                                                                                                                                                                                                        parameters.Add("mainOrderNo", this.            mainOrderNo
);
                                                                                                        parameters.Add("orderAmount", this.            orderAmount
);
                                                                                                        parameters.Add("fromPortDate", this.            fromPortDate
);
                                                                                                        parameters.Add("toPortDate", this.            toPortDate
);
                                                                                                        parameters.Add("interTransMode", this.            interTransMode
);
                                                                                                        parameters.Add("shipId", this.            shipId
);
                                                                                                        parameters.Add("fromCity", this.            fromCity
);
                                                                                                        parameters.Add("toCity", this.            toCity
);
                                                                                                        parameters.Add("actualW", this.            actualW
);
                                                                                                        parameters.Add("chargedW", this.            chargedW
);
                                                                                                        parameters.Add("ex1", this.            ex1
);
                                                                                                        parameters.Add("ex2", this.            ex2
);
                                                                                                        parameters.Add("ex3", this.            ex3
);
                                                                                                        parameters.Add("ex4", this.            ex4
);
                                                                                                        parameters.Add("ex5", this.            ex5
);
                                                                            }
    }
}





        
 

