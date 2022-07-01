using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class FactoryPurchaseQueryPurchaseOrderBycodeRequest : JdRequestBase<FactoryPurchaseQueryPurchaseOrderBycodeResponse>
    {
                                                                                                                                              public  		Nullable<long>
              factoryId
 {get; set;}
                                                          
                                                                                                                            public  		string
              personalKey
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              ptId
 {get; set;}
                                                          
                                                                                           public  		string
              code
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.factory.purchase.queryPurchaseOrderBycode";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("factoryId", this.            factoryId
);
                                                                                                                                                                                                        parameters.Add("personalKey", this.            personalKey
);
                                                                                                        parameters.Add("ptId", this.            ptId
);
                                                                                                                                parameters.Add("code", this.            code
);
                                                    }
    }
}





        
 

