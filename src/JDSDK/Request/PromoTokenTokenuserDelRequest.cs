using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PromoTokenTokenuserDelRequest : JdRequestBase<PromoTokenTokenuserDelResponse>
    {
                                                                                                                                              public  		string
              tokenId
 {get; set;}
                                                          
                                                          public  		string
              userPin
 {get; set;}
                                                          
                                                          public  		string
              secretKey
 {get; set;}
                                                          
                                                                                                                      public  		string
              appCode
 {get; set;}
                                                          
                                                          public  		string
              authKey
 {get; set;}
                                                          
                                                                                           public  		string
                                                                                                                      openIdBuyer
 {get; set;}
                                                                                                                                                          
                                             public override string ApiName
            {
                get{return "jingdong.promo.token.tokenuser.del";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("tokenId", this.            tokenId
);
                                                                                                        parameters.Add("userPin", this.            userPin
);
                                                                                                        parameters.Add("secretKey", this.            secretKey
);
                                                                                                                                                parameters.Add("appCode", this.            appCode
);
                                                                                                        parameters.Add("authKey", this.            authKey
);
                                                                                                                                parameters.Add("open_id_buyer", this.                                                                                                                    openIdBuyer
);
                                                                            }
    }
}





        
 

