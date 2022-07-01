using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LogisticsOtherInstoreAddRequest : JdRequestBase<LogisticsOtherInstoreAddResponse>
    {
                                                                                                                                              public  		string
                                                                                      instoreType
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      poNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      expectedDate
 {get; set;}
                                                                                                                                  
                                                          public  		string
              approver
 {get; set;}
                                                          
                                                          public  		string
                                                                                      warehouseNo
 {get; set;}
                                                                                                                                  
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     		public  		string
  goodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		public  		string
  isvGoodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  expectedQty {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  goodsStatus {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.logistics.otherInstore.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("instore_type", this.                                                                                    instoreType
);
                                                                                                        parameters.Add("po_no", this.                                                                                    poNo
);
                                                                                                        parameters.Add("expected_date", this.                                                                                    expectedDate
);
                                                                                                        parameters.Add("approver", this.            approver
);
                                                                                                        parameters.Add("warehouse_no", this.                                                                                    warehouseNo
);
                                                                                                                                                                                                                parameters.Add("goods_no", this.                                                                                    goodsNo
);
                                                                                                        parameters.Add("isv_goods_no", this.                                                                                                                    isvGoodsNo
);
                                                                                                        parameters.Add("expected_qty", this.                                                                                    expectedQty
);
                                                                                                        parameters.Add("goods_status", this.                                                                                    goodsStatus
);
                                                                                                                                                    }
    }
}





        
 

