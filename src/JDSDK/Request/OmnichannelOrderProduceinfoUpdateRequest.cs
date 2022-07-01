using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnichannelOrderProduceinfoUpdateRequest : JdRequestBase<OmnichannelOrderProduceinfoUpdateResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                          public  		string
              storeType
 {get; set;}
                                                          
                                                          public  		string
              storeId
 {get; set;}
                                                          
                                                          public  		string
              operateName
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              operateTime
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.omnichannel.order.produceinfo.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("storeType", this.            storeType
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("operateName", this.            operateName
);
                                                                                                        parameters.Add("operateTime", this.            operateTime
);
                                                                            }
    }
}





        
 

