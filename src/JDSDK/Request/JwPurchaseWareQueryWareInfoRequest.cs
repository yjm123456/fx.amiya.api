using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JwPurchaseWareQueryWareInfoRequest : JdRequestBase<JwPurchaseWareQueryWareInfoResponse>
    {
                                                                                                                                                                          public  		string
              skus
 {get; set;}
                                                          
                                                                                      public  		string
              fieldNames
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.jw.purchase.ware.queryWareInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("skus", this.            skus
);
                                                                                                        parameters.Add("fieldNames", this.            fieldNames
);
                                                                                                                                                                            }
    }
}





        
 

