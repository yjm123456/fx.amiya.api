using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnicOrderSavecourierRequest : JdRequestBase<OmnicOrderSavecourierResponse>
    {
                                                                                                                                              public  		string
              authKey
 {get; set;}
                                                          
                                                                                                                                                                                        public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		string
              deliveryId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              carrierType
 {get; set;}
                                                          
                                                          public  		string
              carrierName
 {get; set;}
                                                          
                                                          public  		string
              carrierNo
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.omnic.order.savecourier";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("authKey", this.            authKey
);
                                                                                                                                                                                                                                                parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("deliveryId", this.            deliveryId
);
                                                                                                        parameters.Add("carrierType", this.            carrierType
);
                                                                                                        parameters.Add("carrierName", this.            carrierName
);
                                                                                                        parameters.Add("carrierNo", this.            carrierNo
);
                                                                                                    }
    }
}





        
 

