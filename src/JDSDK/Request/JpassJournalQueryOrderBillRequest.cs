using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JpassJournalQueryOrderBillRequest : JdRequestBase<JpassJournalQueryOrderBillResponse>
    {
                                                                                                                                              public  		string
              bid
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
  sId {get; set; }
                                                                                                                                                                                                public  		string
              refStoreId
 {get; set;}
                                                          
                                                          public  		string
              orderCompleteTime
 {get; set;}
                                                          
                                                          public  		string
              orderCompleteTimeBegin
 {get; set;}
                                                          
                                                          public  		string
              orderCompleteTimeEnd
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
                get{return "jingdong.jpass.journal.queryOrderBill";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("bid", this.            bid
);
                                                                                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("refOrderId", this.            refOrderId
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                                                                parameters.Add("sId", this.            sId
);
                                                                                                                                parameters.Add("refStoreId", this.            refStoreId
);
                                                                                                        parameters.Add("orderCompleteTime", this.            orderCompleteTime
);
                                                                                                        parameters.Add("orderCompleteTimeBegin", this.            orderCompleteTimeBegin
);
                                                                                                        parameters.Add("orderCompleteTimeEnd", this.            orderCompleteTimeEnd
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





        
 

