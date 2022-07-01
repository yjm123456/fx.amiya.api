using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnichannelOrderReproduceRequest : JdRequestBase<OmnichannelOrderReproduceResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                          public  		string
              operateName
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              operateTime
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.omnichannel.order.reproduce";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                        parameters.Add("operateName", this.            operateName
);
                                                                                                        parameters.Add("operateTime", this.            operateTime
);
                                                                            }
    }
}





        
 

