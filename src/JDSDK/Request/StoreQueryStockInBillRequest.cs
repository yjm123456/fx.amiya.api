using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class StoreQueryStockInBillRequest : JdRequestBase<StoreQueryStockInBillResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
                                                                                                                      stockInStatus
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<long>
                                                                                                                                                      stockInBillId
 {get; set;}
                                                                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      comId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      orgId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      whId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      skuId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                      beginTime
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                      endTime
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
                                                                              public override string ApiName
            {
                get{return "jingdong.store.queryStockInBill";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("stock_in_status", this.                                                                                                                    stockInStatus
);
                                                                                                        parameters.Add("stock_in_bill_id", this.                                                                                                                                                    stockInBillId
);
                                                                                                        parameters.Add("com_id", this.                                                                                    comId
);
                                                                                                        parameters.Add("org_id", this.                                                                                    orgId
);
                                                                                                        parameters.Add("wh_id", this.                                                                                    whId
);
                                                                                                        parameters.Add("sku_id", this.                                                                                    skuId
);
                                                                                                        parameters.Add("begin_time", this.                                                                                    beginTime
);
                                                                                                        parameters.Add("end_time", this.                                                                                    endTime
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                                                                                            }
    }
}





        
 

