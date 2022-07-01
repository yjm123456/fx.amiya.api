using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DropshipDpsDeliveryRequest : JdRequestBase<DropshipDpsDeliveryResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              customOrderId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              carrierId
 {get; set;}
                                                          
                                                          public  		string
              carrierBusinessName
 {get; set;}
                                                          
                                                          public  		string
              shipNo
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              estimateDate
 {get; set;}
                                                          
                                                          public  		string
              carrierPhone
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dropship.dps.delivery";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("customOrderId", this.            customOrderId
);
                                                                                                        parameters.Add("carrierId", this.            carrierId
);
                                                                                                        parameters.Add("carrierBusinessName", this.            carrierBusinessName
);
                                                                                                        parameters.Add("shipNo", this.            shipNo
);
                                                                                                        parameters.Add("estimateDate", this.            estimateDate
);
                                                                                                        parameters.Add("carrierPhone", this.            carrierPhone
);
                                                                            }
    }
}





        
 

