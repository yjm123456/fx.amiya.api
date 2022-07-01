using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JpassJournalQueryRefundBillRequest : JdRequestBase<JpassJournalQueryRefundBillResponse>
    {
                                                                                                                                                                                                                public  		string
              bid
 {get; set;}
                                                          
                                                          public  		string
              businessBillId
 {get; set;}
                                                          
                                                          public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              refOrderId
 {get; set;}
                                                          
                                                          public  		string
              storeId
 {get; set;}
                                                          
                                                          public  		string
              refStoreId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  sId {get; set; }
                                                                                                                                                                                                public  		string
              happenTime
 {get; set;}
                                                          
                                                          public  		string
              happenTimeBegin
 {get; set;}
                                                          
                                                          public  		string
              happenTimeEnd
 {get; set;}
                                                          
                                                          public  		string
              settleStatus
 {get; set;}
                                                          
                                                          public  		string
              pageIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.jpass.journal.queryRefundBill";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("bid", this.            bid
);
                                                                                                        parameters.Add("businessBillId", this.            businessBillId
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("refOrderId", this.            refOrderId
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("refStoreId", this.            refStoreId
);
                                                                                                                                                parameters.Add("sId", this.            sId
);
                                                                                                                                parameters.Add("happenTime", this.            happenTime
);
                                                                                                        parameters.Add("happenTimeBegin", this.            happenTimeBegin
);
                                                                                                        parameters.Add("happenTimeEnd", this.            happenTimeEnd
);
                                                                                                        parameters.Add("settleStatus", this.            settleStatus
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                            }
    }
}





        
 

