using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JwPurchaseOrderOrderHistoryRequest : JdRequestBase<JwPurchaseOrderOrderHistoryResponse>
    {
                                                                                                                                              public  		Nullable<int>
              pageNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              clientId
 {get; set;}
                                                          
                                                          public  		string
              clientBusinessNo
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.jw.purchase.order.orderHistory";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("clientId", this.            clientId
);
                                                                                                        parameters.Add("clientBusinessNo", this.            clientBusinessNo
);
                                                                                                                                                                            }
    }
}





        
 

