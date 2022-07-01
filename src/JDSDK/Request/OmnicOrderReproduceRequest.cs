using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnicOrderReproduceRequest : JdRequestBase<OmnicOrderReproduceResponse>
    {
                                                                                                                                              public  		string
              authKey
 {get; set;}
                                                          
                                                                                                                                                                                        public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              operateTime
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                                          public  		string
              operateName
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.omnic.order.reproduce";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("authKey", this.            authKey
);
                                                                                                                                                                                                                                                parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("operateTime", this.            operateTime
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("operateName", this.            operateName
);
                                                                                                    }
    }
}





        
 

