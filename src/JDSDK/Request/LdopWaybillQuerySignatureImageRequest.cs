using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopWaybillQuerySignatureImageRequest : JdRequestBase<LdopWaybillQuerySignatureImageResponse>
    {
                                                                                                                                              public  		string
              deliveryId
 {get; set;}
                                                          
                                                          public  		string
              customerCode
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ldop.waybill.querySignatureImage";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deliveryId", this.            deliveryId
);
                                                                                                        parameters.Add("customerCode", this.            customerCode
);
                                                                                                                            }
    }
}





        
 

