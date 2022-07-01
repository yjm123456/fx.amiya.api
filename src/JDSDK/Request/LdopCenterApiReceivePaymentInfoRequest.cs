using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopCenterApiReceivePaymentInfoRequest : JdRequestBase<LdopCenterApiReceivePaymentInfoResponse>
    {
                                                                                                                                              public  		string
              deliveryId
 {get; set;}
                                                          
                                                          public  		string
              customerCode
 {get; set;}
                                                          
                                                          public  		string
              recMoney
 {get; set;}
                                                          
                                                          public  		string
              receivedMoney
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              paymentState
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              paymentTime
 {get; set;}
                                                          
                                                          public  		string
              payer
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ldop.center.api.receivePaymentInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deliveryId", this.            deliveryId
);
                                                                                                        parameters.Add("customerCode", this.            customerCode
);
                                                                                                        parameters.Add("recMoney", this.            recMoney
);
                                                                                                        parameters.Add("receivedMoney", this.            receivedMoney
);
                                                                                                        parameters.Add("paymentState", this.            paymentState
);
                                                                                                        parameters.Add("paymentTime", this.            paymentTime
);
                                                                                                        parameters.Add("payer", this.            payer
);
                                                                            }
    }
}





        
 

