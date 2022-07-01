using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CrmMemberSearchNewRequest : JdRequestBase<CrmMemberSearchNewResponse>
    {
                                                                                                                   public  		string
                                                                                      customerPin
 {get; set;}
                                                                                                                                  
                                                          public  		string
              grade
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
                                                                                                                                                      minLastTradeTime
 {get; set;}
                                                                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                                                                                      maxLastTradeTime
 {get; set;}
                                                                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                                                      minTradeCount
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
                                                                                                                      maxTradeCount
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      avgPrice
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      minTradeAmount
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      currentPage
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      openIdBuyer
 {get; set;}
                                                                                                                                                          
            public override string ApiName
            {
                get{return "jingdong.crm.member.searchNew";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("customer_pin", this.                                                                                    customerPin
);
                                                                                                        parameters.Add("grade", this.            grade
);
                                                                                                        parameters.Add("min_last_trade_time", this.                                                                                                                                                    minLastTradeTime
);
                                                                                                        parameters.Add("max_last_trade_time", this.                                                                                                                                                    maxLastTradeTime
);
                                                                                                        parameters.Add("min_trade_count", this.                                                                                                                    minTradeCount
);
                                                                                                        parameters.Add("max_trade_count", this.                                                                                                                    maxTradeCount
);
                                                                                                        parameters.Add("avg_price", this.                                                                                    avgPrice
);
                                                                                                        parameters.Add("min_trade_amount", this.                                                                                                                    minTradeAmount
);
                                                                                                        parameters.Add("current_page", this.                                                                                    currentPage
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                                                                        parameters.Add("open_id_buyer", this.                                                                                                                    openIdBuyer
);
                                                    }
    }
}





        
 

