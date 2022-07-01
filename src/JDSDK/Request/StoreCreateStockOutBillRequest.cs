using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class StoreCreateStockOutBillRequest : JdRequestBase<StoreCreateStockOutBillResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
                                                                                      comId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      orgId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      whId
 {get; set;}
                                                                                                                                  
                                                                                                                                                                                                                                                                                                                                                                                                                                                    		public  		string
  skuCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  num {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  remark {get; set; }
                                                                                                                                                                                                                    public override string ApiName
            {
                get{return "jingdong.store.createStockOutBill";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("com_id", this.                                                                                    comId
);
                                                                                                        parameters.Add("org_id", this.                                                                                    orgId
);
                                                                                                        parameters.Add("wh_id", this.                                                                                    whId
);
                                                                                                                                                                                        parameters.Add("sku_code", this.                                                                                    skuCode
);
                                                                                                        parameters.Add("num", this.            num
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                                                                                            }
    }
}





        
 

