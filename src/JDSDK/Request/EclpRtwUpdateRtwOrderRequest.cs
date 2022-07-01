using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpRtwUpdateRtwOrderRequest : JdRequestBase<EclpRtwUpdateRtwOrderResponse>
    {
                                                                                                                                              public  		string
              eclpRtwNo
 {get; set;}
                                                          
                                                          public  		string
              isvRtwNum
 {get; set;}
                                                          
                                                          public  		string
              ownerNo
 {get; set;}
                                                          
                                                          public  		string
              packageNo
 {get; set;}
                                                          
                                                          public  		string
              shipperName
 {get; set;}
                                                          
                                                          public  		string
              senderName
 {get; set;}
                                                          
                                                          public  		string
              senderTelPhone
 {get; set;}
                                                          
                                                          public  		string
              senderMobilePhone
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.rtw.updateRtwOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("eclpRtwNo", this.            eclpRtwNo
);
                                                                                                        parameters.Add("isvRtwNum", this.            isvRtwNum
);
                                                                                                        parameters.Add("ownerNo", this.            ownerNo
);
                                                                                                        parameters.Add("packageNo", this.            packageNo
);
                                                                                                        parameters.Add("shipperName", this.            shipperName
);
                                                                                                        parameters.Add("senderName", this.            senderName
);
                                                                                                        parameters.Add("senderTelPhone", this.            senderTelPhone
);
                                                                                                        parameters.Add("senderMobilePhone", this.            senderMobilePhone
);
                                                                                                                            }
    }
}





        
 

