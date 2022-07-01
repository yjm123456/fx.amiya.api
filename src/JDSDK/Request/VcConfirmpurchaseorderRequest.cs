using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcConfirmpurchaseorderRequest : JdRequestBase<VcConfirmpurchaseorderResponse>
    {
                                                                                                                                              public  		Nullable<long>
                                                                                      orderId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                      deliveryTime
 {get; set;}
                                                                                                                                  
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      		public  		string
  wareId {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  confirmNum {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  backExplanation {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		public  		string
  backExplanationType {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		public  		string
  deliverCenterId {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.vc.confirmpurchaseorder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("order_id", this.                                                                                    orderId
);
                                                                                                        parameters.Add("delivery_time", this.                                                                                    deliveryTime
);
                                                                                                                                                                                                                                                                parameters.Add("ware_id", this.                                                                                    wareId
);
                                                                                                        parameters.Add("confirm_num", this.                                                                                    confirmNum
);
                                                                                                        parameters.Add("back_explanation", this.                                                                                    backExplanation
);
                                                                                                        parameters.Add("back_explanation_type", this.                                                                                                                    backExplanationType
);
                                                                                                        parameters.Add("deliver_center_id", this.                                                                                                                    deliverCenterId
);
                                                                                                    }
    }
}





        
 

