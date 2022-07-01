using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopDeliveryProviderCancelWayBillRequest : JdRequestBase<LdopDeliveryProviderCancelWayBillResponse>
    {
                                                                                                                                              public  		string
              userPin
 {get; set;}
                                                          
                                                                                           public  		string
              waybillCode
 {get; set;}
                                                          
                                                          public  		string
              customerCode
 {get; set;}
                                                          
                                                          public  		string
              source
 {get; set;}
                                                          
                                                          public  		string
              cancelReason
 {get; set;}
                                                          
                                                          public  		string
              operatorName
 {get; set;}
                                                          
                                                          public  		string
                                                                                                                      openIdBuyer
 {get; set;}
                                                                                                                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ldop.delivery.provider.cancelWayBill";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("userPin", this.            userPin
);
                                                                                                                                                        parameters.Add("waybillCode", this.            waybillCode
);
                                                                                                        parameters.Add("customerCode", this.            customerCode
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                                                        parameters.Add("cancelReason", this.            cancelReason
);
                                                                                                        parameters.Add("operatorName", this.            operatorName
);
                                                                                                        parameters.Add("open_id_buyer", this.                                                                                                                    openIdBuyer
);
                                                                            }
    }
}





        
 

