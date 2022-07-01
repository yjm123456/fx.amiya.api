using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcCreatepurchaseorderRequest : JdRequestBase<VcCreatepurchaseorderResponse>
    {
                                                                                                                                              public  		Nullable<int>
                                                                                                                                                      orderDeliverCenterId
 {get; set;}
                                                                                                                                                                                  
                                                          public  		string
                                                                                                                      purchaserErpCode
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      orderRemark
 {get; set;}
                                                                                                                                  
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      		public  		string
  wareId {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  wareDeliverCenterId {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  originalNum {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  wareRemark {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.vc.createpurchaseorder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("order_deliver_center_id", this.                                                                                                                                                    orderDeliverCenterId
);
                                                                                                        parameters.Add("purchaser_erp_code", this.                                                                                                                    purchaserErpCode
);
                                                                                                        parameters.Add("order_remark", this.                                                                                    orderRemark
);
                                                                                                                                                                                                                                                                parameters.Add("ware_id", this.                                                                                    wareId
);
                                                                                                        parameters.Add("ware_deliver_center_id", this.                                                                                                                                                    wareDeliverCenterId
);
                                                                                                        parameters.Add("original_num", this.                                                                                    originalNum
);
                                                                                                        parameters.Add("ware_remark", this.                                                                                    wareRemark
);
                                                                                                    }
    }
}





        
 

