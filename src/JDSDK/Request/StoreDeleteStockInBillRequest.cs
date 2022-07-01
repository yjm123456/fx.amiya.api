using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class StoreDeleteStockInBillRequest : JdRequestBase<StoreDeleteStockInBillResponse>
    {
                                                                                                                   public  		Nullable<long>
                                                                                                                                                      stockInBillId
 {get; set;}
                                                                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.store.deleteStockInBill";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("stock_in_bill_id", this.                                                                                                                                                    stockInBillId
);
                                                                                                    }
    }
}





        
 

