using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WarehouseOutboundOrderCreateOutboundOrderForBatchRequest : JdRequestBase<WarehouseOutboundOrderCreateOutboundOrderForBatchResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              stockOutType
 {get; set;}
                                                          
                                                          public  		string
              remarkForOutBound
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  snNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  spareCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  vendorCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  remark {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.warehouse.outbound.order.createOutboundOrderForBatch";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("stockOutType", this.            stockOutType
);
                                                                                                        parameters.Add("remarkForOutBound", this.            remarkForOutBound
);
                                                                                                                                                                                        parameters.Add("snNo", this.            snNo
);
                                                                                                        parameters.Add("spareCode", this.            spareCode
);
                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                                            }
    }
}





        
 

