using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOrderBusinessUploadRequest : JdRequestBase<PopOrderBusinessUploadResponse>
    {
                                                                                                                                              public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                                                           public  		string
              businessIds
 {get; set;}
                                                          
                                                          public  		string
              businessJson
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.pop.order.business.upload";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                                                                        parameters.Add("businessIds", this.            businessIds
);
                                                                                                        parameters.Add("businessJson", this.            businessJson
);
                                                                                                                            }
    }
}





        
 

