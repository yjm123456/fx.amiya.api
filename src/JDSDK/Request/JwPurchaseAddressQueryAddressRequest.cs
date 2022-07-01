using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JwPurchaseAddressQueryAddressRequest : JdRequestBase<JwPurchaseAddressQueryAddressResponse>
    {
                                                                                                                                              public  		Nullable<int>
              addressLevel
 {get; set;}
                                                          
                                                                                                                      public  		string
              addressLevel1Id
 {get; set;}
                                                          
                                                          public  		string
              addressLevel2Id
 {get; set;}
                                                          
                                                          public  		string
              addressLevel3Id
 {get; set;}
                                                          
                                                                                                                                                public override string ApiName
            {
                get{return "jingdong.jw.purchase.address.queryAddress";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("addressLevel", this.            addressLevel
);
                                                                                                                                                parameters.Add("addressLevel1Id", this.            addressLevel1Id
);
                                                                                                        parameters.Add("addressLevel2Id", this.            addressLevel2Id
);
                                                                                                        parameters.Add("addressLevel3Id", this.            addressLevel3Id
);
                                                                                                                                                                                                    }
    }
}





        
 

