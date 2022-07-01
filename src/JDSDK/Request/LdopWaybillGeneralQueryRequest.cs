using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopWaybillGeneralQueryRequest : JdRequestBase<LdopWaybillGeneralQueryResponse>
    {
                                                                                                                                              public  		string
              customerCode
 {get; set;}
                                                          
                                                          public  		string
              deliveryId
 {get; set;}
                                                          
                                                                                           public  		string
              phone
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              dynamicTimeFlag
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ldop.waybill.generalQuery";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("customerCode", this.            customerCode
);
                                                                                                        parameters.Add("deliveryId", this.            deliveryId
);
                                                                                                                                                        parameters.Add("phone", this.            phone
);
                                                                                                        parameters.Add("dynamicTimeFlag", this.            dynamicTimeFlag
);
                                                                            }
    }
}





        
 

