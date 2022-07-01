using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnicOrderSyncpickupcodeRequest : JdRequestBase<OmnicOrderSyncpickupcodeResponse>
    {
                                                                                                                                              public  		string
              authKey
 {get; set;}
                                                          
                                                                                                                                                                                        public  		string
              pickUpCode
 {get; set;}
                                                          
                                                          public  		string
              salesChannelOrderId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.omnic.order.syncpickupcode";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("authKey", this.            authKey
);
                                                                                                                                                                                                                                                parameters.Add("pickUpCode", this.            pickUpCode
);
                                                                                                        parameters.Add("salesChannelOrderId", this.            salesChannelOrderId
);
                                                                                                    }
    }
}





        
 

