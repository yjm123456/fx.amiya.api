using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LogisticsReturnorderAddRequest : JdRequestBase<LogisticsReturnorderAddResponse>
    {
                                                                                                                                              public  		string
                                                                                      sellerNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      warehouseNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      inboundNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      joslOutboundNo
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<DateTime>
                                                                                      expectedDate
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      isvSource
 {get; set;}
                                                                                                                                  
                                                          public  		string
              approver
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     		public  		string
  goodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  expectedQty {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  stockMark {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.logistics.returnorder.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("seller_no", this.                                                                                    sellerNo
);
                                                                                                        parameters.Add("warehouse_no", this.                                                                                    warehouseNo
);
                                                                                                        parameters.Add("inbound_no", this.                                                                                    inboundNo
);
                                                                                                        parameters.Add("josl_outbound_no", this.                                                                                                                    joslOutboundNo
);
                                                                                                        parameters.Add("expected_date", this.                                                                                    expectedDate
);
                                                                                                        parameters.Add("isv_source", this.                                                                                    isvSource
);
                                                                                                        parameters.Add("approver", this.            approver
);
                                                                                                                                                                                                                parameters.Add("goods_no", this.                                                                                    goodsNo
);
                                                                                                        parameters.Add("expected_qty", this.                                                                                    expectedQty
);
                                                                                                        parameters.Add("stock_mark", this.                                                                                    stockMark
);
                                                                                                                                                    }
    }
}





        
 

